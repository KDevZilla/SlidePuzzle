using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzle
{
    [Serializable]
    public class ScoreInfo
    {
        public int Score { get; set; }
        public String Name { get; set; }
        public int Rank { get; set; }
        public ScoreInfo(int Rank, String Name, int Score)
        {
            this.Rank = Rank;
            this.Name = Name;
            this.Score = Score;

        }
    }

    [Serializable]
    public class ScoreInfos
    {
        public List<ScoreInfo> listScoreInfo = null;
        public string PreviousName = "";
    }

    public class ScoreHelper
    {
      //  private static ScoreInfos _scoreInfos = null;
        public static ScoreInfos scoreInfos(int BoardSize)
        {
            return Instance(BoardSize);
            /*
                if(_DicInstance ==null)         
                if (_scoreInfos == null)
                {
                    _scoreInfos = LoadScoreInfo(FileUtility.ScoreFilePath);
                }
                return _scoreInfos;
            */

        }
        public static ScoreInfos LoadScoreInfo(String fileName)
        {
            if (!FileUtility.IsFileExist(fileName))
            {
                SerializeUtility.CreateNewScoreFile(fileName);
            }
            return (ScoreInfos)SerializeUtility.DeserializeScore(fileName);
        }
        public static int CalculateNewRankFromScore(int Score,int BoardSize)
        {
            int PlayerNewRank = int.MaxValue;

            if (Score > -1)
            {
                int i;
                //for(i=scoreInfos.listScoreInfo.Count -1;i>=0;i--)
                for (i = 0; i < scoreInfos(BoardSize).listScoreInfo.Count; i++)
                {
                    if (scoreInfos(BoardSize).listScoreInfo[i].Score > Score)
                    {
                        PlayerNewRank = scoreInfos(BoardSize).listScoreInfo[i].Rank;
                        break;
                    }
                }

            }
            return PlayerNewRank;
        }
        public static void InsertNewRank(String Name, int Score,int BoardSize)
        {

            scoreInfos(BoardSize ).listScoreInfo.Add(new ScoreInfo(-1, Name, Score));
            List<ScoreInfo> SortedList = scoreInfos(BoardSize).listScoreInfo.OrderBy(o => o.Score).Take(10).ToList();
            int i;
            for (i = 0; i < 10; i++)
            {
                SortedList[i].Rank = (i + 1);
            }
           
            scoreInfos(BoardSize).listScoreInfo = SortedList;

            //List<Order> SortedList = objListOrder.OrderBy(o => o.OrderDate).ToList();
        }
        public static void Save(String fileName,int BoardSize)
        {
            
            SerializeUtility.SerializeScoreInfos(scoreInfos(BoardSize), fileName);
        }



        private static Dictionary<int, ScoreInfos>  _DicInstance = null;
        private static readonly object _lock = new object();

        private static void LoadScoreHelper()
        {
           // String ConfigurationSerialzeFilePath = FileUtility.ConfigurationSeralizePath;
            int i;
            _DicInstance = new Dictionary<int, ScoreInfos>();
            for(i=3;i<=5;i++)
            {
                String ScoreFilePath = FileUtility.ScoreFilePath(i);
                ScoreInfos scoreInfos = null;
                if (!SerializeUtility.IsSerializeConfigurationFileExist (ScoreFilePath))
                {
                    // ScoreHelper scorehelp = new ScoreHelper();
                    scoreInfos = new ScoreInfos();
                    scoreInfos.listScoreInfo = new List<ScoreInfo>();
                    int j;
                    for(j=1;j<=10;j++)
                    {
                        scoreInfos.listScoreInfo.Add(new ScoreInfo(j, "Anonymous", 50+(j*10)));
                    }
                    scoreInfos.PreviousName = "Anonymous";

                    SerializeUtility.SerializeScoreInfos(scoreInfos, ScoreFilePath);
                   // SerializeUtility.SerializeScoreInfos ()
                } else
                {
                    scoreInfos = SerializeUtility.DeserializeScore(ScoreFilePath);
                }
                _DicInstance.Add(i, scoreInfos);
            }
            return;
            


        }
        public static void SaveInstance(int BoardSize)
        {
            
            SerializeUtility.SerializeScoreInfos(_DicInstance[BoardSize], FileUtility.ScoreFilePath (BoardSize));
            _DicInstance  = null;
        }

        public static ScoreInfos Instance (int BoardSize)
        {
            if(_DicInstance ==null)
            {
                lock(_lock)
                {
                    if(_DicInstance ==null)
                    {
                        LoadScoreHelper();
                    }
                }
            }
            /*
                if (_Instance == null)
                {
                    lock (_lock)
                    {
                        if (_Instance == null)
                        {
                            LoadConfiguration();
                        }
                    }
                }
            */

            return _DicInstance[BoardSize];

            

        }

    }
}
