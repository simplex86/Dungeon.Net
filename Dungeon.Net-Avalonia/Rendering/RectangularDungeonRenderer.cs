using System;
using Avalonia;
using Avalonia.Media;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    /// <summary>
    /// 矩形地牢渲染器，基于 Avalonia 的 DrawingContext 实现，完全跨平台。
    /// 对应 Winform 版本中的 RectangularDungeonRenderer。
    /// </summary>
    internal class RectangularDungeonRenderer
    {
        private double width = 0;
        private double height = 0;
        private double thickness = 1;
        private int offsetx = 0;
        private int offsety = 0;

        private static readonly IBrush PathBrush = Brushes.GhostWhite;

        /// <summary>
        ///
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public RectangularDungeonRenderer SetSize(double width, double height)
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
        public RectangularDungeonRenderer SetThickness(double thickness)
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
        /// <param name="context"></param>
        /// <param name="field"></param>
        public void Draw(DrawingContext context, RectangularDungeonField field)
        {
            DrawField(context, field);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="field"></param>
        private void DrawField(DrawingContext context, RectangularDungeonField field)
        {
            if (field.Width == 0 || field.Height == 0)
            {
                return;
            }

            var cx = (width - field.Width * thickness) / 2 + offsetx;
            var cy = (height - field.Height * thickness) / 2 + offsety;

            for (int y = 0; y < field.Height; y++)
            {
                var gy = cy + y * thickness;
                for (int x = 0; x < field.Width; x++)
                {
                    var gx = cx + x * thickness;
                    switch (field[x, y])
                    {
                        case TileType.Path:
                            DrawPath(context, gx, gy);
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
        /// <param name="context"></param>
        /// <param name="gx"></param>
        /// <param name="gy"></param>
        private void DrawPath(DrawingContext context, double gx, double gy)
        {
            context.DrawRectangle(PathBrush, null, new Rect(gx, gy, thickness, thickness));
        }
    }
}
