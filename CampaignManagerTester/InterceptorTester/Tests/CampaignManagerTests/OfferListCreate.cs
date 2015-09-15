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
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

		[Test()]
		public static void getOffers()
		{
            Console.WriteLine("\ngetOffers Test");
			string query = "campaign-manager/Offers?orgId=" + TestGlobals.orgIdWithCampSignedUp;
			GenericRequest getOffers = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffers);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(HTTPSCalls.result.Key);
            Console.WriteLine(HTTPSCalls.result.Value);
			Assert.AreEqual("200", statusCode);
		}

		[Test()]
		public static void getSingleOffer()
		{
            Console.WriteLine("\ngetSingleOffer Test");
			string query = "campaign-manager/Offers/" + TestGlobals.offerId;
			Console.WriteLine (query);
			GenericRequest getOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffer);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Console.WriteLine ("Status Code: " + statusCode);
			Console.WriteLine (HTTPSCalls.result.Value);
			Assert.AreEqual ("200", statusCode);
            Offers.removeOffer();
		}

		[Test()]
		public static void createNewOffer()
		{
            Console.WriteLine("\ncreateNewOffer Test");
			string query = "campaign-manager/Offers/?orgId=" + TestGlobals.orgIdWithCampSignedUp;
			OfferJSON json = new OfferJSON ("new offer for QA testing", TestGlobals.orgIdWithCampSignedUp, "123", "blah blah blah");
			GenericRequest postOffer = new GenericRequest (TestGlobals.campaignServer, query, json);
			Test mTest = new Test (postOffer);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Console.WriteLine(HTTPSCalls.result.Value);
			Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value.Substring(7, 36));

			TestGlobals.offerId = HTTPSCalls.result.Value.Substring (7, 36);
			Assert.AreEqual ("200", statusCode);
				
		}

		public static string getOfferJSON()
		{
			if (TestGlobals.offerId == null) 
			{
				createNewOffer ();
			}
			return TestGlobals.offerId;
		}

    }
}
