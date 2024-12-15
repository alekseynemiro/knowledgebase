using System.Windows.Input;

namespace MAUIViewModelDisposable.ViewModels
{
  public interface IMainPageViewModel
  {
    int Counter { get; }
    string Text { get; }
    ICommand IncreaseCounterCommand { get; }
    ICommand OpenSecondPageCommand { get; }
  }
}
