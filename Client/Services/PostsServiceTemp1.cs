using ViewModels;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Services;
//namespace Client.Services;

public class PostsServiceTemp1 : object
{
	public PostsServiceTemp1() : base()
	{
	}

	public async Task<IList<PostViewModel>?> GetAsync()
	{
		List<PostViewModel>? result = null;

		await Task.Run(() =>
		{
			result = [];

			for (var index = 1; index <= 10; index++)
			{
				var post =
					new PostViewModel
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
