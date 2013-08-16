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
        private string action;
        private string recipeName;
        private string cusine;
        private DateTime date;
        private string mealTime;
        private string comments;
        private bool isFavorite;
        private int cookCount;
        private int suggestCount;

        private static bool navigateToCusineSelector = false;

        private Dictionary<string, string> uriParams; 

        public AddRecipe()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetParametersFromUri();
            
            MealListPicker.ItemsSource = Constants.MealTimings;
            MealListPicker.SelectionChanged += MealListPicker_SelectionChanged;
            MealListPicker.Tap += MealListPicker_Tap;
            
            SetUIElements();     
            
        }

        private void MealListPicker_Tap(object sender, SelectionChangedEventArgs e)
        {
            MealListPicker.IsEnabled = true;
        }

        private void MealListPicker_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MealListPicker.SelectedItem = mealTime = e.AddedItems[0] as string;
        }

        private void Cusine_Button_Click(object sender, RoutedEventArgs e)
        {
            GetUIElements();
            SetUriParameters();
            navigateToCusineSelector = true;

            string uri = ConstructUri(Constants.CusineSelectionPage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void CookDatePicker_Tap(object sender, RoutedEventArgs e)
        {
            GetUIElements();
            SetUriParameters();            
        }

        private void MealListPicker_Tap(object sender, RoutedEventArgs e)
        {
            GetUIElements();
            SetUriParameters();            
        }

        private void IsFavorite_Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            isFavorite = (IsFavorite_Checkbox.IsChecked == null) || (IsFavorite_Checkbox.IsChecked==false) ? false : true;                       
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            Recipe recipe = new Recipe(
                        RecipeName_TextBox.Text,
                        cusine,
                        date,
                        mealTime,
                        Comment_TextBox.Text,
                        isFavorite,
                        cookCount,
                        suggestCount);

            Recipes.AddRecipe(recipe);

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

        private void SetUriParameters()
        {
            Utility.SetParameter(uriParams, Constants.ActionParameter, action);
            Utility.SetParameter(uriParams, Constants.RecipeNameParameter, recipeName);
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);
            Utility.SetParameter(uriParams, Constants.DateParameter, date.ToString());
            Utility.SetParameter(uriParams, Constants.MealTimeParameter, mealTime.ToString());
            Utility.SetParameter(uriParams, Constants.CommentsParameter, comments);
            Utility.SetParameter(uriParams, Constants.IsFavoriteParameter, isFavorite.ToString());
        }        

        private void GetParametersFromUri()
        {
            uriParams = (Dictionary<string, string>)this.NavigationContext.QueryString;

            if (this.NavigationContext.QueryString.ContainsKey(Constants.ActionParameter))
            {
                this.action = this.NavigationContext.QueryString[Constants.ActionParameter];
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.RecipeNameParameter))
            {
                this.recipeName = this.NavigationContext.QueryString[Constants.RecipeNameParameter];
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.CusineParameter))
            {
                this.cusine = this.NavigationContext.QueryString[Constants.CusineParameter];
            }

            if (navigateToCusineSelector)
            {
                if (this.NavigationContext.QueryString.ContainsKey(Constants.DateParameter))
                {
                    CookDatePicker.Value = this.date = DateTime.Parse(this.NavigationContext.QueryString[Constants.DateParameter]);
                }

                navigateToCusineSelector = false;
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.MealTimeParameter))
            {
                this.mealTime = this.NavigationContext.QueryString[Constants.MealTimeParameter];
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.CommentsParameter))
            {
                this.comments = this.NavigationContext.QueryString[Constants.CommentsParameter];
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.IsFavoriteParameter))
            {
                this.isFavorite = bool.Parse(this.NavigationContext.QueryString[Constants.IsFavoriteParameter]);
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.CookCountParameter))
            {
                this.cookCount = int.Parse(this.NavigationContext.QueryString[Constants.CookCountParameter]);
            }
            else
            {
                this.cookCount = 0;
            }

            if (this.NavigationContext.QueryString.ContainsKey(Constants.SuggestCountParameter))
            {
                this.isFavorite = bool.Parse(this.NavigationContext.QueryString[Constants.SuggestCountParameter]);
            }
            else
            {
                this.suggestCount = 0;
            }
        }

        private void GetUIElements()
        {
            action = PageName.Text;
            recipeName = RecipeName_TextBox.Text;
            cusine = Cusine_Button.Content.ToString();
            comments = Comment_TextBox.Text;
            date = (DateTime)CookDatePicker.Value;
            mealTime = MealListPicker.SelectedItem.ToString();
            isFavorite = (IsFavorite_Checkbox.IsChecked == null) || (IsFavorite_Checkbox.IsChecked == false) ? false : true;
        }

        private void SetUIElements()
        {
            PageName.Text = string.IsNullOrEmpty(this.action) ? "" : this.action;
            RecipeName_TextBox.Text = string.IsNullOrEmpty(this.recipeName) ? "" : this.recipeName;
            Cusine_Button.Content = string.IsNullOrEmpty(this.cusine) ? "" : this.cusine;
            CookDatePicker.Value = DateTime.MinValue.Equals(CookDatePicker.Value) ? DateTime.Today : CookDatePicker.Value;
            if (!string.IsNullOrEmpty(this.mealTime))
            {
                MealListPicker.SelectedItem = this.mealTime;
            }
            Comment_TextBox.Text = string.IsNullOrEmpty(this.comments) ? "" : this.comments; 
            IsFavorite_Checkbox.IsChecked = this.isFavorite ? true : false;
        }

        private string ConstructUri(string pageName)
        {
            string uri = string.Format(
                "{0}?{1}={2}&{3}={4}&{5}={6}&{7}={8}&{9}={10}&{11}={12}&{13}={14}",
                pageName,
                Constants.ActionParameter,
                string.IsNullOrEmpty(this.action) ? "" : this.action,
                Constants.RecipeNameParameter,
                string.IsNullOrEmpty(this.recipeName) ? "" : this.recipeName,
                Constants.CusineParameter,
                string.IsNullOrEmpty(this.cusine) ? "" : this.cusine,
                Constants.DateParameter,
                string.IsNullOrEmpty(this.date.ToString()) ? "" : this.date.ToString(),
                Constants.MealTimeParameter,
                string.IsNullOrEmpty(this.mealTime) ? "" : this.mealTime,
                Constants.CommentsParameter,
                string.IsNullOrEmpty(this.comments) ? "" : this.comments,
                Constants.IsFavoriteParameter,
                this.isFavorite ? "true" : "false"
                );

            return uri;
        }        
    }
}