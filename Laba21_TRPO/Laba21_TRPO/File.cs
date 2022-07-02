using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba21_TRPO
{
    class File
    {
        private int size;
        private string name;
        private string creating_date;
        public File(int size, string name, string creating_date)
        {
            this.size = size;
            this.name = name;
            this.creating_date = creating_date;
        }
        public void File_Info()
        {
            Console.WriteLine($"Название файла: {name}\nРазмерность файла: {size}\nДата создания файла: {creating_date}");
        }
    }
}
