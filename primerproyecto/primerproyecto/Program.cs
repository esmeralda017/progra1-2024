using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miPrimerProyecto
{
    internal class Conversores
    {
        double[][] valores = new double[][] {
            new double[] {},//vacio solo para comenzar en 1
            new double[] {0,1,7.73,24.76,36.80, 517.04,8.75,0.9},//monedas
            new double[] {0,1,100,39.37,3.28084,1.196308,1.09361,0.001},//longitud
            new double[] {0,1,453.592,16,0.453592, 0.000446429}, //masa
            new double[] {0,1,86400, 1440, 24, 0.142857, 0.032876643423, 0.0027397232876831892345}//tiempo
        };
        public String[][] etiquetas = new String[][]{
            new String[] {},//vacio solo para comenzar en 1
            new string[] {"", "Dolar","Quetzal","Lempira","Cordoba","Colon CR","Colon SV", "Euro"},//monedas
            new string[] {"", "Metro","Cm","Pulgada","Pie","Vara","Yarda","Km"},//longitud
            new string[] {"", "Libra","Gramo","Onza","Kilogramo","Tonelada Larga"},//Masa
            new string[] {"", "Dia","Sg","Min","Horas","Semana","Mes","Año"}
        };
        public double convertir(int de, int a, double cantidad, int opcion)
        {
            return valores[opcion][a] / valores[opcion][de] * cantidad;
        }
    }
}
60 changes: 28 additions & 32 deletions60
miPrimerProyecto/miPrimerProyecto/Program.cs
Original file line number	Diff line number	Diff line change
@@ -8,41 +8,37 @@
namespace miPrimerProyecto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Uso de funciones...
            //ejercicio encontrar la media aritmetica y la desviacion tipica de una seria de numeros.
            Conversores objConversor = new Conversores();
            String continuar = "s";
            while (continuar == "s")
            {
                Console.WriteLine("::.. MENU ..::");
                Console.WriteLine("1. Monedas.");
                Console.WriteLine("2. Longitud.");
                Console.WriteLine("3. Masa.");
                Console.WriteLine("4. Tiempo.");
                Console.WriteLine("0. Salir");
                Console.Write("Opcion: ");
                int opcion = int.Parse(Console.ReadLine());

                if (opcion == 0)
                {
                    continuar = "n";
                }
                else
                {
                    Console.Clear();
                    for (int i = 1; i < objConversor.etiquetas[opcion].Length; i++)
                    {
                        Console.WriteLine("{0}. {1}", i, objConversor.etiquetas[opcion][i]);
                    }
                    Console.Write("De: ");
                    int de = int.Parse(Console.ReadLine());

                    Console.Write("Ingrese la serie de numeros separados por comas: ");
                    String serie = Console.ReadLine();
                    String[] numeros = serie.Split(',');

                    Console.WriteLine("La media aritmetica es: {0}, y la desviacion tipica es: {1}, la media armonica es: {2}",
                        media(numeros), tipica(numeros), armonica(numeros));
                    Console.Write("A: ");
                    int a = int.Parse(Console.ReadLine());

                    Console.ReadLine();
                }
                static double media(string[] serie)
                {
                    double media = 0;
                    foreach (string num in serie)
                    {
                        media += int.Parse(num);
                    }
                    return media / serie.Length;
                }
                static double tipica(string[] serie)
                {
                    double tipica = 0,
                            m = media(serie);
                    foreach (string num in serie)
                    {
                        tipica += Math.Pow(int.Parse(num) - m, 2);
                    }
                    tipica = Math.Sqrt(tipica / serie.Length);
                    return Math.Round(tipica, 2);
                }
                static double armonica(string[] serie)
                {
                    double armonica = 0;
                    foreach (string num in serie)
                    {
                        armonica += (1.0 / double.Parse(num));
                        Console.Write("Cantidad: ");
                        double cantidad = double.Parse(Console.ReadLine());

                        Console.WriteLine("{0} \n", objConversor.convertir(de, a, cantidad, opcion));
                    }
                }
                armonica = serie.Length / armonica;
                return Math.Round(armonica, 2);
            }
        }
    }