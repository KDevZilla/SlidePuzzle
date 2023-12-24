using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public partial class FormBoardConfiguration : Form
    {
        public FormBoardConfiguration()
        {
            InitializeComponent();
        }
        public bool ThumbnailCallback()
        {
            return false;
        }
        public Image  GetThumb(String ImageFileName)
        {
            Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
            Image myThumbnail = null;
            using (Bitmap myBitmap=new Bitmap(ImageFileName))
            {
                 myThumbnail = myBitmap.GetThumbnailImage(
            115, 115, myCallback, IntPtr.Zero);
            }
           // Bitmap myBitmap = new Bitmap(ImageFileName);
           // Image myThumbnail = myBitmap.GetThumbnailImage(
           // 115, 115, myCallback, IntPtr.Zero);
            /*
            Graphics G = new Graphics();

            e.Graphics.DrawImage(myThumbnail, 150, 75);
            */
            return myThumbnail;
        }
        private void RenderImages()
        {
            int i;
            int SpaceBetweenRow = 30;
            int SpaceBetweenColumn = 30;
            this.panel1.Controls.Clear();
            Panel LastPanel = null;
            int LastColumn = -1;
            int LastRow = 0;
            int WidthPanel = -1;
            int NumberofImagePerRow = 4;
            int TileWidth = 115;
            int TileHeight = 115;
            this.panel1.Controls.Clear();
            WidthPanel = NumberofImagePerRow * (TileWidth + 28 + SpaceBetweenColumn);
            for (i = 0; i < listImageInfo.Count; i++)
            {
                LastColumn = (i % 4);
                LastRow = (i / 4);
                Panel panelBorder = new Panel();
                PictureBox pic = new PictureBox();
                pic.Image = GetThumb(listImageInfo[i].FilePath);
                //  pic.Image = Image.FromFile(listImageInfo[i].FilePath);
                //   pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Height = TileWidth;
                pic.Width = TileWidth;
                pic.Top = 4;
                pic.Left = 4;
                pic.Tag = listImageInfo[i].FilePath;
                pic.BorderStyle = BorderStyle.FixedSingle;
               
                panelBorder.Width = pic.Width + 28;
                panelBorder.Height = pic.Height + 28;
                panelBorder.Top = (panelBorder.Height + SpaceBetweenRow) * LastRow;
                panelBorder.Left = (panelBorder.Width + SpaceBetweenColumn) * LastColumn;
                panelBorder.Controls.Add(pic);
                panelBorder.Paint += panelSelected_Paint;
                panelBorder.Tag = false;
                panelBorder.Name = $"pnlBorder_{i.ToString()}";
                pic.Click -= Pic_Click;
                pic.Click += Pic_Click;
                pic.MouseMove -= PanelBorder_MouseMove;
                pic.MouseMove += PanelBorder_MouseMove;
                panelBorder.MouseMove -= PanelBorder_MouseMove;
                panelBorder.MouseMove += PanelBorder_MouseMove;
                panelBorder.Click -= Pic_Click;
                panelBorder.Click += Pic_Click;
           //     panelBorder.Tag = listImageInfo[i].FilePath;
                this.panel1.Controls.Add(panelBorder);
                /*
                if((panelBorder.Left + panelBorder.Width) > WidthPanel){
                    WidthPanel = panelBorder.Left + panelBorder.Width;
                }
                */
                LastPanel = panelBorder;

            }
            Button btn = new Button();
            btn.Text = "Add New Image click here";
            btn.AutoSize = true;
            btn.Height = TileHeight;
            btn.Width = TileWidth;
            int ColumnAddNewButton = LastColumn + 1;
            int RowAddNewButton = LastRow;
            if (ColumnAddNewButton >= NumberofImagePerRow)
            {
                ColumnAddNewButton = 0;
                RowAddNewButton += 1;

            }
            btn.Left = (TileWidth + 28 + SpaceBetweenColumn) * ColumnAddNewButton;
            btn.Top = (TileWidth + 28 + SpaceBetweenColumn) * RowAddNewButton;
            btn.Click -= btnAddNewImage_Click;
            btn.Click += btnAddNewImage_Click;

            panel1.Controls.Add(btn);
            this.panel1.Width = WidthPanel + 30;
           // this.Width = this.panel1.Width + 30;
           // this.panelButton.Left = this.Width - panelButton.Width;
            this.btnDeleteImage.Enabled = false;
            this.btnSelectImage.Enabled = false;

        }

        private void PanelBorder_MouseMove(object sender, MouseEventArgs e)
        {
            //  throw new NotImplementedException();
            Panel panel = (Panel)sender;
            if ((Boolean)panel.Tag == true)
            {
                return;
            }
            DeselectAllImage();
            ((Panel)sender).BackColor = MouseHoverBackColor;

        }

        private void DisplayTileApperance()
        {
            this.chkIsShowNumberOverlay.Checked = Configuration.Instance.IsShowNumberOverlay;
            //this.comboBoxFontSize.SelectedText = Configuration.Instance.TileFontSize.ToString ();
            this.comboBoxFontSize.SelectedIndex = this.comboBoxFontSize.FindString(Configuration.Instance.TileFontSize.ToString());
            this.lblTemplate.Text = "";
            if (this.chkIsShowNumberOverlay.Checked)
            {
                this.lblTemplate.Text = "1";
            }
            float fontSize = new float();
            fontSize = float.Parse(this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());

            this.lblTemplate.Font = new Font(this.lblTemplate.Font.Name, fontSize);
            this.lblTemplate.BackColor = Configuration.Instance.TileBackColor;
            this.lblTemplate.ForeColor = Configuration.Instance.TileForeColor;

        }
        Dictionary<int, int> DicBoardSize = null;
        private void DisplayBoardSize()
        {

            this.cboBoardSize.SelectedIndex = DicBoardSize[Configuration.Instance.RowSize];
        }
        private void FormChooseImage_Load(object sender, EventArgs e)
        {
            DicBoardSize = new Dictionary<int, int>();
            DicBoardSize.Add(3, 0);
            DicBoardSize.Add(4, 1);
            DicBoardSize.Add(5, 2);


            RenderImages();
            DisplayTileApperance();
            DisplayBoardSize();

            IsUseImage = this.chkUseImage.Checked;
            ShowChoosingImageSection(IsUseImage);
        }



        private Color NonSelectedPanelBackColor => Color.White;
        private Color SelectedPanelBackColor => Color.FromArgb(204, 232, 255);
        private Color MouseHoverBackColor => Color.FromArgb(150, 180, 255);
        private Color SelectedPanelBorderColor => Color.FromArgb(153, 209, 255);
        public String SelectedFilePath { get; private set; }


        private void DeselectAllImage()
        {
           
            foreach (Control con in this.panel1.Controls)
            {
                con.BackColor = NonSelectedPanelBackColor;
                if(con is Panel)
                {
                    con.Tag = false;
                }
            }
        }
        private void panelSelected_Paint(object sender, PaintEventArgs e)
        {
            Panel panelSelected = (Panel)sender;
            if(panelSelected.BackColor == NonSelectedPanelBackColor)
            {
                return;
            }
            ControlPaint.DrawBorder(e.Graphics, 
                panelSelected.ClientRectangle, 
                SelectedPanelBorderColor, 
                ButtonBorderStyle.Solid);
        }
        private void Pic_Click(object sender, EventArgs e)
        {
            if(!(sender is Panel || 
                sender is PictureBox))
            {
                return;
            }
            PictureBox pic = null;
            Panel panel = null;
            if(sender is Panel)
            {
                panel = (Panel)sender;
                pic = (PictureBox)panel.Controls[0];
            }
            else
            {
                pic = (PictureBox)sender;
                panel =(Panel) pic.Parent;
            }

            SelectedFilePath = pic.Tag.ToString();
            DeselectAllImage();
            panel.BackColor = SelectedPanelBackColor;
            panel.Tag = true;
            this.btnSelectImage.Enabled = true;
            this.btnDeleteImage.Enabled = true;

                //panelSelected.

        }

        //List<>
        public class ImageInfo
        {
            public string ImageName { get; set; }
            public string FilePath { get; set; }
            public ImageInfo (String FilePath)
            {
                this.FilePath = FilePath;
            }
            
        }
        private List<ImageInfo> _listImageInfo = null;

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
            _listImageInfo = new List<ImageInfo>();
            string[] fileNames = GetFiles(FileUtility.ImageBoardPath , "*.jpg|*.jpeg|*.png", SearchOption.TopDirectoryOnly);  
            fileNames.ToList().ForEach(x => _listImageInfo.Add(new ImageInfo(x)));
        }
        private void ClearListImage()
        {
            _listImageInfo = null;
        }
        public List<ImageInfo> listImageInfo
        {
            get
            {
                if(_listImageInfo ==null)
                {
                    //   throw new Exception("please implement");
                    LoadListImage();
                }
                return _listImageInfo;
            }
               
        }
        /*
        private void Panel1_Paint(object sender, PaintEventArgs e)
        {
            //  throw new NotImplementedException();
            int i;
            for(i=0;i<listImageInfo.Count;i++)
            {
                Bitmap bit =(Bitmap )Image.FromFile(listImageInfo[i].FilePath);
                Point ImagePoint = new Point();
                e.Graphics.DrawImage(bit, ImagePoint);

            }
        }
        */

        public int BoardHeight = 0;
        public int BoardWidth = 0;
        private void btnAddNewImage_Click(object sender, EventArgs e)
        {
            if(BoardHeight==0 || BoardWidth ==0)
            {
                throw new Exception("Please set BoardHeight && BoardWidth first");
            }

            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog () != DialogResult.OK)
            {
                return;
            }

            if(opf.FileName==null ||
                opf.FileName.Trim ().Equals(""))
            {
                return;
            }
            // frmSelectImageRegion F = new frmSelectImageRegion();
            frmSelectRegion F = new frmSelectRegion();
            F.SetImageInfo(opf.FileName, BoardHeight, BoardWidth);
            DialogResult result= F.ShowDialog();
            if(result != DialogResult.OK)
            {
                return;
            }

            ClearListImage();
            Timer TimerDelay = new Timer();
            TimerDelay.Interval = 300;
            TimerDelay.Tick += TimerDelay_Tick;
            TimerDelay.Enabled = true;


          
        }

        private void TimerDelay_Tick(object sender, EventArgs e)
        {
            ((Timer)sender).Enabled = false;
            RenderImages();
        }

        //public string ImageSelectedFileName { get; private set; }
        private void btnDonotUseImage_Click(object sender, EventArgs e)
        {
            //ImageSelectedFileName = "";
           // SelectedFilePath = "";
           // this.Close();
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDeleteImage_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show ("Do you want to delete this image ?","", MessageBoxButtons.OKCancel ) != DialogResult.OK)
            {
                return;
            }

            this.panel1.Controls.Clear();
            this.ClearListImage();
            System.IO.File.Delete(SelectedFilePath);
            this.RenderImages();
            //string selectedFileName = "";
        }

        private void btnChooseFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cda = new ColorDialog();
            if (cda.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            this.lblTemplate.ForeColor = cda.Color;
        }

        private void btnChooseTileColor_Click(object sender, EventArgs e)
        {
            ColorDialog cda = new ColorDialog();
            if (cda.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            this.lblTemplate.BackColor = cda.Color;
        }

        private void chkIsShowNumberOverlay_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = new float();
            fontSize = float.Parse(this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());

            this.lblTemplate.Font = new System.Drawing.Font(this.lblTemplate.Font.Name, fontSize);

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Configuration.Instance.IsShowNumberOverlay = this.chkIsShowNumberOverlay.Checked;
            float fontSize = new float();
            fontSize = float.Parse(this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());
            Configuration.Instance.TileFontSize = fontSize;
            Configuration.Instance.TileBackColor = lblTemplate.BackColor;
            Configuration.Instance.TileForeColor = lblTemplate.ForeColor;




            Configuration.SaveInstance();
            this.Close();
        }
        Boolean IsUseImage = false;
        private void ShowChoosingImageSection(Boolean IsShow)
        {
            this.panel1.Visible = IsShow;
            this.btnDeleteImage.Visible = IsShow ;
        }
        private void chkUseImage_CheckedChanged(object sender, EventArgs e)
        {
            IsUseImage = this.chkUseImage.Checked;
            ShowChoosingImageSection(IsUseImage);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
