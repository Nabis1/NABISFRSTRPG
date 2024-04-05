using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Engine.Services;
using Newtonsoft.Json;

namespace Engine.Models
{
    public class Location
    {
        public int XCoordinate { get; }
        public int YCoordinate { get; }
        [Newtonsoft.Json.JsonIgnore]
        public string Name { get; }
        [Newtonsoft.Json.JsonIgnore]
        public string Description { get; }
        [Newtonsoft.Json.JsonIgnore]
        public string ImageName { get; }
        [Newtonsoft.Json.JsonIgnore]
        public List<Quest> QuestsAvailableHere { get; } = new List<Quest>();
        [Newtonsoft.Json.JsonIgnore]    
        public List<MonsterEncounter> MonstersHere { get; } = new List<MonsterEncounter>();
        [Newtonsoft.Json.JsonIgnore]
        public Trader TraderHere { get; set; }

        public Location(int xCoordinate, int yCoordinate, string name, string description, string imageName)
        {
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Name = name;
            Description = description;
            ImageName = imageName;
        }

        public void AddMonster(int monsterID, int chanceOfEncoutering)
        {
            if (MonstersHere.Exists(m => m.MonsterID == monsterID))
            {
                MonstersHere.First(m => m.MonsterID == monsterID).ChanceOfEncountering = chanceOfEncoutering;
            }
            else
            {
                MonstersHere.Add(new MonsterEncounter(monsterID, chanceOfEncoutering));
            }
        }
       
    }

}
