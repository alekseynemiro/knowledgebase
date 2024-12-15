using MAUIViewModelDisposable.ViewModels;

namespace MAUIViewModelDisposable
{
  public partial class SecondPage : ContentPage
  {
    public SecondPage(ISecondPageViewModel model)
    {
      BindingContext = model;
      InitializeComponent();
    }
  }
}
