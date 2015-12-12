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
    }
}
