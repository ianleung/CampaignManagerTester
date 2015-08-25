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
	public class SignupForm
    {
		[TestFixtureSetUp()]
		public void setup()
		{
			TestGlobals.setup ();
		}

		public static CampaignManagerFormJSON postSignUpForm(string orgId)
		{
			OfferListCreate.createNewOffer();

			CampaignManagerFormFieldsJSON[] jsonList = new CampaignManagerFormFieldsJSON[3];
			jsonList [0] = new CampaignManagerFormFieldsJSON ("email", true);
			jsonList [1] = new CampaignManagerFormFieldsJSON ("firstname", true);
			jsonList [2] = new CampaignManagerFormFieldsJSON ("lastname", true);
			CampaignManagerFormJSON camMan = new CampaignManagerFormJSON (orgId, "ABC"+TestGlobals.orgIdCreated, "ABC1 Sign Up Campaign", "All the ABC deals", TestGlobals.offerId, "Yes I agree to sign up");

			camMan.fields = jsonList;
			return camMan;
		}
        /*
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
        */

		[Test()]
		public static void getSignUpFormList()
		{
			string query = "/campaign-manager/SignupForms?orgId=" +TestGlobals.orgIdCreated;
			GenericRequest getList = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (getList);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
			Assert.AreEqual("200", statusCode);

		}


        // This creates a signup campaign
		// Organization need to be manually added to database after being created

		[Test()]
		public static void createSignUpForms()
		{
            /*
			if (TestGlobals.orgIdCreated == null)
            {
                OrganizationTest.createOrganization();
                System.Threading.Thread.Sleep(5000);
            }
            */

			string query = "/campaign-manager/SignupForms?orgId=" + TestGlobals.orgIdCreated;
			CampaignManagerFormJSON campaign = postSignUpForm(TestGlobals.orgIdCreated);
			GenericRequest postForm = new GenericRequest (TestGlobals.campaignServer, query, campaign);
			Test mTest = new Test (postForm);
			HttpClient client = new HttpClient ();
            client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();

            if (campaign.fields != null)
            {
                Console.WriteLine(campaign.ToString());
            }
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.POST, client));
			string statusCode = HTTPSCalls.result.Key.GetValue ("StatusCode").ToString ();
            Console.WriteLine(statusCode);
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
			if (statusCode == "201") 
			{
				TestGlobals.orgIdWithCampSignedUp = TestGlobals.orgIdCreated;
			}
			Assert.AreEqual ("201", statusCode);
		}

		[Test()]
		public static void displaySignUpForm()
		{
			string query = "/campaign-manager/SignupForms/" + TestGlobals.slug;
			Console.WriteLine (query);
			GenericRequest displayForm = new GenericRequest (TestGlobals.campaignServer, query, null);
			Test mTest = new Test (displayForm);
			HttpClient client = new HttpClient ();
			client.DefaultRequestHeaders.Authorization = AuthenticateTest.getSessionToken();
			AsyncContext.Run (async () => await new HTTPSCalls ().runTest (mTest, HTTPOperation.GET, client));
            string statusCode = HTTPSCalls.result.Key.GetValue("StatusCode").ToString();
            Console.WriteLine(HTTPSCalls.result.Key.ToString());
            Console.WriteLine(HTTPSCalls.result.Value);
			Assert.AreEqual ("200", statusCode);
		}

    }
}
