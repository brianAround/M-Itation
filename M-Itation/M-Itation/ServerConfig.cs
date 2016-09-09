using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class ServerConfig
    {
        public MFilesAuthType AuthType { get; set; } = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public MFilesProtocolSequence ProtocolSequence { get; set; } = MFilesProtocolSequence.ncacn_ip_tcp;
        public string ServerName { get; set; } = "localhost";
        public string EndPoint { get; set; } = "2266";


    }
}
