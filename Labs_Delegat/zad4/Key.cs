using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zad4
{
    class Key
    {
        public delegate void PushKey(string message);
        public event PushKey Keys;
        public void Push()
        {
           Console.ResetColor();
            ConsoleKeyInfo keyInfo = Console.ReadKey();
         //   Console.WriteLine();

            if (keyInfo.Key == ConsoleKey.Enter)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Keys?.Invoke($"Вы нажали- {keyInfo.Key}");
             //   Console.ForegroundColor = COLOR;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Keys?.Invoke($"Вы нажали на кнопку не подходящую по вашему варианту, нажмите Enter,а не - {keyInfo.Key}");
             //   Console.ForegroundColor = ConsoleColor.White;
            }

        }
    }
}
