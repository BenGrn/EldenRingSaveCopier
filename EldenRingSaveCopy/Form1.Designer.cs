
namespace EldenRingSaveCopy
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.sourceFileLoad = new System.Windows.Forms.Button();
            this.sourceFilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.targetFilePath = new System.Windows.Forms.TextBox();
            this.destinationFileLoad = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fromSaveSlot = new System.Windows.Forms.ComboBox();
            this.titleBar = new System.Windows.Forms.Panel();
            this.title = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.toSaveSlot = new System.Windows.Forms.ComboBox();
            this.copyButton = new System.Windows.Forms.Button();
            this.additionalInfoLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.titleBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // sourceFileLoad
            // 
            this.sourceFileLoad.Location = new System.Drawing.Point(19, 399);
            this.sourceFileLoad.Margin = new System.Windows.Forms.Padding(4);
            this.sourceFileLoad.Name = "sourceFileLoad";
            this.sourceFileLoad.Size = new System.Drawing.Size(242, 28);
            this.sourceFileLoad.TabIndex = 0;
            this.sourceFileLoad.Text = "Browse";
            this.sourceFileLoad.UseVisualStyleBackColor = true;
            this.sourceFileLoad.Click += new System.EventHandler(this.sourceFileBrowse);
            // 
            // sourceFilePath
            // 
            this.sourceFilePath.Location = new System.Drawing.Point(19, 435);
            this.sourceFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.sourceFilePath.Name = "sourceFilePath";
            this.sourceFilePath.ReadOnly = true;
            this.sourceFilePath.Size = new System.Drawing.Size(242, 22);
            this.sourceFilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label1.Location = new System.Drawing.Point(90, 366);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 24);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source file";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label2.Location = new System.Drawing.Point(372, 366);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination file";
            // 
            // targetFilePath
            // 
            this.targetFilePath.Location = new System.Drawing.Point(337, 435);
            this.targetFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.targetFilePath.Name = "targetFilePath";
            this.targetFilePath.Size = new System.Drawing.Size(242, 22);
            this.targetFilePath.TabIndex = 4;
            // 
            // destinationFileLoad
            // 
            this.destinationFileLoad.Location = new System.Drawing.Point(337, 399);
            this.destinationFileLoad.Margin = new System.Windows.Forms.Padding(4);
            this.destinationFileLoad.Name = "destinationFileLoad";
            this.destinationFileLoad.Size = new System.Drawing.Size(242, 28);
            this.destinationFileLoad.TabIndex = 3;
            this.destinationFileLoad.Text = "Browse";
            this.destinationFileLoad.UseVisualStyleBackColor = true;
            this.destinationFileLoad.Click += new System.EventHandler(this.targetButtonBrowse);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(16, 61);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(563, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // fromSaveSlot
            // 
            this.fromSaveSlot.FormattingEnabled = true;
            this.fromSaveSlot.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3",
            "Slot 4",
            "Slot 5",
            "Slot 6",
            "Slot 7",
            "Slot 8",
            "Slot 9",
            "Slot 10"});
            this.fromSaveSlot.Location = new System.Drawing.Point(19, 491);
            this.fromSaveSlot.Margin = new System.Windows.Forms.Padding(4);
            this.fromSaveSlot.MaxDropDownItems = 11;
            this.fromSaveSlot.Name = "fromSaveSlot";
            this.fromSaveSlot.Size = new System.Drawing.Size(242, 24);
            this.fromSaveSlot.TabIndex = 7;
            this.fromSaveSlot.SelectedIndexChanged += new System.EventHandler(this.fromSaveSlot_SelectedIndexChanged);
            // 
            // titleBar
            // 
            this.titleBar.BackColor = System.Drawing.Color.White;
            this.titleBar.Controls.Add(this.title);
            this.titleBar.Controls.Add(this.exitButton);
            this.titleBar.Location = new System.Drawing.Point(0, 0);
            this.titleBar.Margin = new System.Windows.Forms.Padding(0);
            this.titleBar.Name = "titleBar";
            this.titleBar.Size = new System.Drawing.Size(600, 31);
            this.titleBar.TabIndex = 8;
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.title.Location = new System.Drawing.Point(209, 5);
            this.title.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(140, 16);
            this.title.TabIndex = 10;
            this.title.Text = "Savegame Copy Tool";
            // 
            // exitButton
            // 
            this.exitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.exitButton.FlatAppearance.BorderSize = 0;
            this.exitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exitButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.exitButton.Location = new System.Drawing.Point(568, 0);
            this.exitButton.Margin = new System.Windows.Forms.Padding(0);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(32, 30);
            this.exitButton.TabIndex = 9;
            this.exitButton.Text = "X";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButtonClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label3.Location = new System.Drawing.Point(101, 461);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 17);
            this.label3.TabIndex = 9;
            this.label3.Text = "Copy from";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.label4.Location = new System.Drawing.Point(428, 461);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 11;
            this.label4.Text = "Copy to";
            // 
            // toSaveSlot
            // 
            this.toSaveSlot.FormattingEnabled = true;
            this.toSaveSlot.Items.AddRange(new object[] {
            "Slot 1",
            "Slot 2",
            "Slot 3",
            "Slot 4",
            "Slot 5",
            "Slot 6",
            "Slot 7",
            "Slot 8",
            "Slot 9",
            "Slot 10"});
            this.toSaveSlot.Location = new System.Drawing.Point(337, 491);
            this.toSaveSlot.Margin = new System.Windows.Forms.Padding(4);
            this.toSaveSlot.MaxDropDownItems = 11;
            this.toSaveSlot.Name = "toSaveSlot";
            this.toSaveSlot.Size = new System.Drawing.Size(242, 24);
            this.toSaveSlot.TabIndex = 10;
            this.toSaveSlot.SelectedIndexChanged += new System.EventHandler(this.toSaveSlot_SelectedIndexChanged);
            // 
            // copyButton
            // 
            this.copyButton.BackColor = System.Drawing.Color.DarkOrange;
            this.copyButton.Enabled = false;
            this.copyButton.FlatAppearance.BorderSize = 0;
            this.copyButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.copyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.copyButton.Location = new System.Drawing.Point(19, 536);
            this.copyButton.Margin = new System.Windows.Forms.Padding(4);
            this.copyButton.Name = "copyButton";
            this.copyButton.Size = new System.Drawing.Size(560, 54);
            this.copyButton.TabIndex = 12;
            this.copyButton.Text = "Select Source and Destination file and characters";
            this.copyButton.UseVisualStyleBackColor = false;
            this.copyButton.Click += new System.EventHandler(this.copyButton_Click);
            // 
            // additionalInfoLabel
            // 
            this.additionalInfoLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.additionalInfoLabel.Location = new System.Drawing.Point(16, 317);
            this.additionalInfoLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.additionalInfoLabel.Name = "additionalInfoLabel";
            this.additionalInfoLabel.Size = new System.Drawing.Size(563, 49);
            this.additionalInfoLabel.TabIndex = 13;
            this.additionalInfoLabel.Text = "Ensure the ER0000.bak file has been deleted from save folder prior to loading.";
            this.additionalInfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(597, 617);
            this.Controls.Add(this.additionalInfoLabel);
            this.Controls.Add(this.copyButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toSaveSlot);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.titleBar);
            this.Controls.Add(this.fromSaveSlot);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.targetFilePath);
            this.Controls.Add(this.destinationFileLoad);
            this.Controls.Add(this.sourceFilePath);
            this.Controls.Add(this.sourceFileLoad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.titleBar.ResumeLayout(false);
            this.titleBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sourceFileLoad;
        private System.Windows.Forms.TextBox sourceFilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox targetFilePath;
        private System.Windows.Forms.Button destinationFileLoad;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox fromSaveSlot;
        private System.Windows.Forms.Panel titleBar;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox toSaveSlot;
        private System.Windows.Forms.Button copyButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Label additionalInfoLabel;
    }
}

