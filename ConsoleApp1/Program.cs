using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Trapeciya
    {
        public double function(double x, double start, double end)
        {
            if (start == end)
                return (1);
            else
                return (x - start) * 1 / (end - start);
        }
        public double to4ka_1;
        public double to4ka_2;
        public double to4ka_3;
        public double to4ka_4;
        public Trapeciya(double to4ka_1, double to4ka_2, double to4ka_3, double to4ka_4)
        {
            this.to4ka_1 = to4ka_1;
            this.to4ka_2 = to4ka_2;
            this.to4ka_3 = to4ka_3;
            this.to4ka_4 = to4ka_4;
        }
        public double znacheniya(double x)
        {
            if (x < to4ka_1)
                return (0);
            if (x < to4ka_2)
                return (function(x, to4ka_1, to4ka_2));
            if (x < to4ka_3)
                return (1);
            if (x < to4ka_4)
                return (1 - function(x, to4ka_3, to4ka_4));
            else
                return (0);
        }
        public double seredina()
        {
            return ((to4ka_1 + to4ka_4) / 2);
        }
            
    }


    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, Trapeciya>> vvod = new Dictionary<string, Dictionary<string, Trapeciya>>()
            {
                {"Температура", new Dictionary<string, Trapeciya>() {
                    {"Холодно",new Trapeciya(10,15,17.5,22.5) },
                    {"Тепло", new Trapeciya(17.5,25,25,32.5)},
                    {"Жарко", new Trapeciya(27.5,32.5,35,40)} } },
                {"Скорость", new Dictionary<string, Trapeciya>(){
                        {"Падает", new Trapeciya(-6,-6,-3.5,-1)},
                    {"Не меняется", new Trapeciya(-3,0.0,0.0,3) },
                    {"Растет", new Trapeciya(1,3.5,6,6) }
                        } }
                };
            Dictionary<string, Dictionary<string, Trapeciya>> vivod = new Dictionary<string, Dictionary<string, Trapeciya>>()
            {
                {"Поворот", new Dictionary<string, Trapeciya>() {
                    {"Против часовой",new Trapeciya(5,20,30,30) },
                    {"Не менять", new Trapeciya(-15,-5,5,15)},
                    {"По часовой", new Trapeciya(-30,-30,-20,-5)} }
                },
                };
            double a , b ;
            Console.WriteLine("Введите температуру в комнате");
            a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите скорость изменения");
            b = Convert.ToDouble(Console.ReadLine());
            object[,] Mas = new object[9,2];
            Mas[0, 0] = vivod["Поворот"]["Против часовой"];
            Mas[0, 1] = Math.Min(vvod["Температура"]["Холодно"].znacheniya(a),vvod["Скорость"]["Падает"].znacheniya(b));
            Mas[1, 0] = vivod["Поворот"]["Против часовой"];
            Mas[1, 1] = Math.Min(vvod["Температура"]["Холодно"].znacheniya(a), vvod["Скорость"]["Не меняется"].znacheniya(b));
            Mas[2, 0] = vivod["Поворот"]["Против часовой"];
            Mas[2, 1] = Math.Min(vvod["Температура"]["Холодно"].znacheniya(a), vvod["Скорость"]["Растет"].znacheniya(b));
            Mas[3, 0] = vivod["Поворот"]["Не менять"];
            Mas[3, 1] = Math.Min(vvod["Температура"]["Тепло"].znacheniya(a), vvod["Скорость"]["Падает"].znacheniya(b));
            Mas[4, 0] = vivod["Поворот"]["Не менять"];
            Mas[4, 1] = Math.Min(vvod["Температура"]["Тепло"].znacheniya(a), vvod["Скорость"]["Не меняется"].znacheniya(b));
            Mas[5, 0] = vivod["Поворот"]["Не менять"];
            Mas[5, 1] = Math.Min(vvod["Температура"]["Тепло"].znacheniya(a), vvod["Скорость"]["Растет"].znacheniya(b));
            Mas[6, 0] = vivod["Поворот"]["По часовой"];
            Mas[6, 1] = Math.Min(vvod["Температура"]["Жарко"].znacheniya(a), vvod["Скорость"]["Падает"].znacheniya(b));
            Mas[7, 0] = vivod["Поворот"]["По часовой"];
            Mas[7, 1] = Math.Min(vvod["Температура"]["Жарко"].znacheniya(a), vvod["Скорость"]["Не меняется"].znacheniya(b));
            Mas[8, 0] = vivod["Поворот"]["По часовой"];
            Mas[8, 1] = Math.Min(vvod["Температура"]["Жарко"].znacheniya(a), vvod["Скорость"]["Растет"].znacheniya(b));
            Console.ReadKey();
        }
    }
}
