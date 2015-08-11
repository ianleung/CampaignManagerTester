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
	public class CampaignList
    {

		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

		public static CampaignJSON newCampaign()
		{
			CampaignSegmentsJSON[] jsonList = new CampaignSegmentsJSON[3];
			jsonList [0] = new CampaignSegmentsJSON ("A", "e8141292-7f20-467a-b905-20261c5a8306");
			jsonList [1] = new CampaignSegmentsJSON ("B", null);
			jsonList [2] = new CampaignSegmentsJSON ("C", null);

			CampaignJSON camp = new CampaignJSON ("QA testing", "This is a campaign for QA testing", TestGlobals.orgIdWithCampSignedUp, "2015-06-23 14:00", "2015-06-24 14:00");
			camp.segments = jsonList;
			return camp;
		}

		[Test()]
		public static void createCampaign()
		{
			string query = "campaign-manager/Campaign/?orgId=" + TestGlobals.orgIdWithCampSignedUp;

			CampaignJSON camp = newCampaign ();
			GenericRequest postCamp = new GenericRequest (TestGlobals.campaignServer, query, camp);
			Test mTest = new Test (postCamp);
			HttpClient client = new HttpClient ();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);

            if(!statusCode.Equals("200"))
            {
                Console.WriteLine("Server: " + TestGlobals.campaignServer);
                Console.WriteLine(HTTPSCalls.result.Key.ToString());
                Console.WriteLine(HTTPSCalls.result.Value);
                Console.WriteLine(camp.ToString());
            }
			Assert.AreEqual ("200", statusCode);
            //??? Campaign id is an input parameter
            TestGlobals.campaignId = HTTPSCalls.result.Value.Substring(7, 36);
		}



		[Test()]
		public static void getRfmCampaigns()
		{
			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaign?"
				+ "orgId=" + TestGlobals.orgIdWithCampSignedUp, null);

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET,client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
			Assert.AreEqual("200", statusCode);
		}

    }
}
