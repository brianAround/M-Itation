using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M_Itation;

namespace M_Itation_Testing
{
    /// <summary>
    /// Summary description for UnitTest_ServerConfig
    /// </summary>
    [TestClass]
    public class UnitTest_ServerConfig
    {
        [TestMethod]
        public void Test_SetServerName_Returns_ServerConfig()
        {
            ServerConfig serverConfig = new ServerConfig();

            serverConfig.AuthType = MFilesAuthType.CurrentlyLoggedOnWindowsUser;
            
            


        }

       
 
    }
}
