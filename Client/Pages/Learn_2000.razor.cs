//namespace Client.Pages
//{
//	public partial class Learn_2000
//	{
//	}
//}

namespace Client.Pages;

/// <summary>
/// Note: It Should be 'partial' Class!
/// Note: Do Should not inherit from anything even 'object' class!
/// </summary>
public partial class Learn_2000
{
	public Learn_2000() : base()
	{
		Message = "Hello, World!";
	}

	// Bad Practice
	//private string Message;

	// Bad Practice
	//private string _message;

	// Bad Practice
	//private string _message = "Hello, World!";

	// Bad Practice
	//public string Message { get; set; } = "Hello, World!";

	// Bad Practice
	//public string Message { get; set; }

	private string Message { get; set; }

	private void DoSomething()
	{
		Message =
			"I'm Dariush Tasdighi";
	}
}
