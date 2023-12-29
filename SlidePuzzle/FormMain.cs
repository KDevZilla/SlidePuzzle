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
            NewGame(con.RowSize, con.ColSize, con.IsUseImage,con.IsShowNumberOverlay , con.SelectedImageFilePath,con.BoradHeight ,con.BoardWidth,con.TileMoveSpeed  );
        }
        private void NewGame(int rowSize,int columnSize, Boolean isUseImage, Boolean isShowNumberOverlay,String imageFilePath, int boardHeight, int boardWidth, int tileMoveSpeed)
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
            ui.TileMoveSpeed = tileMoveSpeed;

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
            



            this.lblTemplate.BackColor = Color.FromArgb(48, 48, 48);

            NewGame(Configuration.Instance.RowSize ,
                Configuration.Instance.ColSize ,
                Configuration.Instance.IsUseImage , 
                Configuration.Instance.IsShowNumberOverlay ,
                Configuration.Instance.SelectedImageFilePath,
                Configuration.Instance.BoradHeight ,
                Configuration.Instance.BoardWidth,
                Configuration.Instance.TileMoveSpeed);

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Up
                 || keyData == Keys.Down
                 || keyData == Keys.Left
                 || keyData == Keys.Right)
            {
                game.SendKeyDirection(keyData);
               
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
            if(DialogResult.OK != MessageBox.Show ("Do you want to exit ?","", MessageBoxButtons.OKCancel ))
            {
                return;
            }
            Application.Exit();

        }
        /*
         * The purpose of imageCached to stroe an image that will be loaded into the items on
          FormNewGame but we might does not have much benefit to use it because
          We already cache the whole FormNewGame

            _FormChooseGame will not be destory when the user choose the game type
            because we don't want to reload an image thumbnail every time
        */
        private ImageCached imageCached = new ImageCached();
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
            FormChooseGame.Icon = this.Icon;
            FormChooseGame.IsUseImage = Configuration.Instance.IsUseImage;
            FormChooseGame.RowSize = Configuration.Instance.RowSize;
            FormChooseGame.ColSize = FormChooseGame.RowSize;
            FormChooseGame.SelectedFileName = Configuration.Instance.SelectedImageFilePath;
            FormChooseGame.IsShowNumberOverlay = Configuration.Instance.IsShowNumberOverlay;
            FormChooseGame.TileMoveSpeed = Configuration.Instance.TileMoveSpeed;
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
            Configuration.Instance.TileMoveSpeed = FormChooseGame.TileMoveSpeed;

            Configuration.SaveInstance();
            NewGame(Configuration.Instance);
        }

       

        private void toolStripMenuItemBoardChoose(object sender, EventArgs e)
        {


            ((ToolStripMenuItem)sender).Checked = true;

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

       

      

       

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            FormScore f = new FormScore();
            f.Icon = this.Icon;
            f.PlayerCurrentScore = -1;
            f.RowSize = Configuration.Instance.RowSize;
            f.StartPosition = FormStartPosition.CenterParent;
            f.ShowDialog();
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
            TimeSpan timeSpan = TimeSpan.FromSeconds(secondCount);
            this.lblTime.Text = timeSpan.ToString(@"hh\:mm\:ss");
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
