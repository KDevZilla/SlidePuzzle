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
    public partial class FormTestPnlDisplay : Form
    {
        public FormTestPnlDisplay()
        {
            InitializeComponent();
        }
        private List<UI.pnlThumbnail.ImageInfo> GetImagesFromDirectory(String path)
        {
            string[] extension = { "*.jpeg", "*.jpg" };
            //string[,] arrFiles = new string()[extension.Length, 0];
            List<String[]> listArrFiles = new List<String[]>();
            extension.ToList().ForEach(x => listArrFiles.Add(Directory.GetFiles(path, x)));
            List<UI.pnlThumbnail.ImageInfo> list = new List<UI.pnlThumbnail.ImageInfo>();
            listArrFiles.ForEach (x=>x.ToList ().
                                  ForEach (y=> list.Add(new UI.pnlThumbnail.ImageInfo(y))));
            //arrFiles.ToList().ForEach(x => list.Add(new UI.pnlDisplayPictureItems.ImageInfo(x)));
            return list;

        }
        UI.pnlThumbnail pnlDis = null;
        private void FormTestPnlDisplay_Load(object sender, EventArgs e)
        {


            pnlDis = new UI.pnlThumbnail()
            {
                Visible = true,
                Top = 12,
                Left = 12,
                Height = 300,
                Width = 682

            };

            pnlDis.HorizontalScroll.Enabled = true;
            pnlDis.VerticalScroll.Enabled = true;
            pnlDis.AddNewButton_Clicked += btnAddNewImage_Click;
            pnlDis.ItemDouble_Clicked += PnlDis_ItemDouble_Clicked;
            this.Controls.Add(pnlDis);
            var listImage = new List<UI.pnlThumbnail.ImageInfo>();
            listImage = GetImagesFromDirectory(FileUtility.ImageBoardPath);
            //listImage = GetImagesFromDirectory(@"D:\Krirk\KRIRK_Practice\Pictures\From_ACER\");

            RenderImages(pnlDis, listImage);
            this.KeyPreview = true;
            this.Text = pnlDis.Height + "," + this.pnlDis.Width;

        }

        private void PnlDis_ItemDouble_Clicked(object sender, EventArgs e)
        {
            String fileName = ((UI.labelDisplayPicture.StringEventArgs)e).Value;
            MessageBox.Show(fileName);

            //throw new NotImplementedException();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Up
                 || keyData == Keys.Down
                 || keyData == Keys.Left
                 || keyData == Keys.Right)
            {
                pnlDis.MoveSelectedImage((UI.pnlThumbnail.MoveSelectedImageDirection)keyData);
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
            pnlDis.MoveSelectedImage((UI.pnlThumbnail.MoveSelectedImageDirection)e.KeyCode);

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
            int BoardHeight = 400;
            int BoardWidth = 400;
            frmSelectRegion F = new frmSelectRegion();
            F.SetImageInfo(opf.FileName, BoardHeight, BoardWidth);
            F.StartPosition = FormStartPosition.CenterParent;
            DialogResult result = F.ShowDialog(this);
            if (result != DialogResult.OK)
            {
                return;
            }
            var listImage = new List<UI.pnlThumbnail.ImageInfo>();
            listImage = GetImagesFromDirectory(FileUtility.ImageBoardPath);

            RenderImages(pnlDis, listImage);

        }
    }
}
