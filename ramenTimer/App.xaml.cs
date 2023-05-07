namespace ramenTimer;

public partial class App : Application
{
	public App(TimerPage timerPage)
	{
		InitializeComponent();

		MainPage = timerPage;
	}
}

