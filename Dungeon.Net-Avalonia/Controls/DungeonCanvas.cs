using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    /// <summary>
    /// 地牢画布控件，对应 Winform 版本中的 PictureBox 画布。
    /// 通过重写 Render 方法使用 DrawingContext 进行跨平台绘制。
    /// </summary>
    public class DungeonCanvas : Control
    {
        private RectangularDungeonField field;
        private double thickness = 5;
        private int offsetx = 0;
        private int offsety = 0;
        private RectangularDungeonRenderer renderer = new RectangularDungeonRenderer();

        /// <summary>
        /// 当前地牢场地
        /// </summary>
        public RectangularDungeonField Field
        {
            get => field;
            set
            {
                field = value;
                InvalidateVisual();
            }
        }

        /// <summary>
        /// 格子厚度
        /// </summary>
        public double Thickness
        {
            get => thickness;
            set
            {
                thickness = value;
                InvalidateVisual();
            }
        }

        /// <summary>
        /// X 轴偏移
        /// </summary>
        public int OffsetX
        {
            get => offsetx;
            set
            {
                offsetx = value;
                InvalidateVisual();
            }
        }

        /// <summary>
        /// Y 轴偏移
        /// </summary>
        public int OffsetY
        {
            get => offsety;
            set
            {
                offsety = value;
                InvalidateVisual();
            }
        }

        /// <summary>
        /// 刷新画布
        /// </summary>
        public void Refresh()
        {
            InvalidateVisual();
        }

        protected override void OnPropertyChanged(AvaloniaPropertyChangedEventArgs change)
        {
            base.OnPropertyChanged(change);

            if (change.Property == BoundsProperty)
            {
                InvalidateVisual();
            }
        }

        public override void Render(DrawingContext context)
        {
            renderer.SetSize(Bounds.Width, Bounds.Height)
                    .SetThickness(thickness)
                    .SetOffset(offsetx, offsety)
                    .Draw(context, field);
        }
    }
}
