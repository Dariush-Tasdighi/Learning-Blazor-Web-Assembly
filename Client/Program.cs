using Microsoft.Extensions.DependencyInjection;

var builder =
	Microsoft.AspNetCore.Components.WebAssembly
	.Hosting.WebAssemblyHostBuilder.CreateDefault(args: args);

builder.RootComponents.Add<Client.App>(selector: "#app");

builder.RootComponents.Add
	<Microsoft.AspNetCore.Components.Web.HeadOutlet>(selector: "head::after");

// using Microsoft.Extensions.DependencyInjection;
builder.Services.AddScoped
	(current =>
	{
		var httpClient =
			new System.Net.Http.HttpClient
			{
				BaseAddress =
					new System.Uri(builder.HostEnvironment.BaseAddress),
			};

		return httpClient;
	});

await builder.Build().RunAsync();
