namespace ViewModels;

public class LogViewModel : object
{
	public LogViewModel(string message) : base()
	{
		Message = message;

		Timestamp =
			System.DateTime.Now;
	}

	//public bool IsSeen { get; }

	public string Message { get; }

	//public string ClassName { get; }

	//public string MethodName { get; }

	//public string NamespaceName { get; }

	//public Enums.LogLevel Level { get; }

	public System.DateTime Timestamp { get; }

	//public void Seen()
	//{
	//	IsSeen = true;
	//}
}
