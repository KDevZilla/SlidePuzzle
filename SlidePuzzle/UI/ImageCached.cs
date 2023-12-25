using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace SlidePuzzle.UI
{
    public class ImageCached
    {
        private  Dictionary<String, Image> dicImage = new Dictionary<string, Image>();
        public   void AddImage(String fileName, Image image) => dicImage[fileName] = image;
        public  bool IsExist(String fileName) => dicImage.ContainsKey(fileName);
        public  Image GetImage(String fileName) => dicImage[fileName];
    }
}
