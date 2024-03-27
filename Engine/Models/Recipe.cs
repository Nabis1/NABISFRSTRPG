using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Engine.Models
{
    public class Recipe
    {
        public int ID { get; }
        [JsonIgnore]
        public string Name { get; }
        [JsonIgnore]
        public List<ItemQuantity> Ingredients { get; } = new List<ItemQuantity>();
        [JsonIgnore]
        public List<ItemQuantity> OutputItems { get; } = new List<ItemQuantity>();
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
        public Recipe(int id,string name) 
        {
            ID = id;
            Name = name;
        }
        public void AddIngredient(int itemID,int quantity)
        {
            if (!Ingredients.Any(x => x.ItemID == itemID))
            {
                Ingredients.Add(new ItemQuantity(itemID,quantity));
            }
        }
        public void AddOutputItem(int itemID,int quantity)
        {
            if (!OutputItems.Any(x => x.ItemID == itemID))
            {
                OutputItems.Add(new ItemQuantity(itemID,quantity));
            }
        }
    }
}
