using System;
using System.Collections.Generic;
using System.Text;

namespace Dfi.Rpc.Specifications
{
    public enum AddNodeCommands
    {
        /// <summary>
        /// adds a node to the list
        /// </summary>
        Add,
        /// <summary>
        /// removes a node from the list
        /// </summary>
        Remove,
        /// <summary>
        /// tries a connection to the node once
        /// </summary>
        OneTry
    }
}
