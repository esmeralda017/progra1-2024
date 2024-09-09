using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miPrimerProyecto
{
    internal class Conversores
    {
        internal class Program
        {
            //filadelfo antonio gutierrez orellana USSS011624
            //Olimpia esmeralda Rivas Vanegas usss017124
            static void Main(string[] args)
            {
                Console.WriteLine("Conversor de Área (Superficie)");
                Console.WriteLine("-------------------------------");

                Console.WriteLine("Seleccione la unidad de área de origen:");
                Console.WriteLine("a. Pie Cuadrado");
                Console.WriteLine("b. Vara Cuadrada");
                Console.WriteLine("c. Yarda Cuadrada");
                Console.WriteLine("d. Metro Cuadrado");
                Console.WriteLine("e. Tareas");
                Console.WriteLine("f. Manzana");
                Console.WriteLine("g. Hectárea");

                int from = int.Parse(Console.ReadLine());

                Console.WriteLine("Seleccione la unidad de área de destino:");
                Console.WriteLine("a. Pie Cuadrado");
                Console.WriteLine("b. Vara Cuadrada");
                Console.WriteLine("c. Yarda Cuadrada");
                Console.WriteLine("d. Metro Cuadrado");
                Console.WriteLine("e. Tareas");
                Console.WriteLine("f. Manzana");
                Console.WriteLine("g. Hectárea");

                int to = int.Parse(Console.ReadLine());

                Console.WriteLine("Ingrese la cantidad a convertir:");
                double amount = double.Parse(Console.ReadLine());

                double result = ConvertirArea(from, to, amount);

                Console.WriteLine($"Resultado: {result}");

                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }

            static double ConvertirArea(int from, int to, double amount)
            {
                double[,] areaConversions = {
                { 1.0, 0.111111, 0.027778, 0.092903, 0.00064516, 0.00015625, 0.000001 }, // Pie Cuadrado
                { 9.0, 1.0, 0.25, 0.836127, 0.00580625, 0.00140625, 0.000009 }, // Vara Cuadrada
                { 36.0, 4.0, 1.0, 3.34451, 0.023225, 0.005625, 0.000036 }, // Yarda Cuadrada
                { 10.7639, 1.19599, 0.298997, 1.0, 0.00694444, 0.00168403, 0.00001 }, // Metro Cuadrado
                { 1550.0, 172.222, 43.0556, 144.0, 1.0, 0.242188, 0.0015 }, // Tareas
                { 6400.0, 711.111, 177.778, 589.824, 4.13223, 1.0, 0.00625 }, // Manzana
                { 107639, 11959.9, 2989.97, 10000.0, 66.6667, 16.0625, 1.0 } // Hectárea
            };

                return amount * areaConversions[from, to];
            }
        }
    }
}