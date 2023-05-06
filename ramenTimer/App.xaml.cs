namespace ramenTimer;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new TimerPage();
	}
}

