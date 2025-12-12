using Challenge.ViewModels;

namespace Challenge;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(DetailsPageViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}