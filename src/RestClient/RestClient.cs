using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Rest.Client
{
	public class RestClient
	{
		private readonly HttpClient client = new HttpClient();

		public string BasePath { get; }

		public RestClient(string basePath)
		{
			this.BasePath = basePath;
		}

		public async Task<ApiResponse<T>> PostAsync<T>(Uri uri, object body, Dictionary<string,string> headers = null)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, uri);
			AddHeadersToRequest(headers, request);

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return await SendAsync<T>(request, body);
		}

		public async Task<ApiResponse<T>> PutAsync<T>(Uri uri, object body, Dictionary<string, string> headers = null)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, uri);
			AddHeadersToRequest(headers, request);

			client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
			return await SendAsync<T>(request, body);
		}

		public async Task<ApiResponse<T>> GetAsync<T>(Uri uri, Dictionary<string, string> headers = null)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, uri);
			AddHeadersToRequest(headers, request);

			return await SendAsync<T>(request);
		}

		public async Task<ApiResponse<T>> DeleteAsync<T>(Uri uri, Dictionary<string, string> headers = null)
		{
			HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, uri);
			AddHeadersToRequest(headers, request);

			return await SendAsync<T>(request);
		}

		public async Task<ApiResponse<T>> SendAsync<T>(HttpRequestMessage request, object body = null)
		{
			if(request==null)
			{
				throw new ArgumentNullException(request.ToString(), "HttpRequestMessage was not set ot null");
			}

			if (body != null)
			{
                Console.WriteLine(JsonConvert.SerializeObject(body));
				request.Content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
			}

			HttpResponseMessage response = client.SendAsync(request).Result;
			ApiResponse<T> apiResponse = new ApiResponse<T>(response);

			if (apiResponse.IsSuccessStatusCode)
			{
				string result = await response.Content.ReadAsStringAsync();

				if (result != null)
				{
					apiResponse.Data = JsonConvert.DeserializeObject<T>(result);
				}
			}

			return apiResponse;
		}

		private void AddHeadersToRequest(Dictionary<string,string> headers, HttpRequestMessage request)
		{
			if (headers != null)
			{
				foreach (var header in headers)
				{
					if(request.Headers.Contains(header.Key))
					{
						throw new ArgumentException("Key already exists in the headers dictionary");
					}

					request.Headers.Add(header.Key, header.Value);
				}
			}
		}
	}
}


