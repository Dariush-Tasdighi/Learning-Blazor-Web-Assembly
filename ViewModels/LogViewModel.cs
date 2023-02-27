namespace ViewModels;

public class LogViewModel : object
{
	public LogViewModel(string message) : base()
	{
		Message = message;

		Timestamp =
			System.DateTime.Now;
	}

	//public bool IsSeen { get; private set; }

	public string Message { get; private init; }

	//public string ClassName { get; private init; }

	//public string MethodName { get; private init; }

	//public string NamespaceName { get; private init; }

	//public Enums.LogLevel Level { get; private init; }

	public System.DateTime Timestamp { get; private init; }

	//public void Seen()
	//{
	//	IsSeen = true;
	//}
}
