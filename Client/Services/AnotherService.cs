namespace Services;

public class AnotherService : object
{
	public AnotherService
		(ApplicationSettingsService applicationSettingsService) : base()
	{
		ApplicationSettingsService = applicationSettingsService;
	}

	protected ApplicationSettingsService ApplicationSettingsService { get; }

	public void DoSomething()
	{
		var baseUrl =
			ApplicationSettingsService.BaseUrl;

		var token =
			ApplicationSettingsService.Token;
	}
}
