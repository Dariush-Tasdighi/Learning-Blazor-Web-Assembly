// **************************************************
//namespace ViewModels
//{
//	public class TodoItemViewModel
//	{
//		public bool IsDone { get; set; }

//		public string Title { get; set; }
//	}
//}
// **************************************************

// **************************************************
//namespace ViewModels
//{
//	public class TodoItemViewModel
//	{
//		public bool IsDone { get; set; }

//		public string? Title { get; set; }
//	}
//}
// **************************************************

// **************************************************
//namespace ViewModels
//{
//	public class TodoItemViewModel
//	{
//		public TodoItemViewModel(string title)
//		{
//			Title = title;
//		}

//		public bool IsDone { get; set; }

//		public string Title { get; set; }
//	}
//}
// **************************************************

// **************************************************
//namespace ViewModels
//{
//	public class TodoItemViewModel(string title) : object
//	{
//		public bool IsDone { get; set; }

//		public string Title { get; set; } = title;
//	}
//}
// **************************************************

// **************************************************
//namespace ViewModels;

//public class TodoItemViewModel : object
//{
//	public TodoItemViewModel() : base()
//	{
//	}

//	public bool IsDone { get; set; }

//	public string? Title { get; set; }
//}
// **************************************************

namespace ViewModels;

/// <summary>
/// کلاس اقلام انجام کار
/// </summary>
public class TodoItemViewModel : object
{
	#region Constructor
	/// <summary>
	/// سازنده کلاس
	/// </summary>
	public TodoItemViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region public bool IsDone { get; set; }
	/// <summary>
	/// انجام شده
	/// </summary>
	public bool IsDone { get; set; }
	#endregion /public bool IsDone { get; set; }

	#region public string? Title { get; set; }
	/// <summary>
	/// عنوان
	/// </summary>
	public string? Title { get; set; }
	#endregion /public string? Title { get; set; }

	#endregion /Properties

	#region Methods
	#endregion /Methods
}
