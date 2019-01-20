using System.Collections.Generic;
using TimetableLibrary;

namespace InnoTimetable
{
    internal class WeekView : TodayView
    {
        private List<List<string>> weekValues;
        List<List<Lesson>> finalWeekSchedule = new List<List<Lesson>>();

        public WeekView(DataParser dataParser) : base(dataParser)
        {
            weekValues = dataParser.getWeekValues();
        }
        public List<List<Lesson>> getWeekValues()
        {
            foreach (var dayList in weekValues)
            {
                List<Lesson> eachDay = new List<Lesson>();
                foreach (var lesson in dayList)
                {
                    if (lesson != "")
                    {
                        eachDay.Add(parseLesson(lesson));
                    }
                    else
                    {
                        eachDay.Add(new Lesson());
                    }
                    
                }
                finalWeekSchedule.Add(eachDay);
            }
            return finalWeekSchedule;
        }

    }
}