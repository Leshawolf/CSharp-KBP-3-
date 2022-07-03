using System.Reflection;
using System.Text;

namespace mnogopot5;
class Program 
{
    public static string Translate(string source)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        ColoredConsole.WriteLine(ConsoleColor.Green, "Translate started ");
        String template = " " + source + " ";
        String res = "";
        using (FileStream fs = File.OpenRead(@"D:\TestFile.txt"))
        using (StreamReader sr = new StreamReader(fs, Encoding.GetEncoding(1251)))
        {
            Boolean found = false;
            Boolean finished = false;

            String line;
            while ((!found || !finished) && ((line = sr.ReadLine()) != null))
            {
                if (found)
                {
                    if (line != "" && line[0] != ' ') 
                        res += line;
                    else 
                        finished = true;
                }
                else
                if (line != "" && line[0] == ' ')
                {
                    int n = line.IndexOf(template);
                    if (n > 0 && n < 20) // ищем слово только в определении
                    {
                        res += line;
                        found = true;
                    }
                }
            }
        }
        ColoredConsole.WriteLine(ConsoleColor.Green, "Translate finished");
        return res;
    }
    delegate String StringToString(String s);
    static void Main(string[] args)
    {
        (new Task(() =>
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(50);

                ColoredConsole.Write(ConsoleColor.Gray, ".");

            }
        })).Start();
        StringToString d = new StringToString(Translate);
        String Z = d.Invoke("zoological");
        ColoredConsole.WriteLine(ConsoleColor.Red, Z);
        Assembly assembly = Assembly.LoadFrom(@"D:\Project C#\XML0802\XML0802\bin\Debug\net6.0\XML0802.dll");
        Console.WriteLine("***Список типов***");
        Type[] types = assembly.GetTypes();
        foreach (Type t in types)
            Console.WriteLine(t.FullName);
        
        Console.WriteLine("***Список конструкторов***");
        foreach (var type in types)
        {
            Console.WriteLine(type.FullName.ToUpper()+"\n");
            ConstructorInfo[] ctors = type.GetConstructors();

            foreach (ConstructorInfo c in ctors)
            {
                Console.WriteLine(c);
                Console.WriteLine("Имя: " + c.Name);
                ParameterInfo[] param = c.GetParameters();
                foreach (ParameterInfo pi in param)
                    Console.WriteLine(" {0}", pi);
            }
        }
        foreach (var type in types)
        {
            Console.WriteLine("***Список методов***");
            MethodInfo[] methods = type.GetMethods();
            foreach (MethodInfo mi in methods)
            {
                Console.WriteLine(mi);
                ParameterInfo[] param = mi.GetParameters();
                foreach (ParameterInfo pi in param)
                    Console.WriteLine(" {0}", pi);
            }
        }






        Console.WriteLine("***Список полей класса BankAccount***");

        Type typeD = assembly.GetType("XML0802.BankAccount");
        Console.WriteLine(typeD.FullName);
        FieldInfo[] fields = typeD.GetFields();
        foreach (FieldInfo field in fields)
        {
            var attributes = field.GetCustomAttributes();
            foreach (Attribute a in attributes)
            {
                String s = a.ToString();
                int n = s.IndexOf("BankAccount");
                if (n > 0)
                    s = s.Substring(0, n);
                Console.Write(s + " ");
            }
            Console.WriteLine(field.Name);
        }
    }
}