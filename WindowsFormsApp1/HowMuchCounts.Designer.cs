namespace MIAnalyzer
{
    partial class HowMuchCounts
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
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonOK = new System.Windows.Forms.Button();
            this.checkBoxGetSequences = new System.Windows.Forms.CheckBox();
            this.checkBoxExtraMD = new System.Windows.Forms.CheckBox();
            this.numericUpDownExtraCounts = new System.Windows.Forms.NumericUpDown();
            this.labelCounts = new System.Windows.Forms.Label();
            this.labelExtraCounts = new System.Windows.Forms.Label();
            this.labelFreq = new System.Windows.Forms.Label();
            this.numericUpDownFreq = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxMaxCounts = new System.Windows.Forms.TextBox();
            this.labelMaxTrials = new System.Windows.Forms.Label();
            this.numericUpDownMaxTrials = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtraCounts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFreq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTrials)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(62, 31);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(117, 20);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.Text = "-1";
            this.textBoxInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(235, 221);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetSequences
            // 
            this.checkBoxGetSequences.AutoSize = true;
            this.checkBoxGetSequences.Location = new System.Drawing.Point(16, 57);
            this.checkBoxGetSequences.Name = "checkBoxGetSequences";
            this.checkBoxGetSequences.Size = new System.Drawing.Size(211, 17);
            this.checkBoxGetSequences.TabIndex = 2;
            this.checkBoxGetSequences.Text = "Ignore Keylogger (work with whole MD)";
            this.checkBoxGetSequences.UseVisualStyleBackColor = true;
            this.checkBoxGetSequences.CheckedChanged += new System.EventHandler(this.checkBoxGetSequences_CheckedChanged);
            // 
            // checkBoxExtraMD
            // 
            this.checkBoxExtraMD.AutoSize = true;
            this.checkBoxExtraMD.Location = new System.Drawing.Point(16, 106);
            this.checkBoxExtraMD.Name = "checkBoxExtraMD";
            this.checkBoxExtraMD.Size = new System.Drawing.Size(141, 17);
            this.checkBoxExtraMD.TabIndex = 3;
            this.checkBoxExtraMD.Text = "Add Extra MD if possible";
            this.checkBoxExtraMD.UseVisualStyleBackColor = true;
            this.checkBoxExtraMD.CheckedChanged += new System.EventHandler(this.checkBoxExtraMD_CheckedChanged);
            // 
            // numericUpDownExtraCounts
            // 
            this.numericUpDownExtraCounts.Location = new System.Drawing.Point(62, 142);
            this.numericUpDownExtraCounts.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownExtraCounts.Name = "numericUpDownExtraCounts";
            this.numericUpDownExtraCounts.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownExtraCounts.TabIndex = 4;
            this.numericUpDownExtraCounts.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownExtraCounts.ValueChanged += new System.EventHandler(this.numericUpDownExtraCounts_ValueChanged);
            // 
            // labelCounts
            // 
            this.labelCounts.AutoSize = true;
            this.labelCounts.Location = new System.Drawing.Point(13, 34);
            this.labelCounts.Name = "labelCounts";
            this.labelCounts.Size = new System.Drawing.Size(43, 13);
            this.labelCounts.TabIndex = 5;
            this.labelCounts.Text = "Counts:";
            // 
            // labelExtraCounts
            // 
            this.labelExtraCounts.AutoSize = true;
            this.labelExtraCounts.Location = new System.Drawing.Point(13, 144);
            this.labelExtraCounts.Name = "labelExtraCounts";
            this.labelExtraCounts.Size = new System.Drawing.Size(43, 13);
            this.labelExtraCounts.TabIndex = 6;
            this.labelExtraCounts.Text = "Counts:";
            // 
            // labelFreq
            // 
            this.labelFreq.AutoSize = true;
            this.labelFreq.Location = new System.Drawing.Point(136, 144);
            this.labelFreq.Name = "labelFreq";
            this.labelFreq.Size = new System.Drawing.Size(83, 13);
            this.labelFreq.TabIndex = 7;
            this.labelFreq.Text = "MD Frequrency:";
            // 
            // numericUpDownFreq
            // 
            this.numericUpDownFreq.Location = new System.Drawing.Point(225, 142);
            this.numericUpDownFreq.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownFreq.Name = "numericUpDownFreq";
            this.numericUpDownFreq.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownFreq.TabIndex = 8;
            this.numericUpDownFreq.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownFreq.ValueChanged += new System.EventHandler(this.numericUpDownFreq_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Maximum Counts:";
            // 
            // textBoxMaxCounts
            // 
            this.textBoxMaxCounts.Location = new System.Drawing.Point(109, 171);
            this.textBoxMaxCounts.Name = "textBoxMaxCounts";
            this.textBoxMaxCounts.Size = new System.Drawing.Size(110, 20);
            this.textBoxMaxCounts.TabIndex = 10;
            this.textBoxMaxCounts.Text = "0";
            this.textBoxMaxCounts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // labelMaxTrials
            // 
            this.labelMaxTrials.AutoSize = true;
            this.labelMaxTrials.Location = new System.Drawing.Point(12, 204);
            this.labelMaxTrials.Name = "labelMaxTrials";
            this.labelMaxTrials.Size = new System.Drawing.Size(126, 13);
            this.labelMaxTrials.TabIndex = 11;
            this.labelMaxTrials.Text = "Maximum Trials Per User:";
            // 
            // numericUpDownMaxTrials
            // 
            this.numericUpDownMaxTrials.Location = new System.Drawing.Point(141, 202);
            this.numericUpDownMaxTrials.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numericUpDownMaxTrials.Name = "numericUpDownMaxTrials";
            this.numericUpDownMaxTrials.Size = new System.Drawing.Size(45, 20);
            this.numericUpDownMaxTrials.TabIndex = 12;
            this.numericUpDownMaxTrials.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // HowMuchCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 256);
            this.Controls.Add(this.numericUpDownMaxTrials);
            this.Controls.Add(this.labelMaxTrials);
            this.Controls.Add(this.textBoxMaxCounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.numericUpDownFreq);
            this.Controls.Add(this.labelFreq);
            this.Controls.Add(this.labelExtraCounts);
            this.Controls.Add(this.labelCounts);
            this.Controls.Add(this.numericUpDownExtraCounts);
            this.Controls.Add(this.checkBoxExtraMD);
            this.Controls.Add(this.checkBoxGetSequences);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HowMuchCounts";
            this.Text = "Enter number of counts...";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownExtraCounts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFreq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMaxTrials)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxGetSequences;
        private System.Windows.Forms.CheckBox checkBoxExtraMD;
        private System.Windows.Forms.NumericUpDown numericUpDownExtraCounts;
        private System.Windows.Forms.Label labelCounts;
        private System.Windows.Forms.Label labelExtraCounts;
        private System.Windows.Forms.Label labelFreq;
        private System.Windows.Forms.NumericUpDown numericUpDownFreq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxMaxCounts;
        private System.Windows.Forms.Label labelMaxTrials;
        private System.Windows.Forms.NumericUpDown numericUpDownMaxTrials;
    }
}