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
	class CampaignList
    {
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

		public static CampaignManagerFormJSON signUpForm(string orgId)
		{
			CampaignManagerFormFieldsJSON[] jsonList = new CampaignManagerFormFieldsJSON[3];
			jsonList [0] = new CampaignManagerFormFieldsJSON ("email", true);
			jsonList [1] = new CampaignManagerFormFieldsJSON ("firstname", true);
			jsonList [2] = new CampaignManagerFormFieldsJSON ("lastname", true);
			CampaignManagerFormJSON camMan = new CampaignManagerFormJSON (orgId, "ABC", "ABC Sign Up Campaign", "All the ABC deals", "123-456-789", "Yes I agree to sign up");
			camMan.fields = jsonList;
			return camMan;
		}


		[Test()]
		public static void getSignUpFormList()
		{
			string query = "/campaign-manager/SignupForms?orgId=" +TestGlobals.orgIdCreated;
			GenericRequest getList = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getList);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
			Assert.AreEqual("200", statusCode);

		}

		[Test()]
		public static void createSignUpForms()
		{
			string orgIdPassed = OrganizationTest.getOrgId ();
			string query = "/campaign-manager/SignupForms?orgId=" + orgIdPassed;
			CampaignManagerFormJSON campaign = signUpForm (orgIdPassed);
			GenericRequest postForm = new GenericRequest (TestGlobals.campaignServer, query, campaign);
			Test mTest = new Test (campaign);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("201", statusCode);

		}

		[Test()]
		public static void displaySignUpForm()
		{
			string query = "/campaign-manager/SignupForms/" + "ABC";
			GenericRequest displayForm = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (displayForm);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
			Assert.AreEqual ("200", statusCode);
		}

    }
}
