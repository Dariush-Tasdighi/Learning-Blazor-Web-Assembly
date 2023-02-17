namespace ViewModels;

public class BasketItemViewModel : object
{
	#region Constructor
	public BasketItemViewModel() : base()
	{
	}
	#endregion /Constructor

	#region Properties

	#region public int ProductPrice { get; set; }
	/// <summary>
	/// قیمت محصول
	/// </summary>
	public int ProductPrice { get; set; }
	#endregion /public int ProductPrice { get; set; }

	#region public int ProductCount { get; set; }
	/// <summary>
	/// تعداد محصول
	/// </summary>
	public int ProductCount { get; set; }
	#endregion /public int ProductCount { get; set; }

	#region public string? ProductName { get; set; }
	/// <summary>
	/// نام محصول
	/// </summary>
	public string? ProductName { get; set; }
	#endregion /public string? ProductName { get; set; }

	#endregion /Properties

	#region Methods

	#region Plus()
	public void Plus()
	{
		if (ProductCount < 10)
		{
			ProductCount++;
		}
	}
	#endregion /Plus()

	#region Minus()
	public void Minus()
	{
		if (ProductCount > 0)
		{
			ProductCount--;
		}
	}
	#endregion /Minus()

	#region GetSubTotal()
	public int GetSubTotal()
	{
		int result =
			ProductPrice * ProductCount;

		if (ProductCount > 5)
		{
			result =
				(int)((decimal)(result * 95) / 100);
		}

		return result;
	}
	#endregion /GetSubTotal()

	#endregion /Methods
}
