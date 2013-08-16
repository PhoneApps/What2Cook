using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace What2Cook
{
    public partial class Settings : PhoneApplicationPage
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            SetUIElements();            
        }

        private void SetUIElements()
        {
            CusineCheckBox.IsChecked = Preferences.Cusine;
            LeastCookFrequencyCheckBox.IsChecked = Preferences.LeastFrequentlyCooked;
            LeastSuggestFrequencyCheckBox.IsChecked = Preferences.LeastFrequentlySuggested;
            MealTimeCheckBox.IsChecked = Preferences.MealTiming;
            FavoritesCheckBox.IsChecked = Preferences.Favorite;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Preferences.SetPreferences(
                CusineCheckBox.IsChecked,                 
                LeastCookFrequencyCheckBox.IsChecked,
                LeastSuggestFrequencyCheckBox.IsChecked,
                MealTimeCheckBox.IsChecked, 
                FavoritesCheckBox.IsChecked);
            
            // Store preferences in a file.

            this.NavigationService.Navigate(new Uri(Constants.MainPage, UriKind.Relative));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri(Constants.MainPage, UriKind.Relative));
        }
    }
}