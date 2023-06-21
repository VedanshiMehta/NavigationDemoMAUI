using C4_Exercises.ViewModel;

namespace C4_Exercises.View.Exercise7;

public partial class FeedbackForm : ContentPage
{
	private FeedbackViewModel _feedbackViewModel;
	public FeedbackForm(Model.FeedbackModel _feedbackModel)
	{
		InitializeComponent();
        NavigationPage.SetHasNavigationBar(this, false);
		_feedbackViewModel = (FeedbackViewModel) BindingContext;
		_feedbackViewModel.TextColor = _feedbackModel.TextColor;
		_feedbackViewModel.FeedbackImage = _feedbackModel.FeedbackImage;
		_feedbackViewModel.Rating = _feedbackModel.Rating;	


    }
}