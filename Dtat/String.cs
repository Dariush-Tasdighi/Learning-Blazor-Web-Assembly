namespace Dtat;

public static class String : object
{
	static String()
	{
	}

	//public static string? Fix(string? text)
	//{
	//	if (string.IsNullOrWhiteSpace(value: text))
	//	{
	//		return null;
	//	}

	//	text =
	//		text.Trim();

	//	while (text.Contains("  "))
	//	{
	//		text = text.Replace
	//			(oldValue: "  ", newValue: " ");
	//	}

	//	return text;
	//}


	public static string? Fix(this string? text)
	{
		if (string.IsNullOrWhiteSpace(value: text))
		{
			return null;
		}

		text =
			text.Trim();

		while (text.Contains("  "))
		{
			text = text.Replace
				(oldValue: "  ", newValue: " ");
		}

		return text;
	}
}
