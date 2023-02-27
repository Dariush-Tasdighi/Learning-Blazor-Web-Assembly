namespace ViewModels;

public class PostViewModel : object
{
	#region Constructor
	public PostViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region public int Id { get; set; }
	/// <summary>
	/// شناسه
	/// </summary>
	public int Id { get; set; }
	#endregion /public int Id { get; set; }

	#region public bool IsActive { get; set; }
	/// <summary>
	/// وضعیت
	/// </summary>
	public bool IsActive { get; set; }
	#endregion /public bool IsActive { get; set; }

	#region public string? Body { get; set; }
	/// <summary>
	/// متن مطلب
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required]
	public string? Body { get; set; }
	#endregion /public string? Body { get; set; }

	#region public string? Title { get; set; }
	/// <summary>
	/// عنوان مطلب
	/// </summary>
	[System.ComponentModel.DataAnnotations.Required]
	public string? Title { get; set; }
	#endregion /public string? Title { get; set; }

	#endregion /Properties
}
