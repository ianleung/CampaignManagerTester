using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignManagerFormJSON
	{

		public CampaignManagerFormJSON(int OrgId, string Slug, string CamName, string CamDesc, string OfferId, string ConsentTxt)
		{
			this.orgId = OrgId;
			this.slug = Slug;
			this.campaignName = CamName;
			this.campaignDescription = CamDesc;
			this.offerId = OfferId;
			this.consentText = ConsentTxt;
		}

		public int orgId;
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

