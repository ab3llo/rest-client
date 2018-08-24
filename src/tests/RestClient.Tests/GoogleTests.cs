using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Rest.Client;
using Rest.Client.Test;
using Xunit;

namespace Rest.Client.Test
{
	public class GoogleTests
	{

		[Fact]
		public async Task GoogleAsync()
		{
			GoogleApiClient api = new GoogleApiClient("https://www.googleapis.com/customsearch/v1");
			ApiResponse<Queries> response = await api.SearchAsync("hello");

			Assert.True(response.IsSuccessStatusCode);
			Assert.NotNull(response.Data);
		}
	}
}
