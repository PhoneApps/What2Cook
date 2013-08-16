using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Text;

namespace What2Cook
{
    public partial class CusineSelector : PhoneApplicationPage
    {
        public CusineSelector()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
        }
        
        private void AmericanCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = AmericanCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void ChineseCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = ChineseCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void EthopianCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = EthopianCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void IndianCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = IndianCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void ItalianCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = ItalianCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void MediterraneanCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = MediterraneanCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }
        
        private void MexicanCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = MexicanCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }

        private void ThaiCusine_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.Cusine = ThaiCusine.Content.ToString();
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage, UriKind.Relative));
        }       
    }
}