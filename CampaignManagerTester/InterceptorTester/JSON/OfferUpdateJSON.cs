using System.Runtime.Serialization;

namespace ConsoleApplication1
{
	public class OfferUpdateJSON
	{
		public OfferUpdateJSON(string Description, string Name, string OfferId, string OrgId, string PosOfferCode, string Terms, bool Ed)
		{
			this.description = Description;
			this.name = Name;
			this.id = OfferId;
			this.posOfferCode = PosOfferCode;
			this.orgId = OrgId;
			this.termsAndConditions = Terms;
			this.editable = Ed;
		}

		public string description;
		public string name;
		public string id;
		public string orgId;
		public string posOfferCode;
		public string termsAndConditions;
		public bool editable;

	}
}

