




using C4_Exercises.View.Exercise4;

namespace C4_Exercises;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();
		MainPage = new NavigationPage(new Exercise4());
	}
}
