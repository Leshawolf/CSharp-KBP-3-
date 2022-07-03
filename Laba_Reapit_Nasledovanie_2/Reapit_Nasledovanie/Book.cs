using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reapit_Nasledovanie
{
    class Book:PrintedEdition
    {
        public string Type { get; set; }
        public string Author { get; set; }
        public int Numblist { get; set; }

        public Book() { }
        public Book(string type,string author,int numblist,string publishingHouse, int year, string name) : base(publishingHouse, year, name)
        {
            Type = type;
            Author = author;
            Numblist = numblist;
            PublishingHouse = publishingHouse;
            Year = year;
        }

        public override string ToString()
        {
            return $"{"-",10}\n\tКнига\nИздательство: {PublishingHouse}\nГод выпуска: {Year}\nНазвание: {Name} \nТип книги: {Type}\nАвтор: {Author}\nКоличество страниц:{Numblist}\n{"-",10}";
        }

    }
}
