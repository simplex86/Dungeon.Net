namespace Dungeon.TApplication
{
    partial class RectangularDungeonControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            generation = new System.Windows.Forms.Button();
            canvas = new System.Windows.Forms.PictureBox();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            width = new System.Windows.Forms.NumericUpDown();
            height = new System.Windows.Forms.NumericUpDown();
            label10 = new System.Windows.Forms.Label();
            thickness = new System.Windows.Forms.NumericUpDown();
            algorithm = new System.Windows.Forms.ComboBox();
            label12 = new System.Windows.Forms.Label();
            mulconnector = new System.Windows.Forms.NumericUpDown();
            label11 = new System.Windows.Forms.Label();
            tortuosity = new System.Windows.Forms.NumericUpDown();
            label9 = new System.Windows.Forms.Label();
            roomCount = new System.Windows.Forms.NumericUpDown();
            label8 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            roomMaxHeight = new System.Windows.Forms.NumericUpDown();
            roomMinHeight = new System.Windows.Forms.NumericUpDown();
            label7 = new System.Windows.Forms.Label();
            label5 = new System.Windows.Forms.Label();
            roomMaxWidth = new System.Windows.Forms.NumericUpDown();
            roomMinWidth = new System.Windows.Forms.NumericUpDown();
            label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)canvas).BeginInit();
            ((System.ComponentModel.ISupportInitialize)width).BeginInit();
            ((System.ComponentModel.ISupportInitialize)height).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thickness).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mulconnector).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tortuosity).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomMaxHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomMinHeight).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomMaxWidth).BeginInit();
            ((System.ComponentModel.ISupportInitialize)roomMinWidth).BeginInit();
            SuspendLayout();
            // 
            // generation
            // 
            generation.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            generation.Location = new System.Drawing.Point(3, 512);
            generation.Name = "generation";
            generation.Size = new System.Drawing.Size(210, 65);
            generation.TabIndex = 0;
            generation.Text = "Generate";
            generation.UseVisualStyleBackColor = true;
            generation.Click += OnGenerationClickedHandler;
            // 
            // canvas
            // 
            canvas.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            canvas.Location = new System.Drawing.Point(218, 3);
            canvas.Name = "canvas";
            canvas.Size = new System.Drawing.Size(529, 574);
            canvas.TabIndex = 1;
            canvas.TabStop = false;
            canvas.Paint += OnCanvasPaintHandler;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(3, 5);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(42, 17);
            label1.TabIndex = 2;
            label1.Text = "Width";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(3, 32);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(46, 17);
            label2.TabIndex = 3;
            label2.Text = "Height";
            // 
            // width
            // 
            width.Location = new System.Drawing.Point(93, 3);
            width.Name = "width";
            width.Size = new System.Drawing.Size(120, 23);
            width.TabIndex = 4;
            // 
            // height
            // 
            height.Location = new System.Drawing.Point(93, 30);
            height.Name = "height";
            height.Size = new System.Drawing.Size(120, 23);
            height.TabIndex = 5;
            // 
            // label10
            // 
            label10.Location = new System.Drawing.Point(3, 59);
            label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label10.Name = "label10";
            label10.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label10.Size = new System.Drawing.Size(74, 17);
            label10.TabIndex = 6;
            label10.Text = "Thickness";
            label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // thickness
            // 
            thickness.Location = new System.Drawing.Point(93, 57);
            thickness.Margin = new System.Windows.Forms.Padding(2);
            thickness.Maximum = new decimal(new int[] { 15, 0, 0, 0 });
            thickness.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            thickness.Name = "thickness";
            thickness.Size = new System.Drawing.Size(120, 23);
            thickness.TabIndex = 7;
            thickness.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // algorithm
            // 
            algorithm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            algorithm.FormattingEnabled = true;
            algorithm.Items.AddRange(new object[] { "Nystroms", "OverlapR" });
            algorithm.Location = new System.Drawing.Point(93, 84);
            algorithm.Margin = new System.Windows.Forms.Padding(2);
            algorithm.Name = "algorithm";
            algorithm.Size = new System.Drawing.Size(120, 25);
            algorithm.TabIndex = 35;
            // 
            // label12
            // 
            label12.Location = new System.Drawing.Point(3, 87);
            label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label12.Name = "label12";
            label12.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label12.Size = new System.Drawing.Size(94, 17);
            label12.TabIndex = 34;
            label12.Text = "Algorithm";
            label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // mulconnector
            // 
            mulconnector.Location = new System.Drawing.Point(93, 194);
            mulconnector.Margin = new System.Windows.Forms.Padding(2);
            mulconnector.Maximum = new decimal(new int[] { 20, 0, 0, 0 });
            mulconnector.Name = "mulconnector";
            mulconnector.Size = new System.Drawing.Size(120, 23);
            mulconnector.TabIndex = 33;
            mulconnector.Value = new decimal(new int[] { 2, 0, 0, 0 });
            // 
            // label11
            // 
            label11.Location = new System.Drawing.Point(3, 196);
            label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label11.Name = "label11";
            label11.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label11.Size = new System.Drawing.Size(86, 17);
            label11.TabIndex = 32;
            label11.Text = "M-Connector";
            label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tortuosity
            // 
            tortuosity.Location = new System.Drawing.Point(93, 221);
            tortuosity.Margin = new System.Windows.Forms.Padding(2);
            tortuosity.Name = "tortuosity";
            tortuosity.Size = new System.Drawing.Size(120, 23);
            tortuosity.TabIndex = 31;
            tortuosity.Value = new decimal(new int[] { 50, 0, 0, 0 });
            // 
            // label9
            // 
            label9.Location = new System.Drawing.Point(3, 223);
            label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label9.Name = "label9";
            label9.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label9.Size = new System.Drawing.Size(86, 17);
            label9.TabIndex = 30;
            label9.Text = "Tortuosity";
            label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // roomCount
            // 
            roomCount.Location = new System.Drawing.Point(93, 167);
            roomCount.Margin = new System.Windows.Forms.Padding(2);
            roomCount.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            roomCount.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            roomCount.Name = "roomCount";
            roomCount.Size = new System.Drawing.Size(120, 23);
            roomCount.TabIndex = 29;
            roomCount.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // label8
            // 
            label8.Location = new System.Drawing.Point(3, 169);
            label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label8.Name = "label8";
            label8.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label8.Size = new System.Drawing.Size(86, 17);
            label8.TabIndex = 28;
            label8.Text = "Room Count";
            label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new System.Drawing.Point(147, 142);
            label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(13, 17);
            label6.TabIndex = 27;
            label6.Text = "-";
            // 
            // roomMaxHeight
            // 
            roomMaxHeight.Location = new System.Drawing.Point(166, 140);
            roomMaxHeight.Margin = new System.Windows.Forms.Padding(2);
            roomMaxHeight.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            roomMaxHeight.Name = "roomMaxHeight";
            roomMaxHeight.Size = new System.Drawing.Size(47, 23);
            roomMaxHeight.TabIndex = 26;
            roomMaxHeight.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // roomMinHeight
            // 
            roomMinHeight.Location = new System.Drawing.Point(93, 140);
            roomMinHeight.Margin = new System.Windows.Forms.Padding(2);
            roomMinHeight.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            roomMinHeight.Name = "roomMinHeight";
            roomMinHeight.Size = new System.Drawing.Size(47, 23);
            roomMinHeight.TabIndex = 25;
            roomMinHeight.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label7
            // 
            label7.Location = new System.Drawing.Point(3, 142);
            label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label7.Name = "label7";
            label7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label7.Size = new System.Drawing.Size(86, 17);
            label7.TabIndex = 24;
            label7.Text = "Room Height";
            label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new System.Drawing.Point(147, 115);
            label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(13, 17);
            label5.TabIndex = 23;
            label5.Text = "-";
            // 
            // roomMaxWidth
            // 
            roomMaxWidth.Location = new System.Drawing.Point(166, 113);
            roomMaxWidth.Margin = new System.Windows.Forms.Padding(2);
            roomMaxWidth.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            roomMaxWidth.Name = "roomMaxWidth";
            roomMaxWidth.Size = new System.Drawing.Size(47, 23);
            roomMaxWidth.TabIndex = 22;
            roomMaxWidth.Value = new decimal(new int[] { 25, 0, 0, 0 });
            // 
            // roomMinWidth
            // 
            roomMinWidth.Location = new System.Drawing.Point(93, 113);
            roomMinWidth.Margin = new System.Windows.Forms.Padding(2);
            roomMinWidth.Minimum = new decimal(new int[] { 3, 0, 0, 0 });
            roomMinWidth.Name = "roomMinWidth";
            roomMinWidth.Size = new System.Drawing.Size(47, 23);
            roomMinWidth.TabIndex = 21;
            roomMinWidth.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label4
            // 
            label4.Location = new System.Drawing.Point(3, 115);
            label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label4.Name = "label4";
            label4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            label4.Size = new System.Drawing.Size(86, 17);
            label4.TabIndex = 20;
            label4.Text = "Room Width";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RectangularDungeonControl
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(algorithm);
            Controls.Add(label12);
            Controls.Add(mulconnector);
            Controls.Add(label11);
            Controls.Add(tortuosity);
            Controls.Add(label9);
            Controls.Add(roomCount);
            Controls.Add(label8);
            Controls.Add(label6);
            Controls.Add(roomMaxHeight);
            Controls.Add(roomMinHeight);
            Controls.Add(label7);
            Controls.Add(label5);
            Controls.Add(roomMaxWidth);
            Controls.Add(roomMinWidth);
            Controls.Add(label4);
            Controls.Add(label10);
            Controls.Add(thickness);
            Controls.Add(height);
            Controls.Add(width);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(canvas);
            Controls.Add(generation);
            Name = "RectangularDungeonControl";
            Size = new System.Drawing.Size(750, 580);
            ((System.ComponentModel.ISupportInitialize)canvas).EndInit();
            ((System.ComponentModel.ISupportInitialize)width).EndInit();
            ((System.ComponentModel.ISupportInitialize)height).EndInit();
            ((System.ComponentModel.ISupportInitialize)thickness).EndInit();
            ((System.ComponentModel.ISupportInitialize)mulconnector).EndInit();
            ((System.ComponentModel.ISupportInitialize)tortuosity).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomMaxHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomMinHeight).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomMaxWidth).EndInit();
            ((System.ComponentModel.ISupportInitialize)roomMinWidth).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button generation;
        private System.Windows.Forms.PictureBox canvas;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown width;
        private System.Windows.Forms.NumericUpDown height;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown thickness;
        private System.Windows.Forms.ComboBox algorithm;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown mulconnector;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown tortuosity;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown roomCount;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown roomMaxHeight;
        private System.Windows.Forms.NumericUpDown roomMinHeight;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown roomMaxWidth;
        private System.Windows.Forms.NumericUpDown roomMinWidth;
        private System.Windows.Forms.Label label4;
    }
}
