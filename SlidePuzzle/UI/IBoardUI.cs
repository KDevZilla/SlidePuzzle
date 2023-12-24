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
        void MoveTile(Point fromPosition, Point toPosition, Boolean isPerformAnimation);
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

        public void Initial(Game game)
        {
            //throw new NotImplementedException();
        }

        public void MoveTile(Point fromPosition, Point toPosition, bool isPerformAnimation)
        {
            //throw new NotImplementedException();
        }
    }
}
