using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using M_Itation;
using MFilesAPI;

namespace M_Itation_Testing
{
    [TestClass]
    public class FunctionalTests_ServerConnection
    {
   
    
        public void Utility_TestServerOperations(ServerConfig serverConfig)
        {
            // Get the library and see if the server is where we expect it to be.
            var con = new MFilesServerConnection(serverConfig);

            Assert.IsNotNull(con);
            Assert.IsFalse(con.IsConnectedtoServer, "MFilesServerconnection just created, but seems to be connected to the server.");
            con.Connect();

            // Verify that you're connected to the server
            Assert.IsTrue(con.IsConnectedtoServer, "After connecting... Library not connected.");

            // Get a list of vaults we can connect to.
            var vaults = con.GetVaults();
            Assert.IsNotNull(vaults);
            Assert.AreNotEqual(0, vaults.Count());

            // The first vault has a name and a Guid that could be used to connect to it.
            var FirstVault = vaults[0];
            Assert.IsNotNull(FirstVault.Name);
            Assert.AreNotEqual(Guid.Empty, FirstVault.VaultGuid);
            

            // Disconnect from the server, just to tidy things up.
            con.Disconnect();
            Assert.IsFalse(con.IsConnectedtoServer, "After disconnection... Library is still connected.");


        }


        [TestMethod]
        public void GetServerInfoCurrentWindowsUser()
        {
            Utility_TestServerOperations(getCurrentWindowsUserConfig());
        }


        [TestMethod]
        public void GetServerInfoSpecificMFilesUser()
        {
            Utility_TestServerOperations(getSpecificMFilesUserConfig());
        }

        [TestMethod]
        public void GetServerInfoSpecificWindowsUser()
        {
            Utility_TestServerOperations(getSpecificWindowsUserConfig());
        }



        private ServerConfig getCurrentWindowsUserConfig()
        {
            return new ServerConfig
            {
                AuthType = MFilesAuthType.CurrentlyLoggedOnWindowsUser,
                UserName = null,
                Password = null,
                ProtocolSequence = MFilesProtocolSequence.ncacn_ip_tcp,
                ServerName = "localhost"
            };
        }

        private ServerConfig getSpecificMFilesUserConfig()
        {
            return new ServerConfig
            {
                AuthType = MFilesAuthType.SpecificMFilesUser,
                UserName = "Lance",
                Password = "Armstrong",
                ProtocolSequence = MFilesProtocolSequence.ncacn_ip_tcp,
                ServerName = "localhost"
            };
        }

        private ServerConfig getSpecificWindowsUserConfig()
        {

            return new ServerConfig
            {
                AuthType = MFilesAuthType.SpecificWindowsUser,
                UserName = "Admin",
                Password = "corsica",
                Domain = "DESKTOP-HN8QES7",
                ProtocolSequence = MFilesProtocolSequence.ncacn_ip_tcp,
                ServerName = "localhost"
            };
        }
    }
}
