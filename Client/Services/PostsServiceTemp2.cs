using System.Net.Http;
using System.Net.Http.Json;

namespace Services;

public class PostsServiceTemp2 : object
{
    public PostsServiceTemp2(HttpClient http) : base()
    {
        Http = http;
        //_http = http;
    }

    private HttpClient Http { get; }
    //private readonly HttpClient _http;

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
