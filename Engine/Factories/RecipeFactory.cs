using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;
using Engine.Models;
using Engine.Shared;

    namespace Engine.Factories
{ 
    public static class RecipeFactory
    {
            private const string GAME_DATA_FILENAME = (".\\GameData\\Recipes.xml");
        private static readonly List<Recipe> _recipes = new  List<Recipe>();

        static RecipeFactory()
        {
            if (File.Exists(GAME_DATA_FILENAME))
            {
                XmlDocument data = new XmlDocument();
                data.LoadXml(File.ReadAllText(GAME_DATA_FILENAME));
                LoadRecipesFromNodes(data.SelectNodes("/Recipes/Recipe"));
            }
            else
            {
                throw new FileNotFoundException($"Missing data file : {GAME_DATA_FILENAME}");
            }
        }
        private static void LoadRecipesFromNodes(XmlNodeList nodes)
        {
            foreach (XmlNode node in nodes)
            {
                Recipe recipe =
                    new Recipe(node.AttributeToInt("ID"),
                               node.SelectSingleNode("./Name")?.InnerText ?? "");
                foreach (XmlNode childNode in node.SelectNodes("./Ingredients/Item"))
                {
                    recipe.AddIngredient(childNode.AttributeToInt("ID"),
                                         childNode.AttributeToInt("Quantity"));
                }
                foreach (XmlNode childNode in node.SelectNodes("./OutputItems/Item"))
                {
                    recipe.AddOutputItem(childNode.AttributeToInt("ID"),
                                         childNode.AttributeToInt("Quantity"));
                }
                _recipes.Add(recipe);
            }
        }
        public static Recipe RecipeByID(int id)
            {
                return _recipes.FirstOrDefault(x => x.ID == id);
            }
        
    }
}
