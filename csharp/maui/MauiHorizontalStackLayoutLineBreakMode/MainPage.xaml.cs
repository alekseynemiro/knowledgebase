using System.ComponentModel;

namespace MauiHorizontalStackLayoutLineBreakMode;

public partial class MainPage : ContentPage
{
  public MainPage()
  {
    InitializeComponent();
  }

  protected void MaximumWidthRequest_PropertyChanged(object sender, PropertyChangedEventArgs e)
  {
#if ANDROID
    if (e.PropertyName.Equals(nameof(MaximumWidthRequest)))
    {
      Dispatcher.Dispatch(((IView)sender).InvalidateMeasure);
    }
#endif
  }
}
