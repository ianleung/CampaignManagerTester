using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignJSON
	{

		public CampaignJSON(string ID, string Name, string desc, string OrgID, string sDate, string eDate)
		{
			id = ID;
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
			return "";
		}
	}

	public class CampaignSegmentsJSON
	{
		public CampaignSegmentsJSON(string Key, string Val)
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


