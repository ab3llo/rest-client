using System;
using System.Text;

namespace Rest.Client
{
	public class Credentials
	{
		public string Username { get; private set; }

		public string Password { get; private set; }

		public Credentials(string username, string password)
		{
			this.Username = username;
			this.Password = password;
		}

		public string GenerateBasicAuthToken()
		{
			string basicAuthToken = string.Empty;

			if(Username != null && Password != null)
			{
				byte[] toBeEncoded = Encoding.UTF8.GetBytes($"{Username}:{Password}");
				basicAuthToken = Convert.ToBase64String(toBeEncoded);
			}

			return $"Basic {basicAuthToken}";
		}
	}
}
