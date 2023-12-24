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
    public partial class FormTileApperance : Form
    {
        public FormTileApperance()
        {
            InitializeComponent();
        }

        private void btnChooseFontColor_Click(object sender, EventArgs e)
        {
            ColorDialog cda = new ColorDialog();
            if(cda.ShowDialog ()!= DialogResult.OK )
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
            this.lblTemplate.BackColor  = cda.Color;
        }

        private void comboBoxFontSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            float fontSize = new float();
            fontSize = float.Parse (this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());

            this.lblTemplate.Font = new System.Drawing.Font(this.lblTemplate.Font.Name, fontSize);
            
        }
       
        private void FormTileApperance_Load(object sender, EventArgs e)
        {
            this.chkIsShowNumberOverlay.Checked = Configuration.Instance.IsShowNumberOverlay;
            //this.comboBoxFontSize.SelectedText = Configuration.Instance.TileFontSize.ToString ();
            this.comboBoxFontSize.SelectedIndex = this.comboBoxFontSize.FindString(Configuration.Instance.TileFontSize.ToString());
            this.lblTemplate.Text = "";
            if(this.chkIsShowNumberOverlay.Checked)
            {
                this.lblTemplate.Text = "1";
            }
            float fontSize = new float();
            fontSize = float.Parse(this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());

            this.lblTemplate.Font = new Font(this.lblTemplate.Font.Name, fontSize);
            this.lblTemplate.BackColor = Configuration.Instance.TileBackColor;
            this.lblTemplate.ForeColor = Configuration.Instance.TileForeColor;


        }

        private void button4_Click(object sender, EventArgs e)
        {
          Configuration.Instance.IsShowNumberOverlay = this.chkIsShowNumberOverlay.Checked;
            float fontSize = new float();
            fontSize = float.Parse(this.comboBoxFontSize.Items[this.comboBoxFontSize.SelectedIndex].ToString());
            Configuration.Instance.TileFontSize = fontSize;
            Configuration.Instance.TileBackColor = lblTemplate.BackColor;
            Configuration.Instance.TileForeColor = lblTemplate.ForeColor;
            Configuration.SaveInstance();


          
        }

        private void chkIsShowNumberOverlay_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
