using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Engine.Models;
using Engine.Shared;
using FluentAssertions.Equivalency;

namespace Engine.Factories
{
    internal static class WorldFactory
    {
        private const string GAME_DATA_FILENAME = ".\\GameData\\Locations.xml";
        internal static World CreateWorld()
        {
            World world = new World();
            if (File.Exists(GAME_DATA_FILENAME))
            {
                XmlDocument data = new XmlDocument();
                data.LoadXml(File.ReadAllText(GAME_DATA_FILENAME));
                string rootImagePath =
                    data.SelectSingleNode("/Locations")
                        .AttributeAsString("RootImagePath");
                LoadLocationsFromNodes(world,
                                       rootImagePath,
                                       data.SelectNodes("/Locations/Location"));
            }
            else
            {
                throw new FileNotFoundException($"Missing data file: {GAME_DATA_FILENAME}");
            }
            return world;
        }
        private static void LoadLocationsFromNodes(World world, string rootImagePath, XmlNodeList nodes)
        {
            if (nodes == null)
            {
                return;
            }
            foreach (XmlNode node in nodes)
            {
                Location location =
                    new Location(node.AttributeToInt("X"),
                                 node.AttributeToInt("Y"),
                                 node.AttributeAsString("Name"),
                                 node.SelectSingleNode("./Description")?.InnerText ?? "",
                                 $".{rootImagePath}{node.AttributeAsString("ImageName")}");
                AddMonsters(location, node.SelectNodes("./Monsters/Monster"));
                AddQuests(location, node.SelectNodes("./Quests/Quest"));
                AddTrader(location, node.SelectSingleNode("./Trader"));
                world.AddLocation(location);
            }
        }
        private static void AddMonsters(Location location, XmlNodeList monsters)
        {
            if (monsters == null)
            {
                return;
            }
            foreach (XmlNode monsterNode in monsters)
            {
                location.AddMonster(monsterNode.AttributeToInt("ID"),
                                    monsterNode.AttributeToInt("Percent"));
            }
        }
        private static void AddQuests(Location location, XmlNodeList quests)
        {
            if (quests == null)
            {
                return;
            }
            foreach (XmlNode questNode in quests)
            {
                location.QuestsAvailableHere
                        .Add(QuestFactory.GetQuestByID(questNode.AttributeToInt("ID")));
            }
        }
        private static void AddTrader(Location location, XmlNode traderHere)
        {
            if (traderHere == null)
            {
                return;
            }
            location.TraderHere =
                TraderFactory.GetTraderByID(traderHere.AttributeToInt("ID"));
        }
    }
}
