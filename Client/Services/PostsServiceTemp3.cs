namespace Services;

public class PostsServiceTemp3 : Infrastructure.ServiceBase1
{
	public PostsServiceTemp3
		(System.Net.Http.HttpClient http) : base(http: http)
	{
		BaseUrl =
			"https://jsonplaceholder.typicode.com";
	}

	public
		async
		System.Threading.Tasks.Task
		<System.Collections.Generic.IList<ViewModels.PostViewModel>?>
		GetAsync()
	{
		var url = "posts";

		var result =
			await
			GetAsync<System.Collections.Generic.IList<ViewModels.PostViewModel>>(url: url);

		return result;
	}
}
