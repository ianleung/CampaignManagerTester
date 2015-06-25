using System.Runtime.Serialization;

namespace ConsoleApplication1
{

	public class CampaignSignUpJSON
	{

		public CampaignSignUpJSON(string Slug)
		{
            this.slug = Slug;
            this.fields = new object[3];
            string email = "myEmail@webnet.org";
            fields[0] = email;
            string firstName = "myFirstName";
            fields[1] = firstName;
            string lastName = "lastName";
            fields[2] = lastName;
		}

		public string slug;
		public object[] fields;


		public override string ToString()
		{
            return slug + "   " + fields[0].ToString() + "   " + fields[1].ToString() + "   " + fields[2].ToString();
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



