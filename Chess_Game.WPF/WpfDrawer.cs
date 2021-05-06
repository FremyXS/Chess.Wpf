using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Chess_Game.Logic;

namespace Chess_Game.WPF
{
    public class WpfDrawer
    {
        private static Canvas FieldCanvas { get; set; }
        public WpfDrawer(Canvas fieldCanvas)
        {
            FieldCanvas = fieldCanvas;
        }
        public static void GrawCanvas()
        {

            FieldCanvas.Children.Clear();

            double height = FieldCanvas.ActualHeight / 9;
            double width = FieldCanvas.ActualWidth / 9;

            if (FieldCanvas.ActualHeight < FieldCanvas.ActualWidth)
                GetSizeElements(height, (FieldCanvas.ActualWidth - FieldCanvas.ActualHeight) / 2, 0);
            else
                GetSizeElements(width, 0, (FieldCanvas.ActualHeight - FieldCanvas.ActualWidth) / 2);

        }
        private static void Placement(Label lab, double x, double y)
        {
            FieldCanvas.Children.Add(lab);
            Canvas.SetTop(lab, x);
            Canvas.SetLeft(lab, y);
        }
        private static void GetSizeElements(double size, double x, double y)
        {

            for (int i = 0; i < 8; i++)
            {
                GetVerticalCoordinate(i, size, x, y);

                for (var j = 0; j < 8; j++)
                {
                    Board.Field[i, j].Rect.Height = size;
                    Board.Field[i, j].Rect.Width = size;
                    Board.Field[i, j].image.Height = size;
                    Board.Field[i, j].image.Width = size;
                    Board.Field[i, j].image.SetValue(Canvas.LeftProperty, (j + 1) * size + x);
                    Board.Field[i, j].image.SetValue(Canvas.TopProperty, (i) * size + y);

                    FieldCanvas.Children.Add(Board.Field[i, j].Rect);
                    FieldCanvas.Children.Add(Board.Field[i, j].image);

                    Canvas.SetTop(Board.Field[i, j].Rect, (i) * size + y);
                    Canvas.SetLeft(Board.Field[i, j].Rect, (j + 1) * size + x);
                    

                }
            }

            GetHorizontalCoordinate(size, x, y);
        }
        private static void GetVerticalCoordinate(int index, double size, double x, double y)
        {
            var lab = new Label { Content = $"{index + 1}", FontSize = size / 3 };

            Placement(
                lab,
                index * size + (size / 6) + y,
                x
            );
        }
        private static void GetHorizontalCoordinate(double size, double x, double y)
        {
            for (var i = 'A'; i <= 'H'; i++)
            {
                var lab = new Label { Content = i.ToString(), FontSize = size / 3 };
                Placement(
                    lab,
                    8 * size + y,
                    (i - 'A' + 1) * size + x
                );
            }
        }
    }
}
