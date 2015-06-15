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
			string query = "campaign-manager/Offers?applicationKey=" + TestGlobals.applicationKey + "&sessionId=" + TestGlobals.sessionId + "&orgId=" + TestGlobals.orgId.ToString ();
			GenericRequest getOffers = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffers);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
			Assert.AreEqual("200", statusCode);
		}


    }
}
