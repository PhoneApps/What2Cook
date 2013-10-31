using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    public class Constants
    {
        // Constants
        public const string RecipesFileName = "Recipes.xml";

        public static List<string> MealTimings = new List<string>(new string[] {"Breakfast", "Brunch", "Lunch", "Dinner" });

        public static Dictionary<string, object> MealTimingsMap = new Dictionary<string, object>() 
                                                                    { 
                                                                        {"Breakfast", new Timings (new DateTime(), new DateTime())},
                                                                        {"Brunch", new object()},
                                                                        {"Lunch", new object()},
                                                                        {"Dinner", new object()}
                                                                    };        

        // Page Names
        public const string MainPage = "/MainPage.xaml";

        public const string AddRecipePage = "/AddRecipe.xaml";

        public const string CusineSelectionPage = "/CusineSelection.xaml";

        public const string DatePickerPage = "/DatePicker.xaml";

        public const string SettingsPage = "/Settings.xaml";
        
        // xml parameters
        public const string RecipesElement = "Recipes"; 
        
        public const string RecipeElement = "Recipe";

        public const string RecipeNameAttribute = "Name";

        public const string CusineAttribute = "Cusine";

        public const string DateAttribute = "Date";

        public const string MealTimeAttribute = "Time";

        public const string CommentsAttribute = "Comments";

        public const string IsFavoriteAttribute = "IsFavorite";

        public const string CookCountAttribute = "CookCount";

        public const string SuggestCountAttribute = "SuggestCount";

        // Parameters
        public const string ActionParameter = "Action";

        public const string RecipeNameParameter = "RecipeName";

        public const string CusineParameter = "Cusine";

        public const string DateParameter = "Date";

        public const string MealTimeParameter = "Time";
        
        public const string CommentsParameter = "Comments";

        public const string IsFavoriteParameter = "IsFavorite";

        public const string CookCountParameter = "CookCount";

        public const string SuggestCountParameter = "SuggestCount";

        // Parameters value
        public const string EditRecipe = "Edit Recipe";
        public const string AddRecipe = "Add Recipe";
        
        public class Timings
        {
            public DateTime StartTime {get; private set;}
            public DateTime EndTime {get; private set;}

            public Timings(DateTime startTime, DateTime endTime)
            {
                StartTime = startTime;
                EndTime = endTime;
            }
        }
    }
}
