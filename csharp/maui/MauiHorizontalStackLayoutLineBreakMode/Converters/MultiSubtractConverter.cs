using System.Globalization;

namespace MauiHorizontalStackLayoutLineBreakMode.Converters;

internal class MultiSubtractConverter : IMultiValueConverter
{
  public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
  {
    return System.Convert.ToInt32(values[0], CultureInfo.InvariantCulture)
      - values.Skip(1).Sum(x => System.Convert.ToInt32(x, CultureInfo.InvariantCulture));
  }

  public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
  {
    throw new NotImplementedException();
  }
}
