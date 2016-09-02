using MFilesAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_Itation
{
    public class MItationLibrary
    {
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

        internal MFilesServerApplication Server { get; private set; }

        public void Connect()
        {
            Server = new MFilesServerApplication();
            Server.Connect(AuthType: MFAuthType.MFAuthTypeLoggedOnWindowsUser, ProtocolSequence: "ncacn_ip_tcp", LocalComputerName: Environment.MachineName);
        }

        public string[] GetVaults()
        {
            return Server.GetVaults().OfType<VaultOnServer>().Select(vos => vos.Name).ToArray(); 
        }
    }
}
