﻿using Microsoft.Win32;
using System.Windows;

namespace Cinema.View
{
    /// <summary>
    /// Interaction logic for AddMovie.xaml
    /// </summary>
    public partial class AddMovieDialog : Window
    {
        public AddMovieDialog()
        {
            InitializeComponent();
            DataContext = new Movie();
        }

        public void add_Button_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        private void DowloadImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog myDialog = new();
            myDialog.Filter = "Images(*.JPG;*.PNG)|*.JPG;*.PNG" + "|All Files (*.*)|*.* ";
            myDialog.CheckFileExists = true;
            if (myDialog.ShowDialog() == true)
            {
                txb_ImageFileName.Text = myDialog.FileName;
            }
        }

        private void cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
