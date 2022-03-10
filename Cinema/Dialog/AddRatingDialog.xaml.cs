﻿using Cinema.Service;
using System.Linq;
using System.Windows;

namespace Cinema.Dialog
{
    /// <summary>
    /// Interaction logic for AddRatingDialog.xaml
    /// </summary>
    public partial class AddRatingDialog : Window
    {
        private string title;
        private int rating;

        public AddRatingDialog(IDataManager dataManager)
        {
            InitializeComponent();
            DataContext = this;

            combo.ItemsSource = dataManager.GetMovies.Select(i => i.MovieName).ToList();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
        }

        public string MovieTitle
        {
            get { return title; }
            set { title = value; }
        }

        public int Rating
        {
            get { return rating; }
            set { rating = value; }
        }
    }
}
