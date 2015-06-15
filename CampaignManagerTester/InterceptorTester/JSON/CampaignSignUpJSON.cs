using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignSignUpJSON
	{

		public CampaignSignUpJSON(string Slug)
		{
			this.slug = Slug;
		}

		public string slug;
		public object[] fields;


		public override string ToString()
		{
			return "";
		}
	}

	public class CampaignSignUpFieldsJSON
	{
		public CampaignSignUpFieldsJSON(string Key, string Val)
		{
			this.key = Key;
			this.value = Val;
		}

		public string key;
		public string value;

		public override string ToString ()
		{
			return "";
		}
	}

}



