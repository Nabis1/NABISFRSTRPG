using NABISFRSTRPG.Models.Actions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NABISFRSTRPG.Models
{
    public class GameItem
    {
        public enum ItemCategory
        {
            Miscellaneous,
            Weapon,
            Consumable
        }
        [Newtonsoft.Json.JsonIgnore]
        public ItemCategory Category { get; }
        public int ItemTypeID { get; }
        [Newtonsoft.Json.JsonIgnore]
        public string Name { get; }
        [Newtonsoft.Json.JsonIgnore]
        public int Price { get; }
        [Newtonsoft.Json.JsonIgnore]
        public bool IsUnique { get; }
        [Newtonsoft.Json.JsonIgnore]
        public IAction Action { get; set; }
        public GameItem(ItemCategory category, int itemTypeID, string name, int price,
                        bool isUnique = false, IAction action = null)
        {
            Category = category;
            ItemTypeID = itemTypeID;
            Name = name;
            Price = price;
            IsUnique = isUnique;
            Action = action;
        }
        public void PerformAction(LivingEntity actor, LivingEntity target)
        {
            Action?.Execute(actor, target);
        }
        public GameItem Clone()
        {
            return new GameItem(Category, ItemTypeID, Name, Price, IsUnique, Action);
        }
    }
}
