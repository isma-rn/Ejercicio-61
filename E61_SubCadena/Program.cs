using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E61_SubCadena
{
    class Program
    {
        static void Main(string[] args)
        {
            bool salir = false;
            string opcion, cadena;
            int numero_1, numero_2;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("Programa que dada una cadena s, y dos números n, m imprime la subcadena que va desde n hasta m");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Ingrese la cadena:");
                cadena = Console.ReadLine().Trim();
                if (cadena.Length > 0)
                {
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ingrese en número de la posición donde quiere que empieze la subcadena");
                        if (Int32.TryParse(Console.ReadLine(), out int n1))
                        {
                            numero_1 = n1;
                            break;
                        }                            
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error, número no válido");
                        }
                    }
                    while (true)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("Ingrese en número de la posición donde quiere que termine la subcadena");
                        if (Int32.TryParse(Console.ReadLine(), out int n2))
                        {
                            numero_2 = n2;
                            break;
                        }
                            
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error, número no válido");
                        }
                    }

                    var resultado = SubCadena(cadena, numero_1, numero_2);

                    if ( resultado != null )
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Resultado:\n\t{0} --> {1}", cadena, resultado);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Error no se puede sustraer la cadena");
                    }                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error, cadena vacía");
                }

                do
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("n : nuevo, s : salir");
                    opcion = Console.ReadLine();

                    if (opcion.Equals("s"))
                    {
                        salir = true;
                        break;
                    }
                    else if (!opcion.Equals("n"))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("No se reconoce opción...");
                    }
                    else
                        break;
                } while (true);
            } while (!salir);
        }
        public static string SubCadena(String cadena, int n1, int n2)
        {
            if( Validar( cadena.Length, n1, n2) )
            {
                StringBuilder resultado = new StringBuilder();
                char[] arreglo = cadena.ToCharArray();
                n1--; n2--;
                for(int i = 0; i<cadena.Length; i++)
                    if( i>=n1 && i<=n2 )
                        resultado.Append(arreglo[i]);
                return resultado.ToString();
            }
            return null;
        }
        public static bool Validar(int size, int n1, int n2)
        {
            n1--;
            n2--;
            if (size > 0 && ( n2>=n1 ) && (n1 >= 0 && n2 < size) )
                return true;
            return false;
        }
    }
}
