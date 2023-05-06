namespace ramenTimer;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		PrgBar.Progress = count / 10f;
		if (count == 10)
		{
			count = 0;
		}
	}
}


