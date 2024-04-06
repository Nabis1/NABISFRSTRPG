using NABISFRSTRPG.Models;
using NABISFRSTRPG.ViewModels;

namespace TestNABISFRSTRPG.ViewModels
{
    [TestClass]
    public class TestGameSession
    {
        private readonly Player _player = new("Nabis", 5, 10, 10,
            new List<PlayerAttribute> { new("ag", "agility", "1d5") }, 0);
        
        private static (int x, int y) Coordinates => (0, -1);
        
        [TestMethod]
        public void TestCreateGameSession()
        {
            var gameSession = new GameSession(_player, Coordinates.x, Coordinates.y);
            Assert.IsNotNull(gameSession.CurrentPlayer);
            Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
        }
        [TestMethod]
        public void TestPlayerMovesHomeAndIsCompletelyHealedOnKilled()
        {
            var gameSession = new GameSession(_player, Coordinates.x, Coordinates.y);
            gameSession.CurrentPlayer.TakeDamage(999);
            Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
            Assert.AreEqual(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
        }
    }
}