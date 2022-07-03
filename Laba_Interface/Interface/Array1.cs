using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Interface
{
    //interface IComparer
    //{
    //    int Compare(object o1, object o2);
    //}
    //interface IComparable
    //{
    //    int CompareTo(object o);
    //}


    class Array1 : ICloneable, IComparable<Array1>, IComparer<Array1>,IEnumerable
    {
        public List<Circle> a  = new List<Circle>();
        public Interface.Circle circle;// = new Circle(1,0,0,100);
        string name;
        int age;
        public void Add(Circle c) { a.Add(c); }
        public Array1() { name = "Anonimous";age = 18; circle = new Circle(1, 0, 0, 100); }

        public Array1(string name, int age)
        {
            this.name = name;
            this.age = age;
            circle = new Circle(1, 0, 0, 100);
        }
        public override string ToString()
        {
            StringBuilder s = new StringBuilder();
            foreach (var item in a)
            {
                s.Append(item+"\n");
            }
            return $"{name} - {age}: {s}";// {string.Join(" ", a)} ";
        }

        public int Compare(Array1 p1, Array1 p2)
        {
            if (p1.name.Length > p2.name.Length)
                return 1;
            else if (p1.name.Length < p2.name.Length)
                return -1;
            else
                return 0;
        }
        public int CompareTo(Array1 arr)
        {
            return this.name.CompareTo(arr.name);
        }
        public Array1 ShallowClone() => (Array1)this.MemberwiseClone();
        public object Clone()
        {

            Array1 arr = new Array1 { name = this.name, age=this.age,circle=this.circle };
            for (int i = 0; i < a.Count; i++)
            {
                arr.a.Add(a[i]);
            }
            return arr;
        }
        public IEnumerator GetEnumerator()
        {
            return name.GetEnumerator();
        }
        public string Name { get { return name; } set { name = value; } }

        public int Age { get { return age; } set { age = value; } }
    }

}
