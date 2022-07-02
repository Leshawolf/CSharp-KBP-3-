using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad5
{
    class Sub
    {
        private string name;
        private List<string> Data;

        public Sub(string name)
        {
            this.name = name;
            Data = new List<string>();
        }

        public string Name 
        { 
            get 
            { 
                return this.name; 
            } 
            set 
            { 
                this.name = value; 
            }
        }

        public void AddNews(string msg)
        {
            Data.Add($"{name,10} - {msg}\n");
            Console.WriteLine($"{name,10} - {msg}\n");
        }
    }
}
