using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    class FilterRecipes
    {
       public static List<Recipe> SortRecipesBasedonCusine(List<Recipe> recipes, string cusine)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.Cusine.Equals(cusine))
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public static List<Recipe> SortRecipesBasedonFavorites(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            foreach (Recipe recipe in recipes)
            {
                if (recipe.IsFavorite)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }

        public static List<Recipe> SortRecipesBasedonMealTime(List<Recipe> recipes)
        {
            List<Recipe> filteredRecipes = new List<Recipe>();
            
            foreach (Recipe recipe in recipes)
            {
                if (recipe.IsFavorite)
                {
                    filteredRecipes.Add(recipe);
                }
            }

            return filteredRecipes;
        }
    }
}
