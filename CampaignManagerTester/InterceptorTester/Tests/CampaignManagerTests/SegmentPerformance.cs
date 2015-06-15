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
    class SegmentPerformance
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
            string sessionId = TestGlobals.sessionId;
            //int;
            string orgId = TestGlobals.orgId;
            string timeFilter = TestGlobals.timeFilter;
            string startDate = TestGlobals.startDate;
            string endDate = TestGlobals.endDate;
            //Guid;
            string campaignId;

            GenericRequest request = new GenericRequest(TestGlobals.adminServer, "/dwh/CampaignSegmentPerformance?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId + "&"
            + "orgId=" + orgId + "&"
            + "timeFilter=" + timeFilter + "&"
            + "startdate=" + startDate + "&"
            + "enddate=" + endDate + "&"
            + "campaignId=" + campaignId, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.POST));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }
    }
}
