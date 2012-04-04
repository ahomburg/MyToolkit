﻿using System;

#if !METRO
	using System.Windows.Data;
#else
	using Windows.UI.Xaml.Data;
	using Windows.Globalization.DateTimeFormatting;
#endif

namespace MyToolkit.Converters
{
	public class TimeSpanConverter : IValueConverter
	{
#if !METRO
		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#else
		public object Convert(object value, Type typeName, object parameter, string language)
#endif
		{
			if (value == null)
				return "";

			var span = (TimeSpan)value;
			var param = parameter != null ? parameter.ToString().ToLower() : null;
			if (param == "days")
				return Math.Round(span.TotalDays, 2).ToString();
			else
				return ((int)span.TotalHours).ToString("D2") + ":" + Math.Abs(span.Minutes).ToString("D2");
		}


#if !METRO
		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
#else
        public object ConvertBack(object value, Type typeName, object parameter, string language)
#endif
		{
			// TODO not tested
			var text = value.ToString();
			if (String.IsNullOrEmpty(text))
				return null; 
			return TimeSpan.Parse(text);
		}
    }
}
