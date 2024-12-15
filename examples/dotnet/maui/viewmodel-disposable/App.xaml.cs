namespace MAUIViewModelDisposable
{
  public partial class App : Application
  {
    public App()
    {
      InitializeComponent();

      MainPage = new AppShell();
    }
  }
}
