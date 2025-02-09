﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades_2019;
namespace TP_02_2018
{
    class Program
    {
        static void Main(string[] args)
        {
            // Configuración de la pantalla
            Console.SetWindowPosition(0, 0);
            Console.SetWindowSize(Console.LargestWindowWidth / 2, Console.LargestWindowHeight - 2);

            // Nombre del alumno
            Console.Title = "Ignacio Rolón - 2°D";
            
            Changuito changoDeCompras = new Changuito(6);

            Dulce dulce1 = new Dulce(Producto.EMarca.Sancor, "ASD012", ConsoleColor.Black);
            Dulce dulce2 = new Dulce(Producto.EMarca.Ilolay, "ASD913", ConsoleColor.Red);
            Leche leche1 = new Leche(Producto.EMarca.Pepsico, "HJK789", ConsoleColor.White);
            Leche leche2 = new Leche(Producto.EMarca.Serenisima, "IOP852", ConsoleColor.Blue, Leche.ETipo.Descremada);
            Snacks snack1 = new Snacks(Producto.EMarca.Campagnola, "QWE968", ConsoleColor.Gray);
            Snacks snack2 = new Snacks(Producto.EMarca.Arcor, "TYU426", ConsoleColor.DarkBlue);
            Snacks snack3 = new Snacks(Producto.EMarca.Sancor, "IOP852", ConsoleColor.Green);
            Snacks snack4 = new Snacks(Producto.EMarca.Sancor, "TRE321", ConsoleColor.Green);

            // Agrego 8 ítems (los últimos 2 no deberían poder agregarse ni el leche1 repetido) y muestro
            changoDeCompras += dulce1;
            changoDeCompras += dulce2;
            changoDeCompras += leche1;
            changoDeCompras += leche1;
            changoDeCompras += leche2;
            changoDeCompras += snack1;
            changoDeCompras += snack2;
            changoDeCompras += snack3;
            changoDeCompras += snack4;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Quito un item y muestro
            changoDeCompras -= dulce1;

            Console.WriteLine(changoDeCompras.ToString());
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Dulces
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Dulce));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Leches
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Leche));
            Console.WriteLine("<-----------PRESIONE UNA TECLA PARA CONTINUAR----------->");
            Console.ReadKey();
            Console.Clear();

            // Muestro solo Snacks
            Console.WriteLine(Changuito.Mostrar(changoDeCompras, Changuito.ETipo.Snacks));
            Console.WriteLine("<-------------PRESIONE UNA TECLA PARA SALIR------------->");
            Console.ReadKey();
        }
    }
}
