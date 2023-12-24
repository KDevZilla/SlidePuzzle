using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlidePuzzle;

namespace SlidePuzzleTest
{
    [TestClass]
    public class GameTest
    {
        [TestMethod]
        public void GameContructor()
        {
            Game game = new Game(4,4, new SlidePuzzle.UI.MockUI ());

            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsFalse(game.IsInFinishedPosition);
            game.Initial();

            game.Start();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Running);
            

        }
    }
}
