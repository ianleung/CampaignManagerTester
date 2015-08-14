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
            this.fields = new CampaignManagerFormFieldsJSON[4];
		}

		public string orgId;
		public string slug;
		public string campaignName;
		public string campaignDescription;
		public string offerId;
		public string consentText;
		public CampaignManagerFormFieldsJSON[] fields;


		public override string ToString()
		{
            string ret = "";
            ret += "orgId: " + orgId + "\n" + "slug: " + slug + "\n" + "campaignName: " + campaignName + "\n" +
            "campaignDescription: " + campaignDescription + "\n" + "offerId: " + offerId + "\n" +
            "consentText: " + consentText + "\n";
            ret += "fields: " + this.fields[0].ToString() + "\n";
            ret += this.fields[1].ToString() + "\n";
            ret += this.fields[2].ToString() + "\n";
            return ret;
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
			return "Name: " + this.name + " required: " + required.ToString();
		}
	}

}

