using System.Drawing;
using System.Windows.Forms;

namespace Dungeon.TApplication
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            rectangularDungeonControl1 = new RectangularDungeonControl();
            SuspendLayout();
            // 
            // rectangularDungeonControl1
            // 
            rectangularDungeonControl1.Dock = DockStyle.Fill;
            rectangularDungeonControl1.Location = new Point(0, 0);
            rectangularDungeonControl1.Margin = new Padding(8, 6, 8, 6);
            rectangularDungeonControl1.Name = "rectangularDungeonControl1";
            rectangularDungeonControl1.Size = new Size(1558, 1024);
            rectangularDungeonControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1558, 1024);
            Controls.Add(rectangularDungeonControl1);
            Margin = new Padding(5, 4, 5, 4);
            MinimumSize = new Size(1200, 800);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dungeon Generator v0.1.2";
            ResumeLayout(false);
        }

        #endregion

        private RectangularDungeonControl rectangularDungeonControl1;
    }
}
