namespace ViewModels;

public class TodoItemViewModel : object
{
	#region Constructor
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
}
