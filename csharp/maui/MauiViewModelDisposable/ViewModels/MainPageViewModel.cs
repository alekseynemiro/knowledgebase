using Microsoft.Extensions.Logging;
using System.Windows.Input;

namespace MAUIViewModelDisposable.ViewModels
{
  public class MainPageViewModel : ViewModelBase, IMainPageViewModel, IDisposable
  {
    private readonly ILogger<IMainPageViewModel> _logger;

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

    public ICommand OpenSecondPageCommand { get; init; }

    public MainPageViewModel(IServiceProvider serviceProvider, ILogger<IMainPageViewModel> logger)
    {
      _logger = logger;

      IncreaseCounterCommand = new Command(() =>
      {
        ++Counter;
      });

      OpenSecondPageCommand = new Command(() =>
      {
        Application.Current.MainPage.Dispatcher.DispatchAsync(async () =>
        {
          var page = serviceProvider.GetRequiredService<SecondPage>();

          await Application.Current.MainPage.Navigation.PushAsync(page);
        });
      });
    }

    public void Dispose()
    {
      _logger.LogInformation(nameof(MainPageViewModel) + "." + nameof(Dispose));
    }
  }
}
