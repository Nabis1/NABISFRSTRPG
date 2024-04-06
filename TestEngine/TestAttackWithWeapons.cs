using System;
using NABISFRSTRPG.Models.Actions;
using NABISFRSTRPG.Services.Factories;
using NABISFRSTRPG.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace TestNABISFRSTRPG.Models.Actions
{
    [TestClass]
    public class TestAttackWithWeapon
    {
        [TestMethod]
        public void Test_Constructor_GoodParameters()
        {
            GameItem pointyStick = ItemFactory.CreateGameItem(1001);
            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(pointyStick, "1d5");
            Assert.IsNotNull(attackWithWeapon);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Constructor_ItemIsNotAWeapon()
        {
            GameItem granolaBar = ItemFactory.CreateGameItem(2001);
            // A granola bar is not a weapon.
            // So, the constructor should throw an exception.
            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(granolaBar, "1d5");
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Constructor_DamageDiceStringEmpty()
        {
            GameItem pointyStick = ItemFactory.CreateGameItem(1001);
            // This damage dice string must exist.
            // So, the constructor should throw an exception.
            AttackWithWeapon attackWithWeapon = new AttackWithWeapon(pointyStick, string.Empty);
        }
    }
}