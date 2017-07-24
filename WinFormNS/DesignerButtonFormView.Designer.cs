namespace WinFormNS
{
    partial class DesignerButtonFormView
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
            this.HeightLabel = new System.Windows.Forms.Label();
            this.HeightInput = new System.Windows.Forms.NumericUpDown();
            this.WidthLabel = new System.Windows.Forms.Label();
            this.WidthInput = new System.Windows.Forms.NumericUpDown();
            this.LevelBuild = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Button();
            this.Erase = new System.Windows.Forms.Button();
            this.Goal = new System.Windows.Forms.Button();
            this.Block = new System.Windows.Forms.Button();
            this.Player = new System.Windows.Forms.Button();
            this.Wall = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).BeginInit();
            this.SuspendLayout();
            // 
            // HeightLabel
            // 
            this.HeightLabel.AutoSize = true;
            this.HeightLabel.Location = new System.Drawing.Point(123, 582);
            this.HeightLabel.Name = "HeightLabel";
            this.HeightLabel.Size = new System.Drawing.Size(38, 13);
            this.HeightLabel.TabIndex = 43;
            this.HeightLabel.Text = "Height";
            // 
            // HeightInput
            // 
            this.HeightInput.Location = new System.Drawing.Point(3, 577);
            this.HeightInput.Name = "HeightInput";
            this.HeightInput.Size = new System.Drawing.Size(120, 20);
            this.HeightInput.TabIndex = 42;
            // 
            // WidthLabel
            // 
            this.WidthLabel.AutoSize = true;
            this.WidthLabel.Location = new System.Drawing.Point(123, 556);
            this.WidthLabel.Name = "WidthLabel";
            this.WidthLabel.Size = new System.Drawing.Size(35, 13);
            this.WidthLabel.TabIndex = 41;
            this.WidthLabel.Text = "Width";
            // 
            // WidthInput
            // 
            this.WidthInput.Location = new System.Drawing.Point(3, 551);
            this.WidthInput.Name = "WidthInput";
            this.WidthInput.Size = new System.Drawing.Size(120, 20);
            this.WidthInput.TabIndex = 40;
            // 
            // LevelBuild
            // 
            this.LevelBuild.Location = new System.Drawing.Point(24, 603);
            this.LevelBuild.Name = "LevelBuild";
            this.LevelBuild.Size = new System.Drawing.Size(75, 23);
            this.LevelBuild.TabIndex = 39;
            this.LevelBuild.Text = "Build";
            this.LevelBuild.UseVisualStyleBackColor = true;
            this.LevelBuild.Click += new System.EventHandler(this.LevelBuild_Click_2);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(24, 509);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 38;
            this.Save.Text = "Save";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click_2);
            // 
            // Erase
            // 
            this.Erase.Location = new System.Drawing.Point(24, 327);
            this.Erase.Name = "Erase";
            this.Erase.Size = new System.Drawing.Size(75, 23);
            this.Erase.TabIndex = 92;
            this.Erase.Text = "Eraser";
            this.Erase.UseVisualStyleBackColor = true;
            this.Erase.Click += new System.EventHandler(this.Erase_Click_1);
            // 
            // Goal
            // 
            this.Goal.Location = new System.Drawing.Point(24, 298);
            this.Goal.Name = "Goal";
            this.Goal.Size = new System.Drawing.Size(75, 23);
            this.Goal.TabIndex = 91;
            this.Goal.Text = "Goal";
            this.Goal.UseVisualStyleBackColor = true;
            this.Goal.Click += new System.EventHandler(this.Goal_Click_1);
            // 
            // Block
            // 
            this.Block.Location = new System.Drawing.Point(24, 269);
            this.Block.Name = "Block";
            this.Block.Size = new System.Drawing.Size(75, 23);
            this.Block.TabIndex = 90;
            this.Block.Text = "Block";
            this.Block.UseVisualStyleBackColor = true;
            this.Block.Click += new System.EventHandler(this.Block_Click_1);
            // 
            // Player
            // 
            this.Player.Location = new System.Drawing.Point(24, 240);
            this.Player.Name = "Player";
            this.Player.Size = new System.Drawing.Size(75, 23);
            this.Player.TabIndex = 89;
            this.Player.Text = "Player";
            this.Player.UseVisualStyleBackColor = true;
            this.Player.Click += new System.EventHandler(this.Player_Click);
            // 
            // Wall
            // 
            this.Wall.Location = new System.Drawing.Point(24, 211);
            this.Wall.Name = "Wall";
            this.Wall.Size = new System.Drawing.Size(75, 23);
            this.Wall.TabIndex = 88;
            this.Wall.Text = "Wall";
            this.Wall.UseVisualStyleBackColor = true;
            this.Wall.Click += new System.EventHandler(this.Wall_Click);
            // 
            // DesignerButtonFormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1186, 925);
            this.Controls.Add(this.Erase);
            this.Controls.Add(this.Goal);
            this.Controls.Add(this.Block);
            this.Controls.Add(this.Player);
            this.Controls.Add(this.Wall);
            this.Controls.Add(this.HeightLabel);
            this.Controls.Add(this.HeightInput);
            this.Controls.Add(this.WidthLabel);
            this.Controls.Add(this.WidthInput);
            this.Controls.Add(this.LevelBuild);
            this.Controls.Add(this.Save);
            this.Name = "DesignerButtonFormView";
            this.Text = "DesignerButtonFormView";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DesignerButtonFormView_FormClosing);
            this.Controls.SetChildIndex(this.Save, 0);
            this.Controls.SetChildIndex(this.LevelBuild, 0);
            this.Controls.SetChildIndex(this.WidthInput, 0);
            this.Controls.SetChildIndex(this.WidthLabel, 0);
            this.Controls.SetChildIndex(this.HeightInput, 0);
            this.Controls.SetChildIndex(this.HeightLabel, 0);
            this.Controls.SetChildIndex(this.Wall, 0);
            this.Controls.SetChildIndex(this.Player, 0);
            this.Controls.SetChildIndex(this.Block, 0);
            this.Controls.SetChildIndex(this.Goal, 0);
            this.Controls.SetChildIndex(this.Erase, 0);
            ((System.ComponentModel.ISupportInitialize)(this.HeightInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button LevelBuild;
        private System.Windows.Forms.NumericUpDown WidthInput;
        private System.Windows.Forms.Label WidthLabel;
        private System.Windows.Forms.NumericUpDown HeightInput;
        private System.Windows.Forms.Label HeightLabel;
        private System.Windows.Forms.Button Wall;
        private System.Windows.Forms.Button Player;
        private System.Windows.Forms.Button Block;
        private System.Windows.Forms.Button Goal;
        private System.Windows.Forms.Button Erase;
    }
}