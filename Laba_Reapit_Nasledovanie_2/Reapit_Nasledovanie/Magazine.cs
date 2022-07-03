using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reapit_Nasledovanie
{
    class Magazine:PrintedEdition
    {
        public int Number { get; set; }
        public string Week { get; set; }
        public Magazine() { }

        public Magazine(int number,string week,string publishingHouse, int year, string name) : base(publishingHouse, year, name)
        {
            Number = number;
            Week = week;
        }

        public override string ToString()
        {
            return $"{"-",10}\n\tЖурнал\nИздательство: {PublishingHouse}\nНомер журнала: {Number}\nМесяц выпуска: {Week}\n Год выпуска: {Year}\n{"-",10}";
        }


    }
}
