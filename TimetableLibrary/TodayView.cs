using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableLibrary
{
    public interface ViewMode
    {
        List<Lession> getValuesList();
    }
    public class TodayView : ViewMode
    {
        private List<Lession> todayLession = new List<Lession>();
        private List<List<string>> weekValues;
        private List<string> todayValues = new List<string>();
        public TodayView(DataParser dataParser)
        {
            weekValues = dataParser.getWeekValues();
        }
        
        public List<Lession> getValuesList()
        {
            todayValues = weekValues[getTodayDay()];
            foreach(string element in todayValues)
            {
                if (element != "")
                {
                    parseLession(element);
                }
                else
                {
                    todayLession.Add(new Lession());
                }
            }
            return todayLession;
        }
        private int getTodayDay()
        {
            return (int)(DateTime.Now.DayOfWeek+6)%7;
        }
        private void parseLession(String element)
        {
            string[] lessionValues = element.Split(new[] { "  " }, StringSplitOptions.RemoveEmptyEntries);
            Lession lession = new Lession(lessionValues[0], lessionValues[1], lessionValues[2]);
            todayLession.Add(lession);
        }
    }
}
