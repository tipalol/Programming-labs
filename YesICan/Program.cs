//
//  Point.cs
//  Point
//
//  Created by Сорокин Дмитрий on 22/05/2019.
//  Copyright © 2019 Сорокин Дмитрий. All rights reserved.
//
using System;

namespace YesICan {
    class MainClass {
        public static void Main(string[] args) {
            var k = 10;
            //Отрезок
            var a = 0.1d;
            var b = 0.8d;
            //Шаг
            var dx = (b - a) / k;
            //Аргумент
            var x = a;
            //Для точности
            var e = 1e-4;



            Console.WriteLine("Разложение функции в ряд");

            for (int i = 0; i <= k; i++)
            {
                Console.Write($"X = {x}, SN  = {x*Math.Atan(x)-Math.Log(Math.Sqrt(1+x*x))}");

                double x2 = -x * x;
                var xn = -1d;
                var f1 = 0d;
                var f2 = 0d;
                var el = 0d;

                int n2 = 0;
                int n = 10;

                do
                {
                    xn *= x2;
                    n2 += 2;
                    el = xn / n2 / (n2 - 1);
                    if (n-- != 0) f1 += el;
                    if (el < -e || el > e) f2 += el;
                } while (n != 0 || el < -e || el > e);
                Console.WriteLine($" SE = {f1} Y = {f2}");
                x += dx;
            }

            Console.WriteLine("Спасибо!");
        }
    }
}
