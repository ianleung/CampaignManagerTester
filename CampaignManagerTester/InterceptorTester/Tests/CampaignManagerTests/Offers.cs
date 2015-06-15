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
			string query = "/campaign-manager/Offers/" + "123123-123123-123123-1231312" + "?applicationKey=" + TestGlobals.applicationKey
			               + "&sessionId=" + TestGlobals.sessionId;
			GenericRequest getOffer = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getOffer);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("200", statusCode);
				
		}



    }
}
