using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlidePuzzle
{
    public class FileUtility
    {
        public static string CurrentPath => Path.GetDirectoryName(new Uri(System.Reflection.Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        public static string ConfigurationSeralizePath => $@"{CurrentPath}\Configuration.bin";
        public static string ImageBoardPath => $@"{CurrentPath}\BoardImage\";
        public static string ScoreFilePath(int BoardSize) => $@"{CurrentPath}\Score{BoardSize.ToString()}.bin";
        public static bool IsFileExist(String fileName) => System.IO.File.Exists(fileName);
    }
}
