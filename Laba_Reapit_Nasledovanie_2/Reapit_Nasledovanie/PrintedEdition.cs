using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reapit_Nasledovanie
{
    abstract class PrintedEdition
    {
        public string PublishingHouse { get; set; }
        public int Year { get; set; }
        public string Name { get; set; }
        static  PrintedEdition()
        {}
        public PrintedEdition()
        {
            PublishingHouse = "OreilyHouse";
            Year = 2000;
            Name = "Oreily";
        }
        public PrintedEdition(string publishingHouse, int year, string name)
        {
            PublishingHouse = publishingHouse;
            Year = year;
            Name = name;
        }


        override public string ToString()
        {
            return $"{"-",10}\n\tИздание\nИздательство: {PublishingHouse}\nГод выпуска: {Year}\nНазвание издания: {Name}\n{"-",10}";
        }
    }
}
