using C4_Exercises.Model;
using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise7;

public partial class Exercise7 : ContentPage
{
	private RateMeViewModel _rateMeViewModel;
	private FeedbackModel _feedbackModel;
	public Exercise7()
	{
		InitializeComponent();
		NavigationPage.SetHasNavigationBar(this, false );	
		_rateMeViewModel =(RateMeViewModel)BindingContext;	
		_feedbackModel = new FeedbackModel();
	}

    private void RateFood_ValueChanged(object sender, ValueChangedEventArgs e)
    {
		_rateMeViewModel.RateValue = e.NewValue;
		_rateMeViewModel.RateMe.Execute(this);
    }

    private async void Next_Clicked(object sender, EventArgs e)
    {
        _feedbackModel.FeedbackImage = _rateMeViewModel.Image;
        _feedbackModel.TextColor = _rateMeViewModel.Color;
		_feedbackModel.Rating = _rateMeViewModel.Rating;
		await Navigation.PushAsync(new FeedbackForm(_feedbackModel));

    }
}