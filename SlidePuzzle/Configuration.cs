using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SlidePuzzle
{
    [Serializable]
    public sealed  class Configuration
    {
        public Color TileBackColor { get; set; }
        public Color TileForeColor { get; set; }
        public float TileFontSize { get; set; }
        public bool IsShowNumberOverlay { get; set; }
        public bool IsUseImage { get; set; }
        public int RowSize { get; set; }
        public int ColSize { get; set; }
        public string SelectedImageFilePath { get; set; } = "";

        public int BoardWidth { get; private set; }
        public int BoradHeight { get; private set; }
        private static  Configuration _Instance = null;
        private static readonly object _lock = new object();
        private static void LoadConfiguration(String configurationFileName)
        {
            if (!SerializeUtility.IsSerializeConfigurationFileExist(configurationFileName))
            {
                _Instance = new Configuration();
                _Instance.BoardWidth = 600;
                _Instance.BoradHeight = 600;
                _Instance.RowSize = 4;
                _Instance.ColSize = 4;
                _Instance.TileFontSize = 22;
                _Instance.TileBackColor = Color.Silver;
                _Instance.TileForeColor = Color.Black;
                _Instance.IsShowNumberOverlay = true;
                SerializeUtility.SerializeConfiguration(_Instance, configurationFileName);
                return;
            }

            _Instance = SerializeUtility.DeserializeConfigurationFile(configurationFileName);

        }
        private static void LoadConfiguration()
        {
            String ConfigurationSerialzeFilePath = FileUtility.ConfigurationSeralizePath;
            LoadConfiguration(ConfigurationSerialzeFilePath);
           

            

        }
        public static void SaveInstance()
        {
            SerializeUtility.SerializeConfiguration(_Instance, FileUtility.ConfigurationSeralizePath);
            _Instance = null;
        }
        public static  Configuration Instance
        {
            get
            {

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
                    return _Instance;

            }
           
        }
    }
  
}
