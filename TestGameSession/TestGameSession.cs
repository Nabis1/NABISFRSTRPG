using Engine.ViewModels;
using FluentAssertions;
using NUnit.Framework;

namespace TestEngine.ViewModels
{
    public class TestGameSession
    {
        [Test]
        public void TestCreateGameSession()
        {
            GameSession gameSession = new GameSession();

            //Assert.IsNotNull(gameSession.CurrentPlayer);
            gameSession.CurrentPlayer.Should().NotBeNull();

            //Assert.AreEqual("Town square", gameSession.CurrentLocation.Name);
            gameSession.CurrentLocation.Name.Should().Be("Home");
        }
        [Test]
        public void TestPlayerMovesHomeAndIsCompletelyHealedOnKilled()
        {
            GameSession gameSession = new GameSession();
            gameSession.CurrentPlayer.TakeDamage(999);

            //Assert.AreEqual("Home", gameSession.CurrentLocation.Name);
            gameSession.CurrentLocation.Name.Should().Be("Home");

            //Assert.AreEqual(gameSession.CurrentPlayer.Level * 10, gameSession.CurrentPlayer.CurrentHitPoints);
            gameSession.CurrentPlayer.CurrentHitPoints.Should().Be(gameSession.CurrentPlayer.Level * 10);
        }
    }
}