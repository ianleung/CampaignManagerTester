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
    class OfferPreview
    {
        [TestFixtureSetUp()]
        public void setup()
        {
            TestGlobals.setup();
        }

        [Test()]
        public static void happyPath()
        {
            //Setup strings
            string applicationKey = TestGlobals.applicationKey;
            string sessionKey = TestGlobals.sessionKey;
            //Guid;
            string id = TestGlobals.offerId;
            //string
            string campaignName = TestGlobals.campaignName;
            string campaignDescription = TestGlobals.campaignDescription;
            string startDate = TestGlobals.startDate;
            string endDate = TestGlobals.endDate;

			GenericRequest request = new GenericRequest(TestGlobals.campaignServer, "/campaign-manager/Offers/"+id+"/Preview/?applicationKey="+applicationKey+"&sessionKey="+sessionKey+"&campaignName="+campaignName+"&campaignDescription="+campaignDescription+"&startDate="+startDate+"&endDate="+endDate, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine("Status Code: " + statusCode);
            Assert.AreEqual("200", statusCode);
        }
    }
}
