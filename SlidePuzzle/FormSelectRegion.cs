using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public partial class FormSelectRegion : Form
    {
        public FormSelectRegion()
        {
            InitializeComponent();
        }

        int cropX;
        int cropY;
        int cropWidth;
        int cropHeight;
        Rectangle RecDrawArea;
        public Pen cropPen;
        public DashStyle cropDashStyle = DashStyle.DashDot;
        private void button1_Click(object sender, EventArgs e)
        {

        }
        PictureBox pictureBoxTemp = new PictureBox();
        private Bitmap PicBackGroudImage = null;
        Rectangle AcceptRectangle;
        private void fromSelectImageRegion_Load(object sender, EventArgs e)
        {





          

        }

        private void Form_Resize(object sender, EventArgs e)
        {
            //  throw new NotImplementedException();
            try
            {
                if (this.WindowState == FormWindowState.Maximized)
                {
                    this.panel1.Height = this.Height - this.btnSave.Height;
                    this.panel1.Width = this.btnSave.Left + this.btnSave.Width;
                }
                else
                {
                    this.panel1.Height = this.btnSave.Top - 2;
                    this.panel1.Width = this.btnSave.Left + this.btnSave.Width;
                }
            }
            catch (Exception ex)
            {
                //Do nothing;
            }

        }

        private void pictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            IsMouseDown = false;
        }

        private void pictureBoxMain_Paint(object sender, PaintEventArgs e)
        {

            if (!IsMouseDown)
            {
                return;
            }
          //  Bitmap B = new Bitmap(cropWidth, cropHeight);

            e.Graphics.DrawImage(pictureBoxTemp.Image, RecDrawArea, RecDrawArea, GraphicsUnit.Pixel);
            e.Graphics.DrawRectangle(cropPen, RecDrawArea);
            this.btnSave.Enabled = true;

        }
        private void AdjestCrop()
        {



            cropX = Math.Max(cropX, AcceptRectangle.X);
            cropX = Math.Min(cropX, AcceptRectangle.Width);
            cropY = Math.Max(cropY, AcceptRectangle.Y);
            cropY = Math.Min(cropY, AcceptRectangle.Height);

        }
        private void pictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {

            if (!IsMouseDown)
            {
                return;
            }



            cropPen = new Pen(Color.Teal ,2);
            cropPen.DashStyle = DashStyle.Dot ;


            cropX = e.X - (cropWidth / 2);
            cropY = e.Y - (cropHeight / 2);
            AdjestCrop();
            RecDrawArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            pictureBoxMain.Invalidate();
          
        }
        Boolean IsMouseDown = false;
        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
            {
                return;
            }
            IsMouseDown = true;
        }

        public Bitmap ChangeImagetoGrayScale(Bitmap pOrignal)
        {
            Bitmap newBitmap = new Bitmap(pOrignal.Width, pOrignal.Height);
            Graphics g = Graphics.FromImage(newBitmap);

            ColorMatrix colorMatrix = new ColorMatrix(
               new float[][]
               {
                   new float[] {.3f, .3f, .3f, 0, 0},
                   new float[] {.59f, .59f, .59f, 0, 0},
                   new float[] {.11f, .11f, .11f, 0, 0},
                   new float[] {0, 0, 0, 1, 0},
                   new float[] {0, 0, 0, 0, 1}
               });

            ImageAttributes img = new ImageAttributes();
            img.SetColorMatrix(colorMatrix);
            Rectangle Re = new Rectangle(0, 0, pOrignal.Width, pOrignal.Height);
            g.DrawImage(pOrignal, Re, 0, 0, pOrignal.Width, pOrignal.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBitmap;

        }
        private void SavePicture()
        {
            Bitmap NewImage = new Bitmap(RecDrawArea.Width, RecDrawArea.Height);

            Graphics g = Graphics.FromImage(NewImage);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.PixelOffsetMode = PixelOffsetMode.HighQuality;
            g.CompositingQuality = CompositingQuality.HighQuality;
          

            g.DrawImage(this.pictureBoxTemp.Image , 0, 0, RecDrawArea , GraphicsUnit.Pixel);
            String fileName = DateTime.Now.ToString ("yyyyMMddHHmmssss")+ ".jpeg";

            NewImage.Save(FileUtility.ImageBoardPath + fileName);
            
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // SavePicture();
        }

        private string ImageFileName = "";
        public void SetImageInfo(String imageFileName, int cropHeight, int cropWidth)
        {
            ImageFileName = imageFileName;
            this.cropHeight = cropHeight;
            this.cropWidth = cropWidth;
        }
        private Boolean IsImageValid(String ImageFileName, int ValidMinimalHeigh, int ValidMinimamWidth,ref string WarningMessage)
        {
            if(!System.IO.File.Exists (ImageFileName))
            {
                WarningMessage = "Cannot find " + ImageFileName;
                return false;
            }

            using (Bitmap bit = (Bitmap)Image.FromFile(ImageFileName))
            {
                if(bit.Width < ValidMinimamWidth)
                {
                    WarningMessage = String.Format("Your image width is {0}. This kind of behaviour is unacceptable please choose an image that the width is >= {1}",
                                                  bit.Width,
                                                  ValidMinimamWidth);
                    return false;
                }
                if(bit.Height < ValidMinimalHeigh )
                {
                    WarningMessage = String.Format("Your image height is {0}. This kind of behaviour is unacceptable please choose an image that the height is >= {1}",
                              bit.Height ,
                              ValidMinimalHeigh);
                    return false;
                }

            }
            return true;
        }
        private void frmSelectRegion_Load(object sender, EventArgs e)
        {
            this.Icon = Resource1.Icon;
            this.lblImageSizeInfo.Text = $"Please make sure that image you choose has the size at least {Configuration.Instance.BoardWidth }x{Configuration.Instance.BoardWidth}";
            String WarningMessage = "";
            //if(!IsImageValid (ImageFileName , ))
            this.pictureBoxMain.Image = Image.FromFile(ImageFileName);
            this.pictureBoxMain.MouseDown += pictureBoxMain_MouseDown;
            this.pictureBoxMain.MouseUp += pictureBoxMain_MouseUp;
            this.pictureBoxMain.MouseMove += pictureBoxMain_MouseMove;
            this.pictureBoxMain.Paint += pictureBoxMain_Paint;
            this.pictureBoxMain.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBoxTemp.Height = this.pictureBoxMain.Height;
            this.pictureBoxTemp.Width = this.pictureBoxMain.Width;
            this.pictureBoxTemp.Visible = false;
            this.pictureBoxTemp.Image = this.pictureBoxMain.Image;

            this.pictureBoxMain.Image = ChangeImagetoGrayScale((Bitmap)this.pictureBoxMain.Image);
            PicBackGroudImage = (Bitmap)this.pictureBoxMain.Image;


            AcceptRectangle = new Rectangle(0, 0, pictureBoxMain.Width - cropWidth - 1, pictureBoxMain.Height - cropHeight - 1);
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Controls.Add(this.pictureBoxTemp);

            this.panel1.Size = new Size(870, 600);
            this.panel1.Top = 1;
            this.panel1.Left = 1;

            this.pictureBoxMain.Top = 0;
            this.pictureBoxMain.Left = 0;
            this.Resize += Form_Resize;
           
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            SavePicture();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
