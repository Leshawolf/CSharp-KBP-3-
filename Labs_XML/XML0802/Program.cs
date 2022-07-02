using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Xml;
using System.Xml.Linq; 

namespace XML0802;
class XML0802
{
    static void Main(string[] args)
    {
        BankAccount ba = null;BankAccount ba1 = null;BankAccount ba2 = null;
        
        try
        {
            ba = new BankAccount(2, "Аекадий", 2, new(2000, 02, 23), 420);
            ba1 = new BankAccount(1, "Аписеп", 4, new(2000, 1, 13), 200);
            ba2 = new BankAccount(3, "Аграном", 1, new(2000, 5, 03), 100);
            List<BankAccount> people = new List<BankAccount>() {ba,ba1,ba2};
            List<BankAccount> list=new List<BankAccount>();
            list = people.OrderBy(x => x.OwnerFio).ThenBy(x=>x.OpenDataAccount).ToList();
            while(true)
            {
                Console.WriteLine("1.Вывод данных из List'a.\n2.Добавление объектов.\n3.Выполнения запросов\n4. Сортировка запросами по дате и ФИО\n0.Выйти из программы\n5.Вывод имена, с 2013 годом акаунта");
                Console.Write("Введите пункт меню: ");
                int a = Convert.ToInt32(Console.ReadLine());
                switch (a)
                {
                case 0:
                    {
                        return;
                    }
                case 1:
                    {
                        foreach (BankAccount item in list)
                        {
                            Console.WriteLine(item);
                        }
                        break;
                    }
                case 2:
                    {
                        XmlDocument xmlDocument = new XmlDocument();
                        xmlDocument.Load(@"D:\Проекты C#\XML0802\XML0802\File.xml");
                        XmlElement xRoot = xmlDocument.DocumentElement;

                        //Создание элемента BankAccount
                        XmlElement BankaAccountElem = xmlDocument.CreateElement("BankAccount");

                        //Атрибут FullName                        
                        XmlAttribute userAttrib = xmlDocument.CreateAttribute("user");

                            //Создание Элементов
                        XmlElement fullNameElem = xmlDocument.CreateElement("ownerFio");
                        XmlElement numAccountElem = xmlDocument.CreateElement("numberAccount");
                        XmlElement sumAccountElem = xmlDocument.CreateElement("sumAccount");
                        XmlElement openDataElem = xmlDocument.CreateElement("openDataAccount");
                        XmlElement accrualPercentElem = xmlDocument.CreateElement("accrualPercentage");
                        
                        BankaAccountElem.SetAttributeNode(userAttrib);
      
                        //Ввод с клавиатуры данных
                        Console.Write("Введите ваше ФИО: ");
                        string ownerFio =Convert.ToString(Console.ReadLine());
                        Console.Write("Введите номер вашего аккаунта: ");
                        int numberAccount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите сумму на аккаунте: ");
                        int sumAccount = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите день основания аккаунта: ");
                        int day = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите месяц основания аккаунта: ");
                        int month = Convert.ToInt32(Console.ReadLine());
                        Console.Write("Введите год основания аккаунта: ");
                        int year = Convert.ToInt32(Console.ReadLine());
                        DateTime openDataAccount = new DateTime(year, month, day);
                        Console.Write("Введите процент в банке: ");
                        int accrualPercent = Convert.ToInt32(Console.ReadLine());
                        //Создаём текстовое значение для элементов и атрибутов
                        XmlText ownerFioText = xmlDocument.CreateTextNode(ownerFio);
                        XmlText numberAccountText = xmlDocument.CreateTextNode(Convert.ToString(numberAccount));
                        XmlText sumAccountText = xmlDocument.CreateTextNode(Convert.ToString(sumAccount));
                        XmlText openDataAccountText = xmlDocument.CreateTextNode(Convert.ToString(openDataAccount));
                        XmlText accrualPercentText = xmlDocument.CreateTextNode(Convert.ToString(accrualPercent));

                            //Добавление узлов
                            fullNameElem.AppendChild(ownerFioText);
                            numAccountElem.AppendChild(numberAccountText);
                            sumAccountElem.AppendChild(sumAccountText);
                            openDataElem.AppendChild(openDataAccountText);
                            accrualPercentElem.AppendChild(accrualPercentText);

                            BankaAccountElem.Attributes.Append(userAttrib);
                            BankaAccountElem.AppendChild(fullNameElem);
                            BankaAccountElem.AppendChild(numAccountElem);
                            BankaAccountElem.AppendChild(sumAccountElem);
                            BankaAccountElem.AppendChild(openDataElem);
                            BankaAccountElem.AppendChild(accrualPercentElem);

                            xRoot.AppendChild(BankaAccountElem);
                            xmlDocument.Save(@"D:\Проекты C#\XML0802\XML0802\File.xml");

                            break;
                    }
                case 3:
                    {
                        XmlDocument xml = new XmlDocument();
                        xml.Load(@"D:\Проекты C#\XML0802\XML0802\File.xml");
                        //Console.WriteLine();
                        XmlElement element = xml.DocumentElement;
                        foreach (XmlNode xnode in element)
                        {
                            if (xnode.Attributes.Count > 0)
                            {
                                XmlNode attr = xnode.Attributes.GetNamedItem("name");
                                if (attr != null)   
                                {
                                    Console.WriteLine(attr.Value);
                                }
                            }
                            foreach (XmlNode childnode in xnode.ChildNodes)
                            {
                                
                                XmlNode attr = childnode.Attributes.GetNamedItem("ownerFio");
                                    Console.WriteLine("================");
                                    if (attr != null)
                                {

                                    Console.WriteLine(attr.InnerText);
                                }                                
                                if (childnode.Name == "numberAccount")
                                {
                                    Console.WriteLine("Номер аккаунта: " + childnode.InnerText);
                                }
                                if (childnode.Name == "ownerFio")
                                {
                                    Console.WriteLine("Полное Ф.И.О.: " + childnode.InnerText);
                                }
                                if (childnode.Name == "sumAccount")
                                {
                                    Console.WriteLine("Денег на Аккаунте: " + childnode.InnerText);
                                }
                                if (childnode.Name == "openDataAccount")
                                {
                                    Console.WriteLine("Дата открытия: " + childnode.InnerText);
                                }
                                if (childnode.Name == "accrualPercentage")
                                {
                                    Console.WriteLine("Процент: " + childnode.InnerText);
                                }
                            }
                        }

                        break;
                    }
                    case 4:
                        {
                            Console.WriteLine("\n\nСортировка по Дате и ФИО\n\n");
                            XDocument xelement = XDocument.Load(@"File.xml");
                            IEnumerable<XElement> sort = from t in xelement.Root.Elements("BankAccount")
                                                         orderby t.Element("openDataAccount").Value,
                                                         t.Element("ownerFio").Value
                                                         select t;
                            XDocument xdoc2 = new XDocument(
                            new XElement("account",
                            from account in sort
                            select new XElement("BankAccount",
                                new XAttribute("user", account.Attribute("user").Value),
                                new XElement("ownerFio", account.Element("ownerFio").Value),
                                new XElement("numberAccount", account.Element("numberAccount").Value),
                                new XElement("sumAccount", account.Element("sumAccount").Value),
                                new XElement("openDataAccount", account.Element("openDataAccount").Value),
                                new XElement("accrualPercentage", account.Element("accrualPercentage").Value))));
                            xdoc2.Save(@"D:\Проекты C#\XML0802\XML0802\File2.xml");
                            var file2 = new XmlDocument();
                            file2.Load(@"D:\Проекты C#\XML0802\XML0802\File2.xml");
                            var temp2 = file2.DocumentElement;
                            Console.WriteLine(temp2);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("\n\nФИО, имеющие на счету 222 руб:  ");
                            XDocument xdoc3 = XDocument.Load(@"D:\Project C#\XML0802\XML0802\File.xml");
                            bool flag = false;
                            foreach (XElement element in xdoc3.Element("account").Elements("BankAccount"))
                            {
                                XElement owerfio = element.Element("ownerFio");
                                XElement summa = element.Element("sumAccount");
                                if ((owerfio != null) && (summa != null) & Convert.ToInt32(summa.Value)==222)
                                {
                                    Console.WriteLine("Пользователь: "+owerfio.Value+" имеет на балансе: "+summa.Value);
                                    flag = true;
                                }
                            }
                            if (!flag)
                                Console.WriteLine("Таких аккаунтов нет");

                            break;
                        }


                }
            }

        }
        catch(NullArgumentException e)
        {
            Console.WriteLine($"Ошибочка отловлена в main^e \n{e.Message}");
        }
    }
}