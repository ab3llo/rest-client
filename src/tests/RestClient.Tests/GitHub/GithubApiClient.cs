using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rest.Client;

namespace Rest.Client.Test
{
	public class GithubApiClient : RestClient
	{

		public GithubApiClient(string basePath):base(basePath)
		{
		}

		public async Task<ApiResponse<List<GitHubModel>>> GetUsers(Dictionary<string, string> headers = null, string queryParameters = null)
		{
			Uri uri = new Uri($"{BasePath}/users/ab3llo/repos{queryParameters}");
			var response = await GetAsync<List<GitHubModel>>(uri, headers);
			return response;
		}
	}
}
