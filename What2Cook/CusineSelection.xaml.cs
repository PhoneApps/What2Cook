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
        private Dictionary<string, string> uriParams;
        private string cusine;

        public CusineSelector()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            GetParametersFromUri();            
        }
        
        private void AmericanCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = AmericanCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void ChineseCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = ChineseCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void EthopianCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = EthopianCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void IndianCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = IndianCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void ItalianCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = ItalianCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void MediterraneanCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = MediterraneanCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
        
        private void MexicanCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = MexicanCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }

        private void ThaiCusine_Checked(object sender, RoutedEventArgs e)
        {
            cusine = ThaiCusine.Content.ToString();
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);

            string uri = ConstructUri(Constants.AddRecipePage);
            this.NavigationService.Navigate(new Uri(uri, UriKind.Relative));
        }
        
        private void SetUriParameters()
        {
            Utility.SetParameter(uriParams, Constants.CusineParameter, cusine);            
        }

        private void GetParametersFromUri()
        {
            uriParams = (Dictionary<string, string>)this.NavigationContext.QueryString;
        }
                
        private string ConstructUri(string pageName)
        {
            StringBuilder builder = new StringBuilder();

            builder.Append(pageName + "?");

            foreach (KeyValuePair<string, string> param in uriParams)
            {
                builder.Append(param.Key + "=" + param.Value + "&");
            }

            return builder.ToString();
        }
    }
}