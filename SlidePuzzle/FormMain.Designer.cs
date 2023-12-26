namespace SlidePuzzle
{
    partial class FormMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemNewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.x5ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBoardSize3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBoardSize4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemBoardSize5 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTemplate
            // 
            this.lblTemplate.BackColor = System.Drawing.Color.Thistle;
            this.lblTemplate.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblTemplate.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTemplate.ForeColor = System.Drawing.Color.White;
            this.lblTemplate.Location = new System.Drawing.Point(1093, 602);
            this.lblTemplate.Name = "lblTemplate";
            this.lblTemplate.Size = new System.Drawing.Size(115, 115);
            this.lblTemplate.TabIndex = 3;
            this.lblTemplate.Text = "1";
            this.lblTemplate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTemplate.Click += new System.EventHandler(this.lblTemplate_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1220, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemNewGame,
            this.toolStripMenuItem2,
            this.toolStripMenuItem1,
            this.x5ToolStripMenuItem,
            this.toolStripMenuItem3,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            // 
            // ToolStripMenuItemNewGame
            // 
            this.ToolStripMenuItemNewGame.Name = "ToolStripMenuItemNewGame";
            this.ToolStripMenuItemNewGame.Size = new System.Drawing.Size(182, 22);
            this.ToolStripMenuItemNewGame.Text = "New Game";
            this.ToolStripMenuItemNewGame.Click += new System.EventHandler(this.ToolStripMenuItemNewGame_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem2.Text = "Tile Apperance";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem1.Text = "Board Configuration";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // x5ToolStripMenuItem
            // 
            this.x5ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemBoardSize3,
            this.toolStripMenuItemBoardSize4,
            this.toolStripMenuItemBoardSize5});
            this.x5ToolStripMenuItem.Name = "x5ToolStripMenuItem";
            this.x5ToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.x5ToolStripMenuItem.Text = "Board Size";
            this.x5ToolStripMenuItem.Click += new System.EventHandler(this.x5ToolStripMenuItem_Click);
            // 
            // toolStripMenuItemBoardSize3
            // 
            this.toolStripMenuItemBoardSize3.Name = "toolStripMenuItemBoardSize3";
            this.toolStripMenuItemBoardSize3.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItemBoardSize3.Text = "3 x 3";
            this.toolStripMenuItemBoardSize3.Click += new System.EventHandler(this.toolStripMenuItemBoardChoose);
            // 
            // toolStripMenuItemBoardSize4
            // 
            this.toolStripMenuItemBoardSize4.Name = "toolStripMenuItemBoardSize4";
            this.toolStripMenuItemBoardSize4.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItemBoardSize4.Text = "4 x 4";
            // 
            // toolStripMenuItemBoardSize5
            // 
            this.toolStripMenuItemBoardSize5.Name = "toolStripMenuItemBoardSize5";
            this.toolStripMenuItemBoardSize5.Size = new System.Drawing.Size(98, 22);
            this.toolStripMenuItemBoardSize5.Text = "5 x 5";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(182, 22);
            this.toolStripMenuItem3.Text = "Score";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(179, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1220, 726);
            this.Controls.Add(this.lblTemplate);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "K15Puzzle";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTemplate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemNewGame;
        private System.Windows.Forms.ToolStripMenuItem x5ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBoardSize3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBoardSize4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemBoardSize5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    }
}