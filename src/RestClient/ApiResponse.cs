using System;
using System.Net;
using System.Net.Http;

namespace Rest.Client
{
	public class ApiResponse<T>
	{
		public static ApiResponse<T> None { get; } = new ApiResponse<T>(new HttpResponseMessage(), null);

		public HttpResponseMessage HttpResponse {get; private set;}

		public HttpStatusCode Status => this.HttpResponse.StatusCode;

		public bool IsSuccessStatusCode => this.HttpResponse.IsSuccessStatusCode;

		public string Authentication => this.HttpResponse.RequestMessage.Headers.Authorization?.Parameter;

		public T Data { get; set; }


		public ApiResponse(HttpResponseMessage httpResponseMessage, object o)
		{
			this.HttpResponse = httpResponseMessage;
			this.Data = (T) o;
		}

		public ApiResponse(HttpResponseMessage response)
		{
			this.HttpResponse = response ?? throw new ArgumentNullException(nameof(response));
		}
	}
}