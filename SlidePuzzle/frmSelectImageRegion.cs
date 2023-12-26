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
    public partial class frmSelectImageRegion : Form
    {
        public frmSelectImageRegion()
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
 
            



            this.pictureBoxMain.MouseDown += pictureBoxMain_MouseDown;
            this.pictureBoxMain.MouseUp += pictureBoxMain_MouseUp;
            this.pictureBoxMain.MouseMove += pictureBoxMain_MouseMove;
            this.pictureBoxMain.Paint += pictureBoxMain_Paint;
            this.pictureBoxMain.SizeMode = PictureBoxSizeMode.AutoSize;
            this.pictureBoxTemp.Height = this.pictureBoxMain.Height;
            this.pictureBoxTemp.Width = this.pictureBoxMain.Width;
            this.pictureBoxTemp.Visible = false;
            this.pictureBoxTemp.Image  = this.pictureBoxMain.Image;

            this.pictureBoxMain.Image  = ChangeImagetoGrayScale((Bitmap)this.pictureBoxMain.Image );
            PicBackGroudImage = (Bitmap)this.pictureBoxMain.Image ;



            cropWidth = 115 * 4;
            cropHeight = 115 * 4;
            AcceptRectangle = new Rectangle(0, 0, pictureBoxMain.Width - cropWidth - 1, pictureBoxMain.Height - cropHeight - 1);
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pictureBoxMain);
            this.panel1.Controls.Add(this.pictureBoxTemp);
            this.panel1.Size = new Size(600, 600);
            this.panel1.Top = 1;
            this.panel1.Left = 1;
            this.panel1.Scroll += (o, e2) =>
            {
                pictureBoxMain.Invalidate();
            };

            this.Resize += Form_Resize;


        }

        private void Form_Resize(object sender, EventArgs e)
        {

            try
            {
                this.panel1.Height = this.btnSave.Top - 2;
                this.panel1.Width = this.btnSave.Left + this.btnSave.Width;
            }catch (Exception ex)
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
    
            if(!IsMouseDown )
            {
                return;
            }
            Bitmap B = new Bitmap(cropWidth, cropHeight);

            e.Graphics.DrawImage(pictureBoxTemp.Image , RecDrawArea, RecDrawArea, GraphicsUnit.Pixel);
            e.Graphics.DrawRectangle(cropPen, RecDrawArea);
            
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
         
            if(!IsMouseDown )
            {
                return;
            }

        

            cropPen = new Pen(Color.Red , 1);
            cropPen.DashStyle = DashStyle.Dash ;


            cropX = e.X - (cropWidth /2);
            cropY = e.Y - (cropHeight / 2);
            AdjestCrop();
            RecDrawArea = new Rectangle(cropX, cropY, cropWidth, cropHeight);

            pictureBoxMain.Invalidate();

        }
        Boolean IsMouseDown = false ;
        private void pictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button != MouseButtons.Left )
            {
                return;
            }
            IsMouseDown = true;  
        }
        //https://stackoverflow.com/questions/2265910/convert-an-image-to-grayscale
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
            g.DrawImage(pOrignal , Re, 0, 0, pOrignal.Width, pOrignal.Height, GraphicsUnit.Pixel, img);
            g.Dispose();
            return newBitmap ;

        }


        private void frmSelectImageRegion_Load(object sender, EventArgs e)
        {

        }
    }
}
