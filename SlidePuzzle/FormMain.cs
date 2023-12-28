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

     //   const int BoardHeight = 600;
     //   const int BoardWidth = 600;
  
        private void NewGame(Configuration con)
        {
            NewGame(con.RowSize, con.ColSize, con.IsUseImage,con.IsShowNumberOverlay , con.SelectedImageFilePath,con.BoradHeight ,con.BoardWidth );
        }
        private void NewGame(int rowSize,int columnSize, Boolean isUseImage, Boolean isShowNumberOverlay,String imageFilePath, int boardHeight, int boardWidth)
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
            var image = (isUseImage &&  imageFilePath != "")
                ? Image.FromFile(imageFilePath)
                : null;


           
            
            ui = new UI.BoardUI(rowSize, columnSize, boardHeight, boardWidth, image);
            ui.IsShowNumberOverLay = isShowNumberOverlay;

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
        
            game.PropertyChanged += (o, e2) =>
            {
               if(e2.PropertyName.Equals("NoofMoves"))
                {
                    this.lblNumberofMoves.Text = game.NoofMoves.ToString ();
                }
            };
            game.Initial();
            StartGame();

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
                Configuration.Instance.SelectedImageFilePath,
                Configuration.Instance.BoradHeight ,
                Configuration.Instance.BoardWidth);

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
            FormChooseGame.IsUseImage = Configuration.Instance.IsUseImage;
            FormChooseGame.RowSize = Configuration.Instance.RowSize;
            FormChooseGame.ColSize = FormChooseGame.RowSize;
            FormChooseGame.SelectedFileName = Configuration.Instance.SelectedImageFilePath;
            FormChooseGame.IsShowNumberOverlay = Configuration.Instance.IsShowNumberOverlay;
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
            Configuration.Instance.IsShowNumberOverlay = FormChooseGame.IsShowNumberOverlay;

            //   this.PnlThumnail =formChooseGame
            Configuration.SaveInstance();
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
            timerSecond.Enabled = false;
            MessageBox.Show("Finished");

            var newRank = ScoreHelper.CalculateNewRankFromScore(this.secondCount , Configuration.Instance.RowSize );
            if(newRank <= -1)
            {
                return;
            }

            FormScore f = new FormScore();
            f.PlayerCurrentScore =secondCount ;
            f.NewRank = newRank;
            f.RowSize = Configuration.Instance.RowSize;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog(this);

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
            f.RowSize = Configuration.Instance.RowSize;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();

        }
        private int secondCount = 0;
        Timer timerSecond = new Timer();
        private void StartGame()
        {
            game.StartWithAutomaticShuffle();
            secondCount = 0;
            timerSecond.Interval = 1000;
            timerSecond.Tick -= TimerSecond_Tick;
            timerSecond.Tick += TimerSecond_Tick;
            timerSecond.Enabled = true;
        }
        private void btnStartGame_Click(object sender, EventArgs e)
        {
            StartGame();
        }

        private void TimerSecond_Tick(object sender, EventArgs e)
        {
            secondCount++;
            this.lblTime.Text = secondCount.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.lblTime.Text = "9";
            Game_Won(null, null);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Game_Won(null, null);
        }
    }
}
