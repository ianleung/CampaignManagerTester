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
	public class Offers
    {
		[TestFixtureSetUp]
		public void setup()
		{
			TestGlobals.setup ();
		}

		[Test()]
		public static void getSpecialOffer()
		{
			string query = "/campaign-manager/Offers/" + OfferListCreate.offerIdCreated + "?applicationKey=" + TestGlobals.applicationKey
			               + "&sessionId=" + TestGlobals.sessionId;
			GenericRequest getOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("200", statusCode);
				
		}

		[Test()]
		public static void modifyOffer()
		{
			OfferJSON json = OfferListCreate.getOfferJSON ();

			string query = "/campaign-manager/Offers/" + OfferListCreate.offerIdCreated + "?applicationKey=" + TestGlobals.applicationKey
							+ "&sessionId=" + TestGlobals.sessionId;
			
			json.name = "50% Offer on next purchase";

			GenericRequest putOffer = new GenericRequest (TestGlobals.campaignServer, query, json);
			Test mTest = new Test (putOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.PUT, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("200", statusCode);
		}

		[Test()]
		public static void removeOffer()
		{
			string query = "/campaign-manager/Offers/" + OfferListCreate.offerIdCreated + "?applicationKey=" + TestGlobals.applicationKey
							+ "&sessionId=" + TestGlobals.sessionId;
			GenericRequest deleteOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (deleteOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.DELETE, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("204", statusCode);
		}

    }
}
