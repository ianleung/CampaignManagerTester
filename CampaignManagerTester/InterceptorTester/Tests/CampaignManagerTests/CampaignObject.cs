using ConsoleApplication1;
using NUnit.Framework;
using Nito.AsyncEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        [Test()]
        public static void getCampaign()
        {
            //Setup strings
            GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/campaigns/"
			+ TestGlobals.campaignId + "?"
            + "applicationKey=" + TestGlobals.applicationKey + "&"
            + "sessionKey=" + TestGlobals.sessionKey, null);

			Console.WriteLine ("campaignId: " + TestGlobals.campaignId);
            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }


        //TODO: Do this when API is legible
        [Test()]
        public static void updateCampaign()
        {
            //Setup strings
            
			CampaignList.createCampaign ();

			CampaignJSON campJSON = CampaignList.newCampaign ();

			CampaignSegmentsJSON[] jsonList = new CampaignSegmentsJSON[3];
			jsonList [0] = new CampaignSegmentsJSON ("A", "e310d9ef-554a-408d-8b8e-2abf28722716");
			jsonList [1] = new CampaignSegmentsJSON ("B", null);
			jsonList [2] = new CampaignSegmentsJSON ("C", null);

			CampaignJSON camp = new CampaignJSON (TestGlobals.campaignId, "QA testing update", "This is an update for QA testing", TestGlobals.orgIdWithCampSignedUp, "2015-06-23 14:00", "2015-06-24 14:00");
			camp.segments = jsonList;

			Console.WriteLine (TestGlobals.campaignId);

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/" + TestGlobals.campaignId + "?"
            						+ "applicationKey=" + TestGlobals.applicationKey + "&"
									+ "orgId=" + TestGlobals.orgIdWithCampSignedUp + "&"
									+ "sessionKey=" + TestGlobals.sessionKey, camp);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.PUT));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);

			removeCampaign ();
        }



        [Test()]
        public static void removeCampaign()
        {
            //Setup strings
            
			//CampaignList.createCampaign ();
			Console.WriteLine (TestGlobals.campaignId);

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Campaigns/" + TestGlobals.campaignId+ "?"
            + "applicationKey=" + TestGlobals.applicationKey + "&"
			+ "orgId=" + TestGlobals.orgIdWithCampSignedUp + "&"
            + "sessionKey=" + TestGlobals.sessionKey, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.DELETE));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("204", statusCode);
        }
    }
}
