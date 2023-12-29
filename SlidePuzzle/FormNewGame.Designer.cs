namespace SlidePuzzle
{
    partial class FormNewGame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNewGame));
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNewImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNumberofBlock = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkUseImage = new System.Windows.Forms.CheckBox();
            this.chkIsShowNumberOverlay = new System.Windows.Forms.CheckBox();
            this.cboTileMoveSpeed = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.pnlThumbnail1 = new SlidePuzzle.UI.pnlThumbnail();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(821, 141);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(825, 187);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(48, 220);
            this.panel1.TabIndex = 1;
            // 
            // btnAddNewImage
            // 
            this.btnAddNewImage.Location = new System.Drawing.Point(548, 137);
            this.btnAddNewImage.Name = "btnAddNewImage";
            this.btnAddNewImage.Size = new System.Drawing.Size(147, 39);
            this.btnAddNewImage.TabIndex = 2;
            this.btnAddNewImage.Text = "Add new image ...";
            this.btnAddNewImage.UseVisualStyleBackColor = true;
            this.btnAddNewImage.Click += new System.EventHandler(this.btnAddNewImage_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(616, 485);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(534, 485);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(76, 39);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Board Size:";
            // 
            // cboNumberofBlock
            // 
            this.cboNumberofBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumberofBlock.FormattingEnabled = true;
            this.cboNumberofBlock.Items.AddRange(new object[] {
            "3 x 3",
            "4 x 4",
            "5 x 5"});
            this.cboNumberofBlock.Location = new System.Drawing.Point(143, 6);
            this.cboNumberofBlock.Name = "cboNumberofBlock";
            this.cboNumberofBlock.Size = new System.Drawing.Size(135, 29);
            this.cboNumberofBlock.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 146);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choose an Image:";
            // 
            // chkUseImage
            // 
            this.chkUseImage.AutoSize = true;
            this.chkUseImage.Location = new System.Drawing.Point(16, 89);
            this.chkUseImage.Name = "chkUseImage";
            this.chkUseImage.Size = new System.Drawing.Size(102, 25);
            this.chkUseImage.TabIndex = 10;
            this.chkUseImage.Text = "Use Image";
            this.chkUseImage.UseVisualStyleBackColor = true;
            this.chkUseImage.CheckedChanged += new System.EventHandler(this.chkUseImage_CheckedChanged);
            // 
            // chkIsShowNumberOverlay
            // 
            this.chkIsShowNumberOverlay.AutoSize = true;
            this.chkIsShowNumberOverlay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsShowNumberOverlay.Location = new System.Drawing.Point(16, 120);
            this.chkIsShowNumberOverlay.Name = "chkIsShowNumberOverlay";
            this.chkIsShowNumberOverlay.Size = new System.Drawing.Size(342, 24);
            this.chkIsShowNumberOverlay.TabIndex = 14;
            this.chkIsShowNumberOverlay.Text = "Show Number overlay in case of using image";
            this.chkIsShowNumberOverlay.UseVisualStyleBackColor = true;
            // 
            // cboTileMoveSpeed
            // 
            this.cboTileMoveSpeed.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTileMoveSpeed.FormattingEnabled = true;
            this.cboTileMoveSpeed.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cboTileMoveSpeed.Location = new System.Drawing.Point(143, 41);
            this.cboTileMoveSpeed.Name = "cboTileMoveSpeed";
            this.cboTileMoveSpeed.Size = new System.Drawing.Size(135, 29);
            this.cboTileMoveSpeed.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(125, 21);
            this.label4.TabIndex = 15;
            this.label4.Text = "Tile Move speed:";
            // 
            // pnlThumbnail1
            // 
            this.pnlThumbnail1.imageCache = null;
            this.pnlThumbnail1.IsUseCacheImage = false;
            this.pnlThumbnail1.Location = new System.Drawing.Point(12, 179);
            this.pnlThumbnail1.Name = "pnlThumbnail1";
            this.pnlThumbnail1.SelectedImageFileName = "";
            this.pnlThumbnail1.Size = new System.Drawing.Size(681, 299);
            this.pnlThumbnail1.TabIndex = 6;
            // 
            // FormNewGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 536);
            this.Controls.Add(this.cboTileMoveSpeed);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.chkIsShowNumberOverlay);
            this.Controls.Add(this.chkUseImage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboNumberofBlock);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pnlThumbnail1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAddNewImage);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormNewGame";
            this.Text = "Select Image";
            this.Load += new System.EventHandler(this.FormTestPnlDisplay_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddNewImage;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private UI.pnlThumbnail pnlThumbnail1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboNumberofBlock;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkUseImage;
        private System.Windows.Forms.CheckBox chkIsShowNumberOverlay;
        private System.Windows.Forms.ComboBox cboTileMoveSpeed;
        private System.Windows.Forms.Label label4;
    }
}