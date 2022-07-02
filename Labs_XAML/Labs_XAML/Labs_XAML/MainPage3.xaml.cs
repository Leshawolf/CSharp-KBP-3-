using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TouchTracking;

using SkiaSharp;
using SkiaSharp.Views.Forms;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Labs_XAML
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class MainPage3 : ContentPage
    {

        public MainPage3()
        {
            InitializeComponent();
        }
        private async void menu_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (menu.SelectedIndex == 0)
                main.BackgroundColor=Color.Yellow;
            if (menu.SelectedIndex == 1)
                main.BackgroundColor = Color.Black;
            if (menu.SelectedIndex == 2)
                await DisplayAlert("Разработчик: Волчек Алексей", "\nГруппа: Т-992", "OK");
            if (menu.SelectedIndex == 3)
                System.Environment.Exit(0);
        }

        private async void panel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (panel.SelectedIndex == 0)
                main.BackgroundColor = Color.Yellow;
            if (panel.SelectedIndex == 1)
                main.BackgroundColor = Color.Black;
            if (panel.SelectedIndex == 2)
                await DisplayAlert("Разработчик: Волчек Алексей", "\nГруппа: Т-992", "OK");
            if(panel.SelectedIndex==3)
                System.Environment.Exit(0);

        }
        Dictionary<long, SKPath> inProgressPaths = new Dictionary<long, SKPath>();
        List<SKPath> completedPaths = new List<SKPath>();

        SKPaint paint = new SKPaint
        {
            Style = SKPaintStyle.Stroke,
            Color = SKColors.Blue,
            StrokeWidth = 10,
            StrokeCap = SKStrokeCap.Round,
            StrokeJoin = SKStrokeJoin.Round
        };
        SkiaSharp.SKPoint ConvertToPixel(TouchTrackingPoint pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width), (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }
        void OnTouchEffectAction(object sender, TouchActionEventArgs args)
        {
            switch (args.Type)
            {
                case TouchActionType.Pressed:
                    if (!inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = new SKPath();
                        path.MoveTo(ConvertToPixel(args.Location));
                        inProgressPaths.Add(args.Id, path);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Moved:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        SKPath path = inProgressPaths[args.Id];
                        path.LineTo(ConvertToPixel(args.Location));
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Released:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        completedPaths.Add(inProgressPaths[args.Id]);
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;

                case TouchActionType.Cancelled:
                    if (inProgressPaths.ContainsKey(args.Id))
                    {
                        inProgressPaths.Remove(args.Id);
                        canvasView.InvalidateSurface();
                    }
                    break;
            }
        }

        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear();

            foreach (SKPath path in completedPaths)
            {
                canvas.DrawPath(path, paint);
            }

            foreach (SKPath path in inProgressPaths.Values)
            {
                canvas.DrawPath(path, paint);
            }
        }

        SKPoint ConvertToPixel(Point pt)
        {
            return new SKPoint((float)(canvasView.CanvasSize.Width * pt.X / canvasView.Width),
                               (float)(canvasView.CanvasSize.Height * pt.Y / canvasView.Height));
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            completedPaths.Clear();
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new MainPage4());
        }
    }
}