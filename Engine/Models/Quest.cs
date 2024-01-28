using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.Models
{
    internal class Quest
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<ItemQuantity> ItemsToComplete { get; set; }

        public int RewardExperiencePoints { get; set; }
        public int RewardGold {  get; set; }
        public List<ItemQuantity> RewardItems { get; set; }
        public Quest(int id, string name, List<ItemQuantity> itemstocomplete,int rewardExperiencePoints, int rewardGold, List<ItemQuantity> rewardItems)
        {
            RewardExperiencePoints = rewardExperiencePoints;
            RewardGold = rewardGold;
            RewardItems = rewardItems;
            ID = id;
            Name = name;
            ItemsToComplete = itemstocomplete;
        }

    }
}
