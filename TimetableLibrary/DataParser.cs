using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableLibrary
{
    public class DataParser
    {
        private IList<IList<Object>> parsedValues;
        private List<List<string>> weekValues = new List<List<string>>();

        public DataParser(IList<IList<Object>> values)
        {
            parsedValues = values;
            breakToDays();
        }

        public List<List<string>> getWeekValues()
        {
            return weekValues;
        }

        private void breakToDays()
        {
            int lecturesIter = 0;
            int daysIter = 0;
            List<string> dayValues = new List<string>();

            int lastDayLessionNumber = parsedValues.Count() % 9; //Гугл API обрезает количество значений до последнего заполненого поля
            if (lastDayLessionNumber != 0)
            {//Если количество пар обрезало до последнего существующего значения
                roundParsedValuesUp(lastDayLessionNumber);//Округляем количество пар до целого последнего дня
            }

            for (int line = 1; line < parsedValues.Count(); line++)
            {
                string dayValue="";
                foreach(string s in parsedValues[line])
                {
                    dayValue = dayValue + s;
                }
                dayValues.Add(dayValue); //lecturesIter,  убрал индекс
                lecturesIter++;

                if (lecturesIter == 9)
                { //Дошли до 9 пары - обнуляем счетчики, добавляем в недельный массив
                    weekValues.Add(dayValues); //daysIter, убрал индекс
                    daysIter++;
                    dayValues = new List<string>();
                    lecturesIter = 0;
                }
                
            }

        }
        private void roundParsedValuesUp(int lastDayLessionNumber)
        {
            List<Object> blankLession = new List<Object>();
            blankLession.Add("");
            for (int i = 0; i < (10 - lastDayLessionNumber); i++)
            {
                parsedValues.Add(blankLession);
            }
        }
    }
}
