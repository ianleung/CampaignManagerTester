using System.Runtime.Serialization;
using System.Collections.Generic;

namespace ConsoleApplication1
{

	public class CampaignSignUpJSON
	{


        //TODO: Figure out what the givens are for this
		public CampaignSignUpJSON(string Slug)
		{
            //this.message = new MessageJSON(Slug, "george@costanza.com");
            this.slug = Slug;
            List<KVPJSON> kvpl = new List<KVPJSON>();
            kvpl.Add(new KVPJSON("george@costanza.com"));
            this.fields = kvpl;
		}

        public List<KVPJSON> fields;
        public string slug;


		public override string ToString()
		{
            return "";
		}
	}

    public class MessageJSON
    {
        public MessageJSON(string slug, string email)
        {
            this.slug = slug;
            List<KVPJSON> kvpl = new List<KVPJSON>();
            kvpl.Add(new KVPJSON(email));
            this.fields = kvpl;
        }
        public string slug;
        public List<KVPJSON> fields;
    }

    public class KVPJSON
    {
        public KVPJSON(string s)
        {
            this.key = "email";
            this.value = s;
        }
        public string key;
        public string value;
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

        public string ToString()
        {
            return "Email: " + email + "   Slug: " + slug;
        }
	}

}



