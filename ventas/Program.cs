using System;
using System.Linq;

namespace ventas
{
    class Program
    {
        static void Main(string[] args)
        {
            decimal venta;
            int semanas;
            bool validNumber, parar = false;
            String[] dias = { "LUNES", "MARTES", "MIÉRCOLES", "JUEVES", "VIERNES", "SÁBADO" };
            decimal[] ventas = new decimal[6];

            Console.Write("Por favor, indica la cantidad de semanas a evaluar: ");
            /* Verificar cantidad */
            validNumber = int.TryParse(Console.ReadLine(), out semanas);

            while (!validNumber || semanas <= 0)
            {
                Console.Write("Ingresa una cantidad válida: ");
                validNumber = int.TryParse(Console.ReadLine(), out semanas);
            }

            for (int i = 1; i <= semanas; i++)
            {
                if (parar) break;

                for (int j = 0; j < dias.Length; j++)
                {
                    Console.Write("Ingrese el valor de la venta del {0}: $ ", dias[j]);
                    validNumber = decimal.TryParse(Console.ReadLine(), out venta);

                    while (!validNumber)
                    {
                        Console.Write("Ingrese un valor válido: $ ");
                        validNumber = decimal.TryParse(Console.ReadLine(), out venta);
                    }

                    if ((dias[j] == "LUNES") && (venta == -1)) {
                        parar = true;
                        break;
                    }

                    ventas[j] = venta;
                }

                if (!parar)
                {
                    // CALCULO POR CADA SEMANA
                    decimal mayor = 0, menor = ventas[0];
                    string diaMayor, diaMenor;

                    mayor = ventas.Max();
                    menor = ventas.Min();
                    diaMayor = dias[Array.IndexOf(ventas, mayor)];
                    diaMenor = dias[Array.IndexOf(ventas, menor)];

                    // Salida de información por semana
                    Console.WriteLine("\n" + (mayor == menor ? "EMPATE" : "{0} {1}") + " " + (ventas[ventas.Length - 1] > ventas.Average() ? "SI" : "NO"), diaMayor, diaMenor);
                    Console.WriteLine();
                }

            }

            Console.WriteLine("\nFin del programa.\nPresione cualquier tecla para salir");
            Console.ReadKey();
        }
    }
}
