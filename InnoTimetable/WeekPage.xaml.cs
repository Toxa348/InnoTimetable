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
    /// <summary>
    /// Логика взаимодействия для WeekPage.xaml
    /// </summary>
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
            WeekView weekView = new WeekView(dataParser);
            List<List<Lesson>> finalFillSchedule = weekView.getWeekValues();
            foreach (var FillLesson in finalFillSchedule[0])
            {
                mondayList.Items.Add(FillLesson);
            }
            foreach (var FillLesson in finalFillSchedule[1])
            {
                tuesdayList.Items.Add(FillLesson);
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

        }

        private void week_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
