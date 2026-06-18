using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Interactivity;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    public partial class RectangularDungeonControl : UserControl
    {
        private RectangularDungeonGenerator generator = new RectangularDungeonGenerator();
        private RectangularDungeonField field;
        private bool generating = false;

        public RectangularDungeonControl()
        {
            InitializeComponent();
            algorithm.SelectedIndex = 0;
        }

        private void OnGenerationClickedHandler(object sender, RoutedEventArgs e)
        {
            if (generating) return;

            _ = OnGenerationClickedHandler();
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
            generation.Content = "...";
            generation.IsEnabled = false;
        }

        private async Task Generate()
        {
            generating = true;

            var t    = (int)(thickness.Value ?? 5);
            var w    = (width.Value  == 0) ? (int)(canvas.Bounds.Width  / t) - 1 : (int)(width.Value  ?? 0);
            var h    = (height.Value == 0) ? (int)(canvas.Bounds.Height / t) - 1 : (int)(height.Value ?? 0);
            var minw = (int)(roomMinWidth.Value  ?? 5);
            var maxw = (int)(roomMaxWidth.Value  ?? 25);
            var minh = (int)(roomMinHeight.Value ?? 5);
            var maxh = (int)(roomMaxHeight.Value ?? 25);
            var cnt  = (int)(roomCount.Value     ?? 30);
            var mct  = (int)(mulconnector.Value  ?? 2);
            var tor  = (int)(tortuosity.Value    ?? 50);
            var alm  = (DungeonAlgorithm)(algorithm.SelectedIndex + 1);

            field = await generator.CreateAsync(w, h, minw, maxw, minh, maxh, cnt, mct, tor, alm);
            canvas.Thickness = t;
            canvas.Field = field;

            generating = false;
        }

        private void PostProcess()
        {
            canvas.Refresh();

            generation.Content = "Generate";
            generation.IsEnabled = true;
        }
    }
}
