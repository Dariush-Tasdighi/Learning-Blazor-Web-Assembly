using Microsoft.Extensions.DependencyInjection;

var builder =
	Microsoft.AspNetCore.Components.WebAssembly
	.Hosting.WebAssemblyHostBuilder.CreateDefault(args: args);

builder.RootComponents.Add
	<Client.App>(selector: "#app");

//builder.Services.AddScoped
//	<System.Net.Http.HttpClient>();

//builder.Services.AddScoped
//	(serviceType: typeof(System.Net.Http.HttpClient));

//builder.Services.AddScoped
//	(implementationFactory: current =>
//	new System.Net.Http.HttpClient
//	{
//		BaseAddress = new System.Uri
//			(uriString: builder.HostEnvironment.BaseAddress),
//	});

builder.RootComponents.Add
	<Microsoft.AspNetCore.Components.Web.HeadOutlet>(selector: "head::after");

// using Microsoft.Extensions.DependencyInjection;
builder.Services.AddScoped
	(implementationFactory: current =>
	{
		var httpClient =
			new System.Net.Http.HttpClient
			{
				BaseAddress = new System.Uri
					(uriString: builder.HostEnvironment.BaseAddress),
			};

		return httpClient;
	});

//builder.Services.AddScoped(serviceType: typeof(Services.PostsServiceTemp1));
//builder.Services.AddTransient(serviceType: typeof(Services.PostsServiceTemp1));
//builder.Services.AddSingleton(serviceType: typeof(Services.PostsServiceTemp1));

builder.Services.AddScoped<Services.PostsServiceTemp1>();
builder.Services.AddScoped<Services.PostsServiceTemp2>();
builder.Services.AddScoped<Services.PostsServiceTemp3>();

// نکته مهم
// دستورات فوق کار نمی‌کنند، مگر آن‌که
// HttpClient
// به صورت
// AddScoped
// ثبت شده باشد

builder.Services.AddSingleton<Services.LogsService>();
builder.Services.AddScoped<Services.PostsService>();

builder.Services.AddScoped
	<Services.ApplicationSettingsService>();

await builder.Build().RunAsync();
