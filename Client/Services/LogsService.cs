using Dtat;

namespace Services;

public class LogsService : object
{
	public LogsService() : base()
	{
		Logs = new System.Collections
			.Generic.List<ViewModels.LogViewModel>();
	}

	protected System.Collections.Generic.IList<ViewModels.LogViewModel> Logs { get; private init; }

	public int LogCount
	{
		get
		{
			return Logs.Count;
		}
	}

	public void AddLog(System.Type type, string? message)
	{
		if (string.IsNullOrWhiteSpace(value: message))
		{
			return;
		}

		// **************************************************
		var stackTrace =
			new System.Diagnostics.StackTrace();

		var methodBase =
			stackTrace.GetFrame(index: 1)?.GetMethod();
		// **************************************************

		message =
			$"{type.Namespace} -> {type.Name} -> {methodBase?.Name}: {message.Fix()}";

		var log = new ViewModels
			.LogViewModel(message: message);

		//Logs.Add(log);
		Logs.Insert
			(index: 0, item: log);
	}

	public System.Collections.Generic
		.IList<ViewModels.LogViewModel> GetLogs()
	{
		return Logs;
	}

	public void ClearLogs()
	{
		Logs.Clear();
	}
}
