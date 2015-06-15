using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class OfferJSON
	{
		public OfferJSON(string ID, string Name, string Desc, string PosOfferCode, int OrgId, string Terms)
		{
			this.id = ID;
			this.name = Name;
			this.description = Desc;
			this.posOfferCode = PosOfferCode;
			this.orgId = OrgId;
			this.termsAndConditions = Terms;
		}

		public string id;
		public string name;
		public string description;
		public string posOfferCode;
		public int orgId;
		public string termsAndConditions;

		public bool editable;

	}
}