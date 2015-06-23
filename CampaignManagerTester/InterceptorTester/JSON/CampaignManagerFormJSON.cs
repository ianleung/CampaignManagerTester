using System.Runtime.Serialization;
using System;

namespace ConsoleApplication1
{

	public class CampaignManagerFormJSON
	{

		public CampaignManagerFormJSON(string OrgId, string Slug, string CamName, string CamDesc, string OfferId, string ConsentTxt)
		{
			this.orgId = OrgId;
			this.slug = Slug;
			this.campaignName = CamName;
			this.campaignDescription = CamDesc;
			this.offerId = OfferId;
			this.consentText = ConsentTxt;
            this.fields = new object[4];
            string name = "email";
            fields[0] = name;
            string description = "Email";
            fields[1] = description;
            string type = "email";
            fields[2] = type;
            bool required = true;
            fields[3] = required;
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
			return "orgId: " + orgId + "\n" + "slug: " + slug + "\n" + "campaignName: " + campaignName + "\n" +
            "campaignDescription: " + campaignDescription + "\n" + "offerId: " + offerId + "\n" + 
            "consentText: " + consentText + "\n" + "fields: " + fields.ToString() + "\n";
		}
	}

	public class CampaignManagerFormFieldsJSON
	{
		public CampaignManagerFormFieldsJSON(string Name, bool Required)
		{
            this.name = Name.ToString();
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

