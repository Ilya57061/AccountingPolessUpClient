using AccountingPolessUp.Models;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace AccountingPolessUp
{
    /// <summary>
    /// Логика взаимодействия для PageEmployment.xaml
    /// </summary>
    public partial class PageEmployment : Page
    {
        //Participants _participants;
        public PageEmployment()
        {
            InitializeComponent();
        }
        private void HyperlinkGitHub_Click(object sender, RoutedEventArgs e)
        {
            //try
            //{
            //    Process.Start(_participants.GitHub);

            //}
            //catch (Exception)
            //{
            //    HyperlinkGitHub.IsEnabled = false;
            //    InfoGitHub.Foreground = new SolidColorBrush(Colors.Gray);
            //}
        }
    }
}
