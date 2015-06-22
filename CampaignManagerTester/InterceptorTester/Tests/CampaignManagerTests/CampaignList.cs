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

			CampaignJSON camp = new CampaignJSON (TestGlobals.campaignId, "QA testing", "This is a campaign for QA testing", TestGlobals.orgIdWithCampSignedUp, "2015-06-23 14:00", "2015-06-24 14:00");
			camp.segments = jsonList;
			return camp;
		}

		[Test()]
		public static void createCampaign()
		{
			string query = "campaign-manager/Campaigns/?applicationKey=" + TestGlobals.applicationKey + "&sessionKey=" + TestGlobals.sessionKey + 
							"&orgId=" + TestGlobals.orgIdWithCampSignedUp;

			CampaignJSON camp = newCampaign ();
			GenericRequest postCamp = new GenericRequest (TestGlobals.campaignServer, query, camp);
			Test mTest = new Test (postCamp);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
			Console.WriteLine("Status Code: " + statusCode);
			Console.WriteLine (HTTPSCalls.result.Value.Substring(7, 36));
			TestGlobals.campaignId = HTTPSCalls.result.Value.Substring (7, 36);
			Assert.AreEqual ("201", statusCode);
		}


		/*
		[Test()]
		public static void getCampaigns()
		{
			string query = "campaign-manager/Campaigns?applicationKey=" + TestGlobals.applicationKey + "&sessionId=" + TestGlobals.sessionId + 
							"&orgId=" + TestGlobals.orgId.ToString();
			GenericRequest getCam = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getCam);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
            Console.WriteLine("Status Code: " + statusCode);
			Assert.AreEqual ("200", statusCode);

		}
		*/

		[Test()]
		public static void optOut()
		{
			string query = "/campaign-manager/Signups";
			SignUpJSON signUp = new SignUpJSON ("george@costanza.com", "umbra");
			GenericRequest deleteSignUp = new GenericRequest (TestGlobals.campaignServer, query, signUp);
			Test mtest = new Test (deleteSignUp);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mtest, HTTPOperation.DELETE));
            Console.WriteLine (HTTPCalls.result.ToString());
            string statusCode = HTTPSCalls.result.Key.GetValue("Statuscode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("204", statusCode);
		}

    }
}
