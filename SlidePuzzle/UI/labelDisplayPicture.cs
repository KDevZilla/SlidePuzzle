using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSlider.UI
{
    /* this panel consist 3 label,
     * To show an image
     * To make a shadow
     * To show an image name
     */
    public class labelDisplayPicture:Label
    {
        public Position Position { get; private set; }
        public void UnSelect()
        {
            this.BackColor = Color.Transparent;
            this.IsSelected = false;
        }
        public String PictureFilePath { get; private set; } = "";

        public event MouseEventHandler Hover;
        public event EventHandler BeingSelected;
        public event EventHandler ContextMenuDeleteClicked;
        public event EventHandler ItemDoubleClick;
        public Boolean IsSelected { get; private set; } = false;
        public void SetSelected()
        {
            IsSelected = true;
        }
        public bool ThumbnailCallback() => false;
        public String imageName { get; private set; } = "";
        public Image GetThumb(String ImageFileName,int pictureHeight, int pictureWidth)
        {

            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(()=>false);
            Image myThumbnail = null;
            using (Bitmap myBitmap = new Bitmap(ImageFileName))
            {
                myThumbnail = myBitmap.GetThumbnailImage(
                pictureHeight, pictureWidth, myCallback, IntPtr.Zero);
            }

            return myThumbnail;
        }
        public class StringEventArgs:EventArgs 
        {
            public String Value { get; private set; }
            public StringEventArgs (String value)
            {
                this.Value = value;
            }
        }
        public String ID { get; private set; } = "";
        public void InitialValue(String ID, String pictureFilePath, int pictureHeight, int picturewidth, Position position)
        {
            this.Position = position;
            this.ID = ID;
            this.imageName = System.IO.Path.GetFileNameWithoutExtension(pictureFilePath);

            this.Width = picturewidth + 36;
            this.Height = pictureHeight + 40;
            Label lblPicture = new Label()
            {
                Image = GetThumb(pictureFilePath, picturewidth, pictureHeight),
                Height = pictureHeight,
                Width = picturewidth,
                Top = 10,
                Left = 18,
            };

            Label lblShadow = new Label()
            {
                Height = pictureHeight,
                Width = picturewidth,
                BackColor = Color.DarkGray,
                Top = lblPicture.Top + 2,
                Left = lblPicture.Left + 2
            };
            Label lblImageName = new Label()
            {
                Height = 20,
                Width =this.Width ,
                BackColor = Color.Transparent,
                Text = this.imageName,
                Top = lblPicture.Top + lblPicture.Height + 5,
                Left = 0,
                TextAlign = ContentAlignment.MiddleCenter  ,
                AutoSize =false ,
                
                
            };

            this.PictureFilePath = pictureFilePath;
            lblPicture.BorderStyle = BorderStyle.FixedSingle;

            
            this.Controls.Add(lblShadow);
            this.Controls.Add(lblPicture);
            this.Controls.Add(lblImageName);
            lblPicture.BringToFront();
            this.Tag = false;


            MouseEventHandler mousemove = (o, e2) => Hover?.Invoke(this, e2);
            EventHandler click = (o, e2) =>
            {
                //this.IsSelected = true;
                BeingSelected?.Invoke(this, e2);
            };

            EventHandler controlDoubleClick = (o,e2) => {
                ItemDoubleClick?.Invoke(this, e2);
              //  DoubleClick?.Invoke(this, e2);
            };
            lblImageName.MouseMove += mousemove;
            lblPicture.MouseMove += mousemove;
            this.MouseMove += mousemove;

            lblImageName.Click += click;
            lblPicture.Click += click;
            this.Click += click;
             Color SelectedPanelBorderColor = Color.FromArgb(153, 209, 255);

           this.Paint += (o, e2) =>
           {
               //If this panel was selected it must show a border
               if (!this.IsSelected)
               {
                   return;
               }
                ControlPaint.DrawBorder(e2.Graphics,
                this.ClientRectangle,
                SelectedPanelBorderColor,
                ButtonBorderStyle.Solid);
               
           };
            lblPicture.DoubleClick += controlDoubleClick;
            lblImageName.DoubleClick += controlDoubleClick;
            this.DoubleClick += controlDoubleClick;
           

            ContextMenu cm = new ContextMenu();
            cm.MenuItems.Add("Delete image").Click += (o, e2)
                => ContextMenuDeleteClicked?.Invoke(this, new StringEventArgs(this.PictureFilePath));


            lblImageName.ContextMenu = cm;
            lblPicture.ContextMenu = cm;
            this.ContextMenu = cm;

        }

    }
}
