namespace SlidePuzzle
{
    partial class FormTileApperance
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTemplate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.btnChooseFontColor = new System.Windows.Forms.Button();
            this.btnChooseTileColor = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkIsShowNumberOverlay = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTemplate
            // 
            this.lblTemplate.BackColor = System.Drawing.Color.Thistle;
            this.lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTemplate.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.ForeColor = System.Drawing.Color.White;
            this.lblTemplate.Location = new System.Drawing.Point(122, 42);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(115, 115);
            this.lblTemplate.TabIndex = 4;
            this.lblTemplate.Text = "1";
            this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Font Size";
            // 
            // comboBoxFontSize
            // 
            this.comboBoxFontSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFontSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxFontSize.FormattingEnabled = true;
            this.comboBoxFontSize.Items.AddRange(new object[] {
            "22",
            "24",
            "26",
            "28",
            "36"});
            this.comboBoxFontSize.Location = new System.Drawing.Point(116, 178);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFontSize.TabIndex = 7;
            this.comboBoxFontSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontSize_SelectedIndexChanged);
            // 
            // btnChooseFontColor
            // 
            this.btnChooseFontColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFontColor.Location = new System.Drawing.Point(27, 212);
            this.btnChooseFontColor.Name = "btnChooseFontColor";
            this.btnChooseFontColor.Size = new System.Drawing.Size(210, 35);
            this.btnChooseFontColor.TabIndex = 8;
            this.btnChooseFontColor.Text = "Choose Font Color ...";
            this.btnChooseFontColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseFontColor.UseVisualStyleBackColor = true;
            this.btnChooseFontColor.Click += new System.EventHandler(this.btnChooseFontColor_Click);
            // 
            // btnChooseTileColor
            // 
            this.btnChooseTileColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseTileColor.Location = new System.Drawing.Point(27, 253);
            this.btnChooseTileColor.Name = "btnChooseTileColor";
            this.btnChooseTileColor.Size = new System.Drawing.Size(210, 35);
            this.btnChooseTileColor.TabIndex = 9;
            this.btnChooseTileColor.Text = "Choose Tile Color ...";
            this.btnChooseTileColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseTileColor.UseVisualStyleBackColor = true;
            this.btnChooseTileColor.Click += new System.EventHandler(this.btnChooseTileColor_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(311, 530);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(85, 35);
            this.button3.TabIndex = 10;
            this.button3.Text = "Cancel";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(220, 530);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(85, 35);
            this.button4.TabIndex = 11;
            this.button4.Text = "OK";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkIsShowNumberOverlay);
            this.groupBox1.Controls.Add(this.lblTemplate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.comboBoxFontSize);
            this.groupBox1.Controls.Add(this.btnChooseTileColor);
            this.groupBox1.Controls.Add(this.btnChooseFontColor);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(372, 343);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tile Apperance";
            // 
            // chkIsShowNumberOverlay
            // 
            this.chkIsShowNumberOverlay.AutoSize = true;
            this.chkIsShowNumberOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsShowNumberOverlay.Location = new System.Drawing.Point(18, 306);
            this.chkIsShowNumberOverlay.Name = "chkIsShowNumberOverlay";
            this.chkIsShowNumberOverlay.Size = new System.Drawing.Size(342, 24);
            this.chkIsShowNumberOverlay.TabIndex = 13;
            this.chkIsShowNumberOverlay.Text = "Show Number overlay in case of using image";
            this.chkIsShowNumberOverlay.UseVisualStyleBackColor = true;
            this.chkIsShowNumberOverlay.CheckedChanged += new System.EventHandler(this.chkIsShowNumberOverlay_CheckedChanged);
            // 
            // FormTileApperance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1229, 588);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Name = "FormTileApperance";
            this.Text = "Option";
            this.Load += new System.EventHandler(this.FormTileApperance_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private System.Windows.Forms.Button btnChooseFontColor;
        private System.Windows.Forms.Button btnChooseTileColor;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkIsShowNumberOverlay;
    }
}