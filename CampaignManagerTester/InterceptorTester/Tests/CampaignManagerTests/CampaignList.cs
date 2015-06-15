using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.IO;
using System.Configuration;
using Nito.AsyncEx;
using System.IO.Compression;
using Newtonsoft.Json.Linq;
using System.Net.Http;
using ConsoleApplication1;
using InterceptorTester.Tests.AdminTests;

namespace InterceptorTester.Tests.CampaignManagerTests
{
	[TestFixture()]
	class CampaignList
    {
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

        [Test()]
        public static void getHappyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionId = TestGlobals.sessionId;
            //int
            string orgId = TestGlobals.orgId;

            GenericRequest request = new GenericRequest(TestGlobals.adminServer, "/campaign-manager/Campaigns?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId + "&"
            + "orgId=" + orgId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }

		[Test()]
		public static void getSignUpFormsList()
		{
			string query = "/campaign-manager/SignupForms?orgId=" +TestGlobals.orgIdCreated;
			GenericRequest getList = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getList);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
			Assert.AreEqual("200", statusCode);

		}



    }
}
