using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class ServerConfig
    {
        public MFilesAuthType AuthType { get; set; } = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
        public string UserName { get; set; }
        public System.Security.SecureString Password { get; set; }
        public string Domain { get; set; }
        public MFilesProtocolSequence ProtocolSequence { get; set; }
        public string ServerName { get; set; } = "localhost";
        public string EndPoint { get; set; } = "2266";


    }
}
