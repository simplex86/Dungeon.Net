using System;
using System.IO;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Platform.Storage;
using SimplexLab.Dungeon;

namespace Dungeon.TApplication
{
    public partial class ReconstructionControl : UserControl
    {
        private DungeonReader reader = new DungeonReader();

        public ReconstructionControl()
        {
            InitializeComponent();
        }

        private async void OnBrowseClickedHandler(object sender, RoutedEventArgs e)
        {
            var topLevel = TopLevel.GetTopLevel(this);
            if (topLevel == null) return;

            var storageProvider = topLevel.StorageProvider;
            var files = await storageProvider.OpenFilePickerAsync(new FilePickerOpenOptions
            {
                Title = "Open Dungeon",
                AllowMultiple = false,
                FileTypeFilter = new[]
                {
                    new FilePickerFileType("Dungeon File")
                    {
                        Patterns = new[] { "*.dungeon" }
                    }
                }
            });

            if (files.Count == 0) return;

            var file = files[0];
            filePath.Text = file.Path.LocalPath;

            using var stream = await file.OpenReadAsync();
            using var memoryStream = new MemoryStream();
            await stream.CopyToAsync(memoryStream);
            memoryStream.Position = 0;

            var field = reader.Read(memoryStream);

            width.Value = field.Width;
            height.Value = field.Height;

            var t = Math.Min(canvas.Bounds.Width / field.Width, canvas.Bounds.Height / field.Height);
            if (t < 1) t = 1;

            canvas.Thickness = t;
            canvas.Field = field;
            canvas.Refresh();
        }
    }
}
