using System;

namespace Симплекс_м
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                int r=0, c=0;//размерности матрицы и векторов
                while (true)//ввод количество вида сырья(размерности по стокам)
                {
                    try
                    {
                        Console.WriteLine("Введите количество вида сырья");
                        r = Convert.ToInt32(Console.ReadLine());
                        if (r < 2)
                        {
                            Console.WriteLine("Видов сырья должно быть не менее двух! Повторите ввод");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные!");
                    }
                }
                while (true)//ввод потребителей(размерности по столбцам)
                {
                    try
                    {
                        Console.WriteLine("Введите количество видов продукции");
                        c = Convert.ToInt32(Console.ReadLine());
                        if (c < 2)
                        {
                            Console.WriteLine("Количество видов продукции должно быть не менее двух! Повторите ввод");
                        }
                        else
                        {
                            break;
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Введены некорректные данные!");
                    }
                }
                int i = 0, j = 0;//переменные для циклов
                int[,] matrxA = new int[r, c];//таблица без запасов сырья
                Console.WriteLine("Ввод таблицы затрат на перевозку продукции:");//ввод данных в таблицу расходов ресурсов
                for (i = 0; i < matrxA.GetLength(0); i++)
                {
                    for (j = 0; j < matrxA.GetLength(1); j++)
                    {

                        while (true)
                        {
                            try
                            {
                                Console.Write($"Введите расход  {i + 1} сырья  для {j + 1} единицы продукции: ");
                                matrxA[i, j] = Convert.ToInt32(Console.ReadLine());
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Введены некорректные данные!");
                            }
                        }

                    }
                    Console.WriteLine();
                }

                Console.WriteLine("Таблица расхода сырья на единицу продукции вида:");//вывод таблицы  на экран
                for (i = 0; i < matrxA.GetLength(0); i++)
                {
                    for (j = 0; j < matrxA.GetLength(1); j++)
                    {
                        Console.Write(matrxA[i, j] + "\t");
                    }
                    Console.WriteLine();
                }
                char otv;
                int temp;//переменная для диалога с пользователем
                         //Изменение матрицы
                while (true)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write("\nХотите изменить данные о таблице?\nДа(любая клавиша)/Нет(N)\nОтвет: ");
                            otv = Convert.ToChar(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }
                    if (otv.Equals('n') || otv.Equals('т') || otv.Equals('N') || otv.Equals('Т'))
                    {
                        break;
                    }
                    else
                    {
                        Console.Write("Введите номер вида сырья, затем номер вида ресурса, который вы хотите изменить\nОтвет:\n");
                        while (true)
                        {
                            i = Convert.ToInt32(Console.ReadLine());
                            j = Convert.ToInt32(Console.ReadLine());
                            if (i < c + 1 && j < r + 1)
                            {
                                while (true)
                                {
                                    try
                                    {
                                        Console.Write("Введите новое значение: ");
                                        temp = Convert.ToInt32(Console.ReadLine());
                                        if (temp != 0)
                                        {
                                            Console.WriteLine($" Была изменена {i} {j} ячейка таблицы c {matrxA[i - 1, j - 1]} на {temp}");
                                            matrxA[i - 1, j - 1] = temp;
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine("Вы ввели нулевое значение! Повторите ввод");
                                        }
                                    }
                                    catch
                                    {
                                        Console.WriteLine("Введены некорректные данные!");
                                    }
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Введенная размерность не соответствует матрице! Повторите ввод");
                            }
                        }
                    }
                }

                Console.Clear();
                int[] m = new int[r];//вектор
               
                Console.WriteLine("Ввод данных о затратах сырья:");//ввод данных в вектор мощности поставщиков
                for (i = 0; i < m.Length; i++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"Введите затраты сырья {i + 1} вида: ");
                            m[i] = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }
                }

                Console.WriteLine("Вектор затрат сырья:");//вывод на экран
                for (i = 0; i < m.Length; i++)
                {
                    Console.WriteLine($"{m[i]} ");
                }

                int[] d = new int[r];//вектор
               


                Console.WriteLine("Введите  доход:");
                for (i = 0; i < c; i++)
                {
                    while (true)
                    {
                        try
                        {
                            Console.Write($"Введите доход продукции {i + 1} вида: ");
                            d[i] = Convert.ToInt32(Console.ReadLine());
                            break;
                        }
                        catch
                        {
                            Console.WriteLine("Введены некорректные данные!");
                        }
                    }
                }

               
                Console.WriteLine("Вектор дохода:");//вывод на экран
                for (i = 0; i < m.Length; i++)
                {
                    Console.WriteLine($"{d[i]} ");
                }


                Console.WriteLine("\nТаблица:");//вывод на экран матрицы и векторов
                Console.Write("  ");

                Console.WriteLine();
                for (i = 0; i < matrxA.GetLength(0); i++)
                {
                    Console.Write($"{m[i]} ");
                    for (j = 0; j < matrxA.GetLength(1); j++)
                    {
                        Console.Write($"{matrxA[i, j]} ");
                    }
                    Console.WriteLine();
                }
                for ( i = 0; i < d.Length; i++)
                {
                    Console.Write($"{d[i]} ");
                }

                double[,] simpleks = new double[r + 1, c + 1 + r];
                for (i = 0; i < r; i++)
                {
                    for (j = 0; j < c; j++)
                    {
                        simpleks[i, j] = matrxA[i, j];
                    }
                }
                for (i = 0; i < d.Length; i++)
                {
                    simpleks[simpleks.GetLength(0) - 1, i] = d[i];
                }
                for (i = 0; i < m.Length; i++)
                {
                    simpleks[i, simpleks.GetLength(1)-1] = m[i];
                }
                int l = 0;
                for (i = c; i < c + r; i++)
                {
                    simpleks[l++, i] = 1;
                }
                Console.WriteLine("\nCимплекс таблица:");
                for (i = 0; i < simpleks.GetLength(0); i++)
                {
                    for (j = 0; j < simpleks.GetLength(1); j++)
                    {
                        Console.Write($"{simpleks[i, j]} "); 
                    }
                    Console.WriteLine();
                }

                double[] b = new double[0];
                int  temp2 = 0;
                for ( j = 0; j < simpleks.GetLength(1) - 1; j++)
                {
                    temp = 0;
                    temp2 = 0;
                    for ( i = 0; i < simpleks.GetLength(0) - 1; i++)
                    {
                        if (simpleks[i, j] == 0)
                            temp++;
                        if (simpleks[i, j] == 1)
                            temp2++;
                    }
                    if (temp == simpleks.GetLength(0) - 2 && temp2 == 1)
                    {
                        for ( i = 0; i < simpleks.GetLength(0) - 1; i++)
                        {
                            if (simpleks[i, j] == 1)
                            {
                                temp = i;
                            }
                        }
                        Array.Resize(ref b, b.Length + 1);
                        b[b.Length - 1] = Math.Round(simpleks[temp, simpleks.GetLength(1) - 1]);
                    }
                    else
                    {
                        Array.Resize(ref b, b.Length + 1);
                        b[b.Length - 1] = 0;
                    }
                   
                }
                for ( i = 0; i < b.Length; i++)
                {
                    Console.WriteLine($"x{i + 1} = {b[i]}");
                    
                }
                Array.Resize(ref b, 0);
                int indexi = 0;
                int indexj = 0;
                Console.WriteLine($"F'={simpleks[simpleks.GetLength(0) - 1, simpleks.GetLength(1) - 1]}");
                Console.WriteLine($"F ={Math.Abs(simpleks[simpleks.GetLength(0) - 1, simpleks.GetLength(1) - 1])}");
                double max = double.MinValue;
                for (i = 0; i < simpleks.GetLength(1); i++)
                {
                    if (simpleks[simpleks.GetLength(0)-1, i]>max)
                    {
                        max = simpleks[simpleks.GetLength(0) - 1, i];
                        indexj = i;
                    }
                }
                double min = double.MaxValue;
                for (i = 0; i < simpleks.GetLength(0)- 1; i++)
                {
                    if (simpleks[i,simpleks.GetLength(1)-1]/simpleks[i, indexj] < min)
                    {
                        min = simpleks[i, simpleks.GetLength(1) - 1] / simpleks[i, indexj];
                        indexi = i;
                    }
                }
                Console.WriteLine($"{indexi+1}  {indexj+1}");

            }
        }
    }
}
