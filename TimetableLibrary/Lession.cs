using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimetableLibrary
{
    public class Lession
    {

        public string title { get; set; }
        public string professor { get; set; }
        public string room { get; set; }
        public Lession(string title, string professor, string room)
        {
            this.title = title;
            this.professor = professor;
            this.room = room;
        }
        public Lession()
        {
            this.title = "";
            this.professor = "";
            this.room = "";
        }
    }
}
