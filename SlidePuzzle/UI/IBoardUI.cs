using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static KSlider.UI.BoardUI;

namespace KSlider.UI
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
}
