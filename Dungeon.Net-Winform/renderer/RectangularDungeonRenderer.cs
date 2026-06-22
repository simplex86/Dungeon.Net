using System;
using System.Drawing;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    /// <summary>
    /// 
    /// </summary>
    internal class RectangularDungeonRenderer
    {
        private int width = 0;
        private int height = 0;
        private int thickness = 1;
        private int offsetx = 0;
        private int offsety = 0;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public RectangularDungeonRenderer SetSize(int width, int height)
        {
            this.width = width;
            this.height = height;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="thickness"></param>
        /// <returns></returns>
        public RectangularDungeonRenderer SetThickness(int thickness)
        {
            this.thickness = thickness; 
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public RectangularDungeonRenderer SetOffset(int x, int y)
        {
            this.offsetx = x;
            this.offsety = y;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grap"></param>
        /// <param name="field"></param>
        public void Draw(Graphics grap, RectangularDungeonField field)
        {
            DrawBackground(grap);
            DrawField(grap, field);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grap"></param>
        private void DrawBackground(Graphics grap)
        {
            var brush = new SolidBrush(Color.Black);
            grap.FillRectangle(brush, 0, 0, width, height);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grap"></param>
        /// <param name="field"></param>
        private void DrawField(Graphics grap, RectangularDungeonField field)
        {
            if (field.Width == 0 || field.Height == 0)
            {
                return;
            }

            var ht = thickness / 2;
            var cx = (width  - field.Width  * thickness) / 2 + offsetx;
            var cy = (height - field.Height * thickness) / 2 + offsety;

            for (int y = 0; y < field.Height; y++)
            {
                var gy = cy + y * thickness + ht;
                for (int x = 0; x < field.Width; x++)
                {
                    var gx = cx + x * thickness + ht;
                    switch (field[x, y])
                    {
                        case TileType.Path:
                            DrawPath(grap, gx, gy);
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="grap"></param>
        /// <param name="gx"></param>
        /// <param name="gy"></param>
        private void DrawPath(Graphics grap, int gx, int gy)
        {
            var brush = new SolidBrush(Color.GhostWhite);
            var ht = thickness / 2;
            grap.FillRectangle(brush, gx - ht, gy - ht, thickness, thickness);
        }
    }
}
