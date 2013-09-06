using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using What2Cook.Resources;

namespace What2Cook
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static Recipe SelectedRecipe;

        // Constructor
        public MainPage()
        {
            InitializeComponent();            
            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            Dictionary<string, Recipe> RecipeList = Recipes.GetRecipeList();
            List<String> stringsList = new List<string>();
            foreach (var item in RecipeList.Keys)
            {
                stringsList.Add(item);
            }

            RecipeListSelector.ItemsSource = stringsList;            
        } 

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri(Constants.SettingsPage, UriKind.Relative));
        }

        private void AddRecipeButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri(Constants.AddRecipePage + "?Action=Add Recipe", UriKind.Relative));
        }

        private void RecipeList_tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            this.NavigationService.Navigate(new Uri(string.Format("/RecipeDetailsPage.xaml?RecipeName={0}", ((TextBlock)e.OriginalSource).Text), UriKind.Relative));
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as MenuItem).DataContext as string;
            switch ((string)((MenuItem)sender).Header)
            {
                case "delete recipe":
                    var currRecipe = RecipeListSelector.SelectedItem as string;
                    Recipes.DeleteRecipe(currRecipe);
                    break;
                case "edit recipe": 
                    
                    break;

                case "add to favorites": 
                    break;
            }
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
    }
}