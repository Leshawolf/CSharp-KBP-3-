using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    public class AvailiableSeats
    {
        DateTime data = new();
        string mesto,time;
        int av_seats;
        public AvailiableSeats() { }

        public AvailiableSeats(DateTime data,string time, string mesto, int av_seats)
        {
            this.time = time;
            this.data = data;
            this.mesto = mesto;
            this.av_seats = av_seats;
        }
        public int Av_Seats
        { 
            get
            {
                return av_seats;
            }
            set 
            {
                if (av_seats<=0)
                {
                    throw new AV("Вы выбрали количество мест 0 или меньше, это запрещено");
                }
                else
                {
                    av_seats = value;
                }
            }
        }
        public void Check(DateTime data1, string time1, int av_seats1,AvailiableSeats[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {

                if (data1 == arr[i].data)
                {
                    if (arr[i].time == time1)
                    {


                        if (arr[i].av_seats >= av_seats1)
                        {
                            arr[i].av_seats -= av_seats1;
                            Console.WriteLine("Вы успешно забронировали место на данную дату");
                           
                            return;
                        }
                        else
                        {
                            Console.WriteLine("К сожалению на данное число, нельзя забронировать столько мест");
                        }
                    }
                }
            }
        }
    }
}
