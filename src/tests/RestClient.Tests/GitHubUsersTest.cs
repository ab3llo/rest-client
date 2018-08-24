using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Rest.Client.Test
{
    public class GitHubUsersTest
	{
		const string basePath = "https://api.github.com";

		[Fact]
		public async Task GetUsersTestAsync()
		{
			GithubApiClient api = new GithubApiClient(basePath);
			Dictionary<string, string> headers = new Dictionary<string, string>
			{
				{ "User-Agent", "Chrome" }
			};

			ApiResponse<List<GitHubModel>> response = await api.GetUsers(headers);

			Assert.True(response.IsSuccessStatusCode);
			Assert.NotNull(response.Data);
		}
	}
}
