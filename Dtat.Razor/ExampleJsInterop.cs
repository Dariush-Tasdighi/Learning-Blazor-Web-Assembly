using Microsoft.JSInterop; // For: InvokeAsync

namespace Dtat.Razor;

// This class provides an example of how JavaScript functionality can be
// wrapped in a .NET class for easy consumption. The associated JavaScript
// module is loaded on demand when first needed.
//
// This class can be registered as scoped DI service and then injected
// into Blazor components for use.

public class ExampleJsInterop : object, IAsyncDisposable
{
	public ExampleJsInterop(Microsoft.JSInterop.IJSRuntime jsRuntime) : base()
	{
		ModuleTask =
			new(() => jsRuntime.InvokeAsync<Microsoft.JSInterop.IJSObjectReference>
			(identifier: "import", args: "./_content/Dtat.Razor/exampleJsInterop.js")
			.AsTask());
	}

	private Lazy<Task<Microsoft.JSInterop.IJSObjectReference>> ModuleTask { get; }
	//private readonly Lazy<Task<Microsoft.JSInterop.IJSObjectReference>> moduleTask;

	public async ValueTask<string> Prompt(string message)
	{
		var module = await ModuleTask.Value;

		var result =
			await
			module.InvokeAsync<string>
			(identifier: "showPrompt", args: message);

		return result;
	}

	public async ValueTask DisposeAsync()
	{
		if (ModuleTask.IsValueCreated)
		{
			var module =
				await ModuleTask.Value;

			await module.DisposeAsync();
		}
	}
}
