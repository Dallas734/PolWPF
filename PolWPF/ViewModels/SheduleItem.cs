using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows;

namespace PolWPF
{
    public class SheduleItem
    {
        public SheduleItem()
        {
            ID = Guid.NewGuid();

            //defaults
            BorderColor = DefaultBorderColor;
            FillColor = DefaultFillColor;
            Clickable = true;
        }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

        internal string Time { get => string.Format("{0} - {1}", Start.ToShortTimeString(), End.ToShortTimeString()); }
        internal Border Panel;

        public string Title { get; set; }
        public string Description { get; set; }
        public bool Clickable { get; set; }
        public Brush BorderColor { get; set; }
        public Brush FillColor { get; set; }

        public static Brush DefaultBorderColor = Brushes.Black;
        public static Brush DefaultFillColor = Brushes.LightGreen;

        public readonly Guid ID;
        public object Data;     //can hold a reference to an object if needed

        internal void GeneratePanel(double width, double height, double secondsStart, double secondsEnd, double secondsTotal)
        {
            Panel = new Border
            {
                BorderThickness = new Thickness(1.0),
                BorderBrush = BorderColor,
                Background = FillColor
            };

            double yPos = (Start.TimeOfDay.TotalSeconds - secondsStart) / secondsTotal * height;

            Panel.Width = width > 16 ? width : 0.0;
            Panel.Height = End < Start ? 0.0 : (End.TimeOfDay.TotalSeconds - secondsStart) / secondsTotal * height - yPos;

            Canvas.SetLeft(Panel, 8);
            Canvas.SetTop(Panel, yPos);

            StackPanel panel = new StackPanel
            {
                Orientation = Orientation.Vertical,
                HorizontalAlignment = HorizontalAlignment.Stretch
            };

            Label apptTime = new Label
            {
                Margin = new Thickness(1.0, 0.0, 0.0, 0.0),
                FontSize = 11,
                Padding = new Thickness(0.0),
                Foreground = Brushes.Black
            };

            apptTime.Content = Time;

            Label apptDesc = new Label
            {
                Margin = new Thickness(1.0, 0.0, 0.0, 0.0),
                FontSize = 11,
                Padding = new Thickness(0.0),
                Foreground = Brushes.Black
            };

            apptDesc.Content = Title;

            panel.Children.Add(apptTime);
            panel.Children.Add(apptDesc);
            Panel.Child = panel;
        }

        internal static int SortByStart(SheduleItem x, SheduleItem y)
        {
            if (x != null)
            {
                if (y != null)
                {
                    return DateTime.Compare(x.Start, y.Start);
                }
                else
                {
                    return -1;  //y is null, put x first
                }
            }
            else
            {
                if (y != null)
                {
                    return 1;   //x is null, put y first
                }
                else
                {
                    return 0;   //they're both null
                }
            }
        }
    }
}
