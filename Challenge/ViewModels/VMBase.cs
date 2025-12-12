using CommunityToolkit.Mvvm.ComponentModel;


namespace Challenge.ViewModels
{
    public partial class VMBase : ObservableObject
    {
        [ObservableProperty]
        bool isBusy;
        [ObservableProperty]
        string pageTitle;
    }
}
