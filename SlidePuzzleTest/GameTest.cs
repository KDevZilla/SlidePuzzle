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

            int i;
            int j;
            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.Finishedboard != null);
            Assert.IsTrue(game.RowSize == 4);
            Assert.IsTrue(game.ColSize == 4);
            Assert.IsTrue(game.board.GetUpperBound(0) == 3);
            Assert.IsTrue(game.board.GetUpperBound(1) == 3);
            Assert.IsTrue(game.Finishedboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.Finishedboard.GetUpperBound(1) == 3);

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Assert.IsTrue(game.board[i, j] == 0);
                    Assert.IsTrue(game.Finishedboard[i, j] == 0);
                }
            }

          //  game.Initial();

         //   game.Start();
         //   Assert.IsTrue(game.GameState == Game.GameStateEnum.Running);
            

        }

        [TestMethod]
        public void GameInitial()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue(game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.Finishedboard != null);
            int i;
            int j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    int value = (i * 4) + (j + 1);
                    if(i==3 && j == 3)
                    {
                        value = 0;
                    }
                    Assert.IsTrue(game.board[i, j] == value);
                    Assert.IsTrue(game.Finishedboard[i, j] == value);
                }
            }


        }

        [TestMethod]
        public void GameStart()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue (game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.Finishedboard != null);


            int[,] customBoardShuffle = new int[,]
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {13,14,0,15 }
            };
            game.StartWithCustomBoard(customerBoardShuffle: customBoardShuffle);
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Running);

            Assert.IsTrue(game.board.GetUpperBound(0) == 3);
            Assert.IsTrue(game.board.GetUpperBound(1) == 3);
            Assert.IsTrue(game.Finishedboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.Finishedboard.GetUpperBound(1) == 3);
            Assert.IsFalse(game.IsInFinishedPosition);
            int i;
            int j;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Assert.IsTrue(game.board[i, j] == customBoardShuffle[i, j]);
                }
            }



        }
    }
}
