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

        public MFilesServerConnection()
        {

        }

        public MFilesServerConnection(ServerConfig config)
        {
            ServerConfig = config;
        }

        public ServerConfig ServerConfig { get; set; } = new ServerConfig();


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
            Server.Connect(AuthType: (MFAuthType)ServerConfig.AuthType,
                            UserName: ServerConfig.UserName,
                            Password: ServerConfig.Password,
                            Domain: ServerConfig.Domain,
                            ProtocolSequence: ServerConfig.ProtocolSequence.ToString(),
                            NetworkAddress: ServerConfig.ServerName, 
                            Endpoint: ServerConfig.EndPoint, 
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
