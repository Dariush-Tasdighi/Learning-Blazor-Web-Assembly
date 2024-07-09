using System;
using Services;
using System.Net.Http;
using System.Text.Json;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Infrastructure;

public abstract class ServiceBase : object
{
	public ServiceBase
		(HttpClient http, LogsService logsService) : base()
	{
		Http = http;
		LogsService = logsService;
	}

	protected HttpClient Http { get; }

	protected string? BaseUrl { get; set; }

	protected LogsService LogsService { get; }

	protected virtual async Task<TResponse?>
		GetAsync<TResponse>(string url, string? query = null)
	{
		HttpResponseMessage? response = null;

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
					var result =
						await
						response.Content.ReadFromJsonAsync<TResponse>();

					return result;
				}

				// When content type is not valid
				catch (NotSupportedException ex)
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
				catch (JsonException ex)
				{
					var errorMessage =
						$"Exception: {ex.Message} - Invalid JSON.";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
			}
		}
		catch (HttpRequestException ex)
		{
			var errorMessage =
				$"Exception: {ex.Message}";

			LogsService.AddLog
				(type: GetType(), message: errorMessage);
		}
		finally
		{
			response?.Dispose();
		}

		return default;
	}

	protected virtual async Task<TResponse?>
		PostAsync<TRequest, TResponse>(string url, TRequest viewModel)
	{
		HttpResponseMessage? response = null;

		try
		{
			var requestUri =
				$"{BaseUrl}/{url}";

			response =
				await Http.PostAsJsonAsync
				(requestUri: requestUri, value: viewModel);

			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				try
				{
					// Solution (1) - Old
					//var data =
					//	await
					//	response.Content.ReadAsStringAsync();

					//var result =
					//	System.Text.Json.JsonSerializer
					//	.Deserialize<TResponse>(json: data);
					// /Solution (1) - Old

					// Solution (2)
					// New Solution
					//var result =
					//	await
					//	response.Content.ReadFromJsonAsync<TResponse>();
					// /Solution (2)

					// Solution (3)
					var jsonSerializerOptions =
						new JsonSerializerOptions
						{
							MaxDepth = 5,
						};

					var result =
						await
						response.Content.ReadFromJsonAsync
						<TResponse>(options: jsonSerializerOptions);
					// /Solution (3)

					return result;
				}
				// When content type is not valid
				catch (NotSupportedException)
				{
					var errorMessage =
						"The content type is not supported!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
				// Invalid JSON
				catch (JsonException)
				{
					var errorMessage = "Invalid JSON!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
			}
		}
		catch (HttpRequestException ex)
		{
			LogsService.AddLog
				(type: GetType(), message: ex.Message);
		}
		finally
		{
			response?.Dispose();
		}

		return default;
	}

	protected virtual async Task<TResponse?>
		PutAsync<TRequest, TResponse>(string url, TRequest viewModel)
	{
		HttpResponseMessage? response = null;

		try
		{
			var requestUri =
				$"{BaseUrl}/{url}";

			response =
				await Http.PutAsJsonAsync
				(requestUri: requestUri, value: viewModel);

			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				try
				{
					var result =
						await
						response.Content.ReadFromJsonAsync<TResponse>();

					return result;
				}
				// When content type is not valid
				catch (NotSupportedException)
				{
					var errorMessage =
						"The content type is not supported!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
				// Invalid JSON
				catch (JsonException)
				{
					var errorMessage = "Invalid JSON!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
			}
		}
		catch (HttpRequestException ex)
		{
			LogsService.AddLog
				(type: GetType(), message: ex.Message);
		}
		finally
		{
			response?.Dispose();
		}

		return default;
	}

	protected virtual async Task<TResponse?>
		DeleteAsync<TResponse>(string url, string? query = null)
	{
		HttpResponseMessage? response = null;

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
				await Http.DeleteAsync(requestUri: requestUri);

			response.EnsureSuccessStatusCode();

			if (response.IsSuccessStatusCode)
			{
				try
				{
					var result =
						await
						response.Content.ReadFromJsonAsync<TResponse>();

					return result;
				}
				// When content type is not valid
				catch (NotSupportedException)
				{
					var errorMessage =
						"The content type is not supported!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
				// Invalid JSON
				catch (JsonException)
				{
					var errorMessage = "Invalid JSON!";

					LogsService.AddLog
						(type: GetType(), message: errorMessage);
				}
			}
		}
		catch (HttpRequestException ex)
		{
			LogsService.AddLog
				(type: GetType(), message: ex.Message);
		}
		finally
		{
			response?.Dispose();
		}

		return default;
	}
}
