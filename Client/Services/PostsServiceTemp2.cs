using System.Net.Http.Json;

namespace Services;

public class PostsServiceTemp2 : object
{
	public PostsServiceTemp2
		(System.Net.Http.HttpClient http) : base()
	{
		Http = http;
		//_http = http;
	}

	private System.Net.Http.HttpClient Http { get; }
	//private readonly System.Net.Http.HttpClient _http;

	public async System.Threading.Tasks.Task
		<System.Collections.Generic.IList<ViewModels.PostViewModel>?> GetAsync()
	{
		var requestUri =
			"https://jsonplaceholder.typicode.com/posts";

		// using System.Net.Http.Json;
		var result =
			await
			Http.GetFromJsonAsync
			<System.Collections.Generic
			.IList<ViewModels.PostViewModel>>(requestUri: requestUri);

		return result;
	}
}
