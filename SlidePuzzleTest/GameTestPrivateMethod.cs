using Microsoft.VisualStudio.TestTools.UnitTesting;
using SlidePuzzle;
using SlidePuzzle.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzleTest
{
    [TestClass]
    public class GameTestPrivateMethod 
    {
        [TestMethod]
        public void GetNextToZeroNumberPostion()
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

            var keyDirection = System.Windows.Forms.Keys.Left;
            var PositionNextToNumberZero = game.CallPrivateMethod<Position>("GetNextToZeroNumberPostionThatCanMoveToDirection", keyDirection);
            Assert.IsTrue(PositionNextToNumberZero.Row == 3);
            Assert.IsTrue(PositionNextToNumberZero.Column  == 3);
            Assert.IsTrue(game.boardValue (PositionNextToNumberZero)==15);

            keyDirection = System.Windows.Forms.Keys.Down;
            PositionNextToNumberZero = game.CallPrivateMethod<Position>("GetNextToZeroNumberPostionThatCanMoveToDirection", keyDirection);
            Assert.IsTrue(PositionNextToNumberZero.Row == 2);
            Assert.IsTrue(PositionNextToNumberZero.Column  == 2);
            Assert.IsTrue(game.boardValue(PositionNextToNumberZero) == 11);

            keyDirection = System.Windows.Forms.Keys.Right ;
            PositionNextToNumberZero = game.CallPrivateMethod<Position>("GetNextToZeroNumberPostionThatCanMoveToDirection", keyDirection);
            Assert.IsTrue(PositionNextToNumberZero.Row == 3);
            Assert.IsTrue(PositionNextToNumberZero.Column  == 1);
            Assert.IsTrue(game.boardValue(PositionNextToNumberZero) == 14);


            //This function does not check if the return value is in the range.
            keyDirection = System.Windows.Forms.Keys.Up;
            PositionNextToNumberZero = game.CallPrivateMethod<Position>("GetNextToZeroNumberPostionThatCanMoveToDirection", keyDirection);
            Assert.IsTrue(PositionNextToNumberZero.Row == 4);
            Assert.IsTrue(PositionNextToNumberZero.Column == 2);
           

            var keyDirectionInvalid = System.Windows.Forms.Keys.A;
            PositionNextToNumberZero = game.CallPrivateMethod<Position>("GetNextToZeroNumberPostionThatCanMoveToDirection", keyDirectionInvalid);
            Assert.IsTrue(PositionNextToNumberZero.isEqual (Position.Empty));



        }
        [TestMethod]
        public void GetTileAvilable()
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
            List<int> listAvilableTile= game.CallPrivateMethod<List<int>>("GetTileAvilable");
            Assert.IsTrue(listAvilableTile.Count == 3);
            Assert.IsTrue(listAvilableTile.Contains(11));
            Assert.IsTrue(listAvilableTile.Contains(14));
            Assert.IsTrue(listAvilableTile.Contains(15));



            customBoardShuffle = new int[,]
            {
                {1,2,3,4 },
                {5,6,7,8 },
                {9,10,11,12 },
                {0,13,14,15 }
            };
            game.StartWithCustomBoard(customerBoardShuffle: customBoardShuffle);
            listAvilableTile = game.CallPrivateMethod<List<int>>("GetTileAvilable");
            Assert.IsTrue(listAvilableTile.Count == 2);
            Assert.IsTrue(listAvilableTile.Contains(9));
            Assert.IsTrue(listAvilableTile.Contains(13));

            customBoardShuffle = new int[,]
            {
                {1,2,3,4 },
                {0,6,7,8 },
                {5,10,11,12 },
                {9,13,14,15 }
            };
            game.StartWithCustomBoard(customerBoardShuffle: customBoardShuffle);
            listAvilableTile = game.CallPrivateMethod<List<int>>("GetTileAvilable");
            Assert.IsTrue(listAvilableTile.Count == 3);
            Assert.IsTrue(listAvilableTile.Contains(1));
            Assert.IsTrue(listAvilableTile.Contains(6));
            Assert.IsTrue(listAvilableTile.Contains(5));

        }
        [TestMethod]
        public void IsPositionInRanget()
        {
            Game game = new Game(4, 4, new MockUI());
            List<Position> listInvalidPosition = new List<Position>()
            {
                new Position (-1,0),
                new Position (5,1),
                new Position (4,4),
                new Position (-1,-1),
                new Position (2,-1),
                new Position (5,4),
                new Position (4,5)
            };
            listInvalidPosition.ForEach(x => Assert.IsFalse(game.CallPrivateMethod<bool>("IsPositionInRange", x)));

            int i;
            int j;
            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j <= 3; j++)
                {
                    Assert.IsTrue(game.CallPrivateMethod<bool>("IsPositionInRange", new Position(i, j)));
                }
            }

        }



    }
}
