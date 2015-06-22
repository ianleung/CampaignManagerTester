using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class OfferJSON
	{
		public OfferJSON(string Name, string OrgId, string PosOfferCode, string Terms)
		{
			this.name = Name;
			this.posOfferCode = PosOfferCode;
			this.orgId = OrgId;
			this.termsAndConditions = Terms;
		}

		public string name;
		public string orgId;
		public string posOfferCode;
		public string termsAndConditions;

	}
}