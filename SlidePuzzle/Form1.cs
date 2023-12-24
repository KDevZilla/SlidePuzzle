using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static SlidePuzzle.Game;

namespace SlidePuzzle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //List<Label> lstTilt = new List<Label>();
        int[,] board = new int[4, 4];
        Dictionary<int, Label> DicTilt = new Dictionary<int, Label>();
        Dictionary<int, Point> DicPositionFromNumber = new Dictionary<int, Point>();
        Dictionary<Point, int> DicNumberFromPosition = new Dictionary<Point, int>();
     
     
        private int ConvertFromTableToLiner(int x, int y, int pRowSize)
        {
            return (y * pRowSize) + x + 1;
        }
        private int ConvertFromTableToLiner(int x, int y)
        {
            return ConvertFromTableToLiner(x, y, this.RowSize);
        }

        private Point ConvertFromLinerToTable(int Index, int pRowSize)
        {
            int iRow = (Index / pRowSize);
            int iCol = (Index % pRowSize) - 1;
            Point PointResult = new Point(iCol, iRow);
            return PointResult;
        }
        private Point ConvertFromLinerToTable(int Index)
        {
            return ConvertFromLinerToTable(Index, RowSize);
        }

        Boolean IsCustomRender = true;
        private void LoadTileImage()
        {
            String fileName = @"D:\Krirk\Pictures\Gadget\GG1.jpeg";
            Bitmap B = (Bitmap)Image.FromFile(fileName);
            _TileImage = B;
        }
        private Bitmap _TileImage = null;
        private Bitmap TileImage
        {
            get
            {
                if (_TileImage == null)
                {
                    LoadTileImage();
                }
                return _TileImage;
            }
        }
        private void Log(String str)
        {
            this.textBox1.AppendText(str + Environment.NewLine);
        }
        private void L_Paint(object sender, PaintEventArgs e)
        {

            if (!IsCustomRender)
            {
                return;
            }
            /*
            Label L = (Label)sender;
            Rectangle R = new Rectangle(L.Left, L.Top, L.Width, L.Height);
            
            L.CreateGraphics().DrawImage(this.TileImage, R);
            */

            // e.Graphics.Clip = new Region(R);
            // Log("Left " + L.Left.ToString() + "  Top " + L.Top.ToString());


            //   throw new NotImplementedException();
        }

        private void DrawLabel(Label L, int x, int y)
        {
            Bitmap NewImage = new Bitmap(L.Width, L.Height);
            Graphics g = Graphics.FromImage(NewImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes  

            int lX = x * L.Width;
            int lY = y * L.Height;
            Log("DrawLabel " + L.Tag.ToString() + " lx :" + lX.ToString() + " ly :" + lY.ToString());

            Rectangle rect = new Rectangle(lX, lY, L.Width, L.Height);


            g.DrawImage(this.TileImage, 0, 0, rect, GraphicsUnit.Pixel);
            //NewImage.Save(@"D:\temp\MytestImag3.jpeg");
            L.Image = NewImage;


        }
        private void button3_Click(object sender, EventArgs e)
        {
            // this.label1.Image = this.BackGroundImage;
            //Graphics g = Graphics.FromImage(this.TileImage);
            //  Graphics g = lblImgTemp.CreateGraphics();

            int i;
            for (i = 0; i <= 14; i++)
            {
                Point P = ConvertFromLinerToTable(i + 1);

                DrawLabel(DicTilt[i + 1], P.X, P.Y);
                DicTilt[i + 1].Text = "";

            }
            /*
            Bitmap BNew = CopyGraphicsContent(g, new Rectangle(0, 0, this.label1.Width, this.label1.Height));

            this.label1.Image = BNew;


            BNew.Save(@"D:\temp\MytestImage2.jpeg");
            */
            /*

            Bitmap NewImage = new Bitmap(this.label1.Width, this.label1.Height);
            Graphics g = Graphics.FromImage(NewImage);
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes  
            Rectangle rect = new Rectangle(0, 0, label1.Width, label1.Height);

            g.DrawImage(this.TileImage , 0, 0, rect, GraphicsUnit.Pixel);
            //NewImage.Save(@"D:\temp\MytestImag3.jpeg");
            this.label1.Image = NewImage;
            */


            /*
            Bitmap OriginalImage = new Bitmap( this.label1.Width, this.label1.Height);
            
            // create graphics  
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighQuality;
            g.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;
            //set image attributes  
            Rectangle rect = new Rectangle(0, 0, label1.Width, label1.Height);

            g.DrawImage(OriginalImage, 0, 0, rect, GraphicsUnit.Pixel);
          //  this.label1.Image = this.TileImage ;
            OriginalImage.Save(@"D:\temp\MytestImage.jpg");
            */
        }
        private void button1_Click(object sender, EventArgs e)
        {
            RowSize = 3;

         //   this.Initial();
            this.button1.Hide();
            this.button2.Hide();

        }
        int RowSize = 5;
        private bool IsPositionInRange(Point P)
        {
            if (P.X < 0 || 
                P.X >= RowSize ||
                P.Y < 0 ||
                P.Y >= RowSize)
            {
                return false;
            }
            return true;
        }
        
        private List<int> GetTileAvilable()
        {
            Point PUp = new Point(PositionZero.X, PositionZero.Y - 1);
            Point PDown = new Point(PositionZero.X, PositionZero.Y + 1);
            Point PLeft = new Point(PositionZero.X -1, PositionZero.Y );
            Point PRight = new Point(PositionZero.X + 1, PositionZero.Y );
            List<int> listResult = new List<int>();
            List<Point> listPoint = new List<Point>();
            listPoint.Add(PUp);
            listPoint.Add(PDown);
            listPoint.Add(PLeft);
            listPoint.Add(PRight);
            foreach (Point poi in listPoint)
            {
                if(!IsPositionInRange(poi))
                {
                    continue;
                }
                listResult.Add(DicNumberFromPosition[poi]);
            }
            return listResult;
        }
        private DirectionEnum GetPositionAviable(int FromPosition)
        {
            if (!DicPositionFromNumber.ContainsKey(FromPosition))
            {
                throw new Exception("Postion is incorrect " + FromPosition.ToString());
            }
            DirectionEnum DirectionResult = DirectionEnum.None;
            //Point FromPoint = ConvertFromLinerToTable(FromPosition, 4);
            Point FromPoint = DicPositionFromNumber[FromPosition];
            int i;
            int j;

            if (FromPoint.X + 1 == PositionZero.X &&
                FromPoint.Y == PositionZero.Y)
            {
                return DirectionEnum.Right;
            }
            if (FromPoint.X == PositionZero.X &&
                FromPoint.Y + 1 == PositionZero.Y)
            {
                return DirectionEnum.Down;
            }

            if (FromPoint.X - 1 == PositionZero.X &&
                FromPoint.Y == PositionZero.Y)
            {
                return DirectionEnum.Left;
            }

            if (FromPoint.X == PositionZero.X &&
                FromPoint.Y - 1 == PositionZero.Y)
            {
                return DirectionEnum.Up;
            }

            return DirectionEnum.None;
        }
        
        
        public void SetBoardValue(Point position, int Value)
        {
            board[position.Y, position.X] = Value;

            if (!DicPositionFromNumber.ContainsKey(Value))
            {
                DicPositionFromNumber.Add(Value, new Point(-1, -1));
            }
            if (!DicNumberFromPosition.ContainsKey(position))
            {
                DicNumberFromPosition.Add(position, -1);
            }


            DicPositionFromNumber[Value] = position;
            DicNumberFromPosition[position] = Value;

            if (Value == 0)
            {
                PositionZero = position;
            }

        }
        
        
        public void MoveTile(Point fromPosition, Point toPosition)
        {
            //DicPosition []
            if (toPosition.X != PositionZero.X ||
                toPosition.Y != PositionZero.Y)
            {
                throw new Exception("Cannot move to " + toPosition.Y.ToString() + " " + toPosition.X.ToString());
            }
            // int LabelValue = ConvertFromTableToLiner(fromPosition.X, fromPosition.Y);

            int FromValue = board[fromPosition.Y, fromPosition.X];
            SetBoardValue(toPosition, FromValue);
            SetBoardValue(fromPosition, 0);
            DicTilt[FromValue].Top = toPosition.Y * lblTemplate.Height;
            DicTilt[FromValue].Left = toPosition.X * lblTemplate.Width;
            this.textBox1.Text += fromPosition.Y + "," + fromPosition.X + "=>" +
                toPosition.Y + "," + toPosition.X + Environment.NewLine;


        }
        public Point GetNeibhourPosition(Point fromPosition, DirectionEnum direction)
        {
            int Dx = 0;
            int Dy = 0;
            switch (direction)
            {
                case DirectionEnum.Up:
                    Dy = -1;
                    break;
                case DirectionEnum.Right:
                    Dx = 1;
                    break;
                case DirectionEnum.Down:
                    Dy = 1;
                    break;
                case DirectionEnum.Left:
                    Dx = -1;
                    break;
            }
            Point PResult = new Point(fromPosition.X + Dx, fromPosition.Y + Dy);
            String ExceptionMessage = "";
            if (PResult.X < 0 || PResult.X >= RowSize
              || PResult.Y < 0 || PResult.Y >= RowSize)
            {
                ExceptionMessage = " Result is " + PointStr(PResult) + " which is not correct ";
                throw new Exception(ExceptionMessage);
            }

            return PResult;

        }
        private String PointStr(Point pPoint)
        {
            return "X::" + pPoint.X.ToString() +
                "Y::" + pPoint.Y;
        }
        private void MoveCell(int index)
        {
            DirectionEnum MovetoEmptyDirection = GetPositionAviable(index);
            if (MovetoEmptyDirection == DirectionEnum.None)
            {
                return;
            }

            Point FromPosition = DicPositionFromNumber[index];
            Point ToPosition = GetNeibhourPosition(FromPosition, MovetoEmptyDirection);

            MoveTile(FromPosition, ToPosition);
        }
        private void L_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            Label L = (Label)sender;
            int index = int.Parse(L.Tag.ToString());
            MoveCell(index);


        }
        private void RenderLabel()
        {

        }

        Point PositionZero = new Point();
        private void Form1_Load(object sender, EventArgs e)
        {
            this.KeyPreview = true;
            this.KeyDown += Form1_KeyDown;
            Initial();

        }
        public void Initial()
        {
            int i;
            int j;
            for (i = 0; i < RowSize; i++)
            {
                for (j = 0; j < RowSize ; j++)
                {
                    int Value = (i * RowSize) + (j + 1);
                    SetBoardValue(new Point(j, i), Value);
                   // Finishedboard[i, j] = Value;

                }
            }

            PositionZero.X = RowSize  - 1;
            PositionZero.Y = RowSize - 1;
          //  Finishedboard[PositionZero.Y, PositionZero.X] = 0;
            SetBoardValue(PositionZero, 0);

          //  ui.Initial(this);
        }
        private void CreateTile()
        {
            int i = 0;
            this.panel1.Controls.Clear();
            DicTilt.Clear();
            int LastIndex = (RowSize * RowSize) - 2;
            for (i = 0; i <= LastIndex; i++)
            {

                int iRow = (i / RowSize);
                int iCol = (i % RowSize);

                Label L = new Label()
                {
                    Size = new Size(lblTemplate.Width, lblTemplate.Height),
                    Font = lblTemplate.Font,
                    TextAlign = lblTemplate.TextAlign,
                    BorderStyle = lblTemplate.BorderStyle,
                    ForeColor = lblTemplate.ForeColor,
                    BackColor = lblTemplate.BackColor,
                    // Text = (i + 1).ToString(),
                    Text = board[iRow, iCol].ToString (),
                    Tag = (i + 1).ToString(),
                    Top = iRow * lblTemplate.Height,
                    Left = iCol * lblTemplate.Width,
                    Visible = true

                };
                
              //  L.Click += L_Click;
                L.Paint += L_Paint;
                

                this.panel1.Controls.Add(L);
                DicTilt.Add(i + 1, L);
            }
       

        }
        public DirectionEnum GetOppositeDirection(DirectionEnum Dir)
        {
            switch (Dir)
            {
                case DirectionEnum.Left:
                    return DirectionEnum.Right;
                    break;
                case DirectionEnum.Right:
                    return DirectionEnum.Left;
                    break;
                case DirectionEnum.Up:
                    return DirectionEnum.Down;
                    break;
                case DirectionEnum.Down:
                    return DirectionEnum.Up;
                    break;
                default:
                    throw new Exception("Direction cannot be None ");
            }
        }
        /*
        private Label GetTitle(System.Windows.Forms.Keys key)
        {
            //Game g = new Game(5,5,new UI.IBoardUI);
          //  DirectionEnum Dir = ConvertKeysToDirection(key);
            DirectionEnum OppositeDir = GetOppositeDirection(Dir);

            if (OppositeDir == DirectionEnum.None)
            {
                throw new Exception("Key is invalid " + key.ToString());
            }
            Point Poi = new Point(-1, -1);
            try
            {
                Poi = GetNeibhourPosition(PositionZero, OppositeDir);
            }
            catch (Exception e)
            {
                //It mean the position is invalid;

                return null;
            }
            if (!DicNumberFromPosition.ContainsKey(Poi))
            {
                throw new Exception("Position is invalid " + PointStr(Poi));
            }
            int NumberofTile = DicNumberFromPosition[Poi];

            if (!DicTilt.ContainsKey(NumberofTile))
            {
                throw new Exception("Number of Title is invalid " + NumberofTile);
            }

            return DicTilt[NumberofTile];

            // Label L = board[Poi.Y, Poi.X];

        }
        */

        
        
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
            if (e.KeyCode == Keys.Left ||
                e.KeyCode == Keys.Right ||
                e.KeyCode == Keys.Up ||
                e.KeyCode == Keys.Down)
            {
                /*
                Label L = GetTitle(e.KeyCode);
                if (L == null)
                {
                    return;
                }
                */

              //  L_Click(L, null);
            }


        }
        


        private void button2_Click(object sender, EventArgs e)
        {
            int i = 0;
            int j = 0;

            StringBuilder strB = new StringBuilder();
            /*
            for (i = 0; i <= 3; i++)
            {
                for (j = 0; j <= 3; j++)
                {
                    int TitleValue = ConvertFromTableToLiner(j, i);
                    strB.Append(i.ToString() + ":" + j.ToString() + " " + TitleValue)
                        .Append(Environment.NewLine);
                }
            }
            */
            for (i = 0; i <= 14; i++)
            {
                Point P = ConvertFromLinerToTable(i + 1);
                strB.Append((i + 1).ToString() + ":" + P.Y + " ," + P.X).Append(Environment.NewLine);
            }

            this.textBox1.Text = strB.ToString();
        }

        private void DrawLabel(Graphics pGra, Label L)
        {
            Bitmap b = new Bitmap(L.Width, L.Height);
            L.DrawToBitmap(b, new Rectangle(0, 0, b.Width, b.Height));

            Image image = b;
            Point[] destinationPoints = {
new Point(L.Left , L.Top ),   // destination for upper-left point of
                      // original
new Point(L.Left + L.Width , L.Top ),  // destination for upper-right point of
                      // original
new Point(L.Left , L.Top + L.Height)};  // destination for lower-left point of
                                        // original
            pGra.DrawImage(image, destinationPoints);
        }



        enum TernaryRasterOperations : uint
        {
            /// <summary>dest = source</summary>
            SRCCOPY = 0x00CC0020,
            /// <summary>dest = source OR dest</summary>
            SRCPAINT = 0x00EE0086,
            /// <summary>dest = source AND dest</summary>
            SRCAND = 0x008800C6,
            /// <summary>dest = source XOR dest</summary>
            SRCINVERT = 0x00660046,
            /// <summary>dest = source AND (NOT dest)</summary>
            SRCERASE = 0x00440328,
            /// <summary>dest = (NOT source)</summary>
            NOTSRCCOPY = 0x00330008,
            /// <summary>dest = (NOT src) AND (NOT dest)</summary>
            NOTSRCERASE = 0x001100A6,
            /// <summary>dest = (source AND pattern)</summary>
            MERGECOPY = 0x00C000CA,
            /// <summary>dest = (NOT source) OR dest</summary>
            MERGEPAINT = 0x00BB0226,
            /// <summary>dest = pattern</summary>
            PATCOPY = 0x00F00021,
            /// <summary>dest = DPSnoo</summary>
            PATPAINT = 0x00FB0A09,
            /// <summary>dest = pattern XOR dest</summary>
            PATINVERT = 0x005A0049,
            /// <summary>dest = (NOT dest)</summary>
            DSTINVERT = 0x00550009,
            /// <summary>dest = BLACK</summary>
            BLACKNESS = 0x00000042,
            /// <summary>dest = WHITE</summary>
            WHITENESS = 0x00FF0062,
            /// <summary>
            /// Capture window as seen on screen.  This includes layered windows 
            /// such as WPF windows with AllowsTransparency="true"
            /// </summary>
            CAPTUREBLT = 0x40000000
        }

        [DllImport("gdi32.dll", EntryPoint = "BitBlt", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool BitBlt([In] IntPtr hdc, int nXDest, int nYDest, int nWidth, int nHeight, [In] IntPtr hdcSrc, int nXSrc, int nYSrc, TernaryRasterOperations dwRop);

        public static Bitmap CopyGraphicsContent(Graphics source, Rectangle rect)
        {
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);

            using (Graphics dest = Graphics.FromImage(bmp))
            {
                IntPtr hdcSource = source.GetHdc();
                IntPtr hdcDest = dest.GetHdc();

                BitBlt(hdcDest, 0, 0, rect.Width, rect.Height, hdcSource, rect.X, rect.Y, TernaryRasterOperations.SRCCOPY);

                source.ReleaseHdc(hdcSource);
                dest.ReleaseHdc(hdcDest);
            }

            return bmp;
        }
        Random R = new Random();
        private void button4_Click(object sender, EventArgs e)
        {
            //this.textBox1.Text = PositionZero.X + " " + PositionZero.Y;

            int i;


            int iLoop;
            StringBuilder strB = new StringBuilder();
            int iMaxLoop = 50;
            for (iLoop = 1; iLoop <= iMaxLoop ; iLoop++)
            {
             //   this.Initial();
                int PreviousInt = -1;
                this.panel1.Visible = false;
                for (i = 1; i <= 100; i++)
                {
                    /*
                    List<int> listTilt = GetTileAvilable();
                    int CandidateTilt = listTilt[0];
                    CandidateTilt = listTilt[R.Next(0, listTilt.Count)];
                    if (PreviousInt == -1)
                    {
                        PreviousInt = CandidateTilt;
                    }
                    else
                    {
                        while (PreviousInt == CandidateTilt)
                        {
                            CandidateTilt = R.Next(0, listTilt.Count);
                        }
                        PreviousInt = CandidateTilt;

                    }
                    */

                   // MoveCell(CandidateTilt);
                    //System.Threading.Thread.Sleep(5);
                }
               // this.panel1.Visible = true;
                string str = ShowValue(board,iLoop , 5, 5);
                strB.Append(str)
                    .Append(Environment.NewLine);
            }
            this.panel1.Visible = true;

            Clipboard.SetText(strB.ToString());


        }

        public string ShowValue(int[,] Value,int index, int NoofRow, int NoofCol)
        {
            StringBuilder strB = new StringBuilder();
            int i;
            int j;
            //  strB.Append("===============").Append(Environment.NewLine);
            strB.Append("int[,] Values" + index.ToString () + " = new int[,] " +
                "{").Append(Environment.NewLine);

            for (i = 0; i < NoofRow; i++)
            {
                strB.Append("{");
                for (j = 0; j < NoofCol; j++)
                {
                    string ValueString = Value[i, j].ToString();
                    if (ValueString.Length < 2)
                    {
                        ValueString = " " + ValueString;
                    }
                    if (j == 0)
                    {
                        ValueString = " " + ValueString;
                    }
                    if (j == NoofCol - 1)
                    {
                        ValueString = ValueString + " ";
                    }
                    strB.Append(ValueString);
                    if (j < NoofCol - 1)
                    {
                        strB.Append("  ,");
                    }
                }
                //strB.Append("}");
                if (i < NoofRow)
                {
                    strB.Append("},");
                    strB.Append(Environment.NewLine);

                    // strB.Append(Environment.NewLine);
                }

                //strB.Append("===============").Append(Environment.NewLine);
            }
            strB.Append("};").Append(Environment.NewLine);
            // strB.Append("   Score:").Append(_Score.ToString()).Append(Environment.NewLine);
            // strB.Append("       RowSpace:").Append(RowSpace.ToString()).Append(Environment.NewLine);
            //strB.Append("       ColSpace:").Append(ColSpace.ToString()).Append(Environment.NewLine);
            return strB.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";

        }

        private void button6_Click(object sender, EventArgs e)
        {
            StringBuilder strB = new StringBuilder();
            int i;
            for(i=1;i<=50;i++)
            {
                strB.Append("listTest.Add(Values" + i.ToString() + ");")
                    .Append(Environment.NewLine);
            }
            Clipboard.SetText(strB.ToString());
        }
    }
}
