using System;
using System.Globalization;
using System.Windows.Data;

namespace KR2_StudentList
{
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = value as string ?? "";

            var result = ValidateName(param);

            if (result == false) return null;

            return param; ;
        }

        public static bool ValidateName(string name)
        {
            return ContainsDigits(name);
        }

        public static bool ContainsDigits(string str)
        {
            foreach (char c in str)
            {
                if (c >= '0' && c <= '9')
                    return false;
            }

            return true;
        }
    }
}