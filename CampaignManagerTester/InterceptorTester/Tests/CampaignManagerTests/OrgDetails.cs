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
            Console.WriteLine("\norgDetailsHappyPath Test");
            //Setup strings
			string id = TestGlobals.orgIdWithCampSignedUp;

			string query = "/campaign-manager/Organizations?"
							+ "id=" + id;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, query, null);

            Test mTest = new Test(request);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }

        [Test()]
        public static void orgUpdateHappyPath()
        {
            Console.WriteLine("\norgUpdate Happy Path Test");
            //Setup strings
			string id = TestGlobals.orgIdWithCampSignedUp;
            
            ConsoleApplication1.OrgUpdateJSON json = new ConsoleApplication1.OrgUpdateJSON();
            json.defaultTermsAndConditions = "Termzan Condit Ions";
			json.id = id;
            json.logoUrl = "http://zombo.com";
            json.name = "ABC Grocery";
            json.privacyPolicy = "stuff";

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Organizations/"
				+ "id=" + id, json);

            Test mTest = new Test(request);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            Console.WriteLine(HTTPSCalls.result.ToString());
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }
    }
}
