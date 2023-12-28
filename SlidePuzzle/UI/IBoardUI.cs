using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SlidePuzzle.UI.BoardUI;

namespace SlidePuzzle.UI
{
    public interface IBoardUI
    {
        event TiltClickHandler TiltClick;
        void MoveTile(Position fromPosition, Position toPosition);
        void MoveTiteNoAnimation(Position fromPosition, Position toPosition);
        Boolean IsShowNumberOverLay { get; set; }
        int TileMoveSpeed { get; set; }
        Image BoardImage { get;  }
        void Initial(Game game);
        void Clear();
    }
    public class MockUI : IBoardUI
    {
        public bool IsShowNumberOverLay { get; set; } = false;
        public Image BoardImage { get; set; } = null;
        public int TileMoveSpeed { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public event TiltClickHandler TiltClick;

        public void Clear()
        {
           // throw new NotImplementedException();
        }
       // private Game game = null;
        public void Initial(Game game)
        {
            //this.game = game;
            //throw new NotImplementedException();
        }

        public void MoveTile(Position fromPosition, Position toPosition)
        {
            //game.SetBoardValue(toPosition, game.board[fromPosition.Row, fromPosition.Column]);
           // game.SetBoardValue(fromPosition, 0);
            //throw new NotImplementedException();
        }

        public void MoveTiteNoAnimation(Position fromPosition, Position toPosition)
        {
           // throw new NotImplementedException();
        }
    }
}
