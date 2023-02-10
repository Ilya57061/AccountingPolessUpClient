using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace AccountingPolessUp.Helpers
{
    public static class NumberValidator
    {
        private static Regex _regex = new Regex("[^0-9,]+");
        public static void Validator(TextCompositionEventArgs e)
        {
            if (!int.TryParse(e.Text, out int result))
            {
                e.Handled = true;
            }
        }
        public static bool IsTextAllowed(string text)
        {
            return !_regex.IsMatch(text);
        }

        public static void DoubleValidator(TextCompositionEventArgs e)
        {
            _regex = new Regex("[^0-9,]+");
            e.Handled = !IsTextAllowed(e.Text);
        }
        public static void DateValidator(TextCompositionEventArgs e)
        {
            _regex = new Regex("[^0-9/:]+");
            e.Handled = !IsTextAllowed(e.Text);
        }
    }
}
