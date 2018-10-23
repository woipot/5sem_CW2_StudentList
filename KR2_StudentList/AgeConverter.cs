using System;
using System.Globalization;
using System.Windows.Data;

namespace KR2_StudentList
{
    public class AgeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var param = value as string ?? "";

            var result = ValidateAge(param);

            if (result == false) return null;

            return System.Convert.ToInt32(param); ;
        }

        public static bool ValidateAge(string age)
        {
            try
            {
                var ageInInt = System.Convert.ToInt32(age);

                if (ageInInt > 18) return false;
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }
    }
}