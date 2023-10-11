using System;
using System.Collections.Generic;
using System.Globalization;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PolWPF
{
    /// <summary>
    /// Логика взаимодействия для SheduleDay.xaml
    /// </summary>
    public partial class SheduleDay : UserControl
    {
        private DateTime currentDate;
        public DateTime CurrentDate
        {
            get => currentDate;
            set
            {
                currentDate = value.Date;
                CultureInfo culture = new CultureInfo("ru-RU");
                Title.Content = string.Format("{0} {1:00}/{2}", culture.DateTimeFormat.GetDayName(CurrentDate.DayOfWeek).ToUpperInvariant(), CurrentDate.Day, CurrentDate.Month);
                ChangeDate();
            }
        }

        public TimeSpan Interval { get; set; }
        public bool FitToSize { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }

        private int timeDisplayInterval;
        private double intervalHeight;
        public double IntervalHeight
        {
            get => intervalHeight;
            set
            {
                intervalHeight = value;
                if (TimeVisualIntervalHeight % value == 0)
                {
                    timeDisplayInterval = (int)(TimeVisualIntervalHeight / value);
                }
                else
                {
                    timeDisplayInterval = (int)(TimeVisualIntervalHeight / value) + 1;
                }
            }
        }

        private bool darkTheme;
        public bool DarkTheme
        {
            get => darkTheme;
            set
            {
                darkTheme = value;
                if (darkTheme)
                {
                    DayGridTimeline.BorderBrush = Brushes.AntiqueWhite;
                    Top.BorderBrush = Brushes.AntiqueWhite;
                    SheduleItem.DefaultBorderColor = Brushes.AntiqueWhite;
                    foreach (SheduleItem item in Items)
                    {
                        item.Panel.BorderBrush = Brushes.AntiqueWhite;
                    }
                }
                else
                {
                    DayGridTimeline.BorderBrush = Brushes.Black;
                    Top.BorderBrush = Brushes.Black;
                    SheduleItem.DefaultBorderColor = Brushes.Black;
                    foreach (SheduleItem item in Items)
                    {
                        item.Panel.BorderBrush = Brushes.Black;
                    }
                }
            }
        }

        private List<SheduleItem> Items;

        public event EventHandler ScheduleItemClick;

        private static double TimeVisualIntervalHeight = 50.0;      //minimum height between displaying the time interval        

        public SheduleDay()
        {
            InitializeComponent();
            Items = new List<SheduleItem>();

            //assign event handlers
            //_guicCanvas.MouseLeftButtonDown += OnScheduleItemClick;

            //default values
            Interval = new TimeSpan(0, 30, 0);
            TimeStart = new TimeSpan(0, 0, 0);
            TimeEnd = new TimeSpan(1, 0, 0, 0);
            CurrentDate = DateTime.Today.Date;
            FitToSize = false;
            IntervalHeight = 35.0;
            DarkTheme = false;

            Redraw();
        }

        public void Add(SheduleItem item)
        {
            double totalSeconds = TimeEnd.TotalSeconds - TimeStart.TotalSeconds;
            item.GeneratePanel(DayCanvas.ActualWidth, DayCanvas.ActualHeight, TimeStart.TotalSeconds, TimeEnd.TotalSeconds, totalSeconds);
            Items.Add(item);
            if (item.Start >= CurrentDate.Add(TimeStart) && item.Start < CurrentDate.Add(TimeEnd))
            {
                DayCanvas.Children.Add(item.Panel);
            }
        }

        public void Remove(SheduleItem item)
        {
            Items.Remove(item);
        }

        public void Remove(Guid id)
        {
            Items.RemoveAll(x => x.ID == id);
        }

        public void Clear()
        {
            DayCanvas.Children.Clear();
            Items.Clear();
        }

        public IReadOnlyCollection<SheduleItem> GetItems()
        {
            return Items.AsReadOnly();
        }


        //private void OnScheduleItemClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        //{
        //    int i = Items.FindIndex(x => x.Start >= CurrentDate.Add(TimeStart));
        //    for(; i < Items.Count && !Items[i].Panel.IsMouseOver; i++) { }
        //    if(i < Items.Count && Items[i].Clickable) {
        //        ScheduleItemClick?.Invoke(Items[i], EventArgs.Empty);
        //    } else {
        //            //nothing was clicked, fire event with no object
        //        ScheduleItemClick?.Invoke(null, EventArgs.Empty);
        //    }
        //}

        private void ChangeDate()
        {
            DayCanvas.Children.Clear();

            int StartItem = Items.FindIndex(x => x.Start >= CurrentDate.Add(TimeStart));
            if (StartItem > -1)
            {
                for (int i = StartItem; i < Items.Count && Items[i].Start < CurrentDate.Add(TimeEnd); i++)
                {
                    DayCanvas.Children.Add(Items[i].Panel);

                }
            }
        }

        public void Redraw()
        {
            DayGrid.Children.Clear();
            DayGrid.RowDefinitions.Clear();
            DayCanvas.Children.Clear();

            this.UpdateLayout();

            double canvasHeight = 0.0;

            int rows = 0;
            //calculate number of intervals in day and height of drawing canvas
            for (TimeSpan c = TimeEnd; c > TimeStart; c -= Interval)
            {
                rows++;
                canvasHeight += IntervalHeight;
            }

            DayGrid.Children.Add(DayGridTimeline);
            DayGridTimeline.SetValue(Grid.RowSpanProperty, rows);
            DayCanvas.SetValue(Grid.RowSpanProperty, rows);

            //recalculate intervals and override canvas height if FitToSize is enabled
            if (FitToSize)
            {
                canvasHeight = _guicScroll.ActualHeight;
                IntervalHeight = canvasHeight / (double)rows;
            }

            //create grid rows and draw time intervals
            TimeSpan time = TimeStart;
            for (int i = 0; i < rows; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(IntervalHeight);
                DayGrid.RowDefinitions.Add(row);

                Border border = new Border();
                border.BorderBrush = DayGridTimeline.BorderBrush;
                border.BorderThickness = new Thickness(0, 0, 0, 1);
                border.SetValue(Grid.ColumnSpanProperty, 2);
                border.SetValue(Grid.RowProperty, i);
                DayGrid.Children.Add(border);

                if (i == 0 || i % timeDisplayInterval == 0)
                {
                    Label label = new Label();
                    label.Content = string.Format("{0:00}:{1:00}", time.Hours, time.Minutes);
                    label.SetValue(Grid.ColumnProperty, 0);
                    label.SetValue(Grid.RowProperty, i);
                    label.SetValue(HorizontalAlignmentProperty, HorizontalAlignment.Left);
                    label.SetValue(VerticalAlignmentProperty, VerticalAlignment.Bottom);
                    DayGrid.Children.Add(label);
                }

                time = time.Add(Interval);
            }

            //draw items
            Items.Sort(SheduleItem.SortByStart);
            double totalSeconds = TimeEnd.TotalSeconds - TimeStart.TotalSeconds;

            foreach (SheduleItem item in Items)
            {
                item.GeneratePanel(DayCanvas.ActualWidth, DayCanvas.ActualHeight, TimeStart.TotalSeconds, TimeEnd.TotalSeconds, totalSeconds);
            }

            int StartItem = Items.FindIndex(x => x.Start >= CurrentDate.Add(TimeStart));
            if (StartItem > -1)
            {
                for (int i = StartItem; i < Items.Count && Items[i].Start < CurrentDate.Add(TimeEnd); i++)
                {
                    DayCanvas.Children.Add(Items[i].Panel);

                }
            }
        }
    }
}
