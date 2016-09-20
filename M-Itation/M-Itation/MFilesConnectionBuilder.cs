using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class MFilesConnectionBuilder
    {
        public const string DefaultServerName = "localhost";
        public const MFilesAuthType DefaultAuthType = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
        public const string EndpointForTCPIP = "2266";
        public const string EndpointForHTTP = "4466";
        public const string EndpointForLPC = "MFServerCommon_F5EE352D-6A03-4866-9988-C69CEA2C39BF";


        public MFilesAuthType AuthType { get; set; } = DefaultAuthType;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public MFilesProtocolSequence ProtocolSequence { get; set; } = MFilesProtocolSequence.ncacn_ip_tcp;
        public string ServerName { get; set; } = DefaultServerName;
        public string EndPoint { get; set; } = EndpointForTCPIP;

        public MFilesConnectionBuilder SetCurrentWindowsUserAuthType()
        {
            AuthType = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
            UserName = null;
            Password = null;
            Domain = null;
            return this;
        }

        public MFilesConnectionBuilder SetSpecificWindowsUserAuthType(string domain, string username, string password)
        {
            AuthType = MFilesAuthType.SpecificWindowsUser;
            UserName = username;
            Password = password;
            Domain = domain;
            return this;
        }

        public MFilesConnectionBuilder SetSpecificMFilesUserAuthType(string username, string password)
        {
            AuthType = MFilesAuthType.SpecificMFilesUser;
            UserName = username;
            Password = password;
            Domain = null;
            return this;
        }

        public MFilesConnectionBuilder SetProtocolSequence(MFilesProtocolSequence protocol, string serverName = "localhost")
        {
            ProtocolSequence = protocol;
            switch (protocol)
            {
                case MFilesProtocolSequence.ncacn_ip_tcp:
                    EndPoint = EndpointForTCPIP;
                    break;
                case MFilesProtocolSequence.ncacn_http:
                    EndPoint = EndpointForHTTP;
                    break;
                case MFilesProtocolSequence.ncalrpc:
                    EndPoint = EndpointForLPC;
                    serverName = null;
                    break;
                case MFilesProtocolSequence.ncacn_spx:
                    break;
            }
            ServerName = serverName;
            return this;
        }

        public MFilesServerConnection GetConnection()
        {
            return new MFilesServerConnection()
            {
                AuthType = this.AuthType,
                UserName = this.UserName,
                Password = this.Password,
                Domain = this.Domain,
                ProtocolSequence = this.ProtocolSequence,
                ServerName = this.ServerName,
                EndPoint = this.EndPoint
            };
        }


    }
}
