using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AccountingPolessUp.Helpers
{
    public static class CancelFrameChecker
    {
        public static bool UpdateData { private get; set; }
        public static bool CreateData { private get; set; }

        static CancelFrameChecker()
        {
            SetDefaultValue();
        }
        private static bool CancelCheck()
        {
            if (UpdateData == false && CreateData == false)
                return false;
            SetDefaultValue();
            return true;
        }
        private static void SetDefaultValue()
        {
            UpdateData = false;
            CreateData = false;
        }
        public static void Cancel(Page page)
        {
            Frame editFrame = (Frame)page.FindName("EditFrame");
            Button buttonCancel = (Button)page.FindName("ButtonCancel");

            void CancelFrame()
            {
                editFrame.Content = null;
                buttonCancel.Visibility = Visibility.Hidden;
            }
            if (CancelCheck() == false)
            {
                MessageBoxResult result = MessageBox.Show("Данные не будут сохранены.\nПродолжить?", "Внимание!", MessageBoxButton.YesNo);
                if (result == MessageBoxResult.Yes)
                    CancelFrame();
            }
            else
                CancelFrame();
        }
    }
}
