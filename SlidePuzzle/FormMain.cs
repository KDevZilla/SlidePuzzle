using KSlider.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KSlider
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
        int BoardHeight = 600;
        int BoardWidth = 600;
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
        private void NewGame()
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

            ui = new UI.BoardUI(RowSize, ColSize,600,600);
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


            game = new Game(RowSize , ColSize , ui);
            game.Won -= Game_Won;
            game.Won += Game_Won;
            game.Initial();
            game.Start();


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            ui = new UI.BoardUI(RowSize ,ColSize,BoardHeight ,BoardWidth );
            ui.IsShowNumberOverLay = true;
            //ui.BoardImage = Image.FromFile(@"D:\Krirk\Pictures\From_ACER2\3503_gta_iv_art.jpg");
            this.lblTemplate.BackColor = Color.FromArgb(48, 48, 48);

            BoardUI b = (BoardUI)ui;
            b.Name = "BoardUI";
            b.lblTemplate = this.lblTemplate;
            b.Visible = true;
            b.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(b);

            this.toolStripMenuItemBoardSize3.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize4.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize5.Click -= toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize3.Click += toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize4.Click += toolStripMenuItemBoardChoose;
            this.toolStripMenuItemBoardSize5.Click += toolStripMenuItemBoardChoose;

            NewGame();

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
        

        private void ToolStripMenuItemNewGame_Click(object sender, EventArgs e)
        {
            NewGame();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int i;
          //  RowSize = 4;
          //  ColSize = 4;
            NewGame();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // RowSize = 5;
           // ColSize = 5;
            NewGame();

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
            game.Start();
            game.Won -= Game_Won;
            game.Won += Game_Won;

        }

        private void Game_Won(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            MessageBox.Show("Finished");

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Text = "No";
            if(game.IsInFinishedPosition)
            {
                this.button4.Text = "Yes";
                return;
            }

            
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBoardConfiguration f = new FormBoardConfiguration();
            f.BoardWidth = this.BoardWidth;
            f.BoardHeight = this.BoardHeight;
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
    }
}
