using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.IO.IsolatedStorage;
using System.IO;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Windows.Storage;

namespace What2Cook
{
    public partial class AddRecipe : PhoneApplicationPage
    {
        private static string action;
        
        private static bool navigateToDateSelector = false;

        public AddRecipe()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            if (this.NavigationContext.QueryString.ContainsKey(Constants.ActionParameter))
            {
                action = this.NavigationContext.QueryString[Constants.ActionParameter];
            }

            MealListPicker.ItemsSource = Constants.MealTimings;
            MealListPicker.SelectionChanged += MealListPicker_SelectionChanged;
            MealListPicker.Tap += MealListPicker_Tap;
            
            if (MainPage.SelectedRecipe == null)
            {
                MainPage.SelectedRecipe = new Recipe();
            }

            SetUIElements();                 
        }

        private void MealListPicker_Tap(object sender, SelectionChangedEventArgs e)
        {
            MealListPicker.IsEnabled = true;
        }

        private void MealListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MealListPicker.SelectedItem = MainPage.SelectedRecipe.MealTime = e.AddedItems[0] as string;            
        }

        private void Cusine_Button_Click(object sender, RoutedEventArgs e)
        {
            GetUIElements();
            this.NavigationService.Navigate(new Uri(Constants.CusineSelectionPage, UriKind.Relative));
        }

        private void CookDatePicker_Tap(object sender, RoutedEventArgs e)
        {
            GetUIElements();
            navigateToDateSelector = true;            
        }

        private void MealListPicker_Tap(object sender, RoutedEventArgs e)
        {
            GetUIElements();               
        }

        private void IsFavorite_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            MainPage.SelectedRecipe.IsFavorite = (IsFavorite_Checkbox.IsChecked == null) || (IsFavorite_Checkbox.IsChecked==false) ? false : true;                       
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            GetUIElements();

            Recipes.AddRecipe(MainPage.SelectedRecipe);

            if (App.RecipeFile != null)
            {
                XmlReaderWriter.UpdateRecipeFile(App.RecipeFile);
            }
            
            this.NavigationService.Navigate(new Uri(Constants.MainPage, UriKind.Relative));
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.NavigationService.Navigate(new Uri(Constants.MainPage, UriKind.Relative));
        }

        private void SetUIElements()
        {
            PageName.Text = action;
            RecipeName_TextBox.Text = string.IsNullOrEmpty(MainPage.SelectedRecipe.Name) ? "" : MainPage.SelectedRecipe.Name;
            Cusine_Button.Content = string.IsNullOrEmpty(MainPage.SelectedRecipe.Cusine) ? "" : MainPage.SelectedRecipe.Cusine;
            if (!navigateToDateSelector)
            {
                CookDatePicker.Value = DateTime.MinValue.Equals(MainPage.SelectedRecipe.Date) ? DateTime.Today : MainPage.SelectedRecipe.Date;               
            }
            navigateToDateSelector = false;

            if (!string.IsNullOrEmpty(MainPage.SelectedRecipe.MealTime))
            {
                MealListPicker.SelectedItem = MainPage.SelectedRecipe.MealTime;
            }
            Comment_TextBox.Text = string.IsNullOrEmpty(MainPage.SelectedRecipe.Comments) ? "" : MainPage.SelectedRecipe.Comments;
            IsFavorite_Checkbox.IsChecked = MainPage.SelectedRecipe.IsFavorite ? true : false;
        }

        private void GetUIElements()
        {
            action = PageName.Text;        
            MainPage.SelectedRecipe.Name = RecipeName_TextBox.Text;
            MainPage.SelectedRecipe.Cusine = Cusine_Button.Content.ToString();
            MainPage.SelectedRecipe.Comments = Comment_TextBox.Text;
            MainPage.SelectedRecipe.Date = (DateTime)CookDatePicker.Value;
            MainPage.SelectedRecipe.MealTime = MealListPicker.SelectedItem.ToString();
            MainPage.SelectedRecipe.IsFavorite = (IsFavorite_Checkbox.IsChecked == null) || (IsFavorite_Checkbox.IsChecked == false) ? false : true;
        }                
    }
}