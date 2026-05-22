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
            rectangularDungeonControl1.Name = "rectangularDungeonControl1";
            rectangularDungeonControl1.Size = new Size(1478, 978);
            rectangularDungeonControl1.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1478, 978);
            Controls.Add(rectangularDungeonControl1);
            MinimumSize = new Size(1276, 710);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Dungeon Generator v0.1.1";
            ResumeLayout(false);
        }

        #endregion

        private RectangularDungeonControl rectangularDungeonControl1;
    }
}
