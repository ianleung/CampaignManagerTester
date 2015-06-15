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
    class SubCountForPub
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
            //Guid
            string publicationId = TestGlobals.publicationId;
            //int
            string status = TestGlobals.status;

            string date = TestGlobals.date;

            GenericRequest request = new GenericRequest(TestGlobals.adminServer, "/dwh/SubscriptionsCount?"
            + "applicationKey=" + applicationKey + "&"
            + "sessionId=" + sessionId + "&"
            + "publicationId=" + publicationId + "&"
            + "status=" + status + "&"
            + "date=" + date, null);

            Test mTest = new Test(request);
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mTest, HTTPOperation.GET));
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Assert.AreEqual("200", HTTPSCalls.result.Value.ToString());
        }
    }
}
