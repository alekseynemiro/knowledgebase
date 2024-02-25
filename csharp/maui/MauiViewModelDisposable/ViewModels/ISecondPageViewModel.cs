using System.Windows.Input;

namespace MAUIViewModelDisposable.ViewModels
{
  public interface ISecondPageViewModel
  {
    int Counter { get; }
    string Text { get; }
    ICommand IncreaseCounterCommand { get; }
  }
}
