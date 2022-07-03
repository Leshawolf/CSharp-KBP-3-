using System;
using static System.Console;

namespace Interface
{

    class ATM : IATM, IATMPrior
    {
        private int id=1;
        public ATM() {}
        public void NumExample()
        {
            Console.WriteLine($"Номер задания: {id}");
        }
        public void Information()
        {
            Console.Write("Добро пожаловать в Приорбанк\nВыберите действие:\n1.Получить бонус в данном банке\n2.Узнать адреса банкоматов\n3.Снять все деньги со счёта\n4.Скип\nВаш выбор: ");
        }
        public void Gettingbonus() { Console.WriteLine("Вы полчили бонус"); }
        public void adress() { Console.WriteLine($"Адрес банкомата тут:\nУлица Пушкина, дом Калатушкина"); }
        public void GiveMoney() { Console.WriteLine("Вы сняли деньги!"); }
    }
}