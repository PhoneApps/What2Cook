using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Windows.Storage;
using Windows.Storage.Streams;

namespace What2Cook
{
    public class XmlReaderWriter
    {
        private static StorageFile xmlFile;

        private static string xmlData;

        public XmlReaderWriter(StorageFile file)
        {
            xmlFile = file;
        }

        public static void UpdateRecipeFile(StorageFile recipeFile)
        {            
            StringBuilder xmlBuilder = new StringBuilder();
            XmlWriter writer = XmlWriter.Create(xmlBuilder);
            writer.WriteStartElement(Constants.RecipesElement);

            foreach (KeyValuePair<string, Recipe> recipe in Recipes.GetRecipeList())
            {
                writer.WriteStartElement(Constants.RecipeElement);
                writer.WriteAttributeString(Constants.RecipeNameAttribute, recipe.Value.Name);
                writer.WriteAttributeString(Constants.CusineAttribute, recipe.Value.Cusine);
                writer.WriteAttributeString(Constants.DateAttribute, recipe.Value.Date.ToString());
                writer.WriteAttributeString(Constants.MealTimeAttribute, recipe.Value.MealTime);
                writer.WriteAttributeString(Constants.CommentsAttribute, recipe.Value.Comments);
                writer.WriteAttributeString(Constants.IsFavoriteAttribute, recipe.Value.IsFavorite ? "true" : "false");
                writer.WriteAttributeString(Constants.CookCountAttribute, recipe.Value.CookCount.ToString());
                writer.WriteAttributeString(Constants.SuggestCountAttribute, recipe.Value.SuggestCount.ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.Close();
            
            WriteToFile(recipeFile, xmlBuilder.ToString());           
        }

        public static void ReadRecipeFile(StorageFile recipeFile)
        {
            do
            {
                ReadFromFile(recipeFile);
            } while (xmlData == null);

            using (XmlReader reader = XmlReader.Create(new StringReader(xmlData)))
            {
                // Parse the file and display each of the nodes.
                while (reader.Read())
                {                    
                    switch (reader.NodeType)
                    {
                        case XmlNodeType.Element:
                            if (reader.Name.Equals("Recipe"))
                            {
                                ReadRecipe(reader);
                            }
                            break;                        
                    }
                }
            }         
        }

        private static void ReadRecipe(XmlReader reader)
        {
            string recipeName = "";
            string cusine = "";
            DateTime date = DateTime.Now;
            string mealTime = "";
            string comments = "";
            bool isFavorite = false;
            int cookCount = 0;
            int suggestCount = 0;
            
            if (reader.MoveToAttribute(Constants.RecipeNameAttribute))
            {
                recipeName = reader.GetAttribute(Constants.RecipeNameAttribute);
            }

            if (reader.MoveToAttribute(Constants.CusineAttribute))
            {
                cusine = reader.GetAttribute(Constants.CusineAttribute);
            }

            if (reader.MoveToAttribute(Constants.DateAttribute))
            {
                date = DateTime.Parse(reader.GetAttribute(Constants.DateAttribute));                                    
            }
                
            if (reader.MoveToAttribute(Constants.MealTimeAttribute))
            {
                mealTime = reader.GetAttribute(Constants.MealTimeAttribute);                                    
            }
                
            if (reader.MoveToAttribute(Constants.CommentsAttribute))
            {
                comments = reader.GetAttribute(Constants.CommentsAttribute);                                    
            }
                
            if (reader.MoveToAttribute(Constants.IsFavoriteAttribute))
            {
                isFavorite = bool.Parse(reader.GetAttribute(Constants.IsFavoriteAttribute));                                    
            }
                
            if (reader.MoveToAttribute(Constants.CookCountAttribute))
            {
                cookCount = int.Parse(reader.GetAttribute(Constants.CookCountAttribute));                                    
            }
                
            if (reader.MoveToAttribute(Constants.SuggestCountAttribute))
            {
                suggestCount = int.Parse(reader.GetAttribute(Constants.SuggestCountAttribute));                                    
            }               
            
            Recipe recipe = new Recipe(recipeName, cusine, date, mealTime, comments, isFavorite, cookCount, suggestCount);
            Recipes.AddRecipe(recipe);
        }   
        
        private static async void ReadFromFile(StorageFile recipeFile)
        {
            try
            {
                using (var fs = await recipeFile.OpenAsync(FileAccessMode.Read))
                {
                    using (var inStream = fs.GetInputStreamAt(0))
                    {
                        using (var reader = new DataReader(inStream))
                        {
                            await reader.LoadAsync((uint)fs.Size);
                            xmlData = reader.ReadString((uint)fs.Size);
                            reader.DetachStream();
                        }
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private static async void WriteToFile(StorageFile recipeFile, string data)
        {
            try
            {
                using (var fs = await recipeFile.OpenAsync(FileAccessMode.ReadWrite))
                {
                    using (var outStream = fs.GetOutputStreamAt(0))
                    {
                        using (var dataWriter = new DataWriter(outStream))
                        {
                            dataWriter.WriteString(data);
                            await dataWriter.StoreAsync();
                            dataWriter.DetachStream();
                        }

                        await outStream.FlushAsync();
                    }
                }                  
            }
            catch(Exception ex)
            {
                throw ex;
            }            
        }            
    }
}