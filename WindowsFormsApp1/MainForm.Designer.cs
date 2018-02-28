namespace MIAnalyzer
{
    partial class MainForm
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
            this.listBoxTrials1 = new System.Windows.Forms.ListBox();
            this.scanSavedDataFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMainForm = new System.Windows.Forms.MenuStrip();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.panelGraphControl1 = new System.Windows.Forms.Panel();
            this.checkBox6Panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox5Panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox4Panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox3Panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox2Panel1 = new System.Windows.Forms.CheckBox();
            this.checkBox1Panel1 = new System.Windows.Forms.CheckBox();
            this.panelGraphControl2 = new System.Windows.Forms.Panel();
            this.checkBox6Panel2 = new System.Windows.Forms.CheckBox();
            this.checkBox5Panel2 = new System.Windows.Forms.CheckBox();
            this.checkBox1Panel2 = new System.Windows.Forms.CheckBox();
            this.checkBox4Panel2 = new System.Windows.Forms.CheckBox();
            this.checkBox2Panel2 = new System.Windows.Forms.CheckBox();
            this.checkBox3Panel2 = new System.Windows.Forms.CheckBox();
            this.plotMain = new OxyPlot.WindowsForms.PlotView();
            this.menuMainForm.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.panelGraphControl1.SuspendLayout();
            this.panelGraphControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBoxTrials1
            // 
            this.listBoxTrials1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxTrials1.FormattingEnabled = true;
            this.listBoxTrials1.Location = new System.Drawing.Point(747, 12);
            this.listBoxTrials1.Name = "listBoxTrials1";
            this.listBoxTrials1.Size = new System.Drawing.Size(186, 472);
            this.listBoxTrials1.TabIndex = 0;
            this.listBoxTrials1.SelectedIndexChanged += new System.EventHandler(this.listBoxTrials1_SelectedIndexChanged);
            this.listBoxTrials1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBoxTrials1_MouseDown);
            // 
            // scanSavedDataFolderToolStripMenuItem
            // 
            this.scanSavedDataFolderToolStripMenuItem.Name = "scanSavedDataFolderToolStripMenuItem";
            this.scanSavedDataFolderToolStripMenuItem.Size = new System.Drawing.Size(143, 19);
            this.scanSavedDataFolderToolStripMenuItem.Text = "ScanSavedDataFolder";
            this.scanSavedDataFolderToolStripMenuItem.Click += new System.EventHandler(this.scanSavedDataFolderMenuMainFormItem_Click);
            // 
            // menuMainForm
            // 
            this.menuMainForm.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.menuMainForm.Dock = System.Windows.Forms.DockStyle.None;
            this.menuMainForm.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.scanSavedDataFolderToolStripMenuItem});
            this.menuMainForm.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.VerticalStackWithOverflow;
            this.menuMainForm.Location = new System.Drawing.Point(0, 0);
            this.menuMainForm.Name = "menuMainForm";
            this.menuMainForm.Size = new System.Drawing.Size(150, 25);
            this.menuMainForm.TabIndex = 1;
            this.menuMainForm.Text = "menuMainForm1";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(150, 150);
            this.toolStripContainer1.Location = new System.Drawing.Point(8, 8);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(150, 175);
            this.toolStripContainer1.TabIndex = 2;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuMainForm);
            // 
            // panelGraphControl1
            // 
            this.panelGraphControl1.AllowDrop = true;
            this.panelGraphControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelGraphControl1.Controls.Add(this.checkBox6Panel1);
            this.panelGraphControl1.Controls.Add(this.checkBox5Panel1);
            this.panelGraphControl1.Controls.Add(this.checkBox4Panel1);
            this.panelGraphControl1.Controls.Add(this.checkBox3Panel1);
            this.panelGraphControl1.Controls.Add(this.checkBox2Panel1);
            this.panelGraphControl1.Controls.Add(this.checkBox1Panel1);
            this.panelGraphControl1.Location = new System.Drawing.Point(12, 393);
            this.panelGraphControl1.Name = "panelGraphControl1";
            this.panelGraphControl1.Size = new System.Drawing.Size(354, 100);
            this.panelGraphControl1.TabIndex = 4;
            this.panelGraphControl1.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelGraphControl1_DragDrop);
            this.panelGraphControl1.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelGraphControl1_DragEnter);
            this.panelGraphControl1.DragOver += new System.Windows.Forms.DragEventHandler(this.panelGraphControl1_DragOver);
            this.panelGraphControl1.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.panelGraphControl1_GiveFeedback);
            // 
            // checkBox6Panel1
            // 
            this.checkBox6Panel1.AutoSize = true;
            this.checkBox6Panel1.Location = new System.Drawing.Point(89, 26);
            this.checkBox6Panel1.Name = "checkBox6Panel1";
            this.checkBox6Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox6Panel1.TabIndex = 5;
            this.checkBox6Panel1.Text = "checkBox6";
            this.checkBox6Panel1.UseVisualStyleBackColor = true;
            // 
            // checkBox5Panel1
            // 
            this.checkBox5Panel1.AutoSize = true;
            this.checkBox5Panel1.Location = new System.Drawing.Point(89, 3);
            this.checkBox5Panel1.Name = "checkBox5Panel1";
            this.checkBox5Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox5Panel1.TabIndex = 4;
            this.checkBox5Panel1.Text = "checkBox5";
            this.checkBox5Panel1.UseVisualStyleBackColor = true;
            // 
            // checkBox4Panel1
            // 
            this.checkBox4Panel1.AutoSize = true;
            this.checkBox4Panel1.Location = new System.Drawing.Point(3, 72);
            this.checkBox4Panel1.Name = "checkBox4Panel1";
            this.checkBox4Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox4Panel1.TabIndex = 3;
            this.checkBox4Panel1.Text = "checkBox4";
            this.checkBox4Panel1.UseVisualStyleBackColor = true;
            // 
            // checkBox3Panel1
            // 
            this.checkBox3Panel1.AutoSize = true;
            this.checkBox3Panel1.Location = new System.Drawing.Point(3, 49);
            this.checkBox3Panel1.Name = "checkBox3Panel1";
            this.checkBox3Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox3Panel1.TabIndex = 2;
            this.checkBox3Panel1.Text = "checkBox3";
            this.checkBox3Panel1.UseVisualStyleBackColor = true;
            // 
            // checkBox2Panel1
            // 
            this.checkBox2Panel1.AutoSize = true;
            this.checkBox2Panel1.Location = new System.Drawing.Point(3, 26);
            this.checkBox2Panel1.Name = "checkBox2Panel1";
            this.checkBox2Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox2Panel1.TabIndex = 1;
            this.checkBox2Panel1.Text = "checkBox2";
            this.checkBox2Panel1.UseVisualStyleBackColor = true;
            // 
            // checkBox1Panel1
            // 
            this.checkBox1Panel1.AutoSize = true;
            this.checkBox1Panel1.Location = new System.Drawing.Point(3, 3);
            this.checkBox1Panel1.Name = "checkBox1Panel1";
            this.checkBox1Panel1.Size = new System.Drawing.Size(80, 17);
            this.checkBox1Panel1.TabIndex = 0;
            this.checkBox1Panel1.Text = "checkBox1";
            this.checkBox1Panel1.UseVisualStyleBackColor = true;
            // 
            // panelGraphControl2
            // 
            this.panelGraphControl2.AllowDrop = true;
            this.panelGraphControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGraphControl2.Controls.Add(this.checkBox6Panel2);
            this.panelGraphControl2.Controls.Add(this.checkBox5Panel2);
            this.panelGraphControl2.Controls.Add(this.checkBox1Panel2);
            this.panelGraphControl2.Controls.Add(this.checkBox4Panel2);
            this.panelGraphControl2.Controls.Add(this.checkBox2Panel2);
            this.panelGraphControl2.Controls.Add(this.checkBox3Panel2);
            this.panelGraphControl2.Location = new System.Drawing.Point(411, 393);
            this.panelGraphControl2.Name = "panelGraphControl2";
            this.panelGraphControl2.Size = new System.Drawing.Size(327, 100);
            this.panelGraphControl2.TabIndex = 5;
            this.panelGraphControl2.DragDrop += new System.Windows.Forms.DragEventHandler(this.panelGraphControl2_DragDrop);
            this.panelGraphControl2.DragEnter += new System.Windows.Forms.DragEventHandler(this.panelGraphControl2_DragEnter);
            // 
            // checkBox6Panel2
            // 
            this.checkBox6Panel2.AutoSize = true;
            this.checkBox6Panel2.Location = new System.Drawing.Point(90, 26);
            this.checkBox6Panel2.Name = "checkBox6Panel2";
            this.checkBox6Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox6Panel2.TabIndex = 11;
            this.checkBox6Panel2.Text = "checkBox6";
            this.checkBox6Panel2.UseVisualStyleBackColor = true;
            // 
            // checkBox5Panel2
            // 
            this.checkBox5Panel2.AutoSize = true;
            this.checkBox5Panel2.Location = new System.Drawing.Point(90, 3);
            this.checkBox5Panel2.Name = "checkBox5Panel2";
            this.checkBox5Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox5Panel2.TabIndex = 10;
            this.checkBox5Panel2.Text = "checkBox5";
            this.checkBox5Panel2.UseVisualStyleBackColor = true;
            // 
            // checkBox1Panel2
            // 
            this.checkBox1Panel2.AutoSize = true;
            this.checkBox1Panel2.Location = new System.Drawing.Point(4, 3);
            this.checkBox1Panel2.Name = "checkBox1Panel2";
            this.checkBox1Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox1Panel2.TabIndex = 6;
            this.checkBox1Panel2.Text = "checkBox1";
            this.checkBox1Panel2.UseVisualStyleBackColor = true;
            // 
            // checkBox4Panel2
            // 
            this.checkBox4Panel2.AutoSize = true;
            this.checkBox4Panel2.Location = new System.Drawing.Point(4, 72);
            this.checkBox4Panel2.Name = "checkBox4Panel2";
            this.checkBox4Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox4Panel2.TabIndex = 9;
            this.checkBox4Panel2.Text = "checkBox4";
            this.checkBox4Panel2.UseVisualStyleBackColor = true;
            // 
            // checkBox2Panel2
            // 
            this.checkBox2Panel2.AutoSize = true;
            this.checkBox2Panel2.Location = new System.Drawing.Point(4, 26);
            this.checkBox2Panel2.Name = "checkBox2Panel2";
            this.checkBox2Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox2Panel2.TabIndex = 7;
            this.checkBox2Panel2.Text = "checkBox2";
            this.checkBox2Panel2.UseVisualStyleBackColor = true;
            // 
            // checkBox3Panel2
            // 
            this.checkBox3Panel2.AutoSize = true;
            this.checkBox3Panel2.Location = new System.Drawing.Point(4, 49);
            this.checkBox3Panel2.Name = "checkBox3Panel2";
            this.checkBox3Panel2.Size = new System.Drawing.Size(80, 17);
            this.checkBox3Panel2.TabIndex = 8;
            this.checkBox3Panel2.Text = "checkBox3";
            this.checkBox3Panel2.UseVisualStyleBackColor = true;
            // 
            // plotMain
            // 
            this.plotMain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.plotMain.Location = new System.Drawing.Point(12, 33);
            this.plotMain.Margin = new System.Windows.Forms.Padding(0);
            this.plotMain.Name = "plotMain";
            this.plotMain.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.plotMain.Size = new System.Drawing.Size(726, 357);
            this.plotMain.TabIndex = 6;
            this.plotMain.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.plotMain.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.plotMain.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 500);
            this.Controls.Add(this.plotMain);
            this.Controls.Add(this.panelGraphControl2);
            this.Controls.Add(this.panelGraphControl1);
            this.Controls.Add(this.toolStripContainer1);
            this.Controls.Add(this.listBoxTrials1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuMainForm;
            this.Name = "MainForm";
            this.Text = "MIA Analyzer";
            this.menuMainForm.ResumeLayout(false);
            this.menuMainForm.PerformLayout();
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.panelGraphControl1.ResumeLayout(false);
            this.panelGraphControl1.PerformLayout();
            this.panelGraphControl2.ResumeLayout(false);
            this.panelGraphControl2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox listBoxTrials1;
        private System.Windows.Forms.ToolStripMenuItem scanSavedDataFolderToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuMainForm;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.Panel panelGraphControl1;
        private System.Windows.Forms.Panel panelGraphControl2;
        private System.Windows.Forms.CheckBox checkBox6Panel1;
        private System.Windows.Forms.CheckBox checkBox5Panel1;
        private System.Windows.Forms.CheckBox checkBox4Panel1;
        private System.Windows.Forms.CheckBox checkBox3Panel1;
        private System.Windows.Forms.CheckBox checkBox2Panel1;
        private System.Windows.Forms.CheckBox checkBox1Panel1;
        private System.Windows.Forms.CheckBox checkBox6Panel2;
        private System.Windows.Forms.CheckBox checkBox5Panel2;
        private System.Windows.Forms.CheckBox checkBox1Panel2;
        private System.Windows.Forms.CheckBox checkBox4Panel2;
        private System.Windows.Forms.CheckBox checkBox2Panel2;
        private System.Windows.Forms.CheckBox checkBox3Panel2;
        private OxyPlot.WindowsForms.PlotView plotMain;
    }
}

