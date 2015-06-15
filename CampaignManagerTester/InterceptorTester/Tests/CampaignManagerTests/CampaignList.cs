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
	public class CampaignList
    {
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

		public static CampaignManagerFormJSON postSignUpForm(int orgId)
		{
			CampaignManagerFormFieldsJSON[] jsonList = new CampaignManagerFormFieldsJSON[3];
			jsonList [0] = new CampaignManagerFormFieldsJSON ("email", true);
			jsonList [1] = new CampaignManagerFormFieldsJSON ("firstname", true);
			jsonList [2] = new CampaignManagerFormFieldsJSON ("lastname", true);
			CampaignManagerFormJSON camMan = new CampaignManagerFormJSON (orgId, "ABC", "ABC Sign Up Campaign", "All the ABC deals", "123-456-789", "Yes I agree to sign up");
			camMan.fields = jsonList;
			return camMan;
		}

		public static CampaignSignUpJSON signUp()
		{
			CampaignSignUpFieldsJSON[] jsonList = new CampaignSignUpFieldsJSON[4];
			jsonList [0] = new CampaignSignUpFieldsJSON ("email", "newman@usps.com");
			jsonList [1] = new CampaignSignUpFieldsJSON ("firstName", "Newman");
			jsonList [2] = new CampaignSignUpFieldsJSON ("lastName", "Newman");
			jsonList [3] = new CampaignSignUpFieldsJSON ("telephone", "+17185555555");
			CampaignSignUpJSON camSignUp = new CampaignSignUpJSON ("umbra");
			camSignUp.fields = jsonList;
			return camSignUp;
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
			CampaignManagerFormJSON campaign = postSignUpForm (Convert.ToInt32(orgIdPassed));
			GenericRequest postForm = new GenericRequest (TestGlobals.campaignServer, query, campaign);
			Test mTest = new Test (postForm);
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

		[Test()]
		public static void newSignUp()
		{
			string query = "/campaign-manager/Signups";
			CampaignSignUpJSON campaign = signUp ();
			GenericRequest postSignUp = new GenericRequest (TestGlobals.campaignServer, query, campaign);
			Test mtest = new Test (postSignUp);
			HttpClient client = new HttpClient ();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mtest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
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
			string statusCode = HTTPSCalls.result.Key.GetValue ("Statuscode").ToString ();
            Assert.AreEqual("204", statusCode);
		}

    }
}
