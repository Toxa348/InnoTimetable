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
    public partial class MainWindow : Window
    {
        DataParser dataParser;
        static ShowMode showMode = ShowMode.today;
        public MainWindow()
        {
            InitializeComponent();
            DataLoader dataLoader = new GoogleApiLoader();
            dataParser = new DataParser(dataLoader.getCellsData("1yXXOK2eP3oaUF6Io0g6NB8EhJqSOBBODAf_4vNyIi1w", "V1:W33"));

        }

        private void today_Click(object sender, RoutedEventArgs e)
        {
            if(showMode!= ShowMode.today)
            {
                showMode = ShowMode.today;
                ViewMode viewMode = new TodayView(dataParser);
                foreach(Lession lession in viewMode.getValuesList())
                {
                    listView.Items.Add(lession);
                        
                }

                //listBox.Items.Add
            }
        }

        private void tomorrow_Click(object sender, RoutedEventArgs e)
        {
            if (showMode != ShowMode.tomorrow)
            {
                showMode = ShowMode.tomorrow;

            }
        }

        private void week_Click(object sender, RoutedEventArgs e)
        {
            if (showMode != ShowMode.week)
            {
                showMode = ShowMode.week;

            }
        }
        enum ShowMode
        {
            today,
            tomorrow,
            week
          
        }
    }
}
