using System;

namespace Magic_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите n: " );
            int n = Convert.ToInt32(Console.ReadLine());

            while (n % 2 == 0) 
            {
                Console.Write("Введите n: " );
                n = Convert.ToInt32(Console.ReadLine());
            }
            int[,] arr = new int[n, n];
            int res = n / 2;
            int k = res - 1;
            int o = res;
    
            for (int num = 1; num <= n*n;) {
              
                if (o == n) {
                    o = 0;
                } 
                if (k == -1) {
                    k = n - 1;
                }
               
                if (arr[k,o] == 0) {
                    arr[k, o] = num;
                }
                else {
                    k--;
                    o--;
                    if (o == -1) {
                        o =  n - 1;
                    }
                    arr[k, o] = num;      
                }

                k--;
                o++;

                if (k == 0 && o == 1) {
                    k--;
                    o--;
                }
                
                num++;
               
            }

            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++) {
                    Console.Write($"{arr[i,j],5}");
                }
                Console.WriteLine();
            }
          
        }
    }
}
