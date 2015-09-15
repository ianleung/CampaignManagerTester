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

		public static void newOffer()
		{
			string query = "campaign-manager/Offers/?orgId=" + TestGlobals.orgIdWithCampSignedUp;
			OfferJSON json = new OfferJSON ("new offer for QA testing", TestGlobals.orgIdWithCampSignedUp, "123", "blah blah blah");
			GenericRequest postOffer = new GenericRequest (TestGlobals.campaignServer, query, json);
			Test mTest = new Test (postOffer);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
            //setting global offer ID to the new offer created
			TestGlobals.offerId = HTTPSCalls.result.Value.Substring (7, 36);

		}

		public static CampaignJSON newCampaign()
		{
			newOffer ();
			CampaignSegmentsJSON[] jsonList = new CampaignSegmentsJSON[3];
			jsonList [0] = new CampaignSegmentsJSON ("A", TestGlobals.offerId);
			jsonList [1] = new CampaignSegmentsJSON ("B", null);
			jsonList [2] = new CampaignSegmentsJSON ("C", null);

			CampaignJSON camp = new CampaignJSON ("QA testing", "This is a campaign for QA testing", TestGlobals.orgIdWithCampSignedUp, "2015-06-23 14:00", "2015-06-24 14:00");
			camp.segments = jsonList;
			return camp;
		}

		[Test()]
		public static void createCampaign()
		{
            Console.WriteLine("\ncreateCampaign Test");
			string query = "/campaign-manager/Campaigns?orgId=" + TestGlobals.orgIdWithCampSignedUp;
			Console.WriteLine (query);
			CampaignJSON camp = newCampaign ();
			GenericRequest postCamp = new GenericRequest (TestGlobals.campaignServer, query, camp);
			Test mTest = new Test (postCamp);
			HttpClient client = new HttpClient ();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);

           	Console.WriteLine("Server: " + TestGlobals.campaignServer);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Console.WriteLine(camp.ToString());

			Assert.AreEqual ("200", statusCode);
            //Setting global campaign ID to the new campaign created
            TestGlobals.campaignId = HTTPSCalls.result.Value.Substring(7, 36);
		}



		[Test()]
		public static void getRfmCampaigns()
		{
            Console.WriteLine("\ngetRfmCampaigns Test");
			string query = "/campaign-manager/Campaigns?orgId=" + TestGlobals.orgIdWithCampSignedUp;
			Console.WriteLine (query);
			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, query, null);
			Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET,client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
			Assert.AreEqual("200", statusCode);
            Console.WriteLine(TestGlobals.campaignId);
            CampaignObject.removeCampaign();
            Console.WriteLine(TestGlobals.offerId);

		}

    }
}
