using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignJSON
	{

		public CampaignJSON(string Name, string desc, string OrgID, string sDate, string eDate)
		{
			name = Name;
			description = desc;
			orgId = OrgID;
			startDate = sDate;
			endDate = eDate;
		}

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


