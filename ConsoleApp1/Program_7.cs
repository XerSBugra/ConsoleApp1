using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laba2
{
    class Program
    {
        class inp
        {
            double[] term1;
            double[] term2;
            double[] term3;

            public inp(double[] a, double[] b, double[] c)
            {
                term1 = a;
                term2 = b;
                term3 = c;
            }

            public static double[] Res(inp ling, double x)
            {
                double[] result = new double[3];

                if (x <= ling.term1[1])
                {
                    if (x > ling.term1[0])
                        result[0] = (x - ling.term1[0]) / (ling.term1[1] - ling.term1[0]);
                    else
                        result[0] = 1;
                }
                else
                    result[0] = 0;

                if (x >= ling.term2[0] && x <= ling.term2[3])
                {
                    if (x < ling.term2[1])
                        result[1] = (x - ling.term2[0]) / (ling.term2[1] - ling.term2[0]);
                    else if (x <= ling.term2[2])
                        result[1] = 1;
                    else
                        result[1] = (x - ling.term2[2]) / (ling.term2[3] - ling.term2[2]);
                }
                else
                    result[1] = 0;

                if (x >= ling.term3[0])
                {
                    if (x < ling.term3[1])
                        result[2] = (x - ling.term3[0]) / (ling.term3[1] - ling.term3[0]);
                    else
                        result[2] = 1;
                }
                else
                    result[2] = 0;

                return result;
            }

            public void print(string a, string b, string c)
            {
                Console.WriteLine("Терм " + a + ":");
                Console.Write("[ ");
                foreach (double i in term1)
                    Console.Write("{0}; ", i);
                Console.Write("]");
                Console.WriteLine("\nТерм " + b + ":");
                Console.Write("[ ");
                foreach (double i in term2)
                    Console.Write("{0}; ", i);
                Console.Write("]");
                Console.WriteLine("\nТерм " + c + ":");
                Console.Write("[ ");
                foreach (double i in term3)
                    Console.Write("{0}; ", i);
                Console.Write("]\n");
            }
        }

        class outp
        {
            double[] term1;
            double[] term2;
            double[] term3;
            public double[] term_half = new double[3];

            public outp(double[] a, double[] b, double[] c)
            {
                term1 = a;
                term2 = b;
                term3 = c;

                term_half[0] = a[0] + ((a[2] - a[0]) / 2);
                term_half[1] = b[0] + ((b[3] - b[0]) / 2);
                term_half[2] = c[0] + ((c[2] - c[0]) / 2);
            }
            public void print(string a, string b, string c)
            {
                Console.WriteLine("Терм " + a + ":");
                Console.Write("[ ");
                foreach (double i in term1)
                    Console.Write("{0}; ", i);
                Console.Write("]");
                Console.WriteLine("\nТерм " + b + ":");
                Console.Write("[ ");
                foreach (double i in term2)
                    Console.Write("{0}; ", i);
                Console.Write("]");
                Console.WriteLine("\nТерм " + c + ":");
                Console.Write("[ ");
                foreach (double i in term3)
                    Console.Write("{0}; ", i);
                Console.Write("]\n");
            }
        }


        static void Main(string[] args)
        {
            inp F = new inp(new double[] { 1, 3 }, new double[] { 2, 3, 4, 5 }, new double[] { 4, 6 });
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Лингвистическая переменная - Количество пар");
            Console.WriteLine(new string('-', 50));
            F.print("Мало", "Золотая середина", "Много");
            Console.WriteLine(new string('=', 50));


            inp C = new inp(new double[] { 0, 30 }, new double[] { 25, 50, 60, 80 }, new double[] { 75, 100 });
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Лингвистическая переменная - Настроение");
            Console.WriteLine(new string('-', 50));
            C.print("Говно", "Спасибо,что живой", "Заряжен");
            Console.WriteLine(new string('=', 50));


            outp WB = new outp(new double[] { 0, 0.3, 0.5 }, new double[] { 0.25, 0.4, 0.65, 0.8 }, new double[] { 0.6, 0.8, 1 });
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Лингвистическая переменная - Возможность пойти на пары");
            Console.WriteLine(new string('-', 50));
            WB.print("Нет", "Посмотрю еще", "Да");
            Console.WriteLine(new string('=', 50));

            double[] f = inp.Res(F,5);
            double[] c = inp.Res(C, 20);

            Console.WriteLine();
            Console.WriteLine("/*" + new string('-', 48) + "*/");
            Console.WriteLine("Вам ничего вводить не нужно - мы сделали это за Вас!");
            Console.WriteLine("/*" + new string('-', 48) + "*/");
            Console.WriteLine();

            Console.WriteLine("Пусть известны Количество прр 3 и Настроение 28 %.\nКакова вероятность приобюртения процессора? ");

            double[] a = new double[9];
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    a[3 * i + j] = Math.Min(f[i], c[j]);

            double SUM = 0;
            foreach (double i in a)
                SUM += i;

            double resultat = (a[0] * WB.term_half[1] +
                                a[1] * WB.term_half[0] +
                                a[2] * WB.term_half[0] +

                                a[3] * WB.term_half[2] +
                                a[4] * WB.term_half[1] +
                                a[5] * WB.term_half[0] +

                                a[6] * WB.term_half[2] +
                                a[7] * WB.term_half[2] +
                                a[8] * WB.term_half[1]) / SUM;

            Console.WriteLine("\nОтвет: {0}", resultat);
            Console.ReadLine();
        }
    }

}
