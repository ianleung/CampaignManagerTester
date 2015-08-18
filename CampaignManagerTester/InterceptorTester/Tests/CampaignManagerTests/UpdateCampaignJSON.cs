using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class UpdateCampaignJSON
	{

		public UpdateCampaignJSON(string Id, string Name, string desc, string OrgID, string sDate, string eDate)
		{
			id = Id;
			name = Name;
			description = desc;
			orgId = OrgID;
			startDate = sDate;
			endDate = eDate;
		}

		public string id;
		public string name;
		public string description;
		public string orgId;
		public string startDate;
		public string endDate;
		public object[] segments;


		public override string ToString()
		{
			return "name: " + name + "\ndescription: " + description + "\norgId: " + orgId + "\nendDate: " + endDate + "\nsegments: " + segments.ToString();
		}
	}

	public class UpdateCampaignSegmentsJSON
	{
		public UpdateCampaignSegmentsJSON(string Key, string Val)
		{
			key = Key;
			value = Val;
		}

		public string key;
		public string value;

		public override string ToString ()
		{
			return "";
		}
	}

}


