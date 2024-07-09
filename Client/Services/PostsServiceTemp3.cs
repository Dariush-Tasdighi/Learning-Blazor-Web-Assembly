using Infrastructure;
using System.Collections.Generic;
using ViewModels;

namespace Services;

public class PostsServiceTemp3 : ServiceBase1
{
	public PostsServiceTemp3
		(System.Net.Http.HttpClient http) : base(http: http)
	{
		BaseUrl =
			"https://jsonplaceholder.typicode.com";
	}

	public async System.Threading.Tasks.Task
		<System.Collections.Generic.IList<ViewModels.PostViewModel>?> GetAsync()
	{
		var url = "posts";
		//var query = "isActive=1&page_index=5";

		var result =
			await
			GetAsync<IList<PostViewModel>>(url: url);

		return result;
	}
}
