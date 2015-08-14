using ConsoleApplication1;
using InterceptorTester.Tests.AdminTests;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace InterceptorTester.Tests.CampaignManagerTests
{
    [TestFixture()]
    class CampaignObject
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();

        }

        //[Test()]
        public static void getCampaign()
        {
            //Setup strings
            GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/campaigns/"
			+ TestGlobals.campaignId, null);

			Console.WriteLine ("campaignId: " + TestGlobals.campaignId);
            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);
        }


        //TODO: Do this when API is legible
        //[Test()]
        public static void updateCampaign()
        {
            //Setup strings
            
			CampaignList.createCampaign ();

			CampaignJSON campJSON = CampaignList.newCampaign ();

			CampaignSegmentsJSON[] jsonList = new CampaignSegmentsJSON[3];
			jsonList [0] = new CampaignSegmentsJSON ("A", "e310d9ef-554a-408d-8b8e-2abf28722716");
			jsonList [1] = new CampaignSegmentsJSON ("B", null);
			jsonList [2] = new CampaignSegmentsJSON ("C", null);

			CampaignJSON camp = new CampaignJSON ("QA testing update", "This is an update for QA testing", TestGlobals.orgIdWithCampSignedUp, "2015-06-23 14:00", "2015-06-24 14:00");
			camp.segments = jsonList;

			Console.WriteLine (TestGlobals.campaignId);

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/" + TestGlobals.campaignId + "?"
									+ "orgId=" + TestGlobals.orgIdWithCampSignedUp, camp);

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT,client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("200", statusCode);

			removeCampaign ();
        }



        //[Test()]
        public static void removeCampaign()
        {
            //Setup strings
            
			//CampaignList.createCampaign ();
			Console.WriteLine (TestGlobals.campaignId);

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/" + TestGlobals.campaignId+ "?"
			+ "orgId=" + TestGlobals.orgIdWithCampSignedUp, null);

            Test mTest = new Test(request);
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.DELETE,client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
            Assert.AreEqual("204", statusCode);
        }
    }
}
