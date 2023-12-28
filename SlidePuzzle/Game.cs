using SlidePuzzle.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public class Game : INotifyPropertyChanged
    {
        public int boardValue(Position position)
        {
            return board[position.Row, position.Column];
        }
        public int[,] board {  get; private set; }
        public int[,] GoalStateboard { get; private set; } 
        public int RowSize { get; private set; }
        public int ColSize { get; private set; }
        Dictionary<int, Position> DicPositionFromNumber = new Dictionary<int, Position>();
        Dictionary<String, int> DicNumberFromPosition = new Dictionary<String, int>();

        //The cell that can move must be the neighbor of the number zero
        public Position PositionOfNumberZero { get; private set; } = Position.Empty;

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
            GoalStateboard = new int[RowSize, ColSize];

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
     

        private List<int> GetTileAvilable()
        {
            List<Position> listPositionNextoNumberZero = new List<Position>();
            List<int> listResult = new List<int>();

            Position positionUp = new Position(PositionOfNumberZero.Row - 1, PositionOfNumberZero.Column);
            Position positionDown = new Position(PositionOfNumberZero.Row + 1, PositionOfNumberZero.Column);
            Position positionLeft = new Position(PositionOfNumberZero.Row, PositionOfNumberZero.Column - 1);
            Position positionRight = new Position(PositionOfNumberZero.Row, PositionOfNumberZero.Column + 1);
            //List<Position> listPoint = new List<Position>();
            listPositionNextoNumberZero.Add(positionUp);
            listPositionNextoNumberZero.Add(positionDown);
            listPositionNextoNumberZero.Add(positionLeft);
            listPositionNextoNumberZero.Add(positionRight);
            //listPosition.ForEach (x=> if(IsPositionInRange (x)) listResult.Add(DicNumberFromPosition[poi])  )
            foreach (Position poi in listPositionNextoNumberZero )
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

            if (FromPoint.Column  + 1 == PositionOfNumberZero.Column  &&
                FromPoint.Row  == PositionOfNumberZero.Row )
            {
                return DirectionEnum.Right;
            }
            if (FromPoint.Column  == PositionOfNumberZero.Column  &&
                FromPoint.Row  + 1 == PositionOfNumberZero.Row )
            {
                return DirectionEnum.Down;
            }

            if (FromPoint.Column  - 1 == PositionOfNumberZero.Column  &&
                FromPoint.Row  == PositionOfNumberZero.Row)
            {
                return DirectionEnum.Left;
            }

            if (FromPoint.Column  == PositionOfNumberZero.Column &&
                FromPoint.Row  - 1 == PositionOfNumberZero.Row )
            {
                return DirectionEnum.Up;
            }

            return DirectionEnum.None;
        }

        Random R = new Random();
        public void StartWithCustomBoard(int[,] customerBoardShuffle)
        {
            NoofMoves = 0;
            if (customerBoardShuffle == null
  || customerBoardShuffle.GetUpperBound(0) != board.GetUpperBound(0)
  || customerBoardShuffle.GetUpperBound(1) != board.GetUpperBound(1))
            {
                throw new Exception("If isNeedtoShuffle is false, the caller need to send customerBoardShuffle");
            }

            int i;
            int j;
            for (i = 0; i < RowSize; i++)
            {
                for (j = 0; j < ColSize; j++)
                {
                    int Value = customerBoardShuffle [i,j];
                    SetBoardValue(new Position(i, j), Value);
                }
            }
            /*
            PositionOfNumberZero = new Position(RowSize - 1, ColSize - 1);

            Finishedboard[PositionOfNumberZero.Row, PositionOfNumberZero.Column] = 0;
            SetBoardValue(PositionOfNumberZero, 0);
            this.board = (int[,])customerBoardShuffle.Clone();
            */
           // this.PositionOfNumberZero.Row = 5;

            this.GameState = GameStateEnum.Running;
        }
        public void StartWithAutomaticShuffle()
        {
           
            GameState = GameStateEnum.Shuffle;
            do
            {
                Shuffle();
            }
            while (IsInFinishedPosition);

            
            GameState = GameStateEnum.Running;
            NoofMoves = 0;
        }
        public void Shuffle()
        {
            int iLoop = 0;
            int iMaxLoop = 10;
            int i = 0;
            for (iLoop = 1; iLoop <= iMaxLoop; iLoop++)
            {

                int PreviousInt = -1;

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

                }

            }


           
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
                    GoalStateboard[i, j] = Value;

                }
            }

            PositionOfNumberZero = new Position(RowSize - 1, ColSize - 1);
            
            GoalStateboard[PositionOfNumberZero.Row , PositionOfNumberZero.Column] = 0;
            SetBoardValue(PositionOfNumberZero, 0);

            ui.Initial(this);
            isInitialed = true;
        }
        public event EventHandler Won;

        private Position GetNextToZeroNumberPostionThatCanMoveToDirection(System.Windows.Forms.Keys keyDataDirection)
        {
            /* if key is down look at Up and vice versa
             * if key is left look at down and vice versa
             */
            var TargetPosition = Position.Empty;
            switch (keyDataDirection)
            {
                case Keys.Down:
                    TargetPosition = new Position(PositionOfNumberZero.Row - 1, PositionOfNumberZero.Column);
                    break;
                case Keys.Up:
                    TargetPosition =new Position(PositionOfNumberZero.Row + 1, PositionOfNumberZero.Column);
                    break;
                case Keys.Right:
                    TargetPosition =new Position(PositionOfNumberZero.Row, PositionOfNumberZero.Column - 1);
                    break;
                case Keys.Left:
                    TargetPosition =new Position(PositionOfNumberZero.Row, PositionOfNumberZero.Column + 1);
                    break;
            }
            return TargetPosition;
        }
        public void SendKeyDirection(System.Windows.Forms.Keys keyData)
        {

            if (keyData != Keys.Up
                && keyData != Keys.Down
                && keyData != Keys.Left
                && keyData != Keys.Right)
            {
                return;
            }
            var PositionNextToNumberZero = GetNextToZeroNumberPostionThatCanMoveToDirection(keyData);
            if(!IsPositionInRange(PositionNextToNumberZero))
            {
                return;
            }
            try
            {
                int tileNumber = boardValue(PositionNextToNumberZero);
                Ui_TiltClick(tileNumber);
            }
            catch (Exception ex)
            {
                throw new Exception  ($"{PositionNextToNumberZero.key}");
            }
            //PositionOfNumberZero 
        }
        private void Ui_TiltClick(int TileNumber)
        {
            if(GameState != GameStateEnum.Running)
            {
                return;
            }

            MoveCell(TileNumber, isPerformAnimation:true);
            
         
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
                PositionOfNumberZero = position;
            }

        }
        public void MoveTile(Position fromPosition, Position toPosition)
        {

            int FromValue = board[fromPosition.Row , fromPosition.Column ];
            SetBoardValue(toPosition, FromValue);
            SetBoardValue(fromPosition, 0);


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
                        if(GoalStateboard [i,j] !=
                            board[i, j])
                        {
                            return false;
                        }
                    }
                }
                return true;
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChanged?.Invoke(this, e);
        }
        protected void OnPropertyChanged(
    [System.Runtime.CompilerServices.CallerMemberName] string propertyName = "")
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }
       // public event PropertyChangedEventHandler PropertyChanged;
        private int _NoofMoves = 0;
        public int NoofMoves {
            get {
                return _NoofMoves;
            }
            private set
            {
                if(value != _NoofMoves)
                {
                    _NoofMoves = value;
                    OnPropertyChanged("NoofMoves");
                }
                
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
            NoofMoves++;
            Position FromPosition = DicPositionFromNumber[index];
            Position ToPosition = GetNeibhourPosition(FromPosition, MovetoEmptyDirection);

            if (!isPerformAnimation)
            {
                ui.MoveTiteNoAnimation(FromPosition, ToPosition);
            }
            else
            {
                ui.MoveTile(FromPosition, ToPosition);
            }

            MoveTile(FromPosition, ToPosition);
            if (this.GameState != GameStateEnum.Shuffle)
            {
                if (this.IsInFinishedPosition)
                {
                    GameState = GameStateEnum.Stop;
                    Won?.Invoke(this, new EventArgs());

                }
            }

        }


    }
}
