using System.Net.Http.Json;

namespace Infrastructure;

public abstract class ServiceBase : object
{
	public ServiceBase
		(System.Net.Http.HttpClient http, Services.LogsService logsService) : base()
	{
		Http = http;
		LogsService = logsService;
	}

	protected string? BaseUrl { get; set; }

	protected System.Net.Http.HttpClient Http { get; }

	protected Services.LogsService LogsService { get; }

	protected virtual
		async
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
					// ReadFromJsonAsync -> Extension Method -> using System.Net.Http.Json;
					TResponse? result =
						await
						response.Content.ReadFromJsonAsync<TResponse>();

					return result;
				}

				// When content type is not valid
				catch (System.NotSupportedException ex)
				{
					var errorMessage =
						$"Exception: {ex.Message} - The content type is not supported.";

					// Static داخل تابع غیر
					LogsService.AddLog
						(type: GetType(), message: errorMessage);

					// Static داخل تابع
					//LogsService.AddLog(type: typeof(ServiceBase), message: errorMessage);
				}

				// Invalid JSON
				catch (System.Text.Json.JsonException ex)
				{
					var errorMessage =
						$"Exception: {ex.Message} - Invalid JSON.";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
			}
		}
		catch (System.Net.Http.HttpRequestException ex)
		{
			string errorMessage =
				$"Exception: {ex.Message}";

			LogsService.AddLog
				(type: GetType(), message: errorMessage);
		}
		finally
		{
			//if(response != null)
			//{
			//	response.Dispose();
			//	//response = null;
			//}

			response?.Dispose();
		}

		return default;
	}

	//protected virtual
	//	async
	//	System.Threading.Tasks.Task<O>
	//	PostAsync<I, O>(I viewModel)
	//{
	//	System.Net.Http.HttpResponseMessage response = null;

	//	try
	//	{
	//		response =
	//			await Http.PostAsJsonAsync
	//			(requestUri: RequestUri, value: viewModel);

	//		response.EnsureSuccessStatusCode();

	//		if (response.IsSuccessStatusCode)
	//		{
	//			try
	//			{
	//				//System.Text.Json.JsonSerializerOptions jsonSerializerOptions =
	//				//	new System.Text.Json.JsonSerializerOptions
	//				//	{
	//				//		MaxDepth = 5,
	//				//	};

	//				//O result =
	//				//	await response.Content.ReadFromJsonAsync<O>(options: jsonSerializerOptions);



	//				// New Solution
	//				O result =
	//					await response.Content.ReadFromJsonAsync<O>();

	//				return result;
	//				// /New Solution

	//				// Old Solution
	//				//string data =
	//				//	await response.Content.ReadAsStringAsync();

	//				//O result =
	//				//	System.Text.Json.JsonSerializer.Deserialize<O>(data);
	//				// /Old Solution
	//			}
	//			// When content type is not valid
	//			catch (System.NotSupportedException)
	//			{
	//				System.Console.WriteLine("The content type is not supported.");
	//			}
	//			// Invalid JSON
	//			catch (System.Text.Json.JsonException)
	//			{
	//				System.Console.WriteLine("Invalid JSON.");
	//			}
	//		}
	//	}
	//	catch (System.Net.Http.HttpRequestException ex)
	//	{
	//		System.Console.WriteLine(ex.Message);
	//	}
	//	finally
	//	{
	//		response.Dispose();
	//		//response = null;
	//	}

	//	return default;
	//}

	//protected virtual
	//	async
	//	System.Threading.Tasks.Task<O>
	//	PutAsync<I, O>(I viewModel)
	//{
	//	System.Net.Http.HttpResponseMessage response = null;

	//	try
	//	{
	//		response =
	//			await Http.PutAsJsonAsync
	//			(requestUri: RequestUri, value: viewModel);

	//		response.EnsureSuccessStatusCode();

	//		if (response.IsSuccessStatusCode)
	//		{
	//			try
	//			{
	//				O result =
	//					await response.Content.ReadFromJsonAsync<O>();

	//				return result;
	//			}
	//			// When content type is not valid
	//			catch (System.NotSupportedException)
	//			{
	//				System.Console.WriteLine("The content type is not supported.");
	//			}
	//			// Invalid JSON
	//			catch (System.Text.Json.JsonException)
	//			{
	//				System.Console.WriteLine("Invalid JSON.");
	//			}
	//		}
	//	}
	//	catch (System.Net.Http.HttpRequestException ex)
	//	{
	//		System.Console.WriteLine(ex.Message);
	//	}
	//	finally
	//	{
	//		response.Dispose();
	//	}

	//	return default;
	//}

	//protected virtual
	//	async
	//	System.Threading.Tasks.Task<O>
	//	DeleteAsync<O>()
	//{
	//	System.Net.Http.HttpResponseMessage response = null;

	//	try
	//	{
	//		response =
	//			await Http.DeleteAsync(requestUri: RequestUri);

	//		response.EnsureSuccessStatusCode();

	//		if (response.IsSuccessStatusCode)
	//		{
	//			try
	//			{
	//				O result =
	//					await response.Content.ReadFromJsonAsync<O>();

	//				return result;
	//			}
	//			// When content type is not valid
	//			catch (System.NotSupportedException)
	//			{
	//				System.Console.WriteLine("The content type is not supported.");
	//			}
	//			// Invalid JSON
	//			catch (System.Text.Json.JsonException)
	//			{
	//				System.Console.WriteLine("Invalid JSON.");
	//			}
	//		}
	//	}
	//	catch (System.Net.Http.HttpRequestException ex)
	//	{
	//		System.Console.WriteLine(ex.Message);
	//	}
	//	finally
	//	{
	//		response.Dispose();
	//	}

	//	return default;
	//}
}
