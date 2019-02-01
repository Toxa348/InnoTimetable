using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableLibrary
{
    public interface IViewMode
    {
        List<Lesson> getValuesList();
    }
    public class TodayView : IViewMode
    {
        private List<Lesson> todayLession;
        private List<List<string>> weekValues;
        private List<string> todayValues;

        public TodayView()
        {
        }

        public TodayView(DataParser dataParser)
        {
            weekValues = dataParser.getWeekValues();
        }
        
        public List<Lesson> getValuesList()
        {
            todayLession = new List<Lesson>();
            if (getTodayDay() > weekValues.Count())
            {
                for (int i = 0; i < 8; i++)
                {
                    todayLession.Add(new Lesson());
                }
                return todayLession;
            }
            else
            {
                todayValues = weekValues[getTodayDay()-1];
                foreach (string element in todayValues)
                {
                    if (element != "")
                    {
                        todayLession.Add(parseLesson(element));
                    }
                    else
                    {
                        todayLession.Add(new Lesson());
                    }
                }
                return todayLession;
            }
        }
        protected virtual int getTodayDay()
        {
            return (int)(DateTime.Now.DayOfWeek);
        }
        protected Lesson parseLesson(String element)
        {
            string[] lessionValues = element.Split(new[] {  @"
" , "\n"}, StringSplitOptions.RemoveEmptyEntries); // "  ",
            Lesson lession = new Lesson(lessionValues[0], lessionValues[1], lessionValues[2]);
            return lession;
        }
    }
}
