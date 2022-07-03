class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Выберите: 1-чтобы зашифровать текст; 2-чтобы расшифровать текст; 3-чтобы выйти из программы.");
        string buf;
        buf = Console.ReadLine();
        switch (buf)
        {
            case "1":
                string[,] encriptionMatrix_l ={
                                                   {"Л", "А", "Б", "О", "Р", "Т","Н","Я"},
                                                   {"В", "Г", "Д", "Е", "Ж", "З","И","Й"},
                                                   {"К", "М", "П", "С", "У", "Ф","Х","Ц"},
                                                   {"Ч", "Ш", "Щ", "Ъ", "Ы", "Ь","Э","Ю"},
                                                  };
                string[,] encriptionMatrix_p ={
                                                   {"Л", "А", "Б", "О", "Р", "А","Т","О"},
                                                   {"Р", "Н", "А", "Я", "Д", "Е","Ж","З"},
                                                   {"Й", "Л", "М", "Т", "У", "Ф","Х","Ц"},
                                                   {"Ш", "Щ", "Ъ", "Ы", "Ь", "Э","Ю","Я"},
                                                  };
                string text = "Лабораторная";
                Console.WriteLine(text);
                text = text.Replace(" ", "").Replace(",", "").Replace(".", ""); //удаляем пробелы запятые и точки      
                text = text.ToUpper(); //переводим текс в заглавные буквы
                int t = text.Length; //длина входного слова
                                     //проверяем, четное ли число символов в строке
                int temp = t % 2;
                if (temp != 0) //если нет то добавляем в конец строки символ "X" 
                {
                    text = text.PadRight((t + 1), 'Х');
                }
                int len = text.Length / 2; /*длина нового массива - равная половине длины входного слова
                                         т.к. в новом масиве каждый элемент будет содержать 2 элемента из старого
                                         массива*/
                string[] str = new string[len]; //новый массив
                int l = -1; //служебная переменная
                int i, j;
                for (i = 0; i < t; i += 2) //в старом массиве шаг равен 2
                {
                    l++; //индексы для нового массива
                    if (l < len)
                    {
                        //Элемент_нового_массива[i] =  Элемент_старого_массива[i] +  Элемент_старого_массива[i+1]
                        str[l] = Convert.ToString(text[i]) + Convert.ToString(text[i + 1]);
                    }
                }
                //выводим на экран биграммы
                for (i = 0; i < str.Length; i++)
                    Console.Write(str[i] + " ");
                // КОДИРОВАНИЕ ---------------------------------------------------------------------------------------
                string s1 = ""; //первый символ биграмы
                string s2 = ""; //второй символ биграмы
                string encodetString = ""; //зашифрованая строка
                                           //координаты очередного найденного символа из каждой пары
                int i_first = 0, j_first = 0;
                int i_second = 0, j_second = 0;
                foreach (string both in str)
                {
                    for (i = 0; i < 4; i++)
                    {
                        for (j = 0; j < 8; j++)
                        {
                            //координаты первого символа пары в исходной матрице
                            if (both[0] == Convert.ToChar(encriptionMatrix_l[i, j]))
                            {
                                i_first = i;
                                j_first = j;
                            }
                            //координаты второго символа пары в исходной матрице
                            if (both[1] == Convert.ToChar(encriptionMatrix_p[i, j]))
                            {
                                i_second = i;
                                j_second = j;
                            }
                        }
                    }
                    //если пара символов находится в одной строке
                    if (i_first == i_second)
                    {
                        if (j_first == 7) /*если символ последний в строке,
                                       кодируем его первым символом из матрицы*/
                        {
                            s1 = Convert.ToString(encriptionMatrix_l[i_first, 0]);
                        }
                        //если символ не последний, кодируем его стоящим справа от него
                        else
                        {
                            s1 = Convert.ToString(encriptionMatrix_l[i_first, j_first + 1]);
                        }
                        if (j_second == 7) /*если символ последний в строке
                                          кодируем его первым символом из матрицы*/
                        {
                            s2 = Convert.ToString(encriptionMatrix_p[i_second, 0]);
                        }
                        //если символ не последний, кодируем его стоящим справа от него
                        else
                        {
                            s2 = Convert.ToString(encriptionMatrix_p[i_second, j_second + 1]);
                        }
                    }
                    //если пара символов находиться в разных столбцах и строках
                    if (i_first != i_second /*&& j_first != j_second  */)
                    {
                        s1 = Convert.ToString(encriptionMatrix_p[i_first, j_second]);
                        s2 = Convert.ToString(encriptionMatrix_l[i_second, j_first]);
                    }
                    //записыавем результат кодирования
                    encodetString = encodetString + s1 + s2;
                }
                Console.WriteLine();
                Console.WriteLine(encodetString);
                Console.ReadLine();
                break;
            case "2":
                //ДЕКОДИРОВАНИЕ ----------------------------------------------------------------------------------
                string decodetString = ""; //расшифрованная строка
                                           //переменная для хранения строки подлежащей расшифровке
                string tempString = "тбтвфгналорспъэяфлнчтчеагчсдтвгсцъасежвчячжклопсязфжфакоожретветглсизонгьрогнппйсжсуаетвйзэвлебхммюярс";
                tempString = tempString.ToUpper(); //переводим текс в заглавные буквы
                int id, jd;
                string sd1 = ""; //первый раскодируемый символ
                string sd2 = ""; //второй раскодированный символ
                                 //координаты очередного найденного символа из каждой пары
                int i_first_d = 0, j_first_d = 0;
                int i_second_d = 0, j_second_d = 0;
                int i1 = 0, j1 = 0; //вспомагательные переменные на случай если буквы не в одной строке и надо менять таблицы
                int i2 = 0, j2 = 0;
                Console.WriteLine(tempString);
                int lend = tempString.Length / 2; /*длина нового массива -
                                                равная половине длины входного слова
                                                 т.к. в новом масиве каждый элемент будет
                                                   содержать 2 элемента из старого массива*/
                string[] str2 = new string[lend]; //новый массив
                int ld = -1; //служебная переменная
                for (id = 0; id < tempString.Length; id += 2) //в старом массиве шаг равен 2
                {
                    ld++; //индексы для нового массива
                    if (ld < lend)
                    {
                        //Элемент_нового_массива[i] =  Элемент_старого_массива[i] +  Элемент_старого_массива[i+1]
                        str2[ld] = Convert.ToString(tempString[id]) + Convert.ToString(tempString[id + 1]);
                    }
                }
                //выводим на экран биграммы
                for (i = 0; i < str2.Length; i++)
                    Console.Write(str2[i] + " ");
                string[,] decriptionMatrix_ld ={
                                                   {"Л", "А", "Б", "О", "Р", "А","Т","О"},
                                                   {"Р", "Н", "А", "Я", "Ж", "З","И","Й"},
                                                   {"К", "М", "П", "С", "У", "Ф","Х","Ц"},
                                                   {"Ч", "Ш", "Щ", "Ъ", "Ы", "Ь","Э","Ю"},
                                                  };
                string[,] decriptionMatrix_pd ={
                                                   {"Л", "А", "Б", "О", "Р", "А","Т","О"},
                                                   {"Р", "Н", "А", "Я", "Д", "Е","Ж","З"}
                                                  };
                foreach (string bothd in str2)
                {
                    for (id = 0; id < 4; id++)
                    {
                        for (jd = 0; jd < 8; jd++)
                        {
                            /* Если буквы находились в одной строке при кодировании, то они остались в своих таблицах
                            и раскодирование надо производить в тех же таблицах*/
                            if (bothd[0] == Convert.ToChar(decriptionMatrix_ld[id, jd]))
                            {
                                i_first_d = id;
                                j_first_d = jd;
                            }
                            if (bothd[1] == Convert.ToChar(decriptionMatrix_pd[id, jd]))
                            {
                                i_second_d = id;
                                j_second_d = jd;
                            }
                            if (bothd[0] == Convert.ToChar(decriptionMatrix_pd[id, jd]))
                            {
                                i1 = id;
                                j1 = jd;
                            }
                            if (bothd[1] == Convert.ToChar(decriptionMatrix_ld[id, jd]))
                            {
                                i2 = id;
                                j2 = jd;
                            }
                        }
                    }
                    if (i_first_d == i_second_d) //если символы в одной строке
                    {
                        if (j_first_d == 0) /*если символ первый в строке,  декодируем его последним символом из матрицы*/
                        {
                            sd1 = Convert.ToString(decriptionMatrix_ld[i_first_d, 7]);
                        }
                        //если символ не первый, декодируем его стоящим слева от него
                        else
                        {
                            sd1 = Convert.ToString(decriptionMatrix_ld[i_first_d, j_first_d - 1]);
                        }
                        if (j_second_d == 0) /*если символ первый в строке  декодируем его последним символом из матрицы*/
                        {
                            sd2 = Convert.ToString(decriptionMatrix_pd[i_second_d, 7]);
                        }
                        //если символ не последний, Декодируем его стоящим слева от него
                        else
                        {
                            sd2 = Convert.ToString(decriptionMatrix_pd[i_second_d, j_second_d - 1]);
                        }
                    }
                    else
                    {   /* если же буквы в разных строках, то при кодировании мы сменили таблицы
                          и раскодированный символ надо брать из таблицы противоположной*/
                        //координаты первого символа пары в исходной матрице
                        sd1 = Convert.ToString(decriptionMatrix_ld[i1, j2]);
                        sd2 = Convert.ToString(decriptionMatrix_pd[i2, j1]);
                    }
                    decodetString = decodetString + sd1 + sd2;
                }
                Console.WriteLine();
                Console.WriteLine(decodetString);
                Console.ReadLine();
                break;
            case "3": return;
            default:
                Console.WriteLine("не попал по клавише!");
                Console.ReadLine();
                break;
        }
    }
}