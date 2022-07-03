using System;

namespace ПР_Структуры
{
    class ClassA { }

    class ClassB : ClassA { }

    class ClassC : ClassA { }

    class Program
    {
        public static void Main()
        {
            ClassA a = new ClassA();
            ClassB b = new ClassB();
            ClassC c = new ClassC();
            ClassA d = (ClassA)b;
        }
    }
}
    struct Information_ATC
    {
        private
        string date_calls;
        int cod_city;
        string name_city;
        int time_calls;
        int tarif;
        int number_phone_city;
        int number_phone_users;
        public Information_ATC(string date_calls, int cod_city, string name_city, int time_calls, int tarif, int number_phone_city, int number_phone_users)
        {
            this.date_calls = date_calls;
            this.cod_city = cod_city;
            this.name_city = name_city;
            this.time_calls = time_calls;
            this.tarif = tarif;
            this.number_phone_city = number_phone_city;
            this.number_phone_users = number_phone_users;
        }
        public void Show()
        {
            Console.WriteLine($"Город звонившего {name_city} | Общее время разговора: {time_calls} | Cтоимость разговора {time_calls*tarif} .");
        }
    }
    struct Information_ATC1
    {
        private
        string date_calls;
        int cod_city;
        string name_city;
        int time_calls;
        int tarif;
        int number_phone_city;
        int number_phone_users;
        public string Date_Calls
        {
            get { return date_calls; }
            set { date_calls = value; }
        }
        public int Cod_City
        {
            get { return cod_city; }
            set { cod_city = value; }
        }
        public string Name_City 
        {
            get {return name_city;}
            set {name_city = value;} 
        }
        public int Time_Calls 
        {
            get {return time_calls;}
            set {time_calls = value;}
        }
        public int Tarif 
        {
            get {return tarif;}
            set {tarif = value;}
        }
        public int Number_Phone_City 
        {
            get {return number_phone_city;}
            set {number_phone_city = value;}
        }
        
        public int Number_Phone_Users 
        {
            get { return number_phone_users; }
            set { number_phone_users = value; }
        }
        public void Show()
        {
            Console.WriteLine($"Город звонившего {name_city} | Общее время разговора: {time_calls} | Cтоимость разговора {time_calls * tarif} .");
        }
    }

}
