// Copyright (c) 2014 - 2016 George Kimionis
// See the accompanying file LICENSE for the Software License Aggrement

using Dfi.Rpc.Specifications;
using System;
using System.Runtime.Serialization;

namespace Dfi.Rpc.Exceptions.Rpc
{
    [Serializable]
    public class RpcInternalServerErrorException : Exception
    {
        public RpcInternalServerErrorException()
        {
        }

        public RpcInternalServerErrorException(string customMessage) : base(customMessage)
        {
        }

        public RpcInternalServerErrorException(string customMessage, Exception exception) : base(customMessage, exception)
        {
        }

        public RpcErrorCode? RpcErrorCode { get; set; }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }

            info.AddValue("RpcErrorCode", RpcErrorCode, typeof(RpcErrorCode));
            base.GetObjectData(info, context);
        }
    }
}