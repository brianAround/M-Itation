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
        [TestMethod]
        public void GetServerInfo()
        {
            // Get the library and see if the server is where we expect it to be.
            var con = new MFilesServerConnection();
            Assert.IsNotNull(con);
            con.Connect();

            // Verify that you're connected to the server
            Assert.IsTrue(con.IsConnectedtoServer, "After connecting... Library not connected.");

            // Get a list of vaults we can connect to.
            var vaults = con.GetVaults();
            Assert.IsNotNull(vaults);
            Assert.AreNotEqual(0, vaults.Count());
            // Connect to the first vault in the list

            con.ConnectToVault(vaults[0]);

            Assert.AreEqual(con.ConnectedVault, vaults[0]);

            
  





            // Once you've covered this case, remove this item.
            Assert.Fail("Finish the GetServerInfo functional test");
        }   
    }
}
