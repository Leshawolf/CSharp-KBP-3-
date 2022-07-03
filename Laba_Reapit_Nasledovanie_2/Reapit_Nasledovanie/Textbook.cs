using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reapit_Nasledovanie
{
    class Textbook:PrintedEdition
    {
        public string Purpose { get; set; }
        public Textbook() { }

        public Textbook(string purpose, string publishingHouse, int year, string name) : base(publishingHouse, year, name)
        {
            Purpose = purpose;
        }


        public override string ToString()
        {
            return $"{"-",10}\n\tУчебник {Name}\nИздание: {PublishingHouse}\nВыпуск {Year} года)\nНазначение:{Purpose}\n{"-",10}";
        }
    }
}
