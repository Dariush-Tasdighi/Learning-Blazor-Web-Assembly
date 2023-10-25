using Microsoft.JSInterop;

namespace Dtat.Razor.Lazy;

public class ExampleJsInterop : object, System.IAsyncDisposable
{
	public ExampleJsInterop(Microsoft.JSInterop.IJSRuntime jsRuntime) : base()
	{
		ModuleTask =
			new(() => jsRuntime.InvokeAsync<Microsoft.JSInterop.IJSObjectReference>
			(identifier: "import", args: "./_content/Dtat.Razor.Lazy/exampleJsInterop.js")
			.AsTask());
	}

	private System.Lazy<System.Threading.Tasks.Task
		<Microsoft.JSInterop.IJSObjectReference>> ModuleTask { get; }

	public async System.Threading.Tasks.ValueTask<string> Prompt(string message)
	{
		var module = await ModuleTask.Value;

		var result =
			await
			module.InvokeAsync<string>
			(identifier: "showPrompt", args: message);

		return result;
	}

	public async System.Threading.Tasks.ValueTask DisposeAsync()
	{
		if (ModuleTask.IsValueCreated)
		{
			var module =
				await ModuleTask.Value;

			await module.DisposeAsync();
		}
	}
}
