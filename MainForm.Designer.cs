namespace Cliver.PrakashPdf
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
            this.bAbout = new System.Windows.Forms.Button();
            this.bInputFile = new System.Windows.Forms.Button();
            this.bOutputFolder = new System.Windows.Forms.Button();
            this.InputFile = new System.Windows.Forms.TextBox();
            this.OutputFolder = new System.Windows.Forms.TextBox();
            this.bExit = new System.Windows.Forms.Button();
            this.bRun = new System.Windows.Forms.Button();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bAbout
            // 
            this.bAbout.Location = new System.Drawing.Point(12, 149);
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(75, 23);
            this.bAbout.TabIndex = 0;
            this.bAbout.Text = "About";
            this.bAbout.UseVisualStyleBackColor = true;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // bInputFile
            // 
            this.bInputFile.Location = new System.Drawing.Point(523, 26);
            this.bInputFile.Name = "bInputFile";
            this.bInputFile.Size = new System.Drawing.Size(24, 23);
            this.bInputFile.TabIndex = 1;
            this.bInputFile.Text = "...";
            this.bInputFile.UseVisualStyleBackColor = true;
            this.bInputFile.Click += new System.EventHandler(this.bInputFile_Click);
            // 
            // bOutputFolder
            // 
            this.bOutputFolder.Location = new System.Drawing.Point(523, 77);
            this.bOutputFolder.Name = "bOutputFolder";
            this.bOutputFolder.Size = new System.Drawing.Size(24, 23);
            this.bOutputFolder.TabIndex = 2;
            this.bOutputFolder.Text = "...";
            this.bOutputFolder.UseVisualStyleBackColor = true;
            this.bOutputFolder.Click += new System.EventHandler(this.bOutputFolder_Click);
            // 
            // InputFile
            // 
            this.InputFile.Location = new System.Drawing.Point(12, 29);
            this.InputFile.Name = "InputFile";
            this.InputFile.Size = new System.Drawing.Size(505, 20);
            this.InputFile.TabIndex = 3;
            // 
            // OutputFolder
            // 
            this.OutputFolder.Location = new System.Drawing.Point(12, 77);
            this.OutputFolder.Name = "OutputFolder";
            this.OutputFolder.Size = new System.Drawing.Size(505, 20);
            this.OutputFolder.TabIndex = 4;
            // 
            // bExit
            // 
            this.bExit.Location = new System.Drawing.Point(472, 149);
            this.bExit.Name = "bExit";
            this.bExit.Size = new System.Drawing.Size(75, 23);
            this.bExit.TabIndex = 5;
            this.bExit.Text = "Exit";
            this.bExit.UseVisualStyleBackColor = true;
            this.bExit.Click += new System.EventHandler(this.bExit_Click);
            // 
            // bRun
            // 
            this.bRun.Location = new System.Drawing.Point(391, 149);
            this.bRun.Name = "bRun";
            this.bRun.Size = new System.Drawing.Size(75, 23);
            this.bRun.TabIndex = 6;
            this.bRun.Text = "Run";
            this.bRun.UseVisualStyleBackColor = true;
            this.bRun.Click += new System.EventHandler(this.bRun_Click);
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(12, 122);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(535, 12);
            this.progress.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Input File:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Output Folder:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 190);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.bRun);
            this.Controls.Add(this.bExit);
            this.Controls.Add(this.OutputFolder);
            this.Controls.Add(this.InputFile);
            this.Controls.Add(this.bOutputFolder);
            this.Controls.Add(this.bInputFile);
            this.Controls.Add(this.bAbout);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bAbout;
        private System.Windows.Forms.Button bInputFile;
        private System.Windows.Forms.Button bOutputFolder;
        private System.Windows.Forms.TextBox InputFile;
        private System.Windows.Forms.TextBox OutputFolder;
        private System.Windows.Forms.Button bExit;
        private System.Windows.Forms.Button bRun;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}