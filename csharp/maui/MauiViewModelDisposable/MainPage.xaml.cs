using MAUIViewModelDisposable.ViewModels;

namespace MAUIViewModelDisposable
{
  public partial class MainPage : ContentPage
  {
    public MainPage(IMainPageViewModel model)
    {
      BindingContext = model;
      InitializeComponent();
    }
  }
}
