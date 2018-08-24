using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Rest.Client.Test
{
    public class GoogleApiClient: RestClient
	{
		const string key = "AIzaSyBw31z_l0DawrgxcU0Ly7x4wBnMCRUYq2g";
		string url = $"https://www.googleapis.com/customsearch/v1?key=INSERT_YOUR_API_KEY&cx=017576662512468239146:omuauf_lfve&q=lectures";

		public GoogleApiClient(string basePath):base(basePath)
		{
		}

		public async Task<ApiResponse<Queries>> SearchAsync(string q, Dictionary<string,string> headers=null)
		{
			Uri uri = new Uri($"{BasePath}?key={key}&cx=017576662512468239146:omuauf_lfve&q={q}");
			ApiResponse<Queries> response = await GetAsync<Queries>(uri,headers);

			return response;
		}
	}
}
