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
	public class Signups
    {
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

        //TODO: Check w/ someone to see if the nonsense error messages are logged in JIRA already
		[Test()]
		public static void newSignUp()
		{
			string query = "/campaign-manager/Signups";
			CampaignSignUpJSON campaign = new CampaignSignUpJSON(TestGlobals.slug);
			GenericRequest postSignUp = new GenericRequest (TestGlobals.campaignServer, query, campaign);
            Test mtest = new Test(postSignUp);
            Console.WriteLine(query.ToString());
            Console.WriteLine(campaign.ToString());
			HttpClient client = new HttpClient ();
            AsyncContext.Run(async () => await new HTTPSCalls().runTest(mtest, HTTPOperation.POST, client));
            Console.WriteLine(HTTPSCalls.result.Key);
            Console.WriteLine(HTTPSCalls.result.Value);
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(statusCode);
			Assert.AreEqual ("201", statusCode);
		}


		[Test()]
		public static void optOut()
		{
			string query = "/campaign-manager/Signups";
			SignUpJSON signUp = new SignUpJSON ("george@costanza.com", "umbra");
			GenericRequest deleteSignUp = new GenericRequest (TestGlobals.campaignServer, query, signUp);
			Test mtest = new Test (deleteSignUp);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mtest, HTTPOperation.DELETE, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(statusCode);
            Console.WriteLine(HTTPSCalls.result.Value.ToString());
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Assert.AreEqual("204", statusCode);
		}
    }
}
