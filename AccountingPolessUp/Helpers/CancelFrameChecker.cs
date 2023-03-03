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
                var messageBoxResult = MessageBox.Show("Данные не будут сохранены.\nПродолжить?", "Внимание!", MessageBoxButton.YesNo);

                if (messageBoxResult == MessageBoxResult.Yes)
                    CancelFrame();
            }
            else
                CancelFrame();
        }
    }
}
