using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using M_Itation;
using System.Linq.Expressions;

namespace M_Itation_Testing
{
    /// <summary>
    /// Summary description for UnitTest_ServerConfig
    /// </summary>
    [TestClass]
    public class UnitTest_MFilesConnectionBuilder
    {
        [TestMethod]
        public void Test_FluentInterface()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            // Test that each method returns the modified class

            
            var actual1 = AssertFluentInterface(() => serverConfig.SetCurrentWindowsUserAuthType(), serverConfig, nameof(serverConfig.SetCurrentWindowsUserAuthType));
            var actual2 = AssertFluentInterface(() => serverConfig.SetSpecificMFilesUserAuthType("foo", "bar"), serverConfig, nameof(serverConfig.SetSpecificMFilesUserAuthType));
            var actual3 = AssertFluentInterface(() => serverConfig.SetSpecificWindowsUserAuthType("localhost", "dipsy", "doodle"), serverConfig, nameof(serverConfig.SetSpecificWindowsUserAuthType));
            var actual4 = AssertFluentInterface(() => serverConfig.SetProtocolSequence(MFilesProtocolSequence.ncacn_http), serverConfig, nameof(serverConfig.SetProtocolSequence));

        }

        [TestMethod]
        public void Test_ProtocolDefaultsSet()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            Assert.AreEqual(MFilesConnectionBuilder.DefaultAuthType, serverConfig.AuthType);
            Assert.AreEqual(MFilesConnectionBuilder.DefaultServerName, serverConfig.ServerName);

            AssertEndpointDefault(MFilesProtocolSequence.ncacn_http, MFilesConnectionBuilder.EndpointForHTTP);
            AssertEndpointDefault(MFilesProtocolSequence.ncacn_ip_tcp, MFilesConnectionBuilder.EndpointForTCPIP);
            AssertEndpointDefault(MFilesProtocolSequence.ncalrpc, MFilesConnectionBuilder.EndpointForLPC);

        }


        [TestMethod]
        public void Test_SetCurrentWindowsUserAuthtype()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            serverConfig.SetCurrentWindowsUserAuthType();
            Assert.AreEqual(MFilesAuthType.CurrentlyLoggedOnWindowsUser, serverConfig.AuthType);
            Assert.IsNull(serverConfig.UserName);
            Assert.IsNull(serverConfig.Password);
            Assert.IsNull(serverConfig.Domain);
        }

        [TestMethod]
        public void Test_SetSpecificWindowsUserAuthType()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            string expectedDomain = "ExpectedDomain * ExpectedDomain";
            string expectedUsername = "ExpectedUsername";
            string expectedPassword = "ExpectedPassword";

            serverConfig.SetSpecificWindowsUserAuthType(expectedDomain, expectedUsername, expectedPassword);

            Assert.AreEqual(MFilesAuthType.SpecificWindowsUser, serverConfig.AuthType);
            Assert.AreEqual(expectedDomain, serverConfig.Domain);
            Assert.AreEqual(expectedUsername, serverConfig.UserName);
            Assert.AreEqual(expectedPassword, serverConfig.Password);
            
        }

        [TestMethod]
        public void Test_SetSpecificMFilesUserAuthType()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();
            string expectedUsername = "ExpectedUsername";
            string expectedPassword = "ExpectedPassword";

            serverConfig.SetSpecificMFilesUserAuthType(expectedUsername, expectedPassword);
            Assert.AreEqual(MFilesAuthType.SpecificMFilesUser, serverConfig.AuthType);
            Assert.AreEqual(expectedUsername, serverConfig.UserName);
            Assert.AreEqual(expectedPassword, serverConfig.Password);
            Assert.IsNull(serverConfig.Domain);
        }


        [TestMethod]
        public void Test_SetProtocolSequenceHttp()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();
            string expectedServerName = "ExpectedServerName";

            serverConfig.SetProtocolSequence(MFilesProtocolSequence.ncacn_http, expectedServerName);

            Assert.AreEqual(MFilesProtocolSequence.ncacn_http, serverConfig.ProtocolSequence);
            Assert.AreEqual(expectedServerName, serverConfig.ServerName);

        }

        [TestMethod]
        public void Test_SetProtocolSequenceLpc()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            serverConfig.SetProtocolSequence(MFilesProtocolSequence.ncalrpc);

            Assert.AreEqual(MFilesProtocolSequence.ncalrpc, serverConfig.ProtocolSequence);
            Assert.AreEqual(MFilesConnectionBuilder.DefaultServerName, serverConfig.ServerName);
        }

        [TestMethod]
        public void Test_SetProtocolSequenceTcpIp()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();
            string expectedServerName = "ExpectedServerName";
            serverConfig.SetProtocolSequence(MFilesProtocolSequence.ncacn_ip_tcp, expectedServerName);

            Assert.AreEqual(MFilesProtocolSequence.ncacn_ip_tcp, serverConfig.ProtocolSequence);
            Assert.AreEqual(expectedServerName, serverConfig.ServerName);
        }

        [TestMethod]
        public void Test_SetProtocolSequenceSpc()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();

            serverConfig.SetProtocolSequence(MFilesProtocolSequence.ncacn_spx);

            Assert.AreEqual(MFilesProtocolSequence.ncacn_spx, serverConfig.ProtocolSequence);
            Assert.AreEqual(MFilesConnectionBuilder.DefaultServerName, serverConfig.ServerName);
        }


        [TestMethod]
        public void Test_GetConnectionReturnsMFilesServerConnection()
        {
            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder();
            var actual = serverConfig.GetConnection();
            Assert.IsInstanceOfType(actual, typeof(MFilesServerConnection));
        }

        [TestMethod]
        public void Test_GetConnectionCopiesValues()
        {

            MFilesConnectionBuilder serverConfig = new MFilesConnectionBuilder
            {
                AuthType = MFilesAuthType.SpecificMFilesUser,
                UserName = "EmmettMcVay",
                Password = "serviceWithASmile",
                Domain = "LazarusLongBoardingSchool",
                ProtocolSequence = MFilesProtocolSequence.ncacn_spx,
                ServerName = "BEHEMOTH.lazaruslongboardingschool.local",
                EndPoint = "Drive55"
            };
            var connection = serverConfig.GetConnection();
            Assert.AreEqual(serverConfig.AuthType, connection.AuthType);
            Assert.AreEqual(serverConfig.UserName, connection.UserName);
            Assert.AreEqual(serverConfig.Password, connection.Password);
            Assert.AreEqual(serverConfig.Domain, connection.Domain);
            Assert.AreEqual(serverConfig.ProtocolSequence, connection.ProtocolSequence);
            Assert.AreEqual(serverConfig.ServerName, connection.ServerName);
            Assert.AreEqual(serverConfig.EndPoint, connection.EndPoint);
        }

        public T AssertFluentInterface<T>(Func<T> action, T expected, string methodName)
        {
            T actual = action.Invoke();
            Assert.AreEqual<T>(expected, actual, "Fluent Breakdown " + methodName);
            return expected;

        }   

        public void AssertEndpointDefault(MFilesProtocolSequence protocolSequence, string expectedEndpoint)
        {
            MFilesConnectionBuilder target = new MFilesConnectionBuilder();

            target.SetProtocolSequence(protocolSequence);
            Assert.AreEqual(expectedEndpoint, target.EndPoint, "{{protocolSequence}} fails to set endpoint");

        }

 
    }
}
