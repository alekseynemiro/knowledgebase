using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace MAUIViewModelDisposable.ViewModels
{
  public class SecondPageViewModel : ViewModelBase, ISecondPageViewModel, IDisposable
  {
    private readonly ILogger<ISecondPageViewModel> _logger;

    private int _counter = 0;

    public int Counter
    {
      get
      {
        return _counter;
      }
      private set
      {
        _counter = value;
        OnProprtyChanged();
        OnProprtyChanged(nameof(Text));
      }
    }

    public string Text
    {
      get
      {
        if (Counter == 1)
        {
          return $"Clicked {Counter} time";
        }
        else if (Counter > 1)
        {
          return $"Clicked {Counter} times";
        }
        else
        {
          return "Click me";
        }
      }
    }

    public ICommand IncreaseCounterCommand { get; init; }

    public SecondPageViewModel(ILogger<ISecondPageViewModel> logger)
    {
      _logger = logger;

      IncreaseCounterCommand = new Command(() =>
      {
        ++Counter;
      });
    }

    public void Dispose()
    {
      _logger.LogInformation(nameof(SecondPageViewModel) + "." + nameof(Dispose));
    }
  }
}
