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
	public class OfferListCreate
    {
		public static string offerIdCreated;

		public static OfferJSON offerJSONCreated;

		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
			offerIdCreated = null;
		}

		[Test()]
		public static void getOffers()
		{
			string query = "campaign-manager/Offers?applicationKey=" + TestGlobals.applicationKey + "&sessionKey=" + TestGlobals.sessionKey + "&orgId=" + TestGlobals.orgId.ToString ();
			GenericRequest getOffers = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffers);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
			Assert.AreEqual("200", statusCode);
		}

		[Test()]
		public static void createNewOffer()
		{
			string query = "campaign-manager/Offers?applicationKey=" + TestGlobals.applicationKey + "&sessionKey=" + TestGlobals.sessionKey + "&orgId=" + TestGlobals.orgId.ToString ();
			string orgIdPassed = OrganizationTest.getOrgId ();
			OfferJSON json = new OfferJSON ("123123-123123-123123-1231312", "10% Offer on next purchase", "Detials on the offer", "12345", Convert.ToInt32 (orgIdPassed), "blah blah blah");
			GenericRequest postOffer = new GenericRequest (TestGlobals.campaignServer, query, json);
			Test mTest = new Test (postOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("201", statusCode);
			offerIdCreated = "123123-123123-123123-1231312";
			offerJSONCreated = json;
				
		}

		public static OfferJSON getOfferJSON()
		{
			if (offerJSONCreated == null) 
			{
				createNewOffer ();
			}
			return offerJSONCreated;
		}

    }
}
