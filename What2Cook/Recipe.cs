using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    public class Recipe
    {
        public string Name { get; set; }

        public string Cusine { get; set; }

        public DateTime Date { get; set; }

        public string MealTime { get; set; }
        
        public string Comments { get; set; }

        public bool IsFavorite { get; set; }

        public int CookCount;

        public int SuggestCount;

        public Recipe()
        {
        }

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
