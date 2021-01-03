using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Dfi.Rpc.Exceptions.Rpc;
using Dfi.Rpc.RequestResponse;
using Dfi.Rpc.Specifications.RpcRequests;
using Newtonsoft.Json;

namespace Dfi.Rpc.Connector
{
    public sealed class RpcConnector : IRpcConnector
    {
        private readonly string _daemonUrl;
        private readonly string _rpcUsername = null;
        private readonly string _rpcPassword = null;
        private readonly short _rpcRequestTimeoutInSeconds;

        public RpcConnector(string daemonUrl, string rpcUsername, string rpcPassword, short rpcRequestTimeoutInSeconds = 1)
        {
            _daemonUrl = daemonUrl;
            _rpcUsername = rpcUsername;
            _rpcPassword = rpcPassword;
            _rpcRequestTimeoutInSeconds = rpcRequestTimeoutInSeconds;
        }
        public T MakeRequest<T>(IRpcRequest rpcMethod)
        {
            var jsonRpcRequest = new JsonRpcRequest(1, rpcMethod.Name, rpcMethod.GetParameters());
            var webRequest = (HttpWebRequest)WebRequest.Create(_daemonUrl);
            SetBasicAuthHeader(webRequest, _rpcUsername, _rpcPassword);
            webRequest.Credentials = new NetworkCredential(_rpcUsername, _rpcPassword);
            webRequest.ContentType = "application/json-rpc";
            webRequest.Method = "POST";
            webRequest.Proxy = null;
            webRequest.Timeout = (int)TimeSpan.FromSeconds(_rpcRequestTimeoutInSeconds).TotalMilliseconds;
            var byteArray = jsonRpcRequest.GetBytes();
#if DEBUG
            var str = UTF8Encoding.UTF8.GetString(byteArray);
#endif
            webRequest.ContentLength = jsonRpcRequest.GetBytes().Length;

            try
            {
                using (var dataStream = webRequest.GetRequestStream())
                {
                    dataStream.Write(byteArray, 0, byteArray.Length);
                    dataStream.Dispose();
                }
            }
            catch (Exception exception)
            {
                throw new RpcException("There was a problem sending the request to the wallet", exception);
            }

            try
            {
                string json;

                using (var webResponse = webRequest.GetResponse())
                {
                    using (var stream = webResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            var result = reader.ReadToEnd();
                            reader.Dispose();
                            json = result;
                        }
                    }
                }

                var rpcResponse = JsonConvert.DeserializeObject<JsonRpcResponse<T>>(json);
                return rpcResponse.Result;
            }
            catch (WebException webException)
            {
                #region RPC Internal Server Error (with an Error Code)

                var webResponse = webException.Response as HttpWebResponse;

                if (webResponse != null)
                {
                    switch (webResponse.StatusCode)
                    {
                        case HttpStatusCode.InternalServerError:
                            {
                                using (var stream = webResponse.GetResponseStream())
                                {
                                    if (stream == null)
                                    {
                                        throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                                    }

                                    using (var reader = new StreamReader(stream))
                                    {
                                        var result = reader.ReadToEnd();
                                        reader.Dispose();

                                        try
                                        {
                                            var jsonRpcResponseObject = JsonConvert.DeserializeObject<JsonRpcResponse<object>>(result);

                                            var internalServerErrorException = new RpcInternalServerErrorException(jsonRpcResponseObject.Error.Message, webException)
                                            {
                                                RpcErrorCode = jsonRpcResponseObject.Error.Code
                                            };

                                            throw internalServerErrorException;
                                        }
                                        catch (JsonException)
                                        {
                                            throw new RpcException(result, webException);
                                        }
                                    }
                                }
                            }

                        default:
                            throw new RpcException("The RPC request was either not understood by the server or there was a problem executing the request", webException);
                    }
                }

                #endregion

                #region RPC Time-Out

                if (webException.Message == "The operation has timed out")
                {
                    throw new RpcRequestTimeoutException(webException.Message);
                }

                #endregion

                throw new RpcException("An unknown web exception occured while trying to read the JSON response", webException);
            }
            catch (JsonException jsonException)
            {
                throw new RpcResponseDeserializationException("There was a problem deserializing the response from the wallet", jsonException);
            }
            catch (ProtocolViolationException protocolViolationException)
            {
                throw new RpcException("Unable to connect to the server", protocolViolationException);
            }
            catch (Exception exception)
            {
                var queryParameters = jsonRpcRequest.Parameters.Cast<string>().Aggregate(string.Empty, (current, parameter) => current + (parameter + " "));
                throw new Exception($"A problem was encountered while calling MakeRpcRequest() for: {jsonRpcRequest.Method} with parameters: {queryParameters}. \nException: {exception.Message}");
            }
        }

        private static void SetBasicAuthHeader(WebRequest webRequest, string username, string password)
        {
            var authInfo = username + ":" + password;
            authInfo = Convert.ToBase64String(Encoding.Default.GetBytes(authInfo));
            webRequest.Headers["Authorization"] = "Basic " + authInfo;
        }

        public T MakeRequest<T>(string method) => MakeRequest<T>(new GenericRpcRequest(method));

        public T MakeRequest<T>(string method, params object[] parameters) => MakeRequest<T>(new GenericRpcRequest(method, parameters));
    }
}
