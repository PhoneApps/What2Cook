using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    class Preferences
    {
        public static bool Cusine { get; private set; }
        public static bool LeastFrequentlyCooked { get; private set; }
        public static bool LeastFrequentlySuggested { get; private set; }
        public static bool MealTiming { get; private set; }
        public static bool Favorite { get; private set; }

        public static bool AllPreferencesSet()
        {
            return (Cusine && LeastFrequentlyCooked && LeastFrequentlySuggested && MealTiming && Favorite);
        }

        public static bool NoPreferencesSet()
        {
            return !(Cusine || LeastFrequentlyCooked || LeastFrequentlySuggested || MealTiming || Favorite);
        }

        public static void SetPreferences(bool? cusine, bool? leastFrequentlyCooked, bool? leastFrequentlySuggested, bool? mealTiming, bool? favorite)
        {
            Cusine = (cusine == null || (cusine == false)) ? false : true;
            LeastFrequentlyCooked = (leastFrequentlyCooked == null || (leastFrequentlyCooked == false)) ? false : true;
            LeastFrequentlySuggested = (leastFrequentlySuggested == null || (leastFrequentlySuggested == false)) ? false : true;
            MealTiming = (mealTiming == null || (mealTiming == false)) ? false : true;
            Favorite = (favorite == null || (favorite == false)) ? false : true;
        }
    }
}
