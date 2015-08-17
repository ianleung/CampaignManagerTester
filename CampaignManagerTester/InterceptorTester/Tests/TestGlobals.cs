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
using InterceptorTester.Tests.AdminTests;

namespace ConsoleApplication1
{
	public static class TestGlobals
	{
		public static Uri testServer;
		public static Uri demoServer;
		public static Uri adminServer;
		public static Uri campaignServer;
		public static string validSerial;
		public static string demoSerial;
		public static string invalidSerial;
		public static int delay;
        public static int maxReps;
        public static string username;
        public static string password;
		public static string orgIdCreated;
		public static string locIdCreated;
        public static string intIdCreated;
        public static string intSerialCreated;
        public static string logFile = "../../../logs/testLog.txt";

        //TODO: Add these to appconfig
        public static string slug;
        public static string startDate;
        public static string endDate;
        public static string redeemedDate;
        public static string timeFilter;
        public static string status;
        public static string publicationId;
        public static string offerId;
        public static string campaignName;
        public static string campaignId;
        public static string campaignDescription;
        public static string couponCode;
        public static string date;
        public static string issuedDate;
		public static string applicationKey;
		public static string sessionKey;
		public static int orgId;

		public static string orgIdWithCampSignedUp;


		public static void setup()
		{
			try
			{
				testServer = new Uri(ConfigurationManager.ConnectionStrings["Server"].ConnectionString);
				//demoServer = new Uri(ConfigurationManager.ConnectionStrings["DemoServer"].ConnectionString);

				demoServer = new Uri("http://cozumointops.cloudapp.net");

				campaignServer = new Uri(ConfigurationManager.ConnectionStrings["CampaignServer"].ConnectionString);

				adminServer = new Uri(ConfigurationManager.ConnectionStrings["AdminServer"].ConnectionString);
				validSerial = ConfigurationManager.ConnectionStrings["ValidSerial"].ConnectionString;
				//demoSerial = ConfigurationManager.ConnectionStrings["DemoSerial"].ConnectionString;

				demoSerial = "D05FB84F2A56";

				invalidSerial = ConfigurationManager.ConnectionStrings["InvalidSerial"].ConnectionString;
				delay = int.Parse(ConfigurationManager.ConnectionStrings["DelayBetweenRuns"].ConnectionString);
                username = ConfigurationManager.ConnectionStrings["Username"].ConnectionString;
                password = ConfigurationManager.ConnectionStrings["Password"].ConnectionString;

				slug = "ABC1";
                startDate = ConfigurationManager.ConnectionStrings["startDate"].ConnectionString;
                endDate = ConfigurationManager.ConnectionStrings["endDate"].ConnectionString;
                redeemedDate = ConfigurationManager.ConnectionStrings["redeemedDate"].ConnectionString;
                timeFilter = ConfigurationManager.ConnectionStrings["timeFilter"].ConnectionString;
                status = ConfigurationManager.ConnectionStrings["status"].ConnectionString;
                publicationId = ConfigurationManager.ConnectionStrings["publicationId"].ConnectionString;
                offerId = ConfigurationManager.ConnectionStrings["offerId"].ConnectionString;
                campaignName = ConfigurationManager.ConnectionStrings["campaignName"].ConnectionString;
                campaignDescription = ConfigurationManager.ConnectionStrings["campaignDescription"].ConnectionString;
                couponCode = ConfigurationManager.ConnectionStrings["couponCode"].ConnectionString;
                date = ConfigurationManager.ConnectionStrings["date"].ConnectionString;
                issuedDate = ConfigurationManager.ConnectionStrings["issuedDate"].ConnectionString;
				applicationKey = ConfigurationManager.ConnectionStrings["applicationKey"].ConnectionString;
				sessionKey = ConfigurationManager.ConnectionStrings["sessionKey"].ConnectionString;

				orgIdCreated = "448";
				orgIdWithCampSignedUp = orgIdCreated;
                if (orgIdCreated == null)
                {
                    OrganizationTest.createOrganization();
					orgIdWithCampSignedUp = orgIdCreated;
                }
				Console.WriteLine(orgIdWithCampSignedUp);
				string testRunsString = ConfigurationManager.ConnectionStrings["TimesToRunTests"].ConnectionString;
				try { maxReps = int.Parse(testRunsString); }
				catch (Exception e)
				{
					Console.WriteLine(e);
					Console.WriteLine("Chances are your appconfig is misconfigured. Double check that performanceTestRuns is an integer and try again.");
				}

			}
			catch (Exception e)
			{
				Console.WriteLine(e);
			}
		}
    }
}

