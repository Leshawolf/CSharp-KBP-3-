using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z2
{
    internal class Book
    {
        private string name;
        private string author;
        private string publish;

        public string Name { get { return name; } set { name = value; } }

        public string Author { get { return author; } set { author = value; } }

        public string Publish { get { return publish; } set { publish = value; } }

        public Book() { }

        public Book(string name, string author, string publish)
        {
            this.name = name;
            this.author = author;
            this.publish = publish;
        }
    }
}
