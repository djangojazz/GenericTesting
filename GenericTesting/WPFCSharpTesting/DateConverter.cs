using System;
using System.Globalization;
using System.Windows.Data;

namespace WPFCSharpTesting
{
  class DateConverter : IValueConverter
  {
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      DateTime date = (DateTime)value;
      return date.ToString("d");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string strValue = value as string;
      DateTime resultDateTime;
      if(DateTime.TryParse(strValue, out resultDateTime))
      {
        return resultDateTime;
      }

      throw new Exception("Unable to convert string to date time");
    }
  }
}
