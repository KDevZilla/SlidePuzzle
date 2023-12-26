using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace SlidePuzzle.UI
{
    /*
     * This control is a simeple panel control that display thumbnail images
     * I only use it for this project only, it was tested to display 200 images, no performance issue at all
     * But if you would like to use it to display more than that please consider using the other methods
     * Because I use panel for each thumbnail which is expensive.
     */
    public class pnlThumbnail:System.Windows.Forms.Panel 
    {
        public class ImageInfo
        {
            public string ImageName { get; set; }
            public string FilePath { get; set; }
            public ImageInfo(String FilePath)
            {
                this.FilePath = FilePath;
            }
            public ImageInfo (String FilePath, String pImageName)
            {
                this.FilePath = FilePath;
                this.ImageName = pImageName;
            }

        }
        public ImageCached imageCache { get; set; } = null;

        public Boolean IsUseCacheImage { get; set; } = false;
        public List<ImageInfo> listImageInfo { get; private set; } = new List<ImageInfo>();
        public event EventHandler AddNewButton_Clicked;
        public event EventHandler ItemDouble_Clicked;
        public List<labelDisplayPicture> listLabelDisplayImage { get; private set; } = new List<labelDisplayPicture>();


        /*In the future, these private values will be allowed to configure from the caller*/
        private Color NonSelectedLabelBackColor => Color.White;
        private Color SelectedLabelBackColor => Color.FromArgb(204, 232, 255);
        private Color MouseHoverBackColor => Color.FromArgb(229, 243, 255);
        private Color SelectedLabelBorderColor => Color.FromArgb(153, 209, 255);
        private Color UnSelectBackColor => Color.Transparent;
        private int tileWidth { get; set; } = 115;
        private int tileHeight { get; set; } = 115;
        private int spaceBetweenRowPixel { get; set; } = 10;
        private int spaceBetweenColumnPixel { get; set; } = 10;



        public String SelectedImageFileName { get; set; } = "";

        public static string[] GetFiles(string path, string searchPattern, SearchOption searchOption)
        {
            string[] searchPatterns = searchPattern.Split('|');
            List<string> files = new List<string>();
            foreach (string sp in searchPatterns)
                files.AddRange(System.IO.Directory.GetFiles(path, sp, searchOption));
            files.Sort();
            return files.ToArray();
        }
        private void LoadListImage()
        {
            listImageInfo = new List<ImageInfo>();
            string[] fileNames = GetFiles(FileUtility.ImageBoardPath, "*.jpg|*.jpeg|*.png", SearchOption.TopDirectoryOnly);
            fileNames.ToList().ForEach(x => listImageInfo.Add(new ImageInfo(x)));
        }

        public Position SelectedImagesPosition { get; private set; } = Position.Empty;
        labelDisplayPicture[,] arr2DPictures = null;




        public void RenderImages(List<ImageInfo> plistImageInfo,int numberofImagePerRow)
        {
            this.BackColor = Color.White;
            this.AutoScroll = true;
            this.BorderStyle = BorderStyle.FixedSingle;
          
            this.listImageInfo = plistImageInfo;
            int i;

            this.Controls.Clear();
            Label LastPanel = null;
            int lastColumn = -1;
            int lastRow = 0;
            int panelWidth = -1;

            this.Controls.Clear();
            panelWidth = numberofImagePerRow * (tileWidth + 28 + spaceBetweenColumnPixel);
            listLabelDisplayImage = new List<labelDisplayPicture>();

            arr2DPictures = new labelDisplayPicture[listImageInfo.Count / numberofImagePerRow ,numberofImagePerRow];

            for (i = 0; i < listImageInfo.Count; i++)
            {
                lastColumn = (i % numberofImagePerRow);
                lastRow = (i / numberofImagePerRow);

                labelDisplayPicture pic = new labelDisplayPicture();
                listLabelDisplayImage.Add(pic);
                Position position = new Position(i / numberofImagePerRow, i % numberofImagePerRow);
                
                pic.Name = listImageInfo[i].FilePath;
                pic.InitialValue(i.ToString (), listImageInfo[i].FilePath, tileHeight, tileWidth,position, imageCache);
                pic.Top = (tileHeight + 36 + spaceBetweenRowPixel) * lastRow;
                pic.Left = (tileWidth + 36 + spaceBetweenColumnPixel) * lastColumn;
                pic.Tag = false;

                pic.BeingSelected += Pic_BeingSelected;
               
                pic.MouseMove += (o, e2) =>
                {
                    //Set all of the control to be unselect color
                    listLabelDisplayImage.ForEach(x =>
                    {
                        if (!x.IsSelected) x.BackColor = UnSelectBackColor;
                    });


                    var pnl = (labelDisplayPicture)o;
                    //if it is the selected one, no need to use MouseHover
                    //because the selected one use SelectedPanelBackColor
                    if (!pnl.IsSelected)
                    {
                        pnl.BackColor = MouseHoverBackColor;
                    }
                };
                pic.ContextMenuDeleteClicked += (o, e2) =>
                {
                    String fileName = ((labelDisplayPicture.StringEventArgs)e2).Value;
                    if(MessageBox.Show ($"Do you want to delete {fileName} ?","Confirm", MessageBoxButtons.OKCancel )!=  DialogResult.OK)
                    {
                        return;
                    }
                    System.IO.File.Delete(fileName);
                    LoadListImage();
                    RenderImages(listImageInfo , numberofImagePerRow);
                };

                pic.ItemDoubleClick += (o, e2) =>
                 {
                     ItemDouble_Clicked?.Invoke(pic, new labelDisplayPicture.StringEventArgs(pic.PictureFilePath));
                 };

                this.Controls.Add(pic);
                LastPanel = pic;

            }

            if (listLabelDisplayImage.Count > 0)
            {
                Pic_BeingSelected(listLabelDisplayImage[0], new EventArgs());
            }
            /* 
             This code is to create a button the put it into the panel along 
             with the images. As of now we don't use it.


            Button btn = new Button();
            btn.Text = "Add New Image...";
            btn.AutoSize = true;
           
            int ColumnAddNewButton = lastColumn + 1;
            int RowAddNewButton = lastRow;
            if (ColumnAddNewButton >= numberofImagePerRow)
            {
                ColumnAddNewButton = 0;
                RowAddNewButton += 1;

            }

            btn.Left = (tileWidth + 36 + spaceBetweenColumnPixel) * ColumnAddNewButton;
            btn.Top = (tileWidth + 36 + spaceBetweenColumnPixel) * RowAddNewButton;
            btn.Click += (o, e2) => AddNewButton_Clicked?.Invoke(this, new EventArgs());
            btn.Visible = false;

            Controls.Add(btn);
            */
            this.Width = panelWidth + 70;
            this.Focus();

            //Assign arr2DPicuter 
            for (i = 0; i <= arr2DPictures.GetUpperBound(0); i++)
            {
                for (int j = 0; j <= arr2DPictures.GetUpperBound(1); j++)
                {
                    arr2DPictures[i, j] = listLabelDisplayImage[i * numberofImagePerRow + j];
                }
            }
            this.SelectedImageFileName = "";

        }

        private void Pic_BeingSelected(object sender, EventArgs e)
        {

            var p = (UI.labelDisplayPicture)sender;
            //Unselect all of the items first.
            listLabelDisplayImage.ForEach(x => {
                if (x.Name != p.Name)
                    x.UnSelect();
            });
            p.SetSelected();
            //Then select the one that fire an event
            p.BackColor = SelectedLabelBackColor;
            p.Invalidate();
            SelectedImagesPosition = p.Position;
            SelectedImageFileName = p.PictureFilePath;
            this.ScrollControlIntoView(p);
        }

        public enum MoveSelectedImageDirection
        {
            Up = Keys.Up,
            Down = Keys.Down,
            Left = Keys.Left,
            Right = Keys.Right,

        }
        public Dictionary<MoveSelectedImageDirection, Position> dicPoint = new Dictionary<MoveSelectedImageDirection, Position>()
        {
            { MoveSelectedImageDirection.Up ,new  Position    (-1,0) },
            { MoveSelectedImageDirection.Down ,new  Position  (1,0) },
            { MoveSelectedImageDirection.Left  ,new  Position (0,-1) },
            { MoveSelectedImageDirection.Right  ,new  Position (0,1) },

        };

        public void MoveSelectedImage(MoveSelectedImageDirection direction)
        {


            Position newPosition = SelectedImagesPosition + dicPoint[direction];
            Boolean isNewPostionOutofRange = newPosition.Row > arr2DPictures.GetUpperBound(0) ||
                newPosition.Column > arr2DPictures.GetUpperBound(1) ||
                newPosition.Row < 0 ||
                newPosition.Column < 0;

            if (isNewPostionOutofRange)
            {                
                //No need to thorw an exception, just return;
                return;
            }

            Pic_BeingSelected(arr2DPictures[newPosition.Row, newPosition.Column], new EventArgs());

        }



    }
}
