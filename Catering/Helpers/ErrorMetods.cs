using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Helpers
{
    public static class ErrorMetods
    {
        public static void InValidSpace(string header)
        {
            string message = header + " " + UIMessages.IsEmptyMessage;
            MessageBox.Show(message, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void InValidLength(string header, int maxSymbol)
        {
            string message = $"{header} {maxSymbol}-dan çox ola bilməz!";
            MessageBox.Show(message, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static void OperationIsTerminated()
        {
            MessageBox.Show("Əməliyyat tamamlanmadı", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public static bool PhoneValidationTest(string phoneNumber)
        {
            if (phoneNumber == null || !phoneNumber.StartsWith("+994"))
            {
                MessageBox.Show("Telefon nömrəsi '+994' simvolu ilə başlamalıdır!");
                return false;
            }
            if(phoneNumber.Length != 13)
            {
                MessageBox.Show("Telefon nömrəsi 13 simvoldan ibarət olmalıdır!");
                return false;
            }
            string prefix = phoneNumber.Substring(4, 2);
            if(prefix != "50" && prefix != "55" && prefix != "70" && prefix != "77" && prefix != "51" && prefix != "99")
            {
                MessageBox.Show("Prefiks düzgün daxil edilməyib!");
                return false;
            }
            string nums = phoneNumber.Substring(1);
            if (!long.TryParse(nums, out long a))
            {
                MessageBox.Show("Telefon nömrəsi yalnız rəqəmlərdən ibarət olmalıdır!");
                return false;
            }
            return true;
        }

        public static bool EmailValidationTest(string email)
        {
            if (email == null || !email.Contains('@'))
            {
                MessageBox.Show("Emaildə '@' işarəsi istifadə olunmalıdır!");
                return false;
            }
            string[] arr = email.Split('@');
            if (!arr[1].Contains('.'))
            {
                MessageBox.Show("Email düzgün deyil!");
                return false;
            }
            return true;
        }
    }
}
