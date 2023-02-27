using System.Net.Http.Json;

namespace Infrastructure;

public abstract class ServiceBase1 : object
{
	public ServiceBase1
		(System.Net.Http.HttpClient http) : base()
	{
		Http = http;

		//JsonOptions =
		//	new System.Text.Json.JsonSerializerOptions
		//	{
		//		PropertyNameCaseInsensitive = true,
		//	};

		//Http.DefaultRequestHeaders
	}

	protected string? BaseUrl { get; set; }

	protected System.Net.Http.HttpClient Http { get; }

	//protected System.Text.Json.JsonSerializerOptions JsonOptions { get; set; }

	protected virtual async
		System.Threading.Tasks.Task<TResponse?>
		GetAsync<TResponse>(string url, string? query = null)
	{
		System.Net.Http.HttpResponseMessage? response = null;

		try
		{
			var requestUri =
				$"{BaseUrl}/{url}";

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
				catch (System.NotSupportedException)
				{
					System.Console.WriteLine
						(value: "The content type is not supported.");
				}
				// Invalid JSON
				catch (System.Text.Json.JsonException)
				{
					System.Console.WriteLine
						(value: "Invalid JSON.");
				}
			}
		}
		catch (System.Net.Http.HttpRequestException ex)
		{
			System.Console.WriteLine(value: ex.Message);
		}
		catch (System.Exception ex)
		{
			System.Console.WriteLine(value: ex.Message);
		}
		finally
		{
			//if (response != null)
			//{
			//	response.Dispose();
			//	//response = null;
			//}

			response?.Dispose();
		}

		return default;
	}
}
