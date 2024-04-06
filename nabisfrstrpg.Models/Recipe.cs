using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NABISFRSTRPG.Models
{
    public class Recipe
    {
        public int ID { get; }
        [JsonIgnore]
        public string Name { get; }
        [JsonIgnore]
        public List<ItemQuantity> Ingredients { get; } 
        public List<ItemQuantity> OutputItems { get; } 
        [JsonIgnore]
        public string ToolTipContents =>
            "Ingredients" + Environment.NewLine +
            "===========" + Environment.NewLine +
            string.Join(Environment.NewLine, Ingredients.Select(i => InsertSpaceAfterNumber(i.QuantityItemDescription))) +
            Environment.NewLine + Environment.NewLine +
            "Creates" + Environment.NewLine +
            "===========" + Environment.NewLine +
            string.Join(Environment.NewLine, OutputItems.Select(i => InsertSpaceAfterNumber(i.QuantityItemDescription)));
        private string InsertSpaceAfterNumber(string spaceAfterNumber)
        {
            return Regex.Replace(spaceAfterNumber, @"(\d)([A-Za-z])", "$1 $2");
        }
        public Recipe(int id,string name,List<ItemQuantity> ingredients,List<ItemQuantity> outputItems) 
        {
            ID = id;
            Name = name;
            Ingredients = ingredients;
            OutputItems = outputItems;
        }

        //public string ToolTipContents
        //{
        //    get
        //    {
        //        string ingredientsSection = "";
        //        if (Ingredients != null)
        //        {
        //            ingredientsSection = "Ingredients" + Environment.NewLine +
        //                                 "===========" + Environment.NewLine +
        //                                 string.Join(Environment.NewLine, Ingredients.Where(i => i != null).Select(i => InsertSpaceAfterNumber(i.QuantityItemDescription))) +
        //                                 Environment.NewLine + Environment.NewLine;
        //        }

        //        string outputItemsSection = "";
        //        if (OutputItems != null)
        //        {
        //            outputItemsSection = "Creates" + Environment.NewLine +
        //                                "===========" + Environment.NewLine +
        //                                string.Join(Environment.NewLine, OutputItems.Where(i => i != null).Select(i => InsertSpaceAfterNumber(i.QuantityItemDescription)));
        //        }

        //        return ingredientsSection + outputItemsSection;
        //    }
        //}
    }
}
