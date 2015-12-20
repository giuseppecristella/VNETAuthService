using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AuthenticationService.Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Should_Create_User_Via_WCF()
        { 
            //var authenticationServiceProxy = new AuthenticationServiceProxy.AuthenticationServiceClient();
            //authenticationServiceProxy.GetUser(1);

            var test = new testAuthAzure.AuthenticationServiceClient();

        }
        //marco
        [TestMethod]
        public void Should_Get_Client_Code()
        {
            var localAuthServiceProxy = new localAuthService.AuthenticationServiceClient();
            var retCode = localAuthServiceProxy.GetClientCode("0001");
            Assert.IsNotNull(retCode);
        } 
    }
}
