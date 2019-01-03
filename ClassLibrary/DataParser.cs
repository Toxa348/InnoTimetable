using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class DataParser
    {
        private List<List<Object>> parsedValues;
        private List<List<String>> weekValues = new List<List<String>>();


        public DataParser(List<List<Object>> values)
        {
            DataLoader dataLoader = new GoogleApiLoader();
            parsedValues = values;
            breakToDays();
        }

        public List<List<String>> getWeekValues()
        {
            return weekValues;
        }

        private void breakToDays()
        {
            int lecturesIter = 0;
            int daysIter = 0;
            List<String> dayValues = new List<String>();

            int lastDayLessionNumber = parsedValues.Count() % 9;
            if (lastDayLessionNumber != 0)
            {//Если количество пар обрезало до последнего существующего значения
                roundParsedValuesUp(lastDayLessionNumber);//Округляем количество пар до целого последнего дня
            }

            for (int line = 1; line < parsedValues.Count(); line++)
            {
                dayValues.Add(parsedValues[line].ToString()); //lecturesIter, убрал индекс
                lecturesIter++;

                if (lecturesIter == 9)
                { //Дошли до 9 пары - обнуляем счетчики, добавляем в недельный массив
                    weekValues.Add(dayValues); //daysIter,убрал индекс
                    daysIter++;
                    dayValues = new List<String>();
                    lecturesIter = 0;
                }
                //Щас последний день собирается но не добавляется в неделю
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
