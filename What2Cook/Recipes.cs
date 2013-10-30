using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What2Cook
{
    public class Recipes
    {
        private static SortedDictionary<string, Recipe> RecipeList;

        public static void AddRecipe(Recipe recipe)
        {
            GetRecipeList();

            if (!RecipeList.ContainsKey(recipe.Name))
            {
                RecipeList.Add(recipe.Name, recipe);
            }
            else
            {
                Recipe updatedRecipe;
                RecipeList.TryGetValue(recipe.Name, out updatedRecipe);
                updatedRecipe.CookCount++;

                DeleteRecipe(recipe.Name);
                AddRecipe(updatedRecipe);
            }            
        }

        public static void EditRecipe(Recipe oldRecipe, Recipe newRecipe)
        {
            DeleteRecipe(oldRecipe.Name);

            if (!RecipeList.ContainsKey(newRecipe.Name))
            {
                RecipeList.Add(newRecipe.Name, newRecipe);
            }
            else
            {
                DeleteRecipe(newRecipe.Name);

                newRecipe.CookCount++;
                RecipeList.Add(newRecipe.Name, newRecipe);                
            }
        }

        public static void DeleteRecipe(string recipeKey)
        {
            if (RecipeList.ContainsKey(recipeKey))
            {
                RecipeList.Remove(recipeKey);
            }
        }

        public static int Size()
        {
            return RecipeList.Count;
        }

        public static Recipe GetRecipe(string recipeName)
        {
            Recipe recipe;
            RecipeList.TryGetValue(recipeName, out recipe);
            return recipe;
        }

        public static SortedDictionary<string, Recipe> GetRecipeList()
        {
            if (RecipeList == null)
            {
                RecipeList = new SortedDictionary<string, Recipe>();
            }

            return RecipeList;
        }
    }
}
