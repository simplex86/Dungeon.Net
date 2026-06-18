using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    public partial class RectangularDungeonControl : UserControl
    {
        private RectangularDungeonGenerator generator = new RectangularDungeonGenerator();
        private RectangularDungeonField field;
        private RectangularDungeonRenderer renderer = new RectangularDungeonRenderer();

        private int offsetx = 0;
        private int offsety = 0;
        private bool generating = false;

        public RectangularDungeonControl()
        {
            InitializeComponent();
            algorithm.SelectedIndex = 0;
        }

        private void OnGenerationClickedHandler(object sender, EventArgs e)
        {
            if (generating) return;

            offsetx = 0;
            offsety = 0;

            OnGenerationClickedHandler();
        }

        private async Task OnGenerationClickedHandler()
        {
            PrevProcess();
            {
                await Generate();
            }
            PostProcess();
        }

        private void PrevProcess()
        {
            generation.Text = "...";
            generation.Enabled = false;
        }

        private async Task Generate()
        {
            generating = true;

            var t    = (int)thickness.Value;
            var w    = (width.Value  == 0) ? canvas.Width  / t - 1 : (int)width.Value;
            var h    = (height.Value == 0) ? canvas.Height / t - 1 : (int)height.Value;
            var minw = (int)roomMinWidth.Value;
            var maxw = (int)roomMaxWidth.Value;
            var minh = (int)roomMinHeight.Value;
            var maxh = (int)roomMaxHeight.Value;
            var cnt  = (int)roomCount.Value;
            var mct  = (int)mulconnector.Value;
            var tor  = (int)tortuosity.Value;
            var alm  = (DungeonAlgorithm)(algorithm.SelectedIndex + 1);

            field = await generator.CreateAsync(w, h, minw, maxw, minh, maxh, cnt, mct, tor, alm);

            generating = false;
        }

        private void PostProcess()
        {
            canvas.Refresh();

            generation.Text = "Generate";
            generation.Enabled = true;
        }

        private void OnCanvasPaintHandler(object sender, PaintEventArgs e)
        {
            renderer.SetSize(canvas.Width, canvas.Height)
                    .SetThickness((int)thickness.Value)
                    .SetOffset(offsetx, offsety)
                    .Draw(e.Graphics, field);
        }
    }
}
