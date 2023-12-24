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
        Dictionary<int, Position> DicPositionFromNumber = new Dictionary<int, Position>();
        Dictionary<String, int> DicNumberFromPosition = new Dictionary<String, int>();
        Position PositionZero  = Position.Empty;

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


        private bool IsPositionInRange(Position P) => P.Row  >= 0 &&
                P.Row < RowSize &&
                P.Column  >= 0 &&
                P.Column  < ColSize;
        private List<Position> _listPosition = null;
        private List<Position> listPosition
        {
            get
            {
                if(_listPosition == null)
                {
                    _listPosition = new List<Position>();
                    Position positionUp = new Position(PositionZero.Row - 1, PositionZero.Column);
                    Position positionDown = new Position(PositionZero.Row, PositionZero.Column);
                    Position positionLeft = new Position(PositionZero.Row, PositionZero.Column - 1);
                    Position positionRight = new Position(PositionZero.Row, PositionZero.Column + 1);
                    //List<Position> listPoint = new List<Position>();
                    _listPosition.Add(positionUp);
                    _listPosition.Add(positionDown);
                    _listPosition.Add(positionLeft);
                    _listPosition.Add(positionRight);
                }
                return _listPosition;
            }
        }
        private List<int> GetTileAvilable()
        {
            
            List<int> listResult = new List<int>();


            //listPosition.ForEach (x=> if(IsPositionInRange (x)) listResult.Add(DicNumberFromPosition[poi])  )
            foreach (Position poi in listPosition )
            {
                if (!IsPositionInRange(poi))
                {
                    continue;
                }
                listResult.Add(DicNumberFromPosition[poi.key]);
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
            Position FromPoint = DicPositionFromNumber[FromPosition];
            int i;
            int j;

            if (FromPoint.Column  + 1 == PositionZero.Column  &&
                FromPoint.Row  == PositionZero.Row )
            {
                return DirectionEnum.Right;
            }
            if (FromPoint.Column  == PositionZero.Column  &&
                FromPoint.Row  + 1 == PositionZero.Row )
            {
                return DirectionEnum.Down;
            }

            if (FromPoint.Column  - 1 == PositionZero.Column  &&
                FromPoint.Row  == PositionZero.Row)
            {
                return DirectionEnum.Left;
            }

            if (FromPoint.Column  == PositionZero.Column &&
                FromPoint.Row  - 1 == PositionZero.Row )
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
                    SetBoardValue(new Position(i,j),Value);
                    Finishedboard[i, j] = Value;

                }
            }

            PositionZero = new Position(RowSize - 1, ColSize - 1);
            
            Finishedboard[PositionZero.Row , PositionZero.Column] = 0;
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

        public void SetBoardValue(Position position, int Value)
        {
            board[position.Row , position.Column ] = Value;

            if (!DicPositionFromNumber.ContainsKey(Value))
            {
                DicPositionFromNumber.Add(Value, Position.Empty);
            }
            if (!DicNumberFromPosition.ContainsKey(position.key))
            {
                DicNumberFromPosition.Add(position.key, -1);
            }


            DicPositionFromNumber[Value] = position;
            DicNumberFromPosition[position.key] = Value;

            if (Value == 0)
            {
                PositionZero = position;
            }

        }
        public void MoveTile(Position fromPosition, Position toPosition)
        {
            //DicPosition []
            /*
            if (toPosition.Column  != PositionZero.Column  ||
                toPosition.Row  != PositionZero.Row)
            {
                throw new Exception($"Cannot move to {toPosition.Row.ToString()} ,{toPosition.Column.ToString()}");
            }
            */
            // int LabelValue = ConvertFromTableToLiner(fromPosition.X, fromPosition.Y);

            int FromValue = board[fromPosition.Row , fromPosition.Column ];
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

        public Position GetNeibhourPosition(Position fromPosition, DirectionEnum direction)
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
            //Point PResult = new Point(fromPosition.Column  + Dx, fromPosition.Y + Dy);
            Position positionResult = new Position(fromPosition.Row + Dy, fromPosition.Column + Dx);
            String ExceptionMessage = "";
            if (positionResult.Column < 0 
              || positionResult.Column  >= ColSize
              || positionResult.Row  < 0 
              || positionResult.Row  >= RowSize)
            {
                ExceptionMessage = $" Result is {PositionStr(positionResult)} which is not correct ";
                throw new Exception(ExceptionMessage);
            }

            return positionResult;

        }
        private String PositionStr(Position position) => $"Row:{position.Row}, Column:{position.Column}";

        
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
        public void MoveCell(int index,Boolean isPerformAnimation)
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

            Position FromPosition = DicPositionFromNumber[index];
            Position ToPosition = GetNeibhourPosition(FromPosition, MovetoEmptyDirection);


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
