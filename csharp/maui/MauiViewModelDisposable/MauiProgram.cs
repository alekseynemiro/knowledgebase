using MAUIViewModelDisposable.Extensions;
using MAUIViewModelDisposable.ViewModels;
using Microsoft.Extensions.Logging;

namespace MAUIViewModelDisposable
{
  public static class MauiProgram
  {
    public static MauiApp CreateMauiApp()
    {
      var builder = MauiApp.CreateBuilder();

      builder
        .UseMauiApp<App>()
        .ConfigureFonts(fonts =>
        {
          fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
          fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
        });

      builder.Logging.AddDebug();

      builder.Services.AddTransient<IMainPageViewModel, MainPageViewModel>();
      builder.Services.AddTransient<ISecondPageViewModel, SecondPageViewModel>();

      builder.Services.AddPage<MainPage>();
      builder.Services.AddPage<SecondPage>();

      return builder.Build();
    }
  }
}
