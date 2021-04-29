using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Catering.Helpers
{
    public class ErrorMetods
    {
        public void InValidSpace(string header)
        {
            string message = header + " " + UIMessages.IsEmptyMessage;
            MessageBox.Show(message, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void InValidLength(string header, int maxSymbol)
        {
            string message = $"{header} {maxSymbol}-dan çox ola bilməz!";
            MessageBox.Show(message, "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void OperationIsTerminated()
        {
            MessageBox.Show("Əməliyyat tamamlanmadı", "Xəta", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
