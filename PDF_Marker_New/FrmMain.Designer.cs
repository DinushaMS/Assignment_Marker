namespace PDF_Marker_New
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tbtnOpen = new System.Windows.Forms.ToolStripButton();
            this.tbtnSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnPrev = new System.Windows.Forms.ToolStripButton();
            this.txtPage = new System.Windows.Forms.ToolStripTextBox();
            this.tbtnNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tbtnCorrect = new System.Windows.Forms.ToolStripButton();
            this.tbtnWrong = new System.Windows.Forms.ToolStripButton();
            this.tbtnText = new System.Windows.Forms.ToolStripButton();
            this.tbtnSelect = new System.Windows.Forms.ToolStripButton();
            this.tbtnDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.txtScore = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtFullScore = new System.Windows.Forms.ToolStripTextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.pnlPage = new System.Windows.Forms.Panel();
            this.pbPage = new System.Windows.Forms.PictureBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.moveFinalScoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCorrectMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addIncorrectMarkerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectAnnotationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteSelectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.pnlPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tbtnOpen,
            this.tbtnSave,
            this.toolStripSeparator1,
            this.tbtnPrev,
            this.txtPage,
            this.tbtnNext,
            this.toolStripSeparator2,
            this.tbtnCorrect,
            this.tbtnWrong,
            this.tbtnText,
            this.tbtnSelect,
            this.tbtnDelete,
            this.toolStripSeparator3,
            this.toolStripLabel2,
            this.txtScore,
            this.toolStripLabel1,
            this.txtFullScore});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 27);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tbtnOpen
            // 
            this.tbtnOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnOpen.Image = global::PDF_Marker_New.Properties.Resources.Open;
            this.tbtnOpen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnOpen.Name = "tbtnOpen";
            this.tbtnOpen.Size = new System.Drawing.Size(24, 24);
            this.tbtnOpen.Text = "toolStripButton1";
            this.tbtnOpen.ToolTipText = "Open PDF";
            this.tbtnOpen.Click += new System.EventHandler(this.tbtnOpen_Click);
            // 
            // tbtnSave
            // 
            this.tbtnSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSave.Image = global::PDF_Marker_New.Properties.Resources.Save;
            this.tbtnSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSave.Name = "tbtnSave";
            this.tbtnSave.Size = new System.Drawing.Size(24, 24);
            this.tbtnSave.Text = "toolStripButton1";
            this.tbtnSave.ToolTipText = "Save PDF";
            this.tbtnSave.Click += new System.EventHandler(this.tbtnSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // tbtnPrev
            // 
            this.tbtnPrev.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnPrev.Image = global::PDF_Marker_New.Properties.Resources.Prev;
            this.tbtnPrev.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnPrev.Name = "tbtnPrev";
            this.tbtnPrev.Size = new System.Drawing.Size(24, 24);
            this.tbtnPrev.Text = "toolStripButton2";
            this.tbtnPrev.Click += new System.EventHandler(this.tbtnPrev_Click);
            // 
            // txtPage
            // 
            this.txtPage.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtPage.Name = "txtPage";
            this.txtPage.ReadOnly = true;
            this.txtPage.Size = new System.Drawing.Size(50, 27);
            this.txtPage.Text = "0 of 0";
            this.txtPage.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbtnNext
            // 
            this.tbtnNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnNext.Image = global::PDF_Marker_New.Properties.Resources.Next;
            this.tbtnNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnNext.Name = "tbtnNext";
            this.tbtnNext.Size = new System.Drawing.Size(24, 24);
            this.tbtnNext.Text = "toolStripButton3";
            this.tbtnNext.Click += new System.EventHandler(this.tbtnNext_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // tbtnCorrect
            // 
            this.tbtnCorrect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnCorrect.Image = global::PDF_Marker_New.Properties.Resources.Ricon;
            this.tbtnCorrect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnCorrect.Name = "tbtnCorrect";
            this.tbtnCorrect.Size = new System.Drawing.Size(24, 24);
            this.tbtnCorrect.Text = "toolStripButton1";
            this.tbtnCorrect.ToolTipText = "Mark Correct";
            this.tbtnCorrect.Click += new System.EventHandler(this.tbtnCorrect_Click);
            // 
            // tbtnWrong
            // 
            this.tbtnWrong.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnWrong.Image = global::PDF_Marker_New.Properties.Resources.Wicon;
            this.tbtnWrong.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnWrong.Name = "tbtnWrong";
            this.tbtnWrong.Size = new System.Drawing.Size(24, 24);
            this.tbtnWrong.Text = "toolStripButton2";
            this.tbtnWrong.ToolTipText = "Mark Incorrect";
            this.tbtnWrong.Click += new System.EventHandler(this.tbtnWrong_Click);
            // 
            // tbtnText
            // 
            this.tbtnText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnText.Image = global::PDF_Marker_New.Properties.Resources.Text;
            this.tbtnText.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnText.Name = "tbtnText";
            this.tbtnText.Size = new System.Drawing.Size(24, 24);
            this.tbtnText.Text = "toolStripButton3";
            this.tbtnText.ToolTipText = "Add Comment";
            this.tbtnText.Click += new System.EventHandler(this.tbtnText_Click);
            // 
            // tbtnSelect
            // 
            this.tbtnSelect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnSelect.Image = global::PDF_Marker_New.Properties.Resources.Select;
            this.tbtnSelect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnSelect.Name = "tbtnSelect";
            this.tbtnSelect.Size = new System.Drawing.Size(24, 24);
            this.tbtnSelect.Text = "toolStripButton1";
            this.tbtnSelect.ToolTipText = "Select Annotation";
            this.tbtnSelect.Click += new System.EventHandler(this.tbtnSelect_Click);
            // 
            // tbtnDelete
            // 
            this.tbtnDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tbtnDelete.Image = global::PDF_Marker_New.Properties.Resources.Delete;
            this.tbtnDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tbtnDelete.Name = "tbtnDelete";
            this.tbtnDelete.Size = new System.Drawing.Size(24, 24);
            this.tbtnDelete.Text = "toolStripButton4";
            this.tbtnDelete.ToolTipText = "Delete Mark";
            this.tbtnDelete.Click += new System.EventHandler(this.tbtnDelete_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(39, 24);
            this.toolStripLabel2.Text = "Score:";
            // 
            // txtScore
            // 
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtScore.Name = "txtScore";
            this.txtScore.ReadOnly = true;
            this.txtScore.Size = new System.Drawing.Size(25, 27);
            this.txtScore.Text = "0";
            this.txtScore.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtScore.TextChanged += new System.EventHandler(this.txtScore_TextChanged);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(12, 24);
            this.toolStripLabel1.Text = "/";
            // 
            // txtFullScore
            // 
            this.txtFullScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtFullScore.Name = "txtFullScore";
            this.txtFullScore.Size = new System.Drawing.Size(25, 27);
            this.txtFullScore.Text = "100";
            this.txtFullScore.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtFullScore.TextChanged += new System.EventHandler(this.txtFullScore_TextChanged);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.LargeChange = 20;
            this.vScrollBar1.Location = new System.Drawing.Point(768, 51);
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(32, 399);
            this.vScrollBar1.SmallChange = 10;
            this.vScrollBar1.TabIndex = 3;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            // 
            // pnlPage
            // 
            this.pnlPage.Controls.Add(this.pbPage);
            this.pnlPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlPage.Location = new System.Drawing.Point(0, 51);
            this.pnlPage.Name = "pnlPage";
            this.pnlPage.Size = new System.Drawing.Size(768, 399);
            this.pnlPage.TabIndex = 5;
            // 
            // pbPage
            // 
            this.pbPage.Location = new System.Drawing.Point(0, 0);
            this.pbPage.Name = "pbPage";
            this.pbPage.Size = new System.Drawing.Size(300, 200);
            this.pbPage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pbPage.TabIndex = 4;
            this.pbPage.TabStop = false;
            this.pbPage.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPage_Paint);
            this.pbPage.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbPage_MouseClick);
            this.pbPage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbPage_MouseDown);
            this.pbPage.MouseLeave += new System.EventHandler(this.pbPage_MouseLeave);
            this.pbPage.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbPage_MouseMove);
            this.pbPage.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.pbPage_MouseWheel);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.moveFinalScoreToolStripMenuItem,
            this.addCorrectMarkerToolStripMenuItem,
            this.addIncorrectMarkerToolStripMenuItem,
            this.addCommentToolStripMenuItem,
            this.selectAnnotationsToolStripMenuItem,
            this.deleteSelectedToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(196, 136);
            // 
            // moveFinalScoreToolStripMenuItem
            // 
            this.moveFinalScoreToolStripMenuItem.Name = "moveFinalScoreToolStripMenuItem";
            this.moveFinalScoreToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.moveFinalScoreToolStripMenuItem.Text = "Move Final Score";
            this.moveFinalScoreToolStripMenuItem.Click += new System.EventHandler(this.moveFinalScoreToolStripMenuItem_Click);
            // 
            // addCorrectMarkerToolStripMenuItem
            // 
            this.addCorrectMarkerToolStripMenuItem.Name = "addCorrectMarkerToolStripMenuItem";
            this.addCorrectMarkerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addCorrectMarkerToolStripMenuItem.Text = "Select Correct Marker";
            this.addCorrectMarkerToolStripMenuItem.Click += new System.EventHandler(this.addCorrectMarkerToolStripMenuItem_Click);
            // 
            // addIncorrectMarkerToolStripMenuItem
            // 
            this.addIncorrectMarkerToolStripMenuItem.Name = "addIncorrectMarkerToolStripMenuItem";
            this.addIncorrectMarkerToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addIncorrectMarkerToolStripMenuItem.Text = "Select Incorrect Marker";
            this.addIncorrectMarkerToolStripMenuItem.Click += new System.EventHandler(this.addIncorrectMarkerToolStripMenuItem_Click);
            // 
            // addCommentToolStripMenuItem
            // 
            this.addCommentToolStripMenuItem.Name = "addCommentToolStripMenuItem";
            this.addCommentToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addCommentToolStripMenuItem.Text = "Select Add Comment";
            this.addCommentToolStripMenuItem.Click += new System.EventHandler(this.addCommentToolStripMenuItem_Click);
            // 
            // selectAnnotationsToolStripMenuItem
            // 
            this.selectAnnotationsToolStripMenuItem.Name = "selectAnnotationsToolStripMenuItem";
            this.selectAnnotationsToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.selectAnnotationsToolStripMenuItem.Text = "Select Annotations";
            this.selectAnnotationsToolStripMenuItem.Click += new System.EventHandler(this.selectAnnotationsToolStripMenuItem_Click);
            // 
            // deleteSelectedToolStripMenuItem
            // 
            this.deleteSelectedToolStripMenuItem.Name = "deleteSelectedToolStripMenuItem";
            this.deleteSelectedToolStripMenuItem.Size = new System.Drawing.Size(195, 22);
            this.deleteSelectedToolStripMenuItem.Text = "Delete Selected";
            this.deleteSelectedToolStripMenuItem.Click += new System.EventHandler(this.deleteSelectedToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pnlPage);
            this.Controls.Add(this.vScrollBar1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FrmMain";
            this.Text = "Assignment Grader";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FrmMain_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.pnlPage.ResumeLayout(false);
            this.pnlPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbPage)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tbtnOpen;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.PictureBox pbPage;
        private System.Windows.Forms.Panel pnlPage;
        private System.Windows.Forms.ToolStripButton tbtnSave;
        private System.Windows.Forms.ToolStripButton tbtnPrev;
        private System.Windows.Forms.ToolStripTextBox txtPage;
        private System.Windows.Forms.ToolStripButton tbtnNext;
        private System.Windows.Forms.ToolStripButton tbtnCorrect;
        private System.Windows.Forms.ToolStripButton tbtnWrong;
        private System.Windows.Forms.ToolStripButton tbtnText;
        private System.Windows.Forms.ToolStripButton tbtnDelete;
        private System.Windows.Forms.ToolStripButton tbtnSelect;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem moveFinalScoreToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCorrectMarkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addIncorrectMarkerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectAnnotationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteSelectedToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripTextBox txtScore;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox txtFullScore;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
    }
}

