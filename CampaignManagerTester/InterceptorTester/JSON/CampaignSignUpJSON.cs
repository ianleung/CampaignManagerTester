using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignSignUpJSON
	{


        //TODO: Figure out what the givens are for this
		public CampaignSignUpJSON(string Slug)
		{
            this.slug = Slug;
            this.fields = new object[1];
            string email = "myEmail@webnet.org";
            fields[0] = email;
		}

		public string slug;
		public object[] fields;


		public override string ToString()
		{
            return slug + "   " + fields[0].ToString();
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

	public class SignUpJSON
	{
		public SignUpJSON(string Email, string Slug)
		{
			this.email = Email;
			this.slug = Slug;
		}

		public string email;
		public string slug;
	}

}



