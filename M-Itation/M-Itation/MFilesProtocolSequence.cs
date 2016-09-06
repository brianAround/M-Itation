
using System.ComponentModel;

namespace M_Itation
{
    public enum MFilesProtocolSequence
    {
        /// <summary>
        /// Maps to value "ncacn_ip_tcp"
        /// </summary>
        [Description("ncacn_ip_tcp")]
        ncacn_ip_tcp,
        /// <summary>
        /// Maps to value "ncacn_spx"
        /// </summary>
        [Description("ncacn_spx")]
        ncacn_spx,
        /// <summary>
        /// Maps to value "ncalrpc"
        /// </summary>
        [Description("ncalrpc")]
        ncalrpc,
        /// <summary>
        /// Maps to value "ncacn_http" for HTTPS connection
        /// </summary>
        [Description("ncacn_http")]
        ncacn_http
    }
}