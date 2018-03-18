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
            this.checkBoxEmptySeq = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(12, 22);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(260, 20);
            this.textBoxInput.TabIndex = 0;
            this.textBoxInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(100, 92);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // checkBoxGetSequences
            // 
            this.checkBoxGetSequences.AutoSize = true;
            this.checkBoxGetSequences.Location = new System.Drawing.Point(79, 48);
            this.checkBoxGetSequences.Name = "checkBoxGetSequences";
            this.checkBoxGetSequences.Size = new System.Drawing.Size(114, 17);
            this.checkBoxGetSequences.TabIndex = 2;
            this.checkBoxGetSequences.Text = "Get All Sequences";
            this.checkBoxGetSequences.UseVisualStyleBackColor = true;
            // 
            // checkBoxEmptySeq
            // 
            this.checkBoxEmptySeq.AutoSize = true;
            this.checkBoxEmptySeq.Checked = true;
            this.checkBoxEmptySeq.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEmptySeq.Location = new System.Drawing.Point(40, 69);
            this.checkBoxEmptySeq.Name = "checkBoxEmptySeq";
            this.checkBoxEmptySeq.Size = new System.Drawing.Size(213, 17);
            this.checkBoxEmptySeq.TabIndex = 3;
            this.checkBoxEmptySeq.Text = "Include sequences without parced trials";
            this.checkBoxEmptySeq.UseVisualStyleBackColor = true;
            // 
            // HowMuchCounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 127);
            this.Controls.Add(this.checkBoxEmptySeq);
            this.Controls.Add(this.checkBoxGetSequences);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.textBoxInput);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "HowMuchCounts";
            this.Text = "Enter number of counts...";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.CheckBox checkBoxGetSequences;
        private System.Windows.Forms.CheckBox checkBoxEmptySeq;
    }
}