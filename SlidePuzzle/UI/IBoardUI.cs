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
        void MoveTile(Position fromPosition, Position toPosition, Boolean isPerformAnimation);
        Boolean IsShowNumberOverLay { get; set; }
        Image BoardImage { get; set; }
        void Initial(Game game);
        void Clear();
    }
    public class MockUI : IBoardUI
    {
        public bool IsShowNumberOverLay { get; set; } = false;
        public Image BoardImage { get; set; } = null;

        public event TiltClickHandler TiltClick;

        public void Clear()
        {
           // throw new NotImplementedException();
        }
        private Game game = null;
        public void Initial(Game game)
        {
            this.game = game;
            //throw new NotImplementedException();
        }

        public void MoveTile(Position fromPosition, Position toPosition, bool isPerformAnimation)
        {
            game.SetBoardValue(toPosition, game.board[fromPosition.Row, fromPosition.Column]);
            game.SetBoardValue(fromPosition, 0);
            //throw new NotImplementedException();
        }
    }
}
