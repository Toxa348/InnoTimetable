using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableLibrary
{
    public class TomorrowView : TodayView
    {
        public TomorrowView(DataParser dataParser) : base(dataParser)
        {

        }
        protected override int getTodayDay()
        {
            return (int)(DateTime.Today.AddDays(1+4).DayOfWeek);
        }
    }
}
