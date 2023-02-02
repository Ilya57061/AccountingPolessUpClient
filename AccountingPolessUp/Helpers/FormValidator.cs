
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AccountingPolessUp.Helpers
{
    public static class FormValidator
    {
        public static bool AreAllElementsFilled(DependencyObject parent)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if (child is PasswordBox passwordBox && string.IsNullOrEmpty(passwordBox.Password)
                    || child is ComboBox comboBox && comboBox.SelectedItem == null
                    || child is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text)
                    || child is DatePicker datePicker && string.IsNullOrEmpty(datePicker.Text))
                {
                    return true;
                }
            }
            return false;
        }
        public static bool ElementsFilledUpdateUser(DependencyObject parent)
        {
            int childrenCount = VisualTreeHelper.GetChildrenCount(parent);

            for (int i = 0; i < childrenCount; i++)
            {
                var child = VisualTreeHelper.GetChild(parent, i);

                if ( child is ComboBox comboBox && comboBox.SelectedItem == null
                    || child is TextBox textBox && string.IsNullOrWhiteSpace(textBox.Text)
                    || child is DatePicker datePicker && string.IsNullOrEmpty(datePicker.Text))
                {
                    return true;
                }
            }
            return false;
        }
    }
}