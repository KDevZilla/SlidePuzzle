using SlidePuzzle.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzle
{
    public class Game
    {
        public int[,] board {  get; private set; }
        public int[,] Finishedboard { get; private set; }
        public int RowSize { get; private set; }
        public int ColSize { get; private set; }
        Dictionary<int, Point> DicPositionFromNumber = new Dictionary<int, Point>();
        Dictionary<Point, int> DicNumberFromPosition = new Dictionary<Point, int>();
        Point PositionZero = new Point();

        public enum GameStateEnum
        {
            Shuffle,
            Running,
            SolvingByBot,
            Stop
        }
        public GameStateEnum GameState { get; private set; }

        public enum DirectionEnum
        {
            Up,
            Right,
            Down,
            Left,
            None
        }
        public DirectionEnum GetOppositeDirection(DirectionEnum Dir)
        {
            switch (Dir)
            {
                case DirectionEnum.Left:
                    return DirectionEnum.Right;

                case DirectionEnum.Right:
                    return DirectionEnum.Left;

                case DirectionEnum.Up:
                    return DirectionEnum.Down;

                case DirectionEnum.Down:
                    return DirectionEnum.Up;
                default:
                    throw new Exception("Direction cannot be None ");
            }
        }
        private IBoardUI ui = null;
        public Game(int RowSize, int ColSize,IBoardUI UI)
        {
            board = new int[RowSize, ColSize];
            Finishedboard = new int[RowSize, ColSize];

            this.RowSize = RowSize;
            this.ColSize = ColSize;
            DicPositionFromNumber.Clear();
            DicNumberFromPosition.Clear();
            ui = UI;
            ui.TiltClick -= Ui_TiltClick;
            ui.TiltClick += Ui_TiltClick;
            this.GameState = GameStateEnum.Stop;
            isInitialed = false;
        }
        public void Clear()
        {
            if(ui!=null)
            {
                ui.TiltClick -= Ui_TiltClick;
          
            }
            ui = null;

            DicPositionFromNumber.Clear();
            DicNumberFromPosition.Clear();
            board = null;

        }


        private bool IsPositionInRange(Point P) => P.X >= 0 &&
                P.X < RowSize &&
                P.Y >= 0 &&
                P.Y < RowSize;

        private List<int> GetTileAvilable()
        {
            Point PUp = new Point(PositionZero.X, PositionZero.Y - 1);
            Point PDown = new Point(PositionZero.X, PositionZero.Y + 1);
            Point PLeft = new Point(PositionZero.X - 1, PositionZero.Y);
            Point PRight = new Point(PositionZero.X + 1, PositionZero.Y);
            List<int> listResult = new List<int>();
            List<Point> listPoint = new List<Point>();
            listPoint.Add(PUp);
            listPoint.Add(PDown);
            listPoint.Add(PLeft);
            listPoint.Add(PRight);
            foreach (Point poi in listPoint)
            {
                if (!IsPositionInRange(poi))
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

        Random R = new Random();
        public void StartWithCustomBoard(int[,] customerBoardShuffle)
        {
            if (customerBoardShuffle == null
  || customerBoardShuffle.GetUpperBound(0) != board.GetUpperBound(0)
  || customerBoardShuffle.GetUpperBound(1) != board.GetUpperBound(1))
            {
                throw new Exception("If isNeedtoShuffle is false, the caller need to send customerBoardShuffle");
            }

            this.board = (int[,])customerBoardShuffle.Clone();
            this.GameState = GameStateEnum.Running;
        }
        public void StartWithAutomaticShuffle()
        {

            GameState = GameStateEnum.Shuffle;
            Shuffle();
            GameState = GameStateEnum.Running;

        }
        public void Shuffle()
        {
            int iLoop = 0;
            int iMaxLoop = 3;
            int i = 0;
            for (iLoop = 1; iLoop <= iMaxLoop; iLoop++)
            {
                //   this.Initial();
                int PreviousInt = -1;

             //   this.panel1.Visible = false;
                for (i = 1; i <= 100; i++)
                {
                    
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


                    MoveCell(CandidateTilt, isPerformAnimation: false);
                     
                    //System.Threading.Thread.Sleep(5);
                }
                // this.panel1.Visible = true;
                /*
                string str = ShowValue(board, iLoop, 5, 5);
                strB.Append(str)
                    .Append(Environment.NewLine);
                */
            }

            //this.panel1.Visible = true;

           
        }
        public bool isInitialed { get; private set; } = false;
        public void Initial()
        {
            int i;
            int j;
            for (i = 0; i < RowSize; i++)
            {
                for(j=0;j<ColSize;j++)
                {
                    int Value = (i * RowSize) + (j + 1);
                    SetBoardValue(new Point(j, i),Value);
                    Finishedboard[i, j] = Value;

                }
            }

            PositionZero.X = ColSize - 1;
            PositionZero.Y = RowSize - 1;
            Finishedboard[PositionZero.Y, PositionZero.X] = 0;
            SetBoardValue(PositionZero, 0);

            ui.Initial(this);
            isInitialed = true;
        }
        public event EventHandler Won;
        private void Ui_TiltClick(int TileNumber)
        {
            if(GameState != GameStateEnum.Running)
            {
                return;
            }

            // throw new NotImplementedException();

            MoveCell(TileNumber, isPerformAnimation:true);
            if (this.IsInFinishedPosition)
            {
                GameState = GameStateEnum.Stop;
                if(Won!=null)
                {
                    Won(this, new EventArgs());
                }
            }
         
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


          //  ui.MoveTile ()
           // DicTilt[FromValue].Top = toPosition.Y * lblTemplate.Height;
           // DicTilt[FromValue].Left = toPosition.X * lblTemplate.Width;
           /*
            this.textBox1.Text += fromPosition.Y + "," + fromPosition.X + "=>" +
                toPosition.Y + "," + toPosition.X + Environment.NewLine;
                */

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
        public bool IsInFinishedPosition
        {
            get
            {
                if (!isInitialed)
                {
                    return false;
                }
                
                int i;
                int j;
                for (i = 0; i < RowSize; i++)
                {
                    for(j=0;j<ColSize;j++)
                    {
                        if(Finishedboard [i,j] !=
                            board[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        private void MoveCell(int index,Boolean isPerformAnimation)
        {
            if(GameState == GameStateEnum.Stop )
            {
                return;
            }

            DirectionEnum MovetoEmptyDirection = GetPositionAviable(index);
            if (MovetoEmptyDirection == DirectionEnum.None)
            {
                return;
            }

            Point FromPosition = DicPositionFromNumber[index];
            Point ToPosition = GetNeibhourPosition(FromPosition, MovetoEmptyDirection);


            ui.MoveTile(FromPosition, ToPosition, isPerformAnimation);
            MoveTile(FromPosition, ToPosition);


        }
        /*
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
        */

    }
}
