namespace SlidePuzzle
{
    partial class FormBoardConfiguration
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSelectImage = new System.Windows.Forms.Button();
            this.panelButton = new System.Windows.Forms.Panel();
            this.chkUseImage = new System.Windows.Forms.CheckBox();
            this.btnDeleteImage = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkIsShowNumberOverlay = new System.Windows.Forms.CheckBox();
            this.lblTemplate = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxFontSize = new System.Windows.Forms.ComboBox();
            this.btnChooseTileColor = new System.Windows.Forms.Button();
            this.btnChooseFontColor = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.cboBoardSize = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.panelButton.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(6, 50);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(886, 292);
            this.panel1.TabIndex = 0;
            // 
            // btnSelectImage
            // 
            this.btnSelectImage.Enabled = false;
            this.btnSelectImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelectImage.Location = new System.Drawing.Point(0, 1);
            this.btnSelectImage.Name = "btnSelectImage";
            this.btnSelectImage.Size = new System.Drawing.Size(99, 34);
            this.btnSelectImage.TabIndex = 2;
            this.btnSelectImage.Text = "Select Image";
            this.btnSelectImage.UseVisualStyleBackColor = true;
            this.btnSelectImage.Visible = false;
            this.btnSelectImage.Click += new System.EventHandler(this.btnSelectImage_Click);
            // 
            // panelButton
            // 
            this.panelButton.Controls.Add(this.btnSelectImage);
            this.panelButton.Location = new System.Drawing.Point(528, 348);
            this.panelButton.Name = "panelButton";
            this.panelButton.Size = new System.Drawing.Size(364, 35);
            this.panelButton.TabIndex = 3;
            // 
            // chkUseImage
            // 
            this.chkUseImage.AutoSize = true;
            this.chkUseImage.Location = new System.Drawing.Point(7, 16);
            this.chkUseImage.Name = "chkUseImage";
            this.chkUseImage.Size = new System.Drawing.Size(106, 24);
            this.chkUseImage.TabIndex = 4;
            this.chkUseImage.Text = "Use Image";
            this.chkUseImage.UseVisualStyleBackColor = true;
            this.chkUseImage.CheckedChanged += new System.EventHandler(this.chkUseImage_CheckedChanged);
            // 
            // btnDeleteImage
            // 
            this.btnDeleteImage.Enabled = false;
            this.btnDeleteImage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteImage.Location = new System.Drawing.Point(6, 348);
            this.btnDeleteImage.Name = "btnDeleteImage";
            this.btnDeleteImage.Size = new System.Drawing.Size(99, 34);
            this.btnDeleteImage.TabIndex = 3;
            this.btnDeleteImage.Text = "Delete Image";
            this.btnDeleteImage.UseVisualStyleBackColor = true;
            this.btnDeleteImage.Click += new System.EventHandler(this.btnDeleteImage_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(942, 454);
            this.tabControl1.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDeleteImage);
            this.tabPage1.Controls.Add(this.chkUseImage);
            this.tabPage1.Controls.Add(this.panel1);
            this.tabPage1.Controls.Add(this.panelButton);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(934, 421);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chkIsShowNumberOverlay);
            this.tabPage2.Controls.Add(this.lblTemplate);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Controls.Add(this.comboBoxFontSize);
            this.tabPage2.Controls.Add(this.btnChooseTileColor);
            this.tabPage2.Controls.Add(this.btnChooseFontColor);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(934, 421);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Tile Apperance";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chkIsShowNumberOverlay
            // 
            this.chkIsShowNumberOverlay.AutoSize = true;
            this.chkIsShowNumberOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsShowNumberOverlay.Location = new System.Drawing.Point(334, 310);
            this.chkIsShowNumberOverlay.Name = "chkIsShowNumberOverlay";
            this.chkIsShowNumberOverlay.Size = new System.Drawing.Size(342, 24);
            this.chkIsShowNumberOverlay.TabIndex = 19;
            this.chkIsShowNumberOverlay.Text = "Show Number overlay in case of using image";
            this.chkIsShowNumberOverlay.UseVisualStyleBackColor = true;
            this.chkIsShowNumberOverlay.CheckedChanged += new System.EventHandler(this.chkIsShowNumberOverlay_CheckedChanged);
            // 
            // lblTemplate
            // 
            this.lblTemplate.BackColor = System.Drawing.Color.Thistle;
            this.lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTemplate.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.ForeColor = System.Drawing.Color.White;
            this.lblTemplate.Location = new System.Drawing.Point(438, 46);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(115, 115);
            this.lblTemplate.TabIndex = 14;
            this.lblTemplate.Text = "1";
            this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(349, 185);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 20);
            this.label1.TabIndex = 15;
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
            this.comboBoxFontSize.Location = new System.Drawing.Point(432, 182);
            this.comboBoxFontSize.Name = "comboBoxFontSize";
            this.comboBoxFontSize.Size = new System.Drawing.Size(121, 28);
            this.comboBoxFontSize.TabIndex = 16;
            this.comboBoxFontSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxFontSize_SelectedIndexChanged);
            // 
            // btnChooseTileColor
            // 
            this.btnChooseTileColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseTileColor.Location = new System.Drawing.Point(343, 257);
            this.btnChooseTileColor.Name = "btnChooseTileColor";
            this.btnChooseTileColor.Size = new System.Drawing.Size(210, 35);
            this.btnChooseTileColor.TabIndex = 18;
            this.btnChooseTileColor.Text = "Choose Tile Color ...";
            this.btnChooseTileColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseTileColor.UseVisualStyleBackColor = true;
            this.btnChooseTileColor.Click += new System.EventHandler(this.btnChooseTileColor_Click);
            // 
            // btnChooseFontColor
            // 
            this.btnChooseFontColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChooseFontColor.Location = new System.Drawing.Point(343, 216);
            this.btnChooseFontColor.Name = "btnChooseFontColor";
            this.btnChooseFontColor.Size = new System.Drawing.Size(210, 35);
            this.btnChooseFontColor.TabIndex = 17;
            this.btnChooseFontColor.Text = "Choose Font Color ...";
            this.btnChooseFontColor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnChooseFontColor.UseVisualStyleBackColor = true;
            this.btnChooseFontColor.Click += new System.EventHandler(this.btnChooseFontColor_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.cboBoardSize);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(934, 421);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Board Size";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // cboBoardSize
            // 
            this.cboBoardSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboBoardSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboBoardSize.FormattingEnabled = true;
            this.cboBoardSize.Items.AddRange(new object[] {
            "3 x 3",
            "4 x 4",
            "5 x 5"});
            this.cboBoardSize.Location = new System.Drawing.Point(299, 118);
            this.cboBoardSize.Name = "cboBoardSize";
            this.cboBoardSize.Size = new System.Drawing.Size(236, 28);
            this.cboBoardSize.TabIndex = 18;
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(693, 473);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(170, 35);
            this.btnOK.TabIndex = 13;
            this.btnOK.Text = "Save and Close";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(869, 473);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 35);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FormBoardConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 520);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormBoardConfiguration";
            this.Text = "Board Configuration";
            this.Load += new System.EventHandler(this.FormChooseImage_Load);
            this.panelButton.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSelectImage;
        private System.Windows.Forms.Panel panelButton;
        private System.Windows.Forms.Button btnDeleteImage;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.CheckBox chkUseImage;
        private System.Windows.Forms.CheckBox chkIsShowNumberOverlay;
        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxFontSize;
        private System.Windows.Forms.Button btnChooseTileColor;
        private System.Windows.Forms.Button btnChooseFontColor;
        private System.Windows.Forms.ComboBox cboBoardSize;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
    }
}