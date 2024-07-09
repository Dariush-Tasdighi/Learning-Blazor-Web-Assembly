using System;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Infrastructure;

public abstract class ServiceBase1 : object
{
	public ServiceBase1(HttpClient http) : base()
	{
		Http = http;

		//JsonOptions =
		//	new JsonSerializerOptions
		//	{
		//		PropertyNameCaseInsensitive = true,
		//	};

		//Http.DefaultRequestHeaders
	}

	protected HttpClient Http { get; }

	protected string? BaseUrl { get; set; }

	//protected JsonSerializerOptions JsonOptions { get; set; }

	protected virtual async Task<TResponse?>
		GetAsync<TResponse>(string? url = null, string? query = null)
	{
		HttpResponseMessage? response = null;

		try
		{
			var requestUri = BaseUrl;

			if (string.IsNullOrWhiteSpace(value: url) == false)
			{
				requestUri = $"{requestUri}/{url}";
			}

			if (string.IsNullOrWhiteSpace(value: query) == false)
			{
				requestUri =
					$"{requestUri}?{query}";
			}

			response =
				await
				Http.GetAsync(requestUri: requestUri);

			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				try
				{
					// using System.Net.Http.Json;
					var result =
						await
						response.Content.ReadFromJsonAsync<TResponse>();

					return result;
				}
				// When content type is not valid
				catch (NotSupportedException)
				{
					Console.WriteLine(value: "The content type is not supported.");
				}
				// Invalid JSON
				catch (JsonException)
				{
					Console.WriteLine(value: "Invalid JSON.");
				}
			}
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine(value: ex.Message);
		}
		catch (Exception ex)
		{
			Console.WriteLine(value: ex.Message);
		}
		finally
		{
			//if (response != null)
			//{
			//	response.Dispose();
			//	//response = null;
			//}

			//if (response is not null)
			//{
			//	response.Dispose();
			//	//response = null;
			//}

			//response?.Dispose();
			//response = null;

			response?.Dispose();
		}

		return default;
	}
}
