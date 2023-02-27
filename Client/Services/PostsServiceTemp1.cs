//namespace Client.Services;
namespace Services;

public class PostsServiceTemp1 : object
{
	public PostsServiceTemp1() : base()
	{
	}

	public async System.Threading.Tasks.Task
		<System.Collections.Generic.IList<ViewModels.PostViewModel>?> GetAsync()
	{
		System.Collections.Generic.List<ViewModels.PostViewModel>? result = null;

		await System.Threading.Tasks.Task.Run(() =>
		{
			result =
				new System.Collections.Generic
				.List<ViewModels.PostViewModel>();

			for (var index = 1; index <= 10; index++)
			{
				var post =
					new ViewModels.PostViewModel
					{
						Id = index,
						Body = $"Body {index}",
						Title = $"Title {index}",
					};

				result.Add(item: post);
			}
		});

		return result;
	}
}
