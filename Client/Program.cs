using System;
using Services;
using System.Net.Http;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder =
	WebAssemblyHostBuilder.CreateDefault(args: args);

builder.RootComponents.Add
	<Client.App>(selector: "#app");

builder.RootComponents.Add
	<HeadOutlet>(selector: "head::after");

//builder.Services.AddScoped<HttpClient>();

//builder.Services.AddScoped
//	(serviceType: typeof(HttpClient));

//builder.Services.AddScoped
//	(implementationFactory: current =>
//	new HttpClient
//	{
//		BaseAddress =
//			new Uri(uriString: builder.HostEnvironment.BaseAddress),
//	});

builder.Services.AddScoped
	(implementationFactory: current =>
	{
		var httpClient =
			new HttpClient
			{
				BaseAddress =
					new Uri(uriString: builder.HostEnvironment.BaseAddress),
			};

		return httpClient;
	});

//builder.Services.AddScoped(serviceType: typeof(PostsServiceTemp1));
//builder.Services.AddTransient(serviceType: typeof(PostsServiceTemp1));
//builder.Services.AddSingleton(serviceType: typeof(PostsServiceTemp1));

builder.Services.AddScoped<PostsServiceTemp1>();
builder.Services.AddScoped<PostsServiceTemp2>();
builder.Services.AddScoped<PostsServiceTemp3>();

// نکته مهم
// دستورات فوق کار نمی‌کنند، مگر آن‌که
// HttpClient
// به صورت
// AddScoped
// ثبت شده باشد

builder.Services.AddScoped<PostsService>();
builder.Services.AddSingleton<LogsService>();
builder.Services.AddScoped<ApplicationSettingsService>();

await builder.Build().RunAsync();
