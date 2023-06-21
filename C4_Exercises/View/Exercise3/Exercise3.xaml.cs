using C4_Exercises.View.Exercise3;

namespace C4_Exercises.View.Exercse3;

public partial class Exercise3 : ContentPage
{
	public Exercise3()
	{
		InitializeComponent();
	}

    private async void PlayButton_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new RegistrationPage());
    }
}