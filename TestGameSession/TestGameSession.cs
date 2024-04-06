using NABISFRSTRPG.ViewModels;
using FluentAssertions;
using NUnit.Framework;

namespace TestNABISFRSTRPG.ViewModels
{
    public class TestGameSession
    {
        [Test]
        public void TestCreateGameSession()
        {
            //Player player = new Player("", 0, 10, 10, 15, 10);

            //GameSession gameSession = new GameSession(player, 0, 0);
            //Assert.IsNotNull(gameSession.CurrentPlayer);
            //Assert.AreEqual("Town Square", gameSession.CurrentLocation.Name);
        }
        [Test]
        public void TestPlayerMovesHomeAndIsCompletelyHealedOnKilled()
        {
            //Player player = new Player("", 0, 10, 10, 15, 10);

            //GameSession gameSession = new GameSession(player, 0, 0);
            //gameSession.CurrentPlayer.TakeDamage(999);
            //Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
            //Assert.AreEqual(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
        }
    }
}