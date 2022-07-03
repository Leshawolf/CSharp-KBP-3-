using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obobschenie
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Cset<int> myChars_1 = new Cset<int>(3);
                Cset<int> myChars_2 = new Cset<int>(3);
                myChars_1.Rand();
                myChars_2.Rand();
                myChars_1.Show();
                Console.WriteLine();
                myChars_2.Show();
                Console.WriteLine();
                myChars_1 = myChars_1 + myChars_2;
                myChars_1.Show();
                Console.WriteLine();
                Console.WriteLine("Ch1>=ch2 " + (myChars_1 >= myChars_2));
                Console.WriteLine("Ch1<=ch2 " + (myChars_1 <= myChars_2));
                Console.WriteLine($"Множество ch1={myChars_1.Moschnost()}\nМножество ch2={myChars_2.Moschnost()}");
                myChars_1.Peresech(myChars_1, myChars_2);
            }
            catch(Exception e)
            {
                throw new Exception("Ошибка");
            }

        }
    }
    public class Cset<T>
    {
        int size;
        public  T [] inner;

        public Cset(int size)
        { 
            this.size = size;
            this.inner = new T [size];
        }
        public void Show()
        {
            foreach (var item in inner)
            {
                Console.Write(item);
            }
        }
        public T this[int index]
        {
            get => inner[index];
            set => inner[index] = value;
        }
        public void Rand()
        {
            Random rnd = new Random();
            for (int i = 0; i < size; i++)
            {
                inner[i]=(dynamic)rnd.Next(1,5);
            }
        }
        public int Moschnost()=>inner.Length;
        public void Peresech(Cset<T> ch1,Cset<T> ch2)
        {
            var result = (dynamic)ch1.inner.Intersect(ch2.inner);
            foreach (int s in result)
                Console.WriteLine(s);
        }
        public static Cset<T> operator +(Cset<T> ch1, Cset<T> ch2)
        {
            for (int i = 0; i < ch1.inner.Length; i++)
            {
                ch1.inner[i] =(dynamic)ch1.inner[i]+ ch2.inner[i];
            }
            return ch1;
        }
        public static bool operator <=(Cset<T> ch1, Cset<T> ch2)
        {
            if (ch1.inner.Length != ch2.inner.Length)
                return false;
            int sum1 = 0, sum2 = 0;
            for (int i = 0; i < ch1.inner.Length; i++)
            {
                sum1 +=(dynamic) ch1.inner[i];
            }
            for (int i = 0; i < ch1.inner.Length; i++)
            {
                sum2 += (dynamic)ch2.inner[i];
            }
            if (sum1 <= sum2)
                return true;
            return false;
        }

        public static bool operator >=(Cset<T> ch1, Cset<T> ch2)
        {
            if (ch1.inner.Length != ch2.inner.Length)
                return false;
            int sum1=0, sum2=0;
            for (int i = 0; i < ch1.inner.Length; i++)
            {
                sum1 += (dynamic)ch1.inner[i];
            }
            for (int i = 0; i < ch1.inner.Length; i++)
            {
                sum2 +=(dynamic) ch2.inner[i];
            }
            if (sum1 >= sum2)
                    return true;
            return false;
        }
    }
}