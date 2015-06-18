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

		public static CampaignJSON newCampaign(string orgIdPassed)
		{
			CampaignSegmentsJSON[] jsonList = new CampaignSegmentsJSON[3];
			jsonList [0] = new CampaignSegmentsJSON ("A", "123123-123123-123123-123123");
			jsonList [1] = new CampaignSegmentsJSON ("B", "123123-123123-123123-123123");
			jsonList [2] = new CampaignSegmentsJSON ("C", "123123-123123-123123-123123");

			CampaignJSON camp = new CampaignJSON ("21345-123", "Receive offers on Umbra products", orgIdPassed, "2015-05-31T11:00:00-04:00", "2015-05-31T11:00:00-04:00");
			camp.segments = jsonList;
			return camp;
		}


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

		[Test()]
		public static void createCampaign()
		{
			string orgIdPassed = OrganizationTest.getOrgId ();
			string query = "campaign-manager/Campaigns?applicationKey=" + TestGlobals.applicationKey + "&sessionId=" + TestGlobals.sessionId + 
							"&orgId=" + orgIdPassed;

			CampaignJSON camp = newCampaign (orgIdPassed);
			GenericRequest postCamp = new GenericRequest (TestGlobals.campaignServer, query, camp);
			Test mTest = new Test (postCamp);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
			Assert.AreEqual ("201", statusCode);
		}

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
