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
    class OfferPreview
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void offerPreviewHappyPath()
        {
            //Setup strings
            //Guid;
            string id = TestGlobals.offerId;
            //string
            string campaignName = TestGlobals.campaignName;
            string campaignDescription = TestGlobals.campaignDescription;
            string startDate = TestGlobals.startDate;
            string endDate = TestGlobals.endDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Offers/"+id+"/Preview/?campaignName="+campaignName+"&campaignDescription="+campaignDescription+"&startDate="+startDate+"&endDate="+endDate, null);

            Test mTest = new Test(request);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Value);
            Console.WriteLine(HTTPSCalls.result.Key);
            Assert.AreEqual("200", statusCode);
        }
    }
}
