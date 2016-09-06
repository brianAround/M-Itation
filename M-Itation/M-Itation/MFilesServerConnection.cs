using MFilesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class MFilesServerConnection
    {

        public MFilesServerConnection()
        {

        }

        public ServerConfig ServerConfig { get; set; } = new ServerConfig();



        public string ConnectedVault { get; set; }

        internal MFilesServerApplication Server { get; private set; }

        public bool IsConnectedtoServer
        {
            get
            {
                bool isConnected = false;
                if (Server != null)
                {
                    try
                    {
                        Server.TestConnectionToServerEx();
                        isConnected = true;
                    }
                    catch
                    {
                        // TODO:  Make a custom exception.
                        throw;
                    }
                }
                return isConnected;
            }

        }


        public void Connect()
        {
            Server = new MFilesServerApplication();

            Server.Connect(AuthType: (MFAuthType)ServerConfig.AuthType,
                            UserName: ServerConfig.UserName,
                            Password: ServerConfig.Password,
                            Domain: ServerConfig.Domain,
                            ProtocolSequence: ServerConfig.ProtocolSequence.ToString(),
                            NetworkAddress: ServerConfig.ServerName, 
                            Endpoint: ServerConfig.EndPoint, 
                            LocalComputerName: Environment.MachineName);
        }

        public void ConnectToVault(string v)
        {
            
        }

        public string[] GetVaults()
        {
            return Server.GetVaults().OfType<VaultOnServer>().Select(vos => vos.Name).ToArray(); 
        }
    }
}
