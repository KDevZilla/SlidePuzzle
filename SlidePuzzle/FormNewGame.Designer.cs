namespace SlidePuzzle
{
    partial class FormTestPnlDisplay
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnAddNewImage = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboNumberofBlock = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlThumbnail1 = new SlidePuzzle.UI.pnlThumbnail();
            this.chkUseImage = new System.Windows.Forms.CheckBox();
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
            this.btnAddNewImage.Location = new System.Drawing.Point(548, 101);
            this.btnAddNewImage.Name = "btnAddNewImage";
            this.btnAddNewImage.Size = new System.Drawing.Size(147, 39);
            this.btnAddNewImage.TabIndex = 2;
            this.btnAddNewImage.Text = "Add new image ...";
            this.btnAddNewImage.UseVisualStyleBackColor = true;
            this.btnAddNewImage.Click += new System.EventHandler(this.btnAddNewImage_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(619, 453);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(76, 39);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(537, 453);
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
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 7;
            this.label2.Text = "Number of blocks:";
            // 
            // cboNumberofBlock
            // 
            this.cboNumberofBlock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboNumberofBlock.FormattingEnabled = true;
            this.cboNumberofBlock.Items.AddRange(new object[] {
            "8",
            "15",
            "24"});
            this.cboNumberofBlock.Location = new System.Drawing.Point(155, 6);
            this.cboNumberofBlock.Name = "cboNumberofBlock";
            this.cboNumberofBlock.Size = new System.Drawing.Size(99, 29);
            this.cboNumberofBlock.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 110);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Choose an Image:";
            // 
            // pnlThumbnail1
            // 
            this.pnlThumbnail1.Location = new System.Drawing.Point(12, 143);
            this.pnlThumbnail1.Name = "pnlThumbnail1";
            this.pnlThumbnail1.Size = new System.Drawing.Size(681, 299);
            this.pnlThumbnail1.TabIndex = 6;
            // 
            // chkUseImage
            // 
            this.chkUseImage.AutoSize = true;
            this.chkUseImage.Location = new System.Drawing.Point(16, 53);
            this.chkUseImage.Name = "chkUseImage";
            this.chkUseImage.Size = new System.Drawing.Size(102, 25);
            this.chkUseImage.TabIndex = 10;
            this.chkUseImage.Text = "Use Image";
            this.chkUseImage.UseVisualStyleBackColor = true;
            // 
            // FormTestPnlDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 500);
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
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormTestPnlDisplay";
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
    }
}