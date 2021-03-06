﻿using System;
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
    public partial class NormalPage : Page
    {
        DataParser dataParser;
        public static ShowMode showMode;

        public NormalPage()
        {
            InitializeComponent();
            DataLoader dataLoader = new GoogleApiLoader();
            showMode = ShowMode.today;
            try
            {
                dataParser = new DataParser(dataLoader.getCellsData("1nWzmxw2_OMfGkqfJZIkKBfFpS_gOTPDIEHOrGeYwwOg", "Z1:Z55"));
            }
            catch (Exception)
            {
                MessageBox.Show("Can't recieve the data");
            }
            //1yXXOK2eP3oaUF6Io0g6NB8EhJqSOBBODAf_4vNyIi1w   V1:W33    Autumn
            //1nWzmxw2_OMfGkqfJZIkKBfFpS_gOTPDIEHOrGeYwwOg   Z1:AA55    Spring
            loadToday();
        }

        public NormalPage(DataParser dataParser) //Constructor for tomorrow schedule from week page
        {
            this.dataParser = dataParser;

            InitializeComponent();
            if (showMode != ShowMode.tomorrow)
            {
                showMode = ShowMode.tomorrow;
                IViewMode viewMode = new TomorrowView(dataParser);
                foreach (Lesson lession in viewMode.getValuesList())
                {
                    listView.Items.Add(lession);
                }
            }
        }

        private void today_Click(object sender, RoutedEventArgs e)
        {
            if (showMode != ShowMode.today)
            {
                listView.Items.Clear();
                showMode = ShowMode.today;
                loadToday();
            }
        }

        private void loadToday()
        {
            IViewMode viewMode = new TodayView(dataParser);//тут баг
            foreach (Lesson lession in viewMode.getValuesList())
            {
                listView.Items.Add(lession);
            }
        }

        private void tomorrow_Click(object sender, RoutedEventArgs e)
        {
            if (showMode != ShowMode.tomorrow)
            {
                listView.Items.Clear();
                showMode = ShowMode.tomorrow;
                IViewMode viewMode = new TomorrowView(dataParser);
                foreach (Lesson lession in viewMode.getValuesList())
                {
                    listView.Items.Add(lession);
                }
            }
        }

        private void week_Click(object sender, RoutedEventArgs e)
        {
            if (showMode != ShowMode.week)
            {
                listView.Items.Clear();
                showMode = ShowMode.week;
                Application.Current.MainWindow.Height = 800;
                Application.Current.MainWindow.Top = 0;
                this.NavigationService.Navigate(new WeekPage(dataParser));
            }
        }
        public enum ShowMode
        {
            today,
            tomorrow,
            week

        }
    }
}
