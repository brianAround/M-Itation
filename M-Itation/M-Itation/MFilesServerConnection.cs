using MFilesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class MFilesServerConnection
    {

        #region ServerConfig
        public MFilesAuthType AuthType { get; set; } = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Domain { get; set; }
        public MFilesProtocolSequence ProtocolSequence { get; set; } = MFilesProtocolSequence.ncacn_ip_tcp;
        public string ServerName { get; set; } = "localhost";
        public string EndPoint { get; set; } = "2266";

        #endregion

        public MFilesServerConnection()
        {

        }



        internal MFilesServerApplication Server { get; private set; } = new MFilesServerApplication();

        public bool IsConnectedtoServer
        {
            get
            {
                bool isConnected = false;
                if (Server != null)
                {
                    try
                    {
                        MFilesVersion mfv = Server.GetServerVersion();
                        isConnected = true;
                    }
                    catch
                    { }
                }
                return isConnected;
            }

        }


        public void Connect()
        {
            Server = new MFilesServerApplication();
            Server.Connect(AuthType: (MFAuthType)this.AuthType,
                            UserName: this.UserName,
                            Password: this.Password,
                            Domain: this.Domain,
                            ProtocolSequence: this.ProtocolSequence.ToString(),
                            NetworkAddress: this.ServerName, 
                            Endpoint: this.EndPoint, 
                            LocalComputerName: Environment.MachineName);
        }

        
        public void Disconnect()
        {
            Server?.Disconnect();
        }


        public VaultInfo[] GetVaults()
        {
            return Server?.GetVaults().OfType<VaultOnServer>().Select(vos => new VaultInfo(vos.Name, Guid.Parse(vos.GUID))).ToArray(); 
        }
    }
}
