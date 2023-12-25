using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlidePuzzle;
using SlidePuzzle.UI;

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
            Assert.IsTrue(game.GoalStateboard != null);
            Assert.IsTrue(game.RowSize == 4);
            Assert.IsTrue(game.ColSize == 4);
            Assert.IsTrue(game.board.GetUpperBound(0) == 3);
            Assert.IsTrue(game.board.GetUpperBound(1) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(1) == 3);

            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    Assert.IsTrue(game.board[i, j] == 0);
                    Assert.IsTrue(game.GoalStateboard[i, j] == 0);
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
            Assert.IsTrue(game.GoalStateboard != null);
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
                    Assert.IsTrue(game.GoalStateboard[i, j] == value);
                }
            }


        }

        [TestMethod]
        public void GameStartWithCustomBoard()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue (game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.GoalStateboard != null);


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
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(1) == 3);
            Assert.IsTrue(game.PositionOfNumberZero.Row == 3);
            Assert.IsTrue(game.PositionOfNumberZero.Column  == 2);

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

        [TestMethod]
        public void StartWithAutomaticShuffle()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue(game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.GoalStateboard != null);

            game.StartWithAutomaticShuffle();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Running);

            Assert.IsTrue(game.board.GetUpperBound(0) == 3);
            Assert.IsTrue(game.board.GetUpperBound(1) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(1) == 3);
            Assert.IsFalse(game.IsInFinishedPosition);
            int i;
            int j;
            Boolean isAtLestOneCellDifferentThantheboard = false;
            for (i = 0; i < 4; i++)
            {
                for (j = 0; j < 4; j++)
                {
                    if(game.board [i,j] != game.GoalStateboard[i, j])
                    {
                        isAtLestOneCellDifferentThantheboard = true;
                    }
                   // Assert.IsTrue(game.board[i, j] == customBoardShuffle[i, j]);
                }
            }

            Assert.IsTrue(isAtLestOneCellDifferentThantheboard);


        }

        [TestMethod]
        public void GameMoveCell()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue(game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.GoalStateboard != null);


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
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(1) == 3);
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
            game.MoveCell(16, false);
            
            //game.MoveTile(new Position(3, 3), new Position(3, 2));
            Assert.IsTrue(game.IsInFinishedPosition);
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);

            // game.MoveTile (new System.Drawing.Point ())


        }
        [TestMethod]
        public void GameFinish()
        {
            Game game = new Game(4, 4, new SlidePuzzle.UI.MockUI());
            game.Initial();
            Assert.IsTrue(game.GameState == Game.GameStateEnum.Stop);
            Assert.IsTrue(game.IsInFinishedPosition);


            Assert.IsTrue(game.board != null);
            Assert.IsTrue(game.GoalStateboard != null);


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
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(0) == 3);
            Assert.IsTrue(game.GoalStateboard.GetUpperBound(1) == 3);
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
            game.MoveTile(new Position(3, 3), new Position(3, 2));
           // game.MoveTile (new System.Drawing.Point ())


        }
    }
}
