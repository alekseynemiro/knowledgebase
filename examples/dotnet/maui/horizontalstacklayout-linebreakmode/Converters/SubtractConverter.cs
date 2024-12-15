using System.Globalization;

namespace MauiHorizontalStackLayoutLineBreakMode.Converters;

internal class SubtractConverter : IValueConverter
{
  public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
  {
    var valueInt = System.Convert.ToInt32(value, CultureInfo.InvariantCulture);
    var parameterInt = System.Convert.ToInt32(parameter, CultureInfo.InvariantCulture);
    var result = valueInt - parameterInt;

    return result;
  }

  public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
