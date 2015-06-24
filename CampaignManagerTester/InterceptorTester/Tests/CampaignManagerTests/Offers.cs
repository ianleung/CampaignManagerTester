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
			string query = "/campaign-manager/Offers/" + TestGlobals.offerId + "?applicationKey=" + TestGlobals.applicationKey
							+ "&sessionKey=" + TestGlobals.sessionKey + "&orgId=" + TestGlobals.orgIdWithCampSignedUp;
			GenericRequest getOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("200", statusCode);
				
		}

        //API Needs fixing, can't resolve on our own
		[Test()]
		public static void modifyOffer()
		{
			//OfferListCreate.createNewOffer();

			Console.WriteLine (TestGlobals.offerId);

			string query = "/campaign-manager/Offers/" + TestGlobals.offerId + "?applicationKey=" + TestGlobals.applicationKey
							+ "&orgId=" + TestGlobals.orgIdWithCampSignedUp
							+ "&sessionKey=" + TestGlobals.sessionKey;

			OfferJSON json = new OfferJSON ("new offer for QA testing", TestGlobals.orgIdWithCampSignedUp, "456", "blah blah blah");

			GenericRequest putOffer = new GenericRequest (TestGlobals.campaignServer, query, json);
			Test mTest = new Test (putOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.PUT, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(HTTPSCalls.result.Value);
            Console.WriteLine(HTTPSCalls.result.Key);
			Assert.AreEqual ("200", statusCode);
		}

		[Test()]
		public static void removeOffer()
		{
			string query = "/campaign-manager/Offers/" + TestGlobals.offerId + "?applicationKey=" + TestGlobals.applicationKey
							+ "&sessionKey=" + TestGlobals.sessionKey;
			GenericRequest deleteOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (deleteOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.DELETE, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("204", statusCode);
		}

    }
}
