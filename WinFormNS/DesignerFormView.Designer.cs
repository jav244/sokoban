namespace WinFormNS
{
    partial class DesignerFormView
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
            this.Save = new System.Windows.Forms.Button();
            this.Erase = new System.Windows.Forms.Button();
            this.Goal = new System.Windows.Forms.Button();
            this.Block = new System.Windows.Forms.Button();
            this.Player = new System.Windows.Forms.Button();
            this.Wall = new System.Windows.Forms.Button();
            this.BuildLevel = new System.Windows.Forms.Button();
            this.LevelBuild = new System.Windows.Forms.Button();
            this.WidthInput = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightInput = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).BeginInit();
            this.SuspendLayout();
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(30, 510);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 21;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click_1);
            // 
            // Erase
            // 
            this.Erase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Erase.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Erase.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Erase.Image = global::WinFormNS.Properties.Resources.Empty;
            this.Erase.Location = new System.Drawing.Point(30, 370);
            this.Erase.Name = "Erase";
            this.Erase.Size = new System.Drawing.Size(64, 64);
            this.Erase.TabIndex = 20;
            this.Erase.UseVisualStyleBackColor = true;
            this.Erase.Click += new System.EventHandler(this.Erase_Click);
            // 
            // Goal
            // 
            this.Goal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Goal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Goal.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Goal.Image = global::WinFormNS.Properties.Resources.Goal;
            this.Goal.Location = new System.Drawing.Point(30, 287);
            this.Goal.Name = "Goal";
            this.Goal.Size = new System.Drawing.Size(64, 64);
            this.Goal.TabIndex = 19;
            this.Goal.UseVisualStyleBackColor = true;
            this.Goal.Click += new System.EventHandler(this.Goal_Click);
            // 
            // Block
            // 
            this.Block.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Block.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Block.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Block.Image = global::WinFormNS.Properties.Resources.Block;
            this.Block.Location = new System.Drawing.Point(30, 204);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(64, 64);
            this.Block.TabIndex = 18;
            this.Block.UseVisualStyleBackColor = true;
            this.Block.Click += new System.EventHandler(this.Block_Click);
            // 
            // Player
            // 
            this.Player.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Player.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Player.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Player.Image = global::WinFormNS.Properties.Resources.Player;
            this.Player.Location = new System.Drawing.Point(30, 121);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(64, 64);
            this.Player.TabIndex = 17;
            this.Player.UseVisualStyleBackColor = true;
            this.Player.Click += new System.EventHandler(this.Player_Click_1);
            // 
            // Wall
            // 
            this.Wall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Wall.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Wall.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Wall.Image = global::WinFormNS.Properties.Resources.Wall;
            this.Wall.Location = new System.Drawing.Point(30, 38);
            this.Wall.Name = "Wall";
            this.Wall.Size = new System.Drawing.Size(64, 64);
            this.Wall.TabIndex = 16;
            this.Wall.UseVisualStyleBackColor = true;
            this.Wall.Click += new System.EventHandler(this.Wall_Click_1);
            // 
            // BuildLevel
            // 
            this.BuildLevel.Location = new System.Drawing.Point(30, 481);
            this.BuildLevel.Name = "BuildLevel";
            this.BuildLevel.Size = new System.Drawing.Size(75, 23);
            this.BuildLevel.TabIndex = 13;
            this.BuildLevel.Text = "Reset";
            this.BuildLevel.UseVisualStyleBackColor = true;
            this.BuildLevel.Click += new System.EventHandler(this.BuildLevel_Click_1);
            // 
            // LevelBuild
            // 
            this.LevelBuild.Location = new System.Drawing.Point(30, 604);
            this.LevelBuild.Name = "LevelBuild";
            this.LevelBuild.Size = new System.Drawing.Size(75, 23);
            this.LevelBuild.TabIndex = 22;
            this.LevelBuild.Text = "Build";
            this.LevelBuild.UseVisualStyleBackColor = true;
            this.LevelBuild.Click += new System.EventHandler(this.LevelBuild_Click);
            // 
            // WidthInput
            // 
            this.WidthInput.Location = new System.Drawing.Point(9, 552);
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(120, 20);
            this.WidthInput.TabIndex = 23;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(129, 557);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 24;
            this.WidthLabel.Text = "Width";
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(129, 583);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 26;
            this.HeightLabel.Text = "Height";
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(9, 578);
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(120, 20);
            this.HeightInput.TabIndex = 25;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 13);
            this.label1.TabIndex = 27;
            this.label1.Text = "Wall";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(45, 188);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Player";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(45, 271);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 29;
            this.label3.Text = "Block";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(45, 354);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 30;
            this.label4.Text = "Goal";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(45, 437);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(36, 13);
            this.label5.TabIndex = 31;
            this.label5.Text = "Empty";
            // 
            // DesignerFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(928, 646);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.LevelBuild);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.Erase);
            this.Controls.Add(this.Goal);
            this.Controls.Add(this.Block);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Wall);
            this.Controls.Add(this.BuildLevel);
            this.Name = "DesignerFormView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignerForm_FormClosing);
            this.Controls.SetChildIndex(this.BuildLevel, 0);
            this.Controls.SetChildIndex(this.Wall, 0);
            this.Controls.SetChildIndex(this.Player, 0);
            this.Controls.SetChildIndex(this.Block, 0);
            this.Controls.SetChildIndex(this.Goal, 0);
            this.Controls.SetChildIndex(this.Erase, 0);
            this.Controls.SetChildIndex(this.Save, 0);
            this.Controls.SetChildIndex(this.LevelBuild, 0);
            this.Controls.SetChildIndex(this.WidthInput, 0);
            this.Controls.SetChildIndex(this.WidthLabel, 0);
            this.Controls.SetChildIndex(this.HeightInput, 0);
            this.Controls.SetChildIndex(this.HeightLabel, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.label3, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button Erase;
        private System.Windows.Forms.Button Goal;
        private System.Windows.Forms.Button Block;
        private System.Windows.Forms.Button Player;
        private System.Windows.Forms.Button Wall;
        private System.Windows.Forms.Button BuildLevel;
        private System.Windows.Forms.Button LevelBuild;
        private System.Windows.Forms.NumericUpDown WidthInput;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.NumericUpDown HeightInput;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}
