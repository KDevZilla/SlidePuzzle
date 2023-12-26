using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidePuzzle.UI
{
    public class BoardUI:Panel,IBoardUI
    {
        public int RowSize { get; private set; }
        public int ColSize { get; private set; }

        Dictionary<int, Label> DicTilt = new Dictionary<int, Label>();
        private int ConvertFromTableToLiner(int x, int y, int pRowSize)
        {
            return (y * pRowSize) + x + 1;
        }
        private int ConvertFromTableToLiner(int x, int y)
        {
            return ConvertFromTableToLiner(x, y, this.RowSize);
        }
        public Label lblTemplate = null;
        private Game game = null;
        int[,] board => game.board;
        
        public int BoardWidth { get; private set; }
        public int BoardHeight { get; private set; }
        public BoardUI (int RowSize, int ColSize, int BoardHeight, int BoardWidth)
        {
            this.RowSize = RowSize;
            this.ColSize = ColSize;
            this.BoardHeight = BoardHeight;
            this.BoardWidth = BoardWidth;

            TileWidth = BoardWidth / ColSize;
            TileHeight = BoardHeight / RowSize;
            this.Width = this.BoardWidth;
            this.Height = this.BoardHeight;

        }

        public void Initial(Game game)
        {
            if(lblTemplate ==null)
            {
                throw new Exception("Please set lblTemplate property first");
            }
           // lblTemplate = plblTemplate;
            int i;
            int j;
          //  board = new int[RowSize, RowSize];
          //  this.Height = lblTemplate.Height * RowSize;
          //  this.Width = lblTemplate.Width * ColSize;
            this.game = game;
            CreateTile();



        }
        private Boolean IsRenderImage => BoardImage != null;
        int TileWidth = 0;
        int TileHeight = 0;
        
        private void CreateTile()
        {
            int i = 0;

            this.Clear();

            int LastIndex = (RowSize * RowSize) - 2;

            for (i = 0; i <= LastIndex; i++)
            {

                int iRow = (i / RowSize);
                int iCol = (i % RowSize);

                Label L = new Label()
                {
                    Size = new Size(TileWidth , TileHeight ),
                    Font = lblTemplate.Font,
                    TextAlign = lblTemplate.TextAlign,
                    BorderStyle = lblTemplate.BorderStyle,
                    ForeColor = lblTemplate.ForeColor,
                    BackColor = lblTemplate.BackColor,
                    // Text = (i + 1).ToString(),
                    Text = board[iRow, iCol].ToString(),
                    Tag = (i + 1).ToString(),
                    Top = iRow * TileHeight ,
                    Left = iCol * TileWidth ,
                    Visible = true

                };
                if(IsRenderImage)
                {
                    DrawLabel(this.BoardImage  , L, iCol, iRow);
                    if(!IsShowNumberOverLay )
                    {
                        L.Text = "";
                    } else
                    {
                        L.TextAlign = ContentAlignment.TopLeft;
                    }
                }
                L.Click += labelClick;
                this.Controls.Add(L);
                DicTilt.Add(i + 1, L);
            }


        }
        public delegate void TiltClickHandler(int TileNumber);
        public event TiltClickHandler TiltClick; 

       // public void MoveUp()
        private void labelClick(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Label L = (Label)sender;
            int NumberClicked = int.Parse(L.Tag.ToString());
            //   MoveCell(index);
            TiltClick?.Invoke(NumberClicked);

       
            
        }

        public Image TileImage { get; set; }
        public Boolean IsCustomRender { get; set; }
        public bool IsShowNumberOverLay { get ; set ; }
        public Image BoardImage { get; set; }

        private void DrawLabel(Image img, Label L,int x,int y)
        {
            DrawLabel(img , L, x, y, 0, 0);
        }
        private void DrawLabel(Image img, Label L, int x, int y, int xOffSet, int yOffset)
        {
            Bitmap NewImage = new Bitmap(L.Width, L.Height);

            Graphics g = Graphics.FromImage(NewImage);

            NewImage.SetResolution(g.DpiX, g.DpiY);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;


            int lX = x * L.Width;
            int lY = y * L.Height;
              Rectangle rect = new Rectangle(lX + xOffSet, lY + yOffset, L.Width, L.Height);
            g.DrawImage(img , 0, 0, rect, GraphicsUnit.Pixel);

          
            L.Image = NewImage;


        }

        public void MoveTile(Position fromPosition, Position toPosition, Boolean isPerformAnimation)
        {
            //DicPosition []
         
            int FromValue = board[fromPosition.Row , fromPosition.Column ];

            int destinationTop = toPosition.Row  * TileHeight;
            int destinationLeft = toPosition.Column  * TileWidth;
            if (!isPerformAnimation)
            {
                DicTilt[FromValue].Top = destinationTop;
                DicTilt[FromValue].Left = destinationLeft;
                return;
            }



            int deltaY = 0;
            if(DicTilt[FromValue].Top < destinationTop)
            {
                deltaY = 1;
            };
            if(DicTilt[FromValue].Top > destinationTop)
            {
                deltaY = -1;
            }

            int deltaX = 0;


            if (DicTilt[FromValue].Left  < destinationLeft)
            {
                deltaX = 1;
            };
            if (DicTilt[FromValue].Left  > destinationLeft)
            {
                deltaX = -1;
            }

            int iCount = 0;
            while (true)
            {
                if(DicTilt[FromValue].Top == destinationTop  &&
                    DicTilt[FromValue].Left == destinationLeft)
                {
                    break;
                }

                DicTilt[FromValue].Top += deltaY;
                DicTilt[FromValue].Left += deltaX;

                if (iCount >= 10)
                {
                    // Application.DoEvents();
                    System.Threading.Thread.Sleep(1);
                   // Application.DoEvents();
                    iCount = 0;
                }
                iCount++;
                //DicTilt[FromValue].Left = toPosition.X * TileWidth;
            }


        }

        public void Clear()
        {
            this.Controls.Clear();
            DicTilt.Clear();
            // throw new NotImplementedException();
        }
        /*
void IBoardUI.MoveTile(Point fromPosition, Point toPosition)
{
   throw new NotImplementedException();
}
*/

    }
}
