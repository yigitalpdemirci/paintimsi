using System.Security.Permissions;

namespace paintApp
{
    partial class Paint
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Paint));
            this.FileIO = new System.Windows.Forms.Panel();
            this.saveFileButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.Tools = new System.Windows.Forms.Panel();
            this.clearBoardButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.selectButton = new System.Windows.Forms.Button();
            this.ShapeMenu = new System.Windows.Forms.Panel();
            this.hexagonButton = new System.Windows.Forms.Button();
            this.rectangleButton = new System.Windows.Forms.Button();
            this.circleButton = new System.Windows.Forms.Button();
            this.triangleButton = new System.Windows.Forms.Button();
            this.TopMenu = new System.Windows.Forms.Panel();
            this.ColorPicker = new System.Windows.Forms.Panel();
            this.whiteButton = new System.Windows.Forms.Button();
            this.purpleButton = new System.Windows.Forms.Button();
            this.yellowButton = new System.Windows.Forms.Button();
            this.blackButton = new System.Windows.Forms.Button();
            this.greenButton = new System.Windows.Forms.Button();
            this.blueButton = new System.Windows.Forms.Button();
            this.orangeButton = new System.Windows.Forms.Button();
            this.redButton = new System.Windows.Forms.Button();
            this.paintArea = new System.Windows.Forms.Panel();
            this.FileIO.SuspendLayout();
            this.Tools.SuspendLayout();
            this.ShapeMenu.SuspendLayout();
            this.TopMenu.SuspendLayout();
            this.ColorPicker.SuspendLayout();
            this.SuspendLayout();
            // 
            // FileIO
            // 
            this.FileIO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FileIO.Controls.Add(this.saveFileButton);
            this.FileIO.Controls.Add(this.openFileButton);
            this.FileIO.Dock = System.Windows.Forms.DockStyle.Left;
            this.FileIO.Location = new System.Drawing.Point(0, 0);
            this.FileIO.Name = "FileIO";
            this.FileIO.Size = new System.Drawing.Size(200, 120);
            this.FileIO.TabIndex = 0;
            // 
            // saveFileButton
            // 
            this.saveFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.saveFileButton.Image = ((System.Drawing.Image)(resources.GetObject("saveFileButton.Image")));
            this.saveFileButton.Location = new System.Drawing.Point(110, 25);
            this.saveFileButton.Name = "saveFileButton";
            this.saveFileButton.Size = new System.Drawing.Size(75, 75);
            this.saveFileButton.TabIndex = 1;
            this.saveFileButton.UseVisualStyleBackColor = true;
            this.saveFileButton.Click += new System.EventHandler(this.saveFileButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.openFileButton.Image = ((System.Drawing.Image)(resources.GetObject("openFileButton.Image")));
            this.openFileButton.Location = new System.Drawing.Point(20, 25);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(75, 75);
            this.openFileButton.TabIndex = 0;
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // Tools
            // 
            this.Tools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Tools.Controls.Add(this.clearBoardButton);
            this.Tools.Controls.Add(this.deleteButton);
            this.Tools.Controls.Add(this.selectButton);
            this.Tools.Dock = System.Windows.Forms.DockStyle.Left;
            this.Tools.Location = new System.Drawing.Point(200, 0);
            this.Tools.Name = "Tools";
            this.Tools.Size = new System.Drawing.Size(290, 120);
            this.Tools.TabIndex = 1;
            // 
            // clearBoardButton
            // 
            this.clearBoardButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.clearBoardButton.Image = ((System.Drawing.Image)(resources.GetObject("clearBoardButton.Image")));
            this.clearBoardButton.Location = new System.Drawing.Point(195, 25);
            this.clearBoardButton.Name = "clearBoardButton";
            this.clearBoardButton.Size = new System.Drawing.Size(75, 75);
            this.clearBoardButton.TabIndex = 4;
            this.clearBoardButton.UseVisualStyleBackColor = true;
            this.clearBoardButton.Click += new System.EventHandler(this.clearBoardButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.deleteButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteButton.Image")));
            this.deleteButton.Location = new System.Drawing.Point(105, 25);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 75);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // selectButton
            // 
            this.selectButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.selectButton.Image = ((System.Drawing.Image)(resources.GetObject("selectButton.Image")));
            this.selectButton.Location = new System.Drawing.Point(15, 25);
            this.selectButton.Name = "selectButton";
            this.selectButton.Size = new System.Drawing.Size(75, 75);
            this.selectButton.TabIndex = 2;
            this.selectButton.UseVisualStyleBackColor = true;
            this.selectButton.Click += new System.EventHandler(this.selectButton_Click);
            // 
            // ShapeMenu
            // 
            this.ShapeMenu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ShapeMenu.Controls.Add(this.hexagonButton);
            this.ShapeMenu.Controls.Add(this.rectangleButton);
            this.ShapeMenu.Controls.Add(this.circleButton);
            this.ShapeMenu.Controls.Add(this.triangleButton);
            this.ShapeMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.ShapeMenu.Location = new System.Drawing.Point(490, 0);
            this.ShapeMenu.Name = "ShapeMenu";
            this.ShapeMenu.Size = new System.Drawing.Size(380, 120);
            this.ShapeMenu.TabIndex = 2;
            // 
            // hexagonButton
            // 
            this.hexagonButton.BackColor = System.Drawing.Color.Transparent;
            this.hexagonButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hexagonButton.Image = ((System.Drawing.Image)(resources.GetObject("hexagonButton.Image")));
            this.hexagonButton.Location = new System.Drawing.Point(285, 25);
            this.hexagonButton.Name = "hexagonButton";
            this.hexagonButton.Size = new System.Drawing.Size(75, 75);
            this.hexagonButton.TabIndex = 8;
            this.hexagonButton.UseVisualStyleBackColor = false;
            this.hexagonButton.Click += new System.EventHandler(this.hexagonButton_Click);
            // 
            // rectangleButton
            // 
            this.rectangleButton.BackColor = System.Drawing.Color.Transparent;
            this.rectangleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rectangleButton.Image = ((System.Drawing.Image)(resources.GetObject("rectangleButton.Image")));
            this.rectangleButton.Location = new System.Drawing.Point(195, 25);
            this.rectangleButton.Name = "rectangleButton";
            this.rectangleButton.Size = new System.Drawing.Size(75, 75);
            this.rectangleButton.TabIndex = 7;
            this.rectangleButton.UseVisualStyleBackColor = false;
            this.rectangleButton.Click += new System.EventHandler(this.rectangleButton_Click);
            // 
            // circleButton
            // 
            this.circleButton.BackColor = System.Drawing.Color.Transparent;
            this.circleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.circleButton.Image = ((System.Drawing.Image)(resources.GetObject("circleButton.Image")));
            this.circleButton.Location = new System.Drawing.Point(105, 25);
            this.circleButton.Name = "circleButton";
            this.circleButton.Size = new System.Drawing.Size(75, 75);
            this.circleButton.TabIndex = 6;
            this.circleButton.UseVisualStyleBackColor = false;
            this.circleButton.Click += new System.EventHandler(this.circleButton_Click);
            // 
            // triangleButton
            // 
            this.triangleButton.BackColor = System.Drawing.Color.Transparent;
            this.triangleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.triangleButton.Image = ((System.Drawing.Image)(resources.GetObject("triangleButton.Image")));
            this.triangleButton.Location = new System.Drawing.Point(15, 25);
            this.triangleButton.Name = "triangleButton";
            this.triangleButton.Size = new System.Drawing.Size(75, 75);
            this.triangleButton.TabIndex = 5;
            this.triangleButton.UseVisualStyleBackColor = false;
            this.triangleButton.Click += new System.EventHandler(this.triangleButton_Click);
            // 
            // TopMenu
            // 
            this.TopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.TopMenu.Controls.Add(this.ColorPicker);
            this.TopMenu.Controls.Add(this.ShapeMenu);
            this.TopMenu.Controls.Add(this.Tools);
            this.TopMenu.Controls.Add(this.FileIO);
            this.TopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopMenu.Location = new System.Drawing.Point(0, 0);
            this.TopMenu.Name = "TopMenu";
            this.TopMenu.Size = new System.Drawing.Size(1581, 120);
            this.TopMenu.TabIndex = 0;
            // 
            // ColorPicker
            // 
            this.ColorPicker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorPicker.Controls.Add(this.whiteButton);
            this.ColorPicker.Controls.Add(this.purpleButton);
            this.ColorPicker.Controls.Add(this.yellowButton);
            this.ColorPicker.Controls.Add(this.blackButton);
            this.ColorPicker.Controls.Add(this.greenButton);
            this.ColorPicker.Controls.Add(this.blueButton);
            this.ColorPicker.Controls.Add(this.orangeButton);
            this.ColorPicker.Controls.Add(this.redButton);
            this.ColorPicker.Dock = System.Windows.Forms.DockStyle.Left;
            this.ColorPicker.Location = new System.Drawing.Point(870, 0);
            this.ColorPicker.Name = "ColorPicker";
            this.ColorPicker.Size = new System.Drawing.Size(712, 120);
            this.ColorPicker.TabIndex = 3;
            // 
            // whiteButton
            // 
            this.whiteButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.whiteButton.Image = ((System.Drawing.Image)(resources.GetObject("whiteButton.Image")));
            this.whiteButton.Location = new System.Drawing.Point(580, 25);
            this.whiteButton.Name = "whiteButton";
            this.whiteButton.Size = new System.Drawing.Size(75, 75);
            this.whiteButton.TabIndex = 16;
            this.whiteButton.UseVisualStyleBackColor = false;
            this.whiteButton.Click += new System.EventHandler(this.whiteButton_Click);
            // 
            // purpleButton
            // 
            this.purpleButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.purpleButton.Image = ((System.Drawing.Image)(resources.GetObject("purpleButton.Image")));
            this.purpleButton.Location = new System.Drawing.Point(495, 25);
            this.purpleButton.Name = "purpleButton";
            this.purpleButton.Size = new System.Drawing.Size(75, 75);
            this.purpleButton.TabIndex = 15;
            this.purpleButton.UseVisualStyleBackColor = false;
            this.purpleButton.Click += new System.EventHandler(this.purpleButton_Click);
            // 
            // yellowButton
            // 
            this.yellowButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.yellowButton.Image = ((System.Drawing.Image)(resources.GetObject("yellowButton.Image")));
            this.yellowButton.Location = new System.Drawing.Point(416, 25);
            this.yellowButton.Name = "yellowButton";
            this.yellowButton.Size = new System.Drawing.Size(75, 75);
            this.yellowButton.TabIndex = 14;
            this.yellowButton.UseVisualStyleBackColor = false;
            this.yellowButton.Click += new System.EventHandler(this.yellowButton_Click);
            // 
            // blackButton
            // 
            this.blackButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blackButton.Image = ((System.Drawing.Image)(resources.GetObject("blackButton.Image")));
            this.blackButton.Location = new System.Drawing.Point(334, 25);
            this.blackButton.Name = "blackButton";
            this.blackButton.Size = new System.Drawing.Size(75, 75);
            this.blackButton.TabIndex = 13;
            this.blackButton.UseVisualStyleBackColor = false;
            this.blackButton.Click += new System.EventHandler(this.blackButton_Click);
            // 
            // greenButton
            // 
            this.greenButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.greenButton.Image = ((System.Drawing.Image)(resources.GetObject("greenButton.Image")));
            this.greenButton.Location = new System.Drawing.Point(176, 25);
            this.greenButton.Name = "greenButton";
            this.greenButton.Size = new System.Drawing.Size(75, 75);
            this.greenButton.TabIndex = 11;
            this.greenButton.UseVisualStyleBackColor = false;
            this.greenButton.Click += new System.EventHandler(this.greenButton_Click);
            // 
            // blueButton
            // 
            this.blueButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.blueButton.Image = ((System.Drawing.Image)(resources.GetObject("blueButton.Image")));
            this.blueButton.Location = new System.Drawing.Point(94, 25);
            this.blueButton.Name = "blueButton";
            this.blueButton.Size = new System.Drawing.Size(75, 75);
            this.blueButton.TabIndex = 10;
            this.blueButton.UseVisualStyleBackColor = false;
            this.blueButton.Click += new System.EventHandler(this.blueButton_Click);
            // 
            // orangeButton
            // 
            this.orangeButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.orangeButton.Image = ((System.Drawing.Image)(resources.GetObject("orangeButton.Image")));
            this.orangeButton.Location = new System.Drawing.Point(255, 25);
            this.orangeButton.Name = "orangeButton";
            this.orangeButton.Size = new System.Drawing.Size(75, 75);
            this.orangeButton.TabIndex = 12;
            this.orangeButton.UseVisualStyleBackColor = false;
            this.orangeButton.Click += new System.EventHandler(this.orangeButton_Click);
            // 
            // redButton
            // 
            this.redButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.redButton.Image = ((System.Drawing.Image)(resources.GetObject("redButton.Image")));
            this.redButton.Location = new System.Drawing.Point(15, 25);
            this.redButton.Name = "redButton";
            this.redButton.Size = new System.Drawing.Size(75, 75);
            this.redButton.TabIndex = 9;
            this.redButton.UseVisualStyleBackColor = false;
            this.redButton.Click += new System.EventHandler(this.redButton_Click);
            // 
            // paintArea
            // 
            this.paintArea.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.paintArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintArea.Location = new System.Drawing.Point(0, 120);
            this.paintArea.Name = "paintArea";
            this.paintArea.Size = new System.Drawing.Size(1581, 722);
            this.paintArea.TabIndex = 1;
            this.paintArea.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintArea_MouseDown);
            this.paintArea.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintArea_MouseMove);
            this.paintArea.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintArea_MouseUp);
            // 
            // Paint
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1581, 842);
            this.Controls.Add(this.paintArea);
            this.Controls.Add(this.TopMenu);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Paint";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Paintimsi";
            this.FileIO.ResumeLayout(false);
            this.Tools.ResumeLayout(false);
            this.ShapeMenu.ResumeLayout(false);
            this.TopMenu.ResumeLayout(false);
            this.ColorPicker.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel FileIO;
        private System.Windows.Forms.Button saveFileButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Panel Tools;
        private System.Windows.Forms.Button clearBoardButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button selectButton;
        private System.Windows.Forms.Panel ShapeMenu;
        private System.Windows.Forms.Button hexagonButton;
        private System.Windows.Forms.Button rectangleButton;
        private System.Windows.Forms.Button circleButton;
        private System.Windows.Forms.Button triangleButton;
        private System.Windows.Forms.Panel TopMenu;
        private System.Windows.Forms.Button redButton;
        private System.Windows.Forms.Button orangeButton;
        private System.Windows.Forms.Button blueButton;
        private System.Windows.Forms.Button greenButton;
        private System.Windows.Forms.Button blackButton;
        private System.Windows.Forms.Button yellowButton;
        private System.Windows.Forms.Button purpleButton;
        private System.Windows.Forms.Button whiteButton;
        private System.Windows.Forms.Panel ColorPicker;
        private System.Windows.Forms.Panel paintArea;
    }
}