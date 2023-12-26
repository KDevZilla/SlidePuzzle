using SlidePuzzle.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SlidePuzzle
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        Game game = null;
        UI.IBoardUI ui = null;
        /*
        int RowSize = 5;
        int ColSize = 5;
        */
        const int BoardHeight = 600;
        const int BoardWidth = 600;
        /*
        int RowSize
        {
            get
            {
                if(this.toolStripMenuItemBoardSize3.Checked )
                {
                    return 3;
                }
                if (this.toolStripMenuItemBoardSize4.Checked)
                {
                    return 4;
                }
                if (this.toolStripMenuItemBoardSize5.Checked)
                {
                    return 5;
                }
                return 4;
            }
        }
        */
        /*
        int ColSize
        {
            get
            {
                if (this.toolStripMenuItemBoardSize3.Checked)
                {
                    return 3;
                }
                if (this.toolStripMenuItemBoardSize4.Checked)
                {
                    return 4;
                }
                if (this.toolStripMenuItemBoardSize5.Checked)
                {
                    return 5;
                }
                return 4;
            }
        }
        */
        private void NewGame(Configuration con)
        {
            NewGame(con.RowSize, con.ColSize, con.IsUseImage, con.SelectedImageFilePath);
        }
        private void NewGame(int rowSize,int columnSize, Boolean isUseImage,String imageFilePath)
        {

            string UIControlName = "BoardUI";
            if (game != null)
            {
                game.Clear();
            }
            if (ui != null)
            {
                ui.Clear();
                int j;
                for(j=this.Controls.Count - 1; j >= 0;j--)
                {
                   if(this.Controls [j].Name.Equals (UIControlName))
                    {
                        this.Controls.RemoveAt(j);
                    }
                }


            }
            var image = imageFilePath != ""
                ? Image.FromFile(imageFilePath)
                : null;


           
            
            ui = new UI.BoardUI(rowSize, columnSize, BoardHeight, BoardWidth, image);
            ui.IsShowNumberOverLay = true;
           // ui.BoardImage = Image.FromFile(@"D:\Krirk\Pictures\From_ACER2\3503_gta_iv_art.jpg");
           /*
            if(!string.IsNullOrEmpty ( Configuration.Instance.SelectedImageFilePath))
            {
                ui.BoardImage = Image.FromFile(Configuration.Instance.SelectedImageFilePath);
            }
            */
            BoardUI b = (BoardUI)ui;
            b.Name = UIControlName;
            b.lblTemplate = this.lblTemplate;
            b.Visible = true;
            b.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(b);
            b.Top = this.menuStrip1.Height;
          


            game = new Game(rowSize , columnSize , ui);
            game.Won -= Game_Won;
            game.Won += Game_Won;
            game.Initial();
            game.StartWithAutomaticShuffle();


        }

        private void Form2_Load(object sender, EventArgs e)
        {

            /*
            ui = new UI.BoardUI(RowSize ,ColSize,BoardHeight ,BoardWidth );
            ui.IsShowNumberOverLay = true;
            //ui.BoardImage = Image.FromFile(@"D:\Krirk\Pictures\From_ACER2\3503_gta_iv_art.jpg");
          
            BoardUI b = (BoardUI)ui;
            b.Name = "BoardUI";
            b.lblTemplate = this.lblTemplate;
            b.Visible = true;
            b.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(b);
            */

            this.toolStripMenuItemBoardSize3.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize4.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize5.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize3.Click += toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize4.Click += toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize5.Click += toolStripMenuItemBoardChoose;
            this.lblTemplate.BackColor = Color.FromArgb(48, 48, 48);

            NewGame(Configuration.Instance.RowSize ,
                Configuration.Instance.ColSize ,
                Configuration.Instance.IsUseImage , 
                Configuration.Instance.SelectedImageFilePath );

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Up
                 || keyData == Keys.Down
                 || keyData == Keys.Left
                 || keyData == Keys.Right)
            {
                game.SendKeyDirection(keyData);
                //pnlThumbnail1.MoveSelectedImage((UI.pnlThumbnail.MoveSelectedImageDirection)keyData);
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
        private void ToolStripMenuItemBoardSize3_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void lblTemplate_Click(object sender, EventArgs e)
        {

        }

        private void x5ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private ImageCached imageCached = new ImageCached();
        //  private pnlThumbnail PnlThumnail = null;
        private FormNewGame _FormChooseGame = null;
        private FormNewGame FormChooseGame
        {
            get
            {
                if(_FormChooseGame == null)
                {
                    _FormChooseGame = new FormNewGame();
                    _FormChooseGame.ImageFilePath = FileUtility.ImageBoardPath;
                    _FormChooseGame.StartPosition = FormStartPosition.CenterParent;
                    _FormChooseGame.imageCached = this.imageCached;
                    _FormChooseGame.InitialControlAndLoadImages();
                }
                return _FormChooseGame;
            }
        }
        private void ToolStripMenuItemNewGame_Click(object sender, EventArgs e)
        {

            FormChooseGame.ShowDialog(this);
            if(FormChooseGame.DialogResult != DialogResult.OK)
            {
                return;
            }
            if(FormChooseGame.SelectedFileName != "")
            {
                Configuration.Instance.SelectedImageFilePath = FormChooseGame.SelectedFileName;
            }
            Configuration.Instance.IsUseImage = FormChooseGame.IsUseImage;
            Configuration.Instance.RowSize = FormChooseGame.RowSize;
            Configuration.Instance.ColSize = FormChooseGame.ColSize;

            //   this.PnlThumnail =formChooseGame

            NewGame(Configuration.Instance);
        }

       

        private void toolStripMenuItemBoardChoose(object sender, EventArgs e)
        {
            this.toolStripMenuItemBoardSize3.Checked = false;
            this.toolStripMenuItemBoardSize4.Checked = false;
            this.toolStripMenuItemBoardSize5.Checked = false;

            ((ToolStripMenuItem)sender).Checked = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            game.Start();
            game.Won -= Game_Won;
            game.Won += Game_Won;
            */

        }

        private void Game_Won(object sender, EventArgs e)
        {

            MessageBox.Show("Finished");

        }

       

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBoardConfiguration f = new FormBoardConfiguration();
         //   f.BoardWidth = this.BoardWidth;
         //   f.BoardHeight = this.BoardHeight;
            f.ShowDialog();

            if(f.SelectedFilePath==null ||
                f.SelectedFilePath.Trim ()=="")
            {
                return;
            }
            Configuration.Instance.SelectedImageFilePath = f.SelectedFilePath;
            Configuration.SaveInstance();

          //  GC.Collect();

        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            FormTileApperance f = new FormTileApperance();
            f.ShowDialog();

        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormScore f = new FormScore();
            f.PlayerCurrentScore = -1;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

        }
    }
}
