namespace ViewModels;

public class PersonViewModel : object
{
	public PersonViewModel() : base()
	{
	}

	public int Age { get; set; }

	public string? FirstName { get; set; }

	public string? LastName { get; set; }

	public string? Description { get; set; }
}
