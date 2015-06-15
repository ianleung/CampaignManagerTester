﻿using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignManagerJSON
	{

		public CampaignManagerJSON(string OrgId, string Slug, string CamName, string CamDesc, string OfferId, string ConsentTxt)
		{
			this.orgId = OrgId;
			this.slug = Slug;
			this.campaignName = CamName;
			this.campaignDescription = CamDesc;
			this.offerId = OfferId;
			this.consentText = ConsentTxt;
		}

		public string orgId;
		public string slug;
		public string campaignName;
		public string campaignDescription;
		public string offerId;
		public string consentText;
		public object[] fields;


		public override string ToString()
		{
			return "";
		}
	}

	public class CampaignManagerFieldsJSON
	{
		public CampaignManagerFieldsJSON(int Name, bool Required)
		{
			this.name = Name;
			this.required = Required;
		}

		public string name;
		public bool required;

		public override string ToString ()
		{
			return "";
		}
	}

}

