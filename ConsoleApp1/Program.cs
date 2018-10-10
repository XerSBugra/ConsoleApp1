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
                {"Скорость авто", new Dictionary<string, Trapeciya>() {
                    {"Медленно",new Trapeciya(10,20,40,50) },
                    {"Нормально", new Trapeciya(45,60,80,90)},
                    {"Быстро", new Trapeciya(80,95,110,120)} } },
                {"Вероятность камеры на дороге", new Dictionary<string, Trapeciya>(){
                        {"Низкая", new Trapeciya(5,10,25,30)},
                    {"Средняя", new Trapeciya(25,35,50,60) },
                    {"Высокая", new Trapeciya(50,65,95,100) }
                        } }
                };
            Dictionary<string, Dictionary<string, Trapeciya>> vivod = new Dictionary<string, Dictionary<string, Trapeciya>>()
            {
                {"Вероятность прихода штрафа", new Dictionary<string, Trapeciya>() {
                    {"Не придёт",new Trapeciya(5,10,30,40) },
                    {"Возможно придёт", new Trapeciya(30,50,50,70)},
                    {"Точно придёт", new Trapeciya(50,70,95,100)} }
                },
                };
            double a , b ;
            Console.Write("Введите вашу скорость:");
            a = Convert.ToDouble(Console.ReadLine());
            Console.Write("Введите вероятность камеры на дороге:");
            b = Convert.ToDouble(Console.ReadLine());
            dynamic[,] Mas = new dynamic[9,2];
            Mas[0, 0] = vivod["Вероятность прихода штрафа"]["Не придёт"];
            Mas[0, 1] = Math.Min(vvod["Скорость авто"]["Медленно"].znacheniya(a),vvod["Вероятность камеры на дороге"]["Низкая"].znacheniya(b));
            Mas[1, 0] = vivod["Вероятность прихода штрафа"]["Не придёт"];
            Mas[1, 1] = Math.Min(vvod["Скорость авто"]["Медленно"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Средняя"].znacheniya(b));
            Mas[2, 0] = vivod["Вероятность прихода штрафа"]["Не придёт"];
            Mas[2, 1] = Math.Min(vvod["Скорость авто"]["Медленно"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Высокая"].znacheniya(b));
            Mas[3, 0] = vivod["Вероятность прихода штрафа"]["Возможно придёт"];
            Mas[3, 1] = Math.Min(vvod["Скорость авто"]["Нормально"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Низкая"].znacheniya(b));
            Mas[4, 0] = vivod["Вероятность прихода штрафа"]["Возможно придёт"];
            Mas[4, 1] = Math.Min(vvod["Скорость авто"]["Нормально"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Средняя"].znacheniya(b));
            Mas[5, 0] = vivod["Вероятность прихода штрафа"]["Возможно придёт"];
            Mas[5, 1] = Math.Min(vvod["Скорость авто"]["Нормально"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Высокая"].znacheniya(b));
            Mas[6, 0] = vivod["Вероятность прихода штрафа"]["Точно придёт"];
            Mas[6, 1] = Math.Min(vvod["Скорость авто"]["Быстро"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Низкая"].znacheniya(b));
            Mas[7, 0] = vivod["Вероятность прихода штрафа"]["Точно придёт"];
            Mas[7, 1] = Math.Min(vvod["Скорость авто"]["Быстро"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Средняя"].znacheniya(b));
            Mas[8, 0] = vivod["Вероятность прихода штрафа"]["Точно придёт"];
            Mas[8, 1] = Math.Min(vvod["Скорость авто"]["Быстро"].znacheniya(a), vvod["Вероятность камеры на дороге"]["Высокая"].znacheniya(b));
            double chisl = 0, znam = 0;
            for (int i=0;i<Mas.GetLength(0);i++)
            {
                chisl += Mas[i,0].seredina()*Mas[i,1];
                znam += Mas[i, 1];
            }
            double result = chisl / znam;
            Console.Write($"Вероятность прихода штрафа = {znam}");
            Console.ReadKey();
        }
    }
}
