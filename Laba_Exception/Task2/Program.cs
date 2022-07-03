using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                DateTime ar = new DateTime(2021, 9, 30);
                DateTime ar1 = new DateTime(2021, 05, 12);
                AvailiableSeats avSeats = new AvailiableSeats(ar, "12:30", "Ул.Пушкина", 10);
                AvailiableSeats avSeats1 = new AvailiableSeats(ar1, "12:30", "Ул.Козанцева", 23);
                AvailiableSeats[] spisok = { avSeats, avSeats1 };
                AvailiableSeats avSeats2 = new AvailiableSeats();
                DateTime ar2 = new DateTime(2021, 05, 12);
                avSeats2.Check(ar2, "12:30", 20, spisok);
                avSeats.Av_Seats=-1;
            }
            catch(AV e)
            {
                throw new AV("Ошибочка");
            }
            catch(Exception e)
            {
                throw new Exception("Ошибка");
            }
        }
    }
}