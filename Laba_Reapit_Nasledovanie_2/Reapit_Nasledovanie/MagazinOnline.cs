using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reapit_Nasledovanie
{
    sealed class MagazinOnline:PrintedEdition
    {
        public MagazinOnline(): base()
        {}

        public MagazinOnline(string publishingHouse, int year, string name) : base(publishingHouse, year, name)
        {

        }
        public override string ToString()
        {
            return $"{"-",10}\n\tМагазин онлайн\nИздательство: {PublishingHouse}\nГод выпуска: {Year}\nНазвание: {Name}";
        }
    }
}
