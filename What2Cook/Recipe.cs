using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    public class Recipe
    {
        public string Name { get; private set; }

        public string Cusine { get; private set; }

        public DateTime Date { get; private set; }

        public string MealTime { get; private set; }
        
        public string Comments { get; private set; }

        public bool IsFavorite { get; private set; }

        public int CookCount;

        public int SuggestCount;

        public Recipe(string name, string cusine, DateTime date, string mealTime, string comments, bool isFavorite, int cookCount, int suggestCount)
        {
            Name = name;
            Cusine = cusine;
            Date = date;
            MealTime = mealTime;
            Comments = comments;
            IsFavorite = isFavorite;
            CookCount = cookCount;
            SuggestCount = suggestCount;
        }
    }
}
