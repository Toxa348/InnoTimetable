using System;
using System.Collections.Generic;
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
using TimetableLibrary;

namespace InnoTimetable
{
    public partial class WeekPage : Page
    {
        private DataParser dataParser;
        public WeekPage(DataParser dataParser)
        {
            this.dataParser = dataParser;
            InitializeComponent();
            
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowsNavigationUI = false;
            WeekView weekView = new WeekView(dataParser);
            List<List<Lesson>> finalFillSchedule = weekView.getWeekValues();
            var weekLists = FindVisualChildren<ListView>(this);
            for (int i = 0; i < finalFillSchedule.Count(); i++)
            {
                foreach (var FillLesson in finalFillSchedule[i])
                {
                    weekLists.ElementAt(i).Items.Add(FillLesson);
                }
            }
        }

        private void today_Click(object sender, RoutedEventArgs e)
        {
            if (NormalPage.showMode != NormalPage.ShowMode.today)
            {
                this.NavigationService.Navigate(new NormalPage());
            }
        }

        private void tomorrow_Click(object sender, RoutedEventArgs e)
        {
            if (NormalPage.showMode != NormalPage.ShowMode.tomorrow)
            {
                this.NavigationService.Navigate(new NormalPage(dataParser)); // if this return dataParser then start the constructor with tomorrow view launcher
            }
        }

        private void week_Click(object sender, RoutedEventArgs e)
        {

        }
        public static IEnumerable<T> FindVisualChildren<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
                {
                    DependencyObject child = VisualTreeHelper.GetChild(depObj, i);
                    if (child != null && child is T)
                    {
                        yield return (T)child;
                    }

                    foreach (T childOfChild in FindVisualChildren<T>(child))
                    {
                        yield return childOfChild;
                    }
                }
            }
        }
    }
}
