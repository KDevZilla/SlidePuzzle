using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace SlidePuzzle
{
    public partial class FormNewGame : Form
    {
        public FormNewGame()
        {
            InitializeComponent();
        }
        private List<UI.pnlThumbnail.ImageInfo> GetImagesFromDirectory(String path)
        {
            string[] extension = { "*.jpeg", "*.jpg" };
           
            List<String[]> listArrFiles = new List<String[]>();
            extension.ToList().ForEach(x => listArrFiles.Add(Directory.GetFiles(path, x)));

            List<UI.pnlThumbnail.ImageInfo> list = new List<UI.pnlThumbnail.ImageInfo>();

            listArrFiles.ForEach (x=>x.ToList ().
                                  ForEach (y=> list.Add(new UI.pnlThumbnail.ImageInfo(y))));
           
            return list;

        }
        //UI.pnlThumbnail pnlDis = null;

        public String ImageFilePath { get; set; } = "";
        public UI.ImageCached imageCached { get; set; } = null;
        public void InitialControlAndLoadImages()
        {
            pnlThumbnail1.HorizontalScroll.Enabled = true;
            pnlThumbnail1.VerticalScroll.Enabled = true;
            pnlThumbnail1.AddNewButton_Clicked += btnAddNewImage_Click;
            pnlThumbnail1.ItemDouble_Clicked += PnlDis_ItemDouble_Clicked;
            pnlThumbnail1.Enabled = false;
            pnlThumbnail1.imageCache = imageCached;


            var listImage = new List<UI.pnlThumbnail.ImageInfo>();
            listImage = GetImagesFromDirectory(ImageFilePath);
            RenderImages(pnlThumbnail1, listImage);

            this.KeyPreview = true;
            this.Text = pnlThumbnail1.Height + "," + this.pnlThumbnail1.Width;

            this.chkUseImage.CheckedChanged += (o, e2) =>
            {
                this.pnlThumbnail1.Enabled = chkUseImage.Checked;
                this.btnAddNewImage.Enabled = chkUseImage.Checked;
                this.chkIsShowNumberOverlay.Enabled = chkUseImage.Checked;
            };
            this.btnAddNewImage.Click += btnAddNewImage_Click;
            cboNumberofBlock.SelectedIndex = 0;

        }
        private void FormTestPnlDisplay_Load(object sender, EventArgs e)
        {
            if(ImageFilePath.Equals(""))
            {
                throw new Exception($"{ImageFilePath} is blank, please set it first");
            }
            this.chkUseImage.Checked = this.IsUseImage;
            switch (this.RowSize)
            {
                case 3:
                    this.cboNumberofBlock.SelectedIndex = 0;
                    break;
                case 4:
                    this.cboNumberofBlock.SelectedIndex = 1;
                    break;
                case 5:
                    this.cboNumberofBlock.SelectedIndex = 2;
                    break;
            }

            if(this.SelectedFileName != "")
            {
                pnlThumbnail1.SelecteImageByFileName(this.SelectedFileName );
            }
          


        }

        private void PnlDis_ItemDouble_Clicked(object sender, EventArgs e)
        {
           // String fileName = ((UI.labelDisplayPicture.StringEventArgs)e).Value;
           // MessageBox.Show(fileName);

            //throw new NotImplementedException();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Up
                 || keyData == Keys.Down
                 || keyData == Keys.Left
                 || keyData == Keys.Right)
            {
                pnlThumbnail1.MoveSelectedImage((UI.pnlThumbnail.MoveSelectedImageDirection)keyData);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        /*No use because it has the problem when there is a button control 
        on the form. Please use ProcessCmdKey instead.
        */
        private void FormTestPnlDisplay_KeyDown(object sender, KeyEventArgs e)
        {
           // throw new NotImplementedException();
           if(e.KeyCode != Keys.Up 
                && e.KeyCode != Keys.Down 
                && e.KeyCode != Keys.Left 
                && e.KeyCode != Keys.Right)
            {
                return;
            }
            pnlThumbnail1.MoveSelectedImage((UI.pnlThumbnail.MoveSelectedImageDirection)e.KeyCode);

        }



        private void RenderImages(UI.pnlThumbnail pnlDis, List<UI.pnlThumbnail.ImageInfo> listImage)
        {
            //listImage = GetImagesFromDirectory(FileUtility.ImageBoardPath);
            pnlDis.RenderImages(listImage, 4);
            pnlDis.Focus();
        }



        private void btnAddNewImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if (opf.ShowDialog() != DialogResult.OK ||
                opf.FileName == null ||
                opf.FileName.Trim().Equals(""))
            {
                return;
            }
            //    int BoardHeight = 400;
            //    int BoardWidth = 400;
             
            frmSelectRegion F = new frmSelectRegion();
            F.SetImageInfo(opf.FileName, Configuration.Instance.BoradHeight, Configuration.Instance.BoardWidth );
            F.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = F.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            var listImage = new List<UI.pnlThumbnail.ImageInfo>();
            listImage = GetImagesFromDirectory(ImageFilePath);

            RenderImages(pnlThumbnail1, listImage);

        }

        private void btnAddNewImage_Click_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        public Boolean IsUseImage { get;  set; } = true;
        public string SelectedFileName { get;  set; } = "";
     //   public int NumberofSlide { get; private set; } = 15;
        public int RowSize { get;  set; } = 4;
        public int ColSize { get;  set; } = 4;
        public Boolean IsShowNumberOverlay { get; set; } = true;
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;


            this.IsUseImage = this.chkUseImage.Checked;
            this.IsShowNumberOverlay = this.chkIsShowNumberOverlay.Checked;
            this.SelectedFileName = IsUseImage
                ? pnlThumbnail1.SelectedImageFileName
                : "";
          
            //
            //RowSize = this.cboNumberofBlock.SelectedIndex + 3;

            switch (this.cboNumberofBlock.SelectedIndex)
            {
                case 0:
                    RowSize = 3;
                    break;
                    
                case 1:
                    RowSize = 4;
                    break;
                case 2:
                    RowSize = 5;
                    break;
                default:
                    throw new Exception($"Board Size is invalid");
            }
            this.ColSize = RowSize;
            this.Close();
        }

        private void chkUseImage_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
