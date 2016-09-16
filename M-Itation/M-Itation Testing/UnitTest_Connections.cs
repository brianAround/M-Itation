using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M_Itation;
using System.Runtime.InteropServices;

namespace M_Itation_Testing
{
    [TestClass]
    public class UnitTest_Connections
    {
        [TestMethod]
        public void TestConnectToServer()
        {
            MFilesServerConnection library = new MFilesServerConnection();
            library.Connect();
            Assert.IsTrue(library.IsConnectedtoServer, "Server Not Connected");
        }

        [TestMethod]
        [ExpectedException(typeof(COMException), AllowDerivedTypes = true)]
        public void TestConnectionToFakeServer()
        {
            MFilesServerConnection con = new MFilesServerConnection();
            con.ServerName = "ThisIsNotARealServerName";
            con.Connect();
        }

        [TestMethod]
        public void TestNewServerInstanceStartsDisconnected()
        {
            MFilesServerConnection con = new MFilesServerConnection();
            Assert.IsFalse(con.IsConnectedtoServer, "The brand new connection ");
        }


        [TestMethod]
        public void TestDisconnectionConnectedInstance()
        {
            MFilesServerConnection library = new MFilesServerConnection();
            library.Connect();
            if (!library.IsConnectedtoServer)
            {
                Assert.Inconclusive("Can't connect to server to test disconnect.");
            }
            library.Disconnect();
            Assert.IsFalse(library.IsConnectedtoServer, "Disconnect failure");

        }

        [TestMethod]
        public void TestGetVaultsReturnsNameAndGuid()
        {
            MFilesServerConnection con = new MFilesServerConnection();
            con.Connect();

            if (!con.IsConnectedtoServer) Assert.Inconclusive("Can't continue without server connection.");

            foreach(VaultInfo vaultInfo in con.GetVaults())
            {
                Assert.IsNotNull(vaultInfo);
                Assert.IsNotNull(vaultInfo.Name, "VaultInfo name not set");
                Assert.AreNotEqual(Guid.Empty, vaultInfo.VaultGuid, "VaultInfo Guid not set");
            }

        }
    }
}
