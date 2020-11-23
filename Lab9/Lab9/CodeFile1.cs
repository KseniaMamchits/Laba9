using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab9
{
    public static class StrUpgrade
    {
        public static Func<string, string> StrFunc;
        public static Action<string> action;

        private static string AddDot(string str)//добавить точку
        {
            str += ".";
            return str;
        }
        private static void SubString(string str)//выделить 1 слово
        {
            Console.WriteLine(str.Substring(0, 5));
        }
        private static string RemoveDoubleSpaces(string str)//заменить 2 пробел
        {

            return str.Replace("  ", " ");
        }
        private static string ToUpperCase(string str)//капс
        {

            return str.ToUpper();
        }
        private static string RemoveCom(string str)//удалить запятые
        {
            return str.Replace(",", " ");
        }
        public static void Upgrade(string str)
        {

            StrFunc = RemoveCom;//удалять запятые
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += ToUpperCase;//капс
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += RemoveDoubleSpaces;//замена двойного пробела
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            StrFunc += AddDot;//добавить точку
            StrFunc?.Invoke(str);
            Console.WriteLine(StrFunc(str));
            action = SubString;//выделяем слова
            action?.Invoke(str);
        }
    }
    class Boss
    {
        static bool OnOff = false;//для проверки включения техники
        static int person_power = 220;//макс мощность человека
        static int tech_power = 500;//макс мощность техники
        public static int techvolt;
        public static int persVolt;
        public int Techvolt
        {
            get
            {
                return techvolt;
            }
            set
            {
                if (value > 0)
                {
                    techvolt = value;
                }
            }
        }
        public delegate void Technic(string str);
        public event Technic Upgrade;
        public event Technic TurnOn;
        
        public void On()
        {
            OnOff = true;
            Upgrade?.Invoke("Техника включена");
        }
        public void Add(int vlt)
        {
            if (OnOff == true)//проверяем включина ли техника
            {
                techvolt += vlt;
                persVolt += vlt;

                if (techvolt < tech_power)
                {
                    TurnOn?.Invoke($"Мощность увеличина на {vlt}");
                    TurnOn?.Invoke($"(В настоящий момент мощность техники {techvolt})");

                }
                else
                {
                    Console.WriteLine("Техника сломалась");
                }
                if (persVolt < person_power)
                {
                    TurnOn?.Invoke($"(В настоящий момент мощность человека {persVolt})");
                }
                else
                {
                    Console.WriteLine("Человек сломался");
                }

            }
            else
            {
                Console.WriteLine("Вы не включили технику");
            }

        }


    }
    class Program
    {
        static void Main(string[] args)
        {
            string str = "Car,  Bus,  Horse, Train";
            Console.WriteLine(str);
            StrUpgrade.Upgrade(str);
            Boss boss1 = new Boss();
            Boss boss2 = new Boss();
            boss1.Upgrade += st => Console.WriteLine(st);
            boss1.TurnOn += st => Console.WriteLine(st);
            boss2.Upgrade += st => Console.WriteLine(st);
            boss2.TurnOn += st => Console.WriteLine(st);
            boss1.Techvolt = 100;//пока не включили технику
            boss1.Add(50);
            boss1.On();//после включения
            boss1.Techvolt = 100;
            boss1.Add(40);
            boss2.On();//после включения
            boss2.Techvolt = 90;
            boss2.Add(400);
            Console.ReadLine();
        }
    }
}