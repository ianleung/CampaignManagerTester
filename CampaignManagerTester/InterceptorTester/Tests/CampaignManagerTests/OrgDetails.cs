﻿using ConsoleApplication1;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterceptorTester.Tests.CampaignManagerTests
{
    [TestFixture()]
    class OrgDetails
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void orgDetailsHappyPath()
        {
            //Setup strings
            string id = TestGlobals.orgId.ToString();
            string applicationKey = TestGlobals.applicationKey;
            string sessionKey = TestGlobals.sessionKey;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Organizations?"
            + "id=" + id + "&"
            + "applicationKey=" + applicationKey + "&"
            + "sessionKey=" + sessionKey, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }

        [Test()]
        public static void orgUpdateHappyPath()
        {
            //Setup strings
            string id = TestGlobals.orgId.ToString();
            string applicationKey = TestGlobals.applicationKey;
            string sessionKey = TestGlobals.sessionKey;

            ConsoleApplication1.OrgUpdateJSON json = new ConsoleApplication1.OrgUpdateJSON();
            json.defaultTermsAndConditions = "Termzan Condit Ions";
            json.id = "1124";
            json.logoUrl = "http://zombo.com";
            json.name = "Umbra";
            json.privacyPolicy = "stuff";

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Organizations/"
            + "id=" + id + "&"
            + "applicationKey=" + applicationKey + "&"
            + "sessionKey=" + sessionKey, json);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            Console.WriteLine(HTTPSCalls.result.ToString());
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }
    }
}
