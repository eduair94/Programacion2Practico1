using System.Reflection.Metadata.Ecma335;

namespace Practico1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Práctico 1");
            Console.WriteLine("Elija el ejercicio 1-8 que desea ejecutar");
            Action[] ejercicios = [Ejercicio1, Ejercicio2, Ejercicio3, Ejercicio4, Ejercicio5, Ejercicio6, Ejercicio7, Ejercicio8];
            int value;
            bool esValido;
            do
            {
                Console.Write("Ingrese número de ejercicio (1-8): ");
                string? input = Console.ReadLine();
                esValido = int.TryParse(input, out value);
                if (!esValido || value < 1 || value > 8)
                {
                    Console.WriteLine($"{input} no es un número válido, debe estar entre 1 y 8");
                }
            } while (!esValido);

            Action ejercicio = ejercicios[value - 1];
            ejercicio();
        }
        static int SolicitarNumero(string? texto)
        {
            int value;
            bool esValido;
            do
            {
                if (texto == null)
                {
                    Console.Write("Ingrese número: ");
                }
                else
                {
                    Console.Write(texto);
                }
                string? input = Console.ReadLine();
                esValido = int.TryParse(input, out value);
                if (!esValido)
                {
                    Console.WriteLine($"{input} no es un número entero válido");
                }
            } while (!esValido);
            return value;
        }

        static void SeguirIntentandoMulti(Func<int[], bool> checkFunction, int cantidadValores)
        {
            int[] valores = new int[cantidadValores];
            bool detener = false;
            while (!detener)
            {
                for (int i = 0; i < cantidadValores; i++)
                {
                    valores[i] = SolicitarNumero($"Ingrese número {i + 1}: ");
                    if (valores[i] == 0)
                    {
                        detener = true;
                        break;
                    }
                }
                if (!detener)
                {
                    detener = checkFunction(valores);
                }
            }
            Console.WriteLine("Proceso terminado");
        }

        static void SeguirIntentando(Func<int, bool> checkFunction, string? texto = null)
        {
            int value = -1;
            bool detener = false;
            while (value != 0 && !detener)
            {
                value = SolicitarNumero(texto);
                if (value != 0)
                {
                    detener = checkFunction(value);
                }
            }
            Console.WriteLine("Proceso terminado");
        }

        /**
         * Ingresar una palabra e indicar si es palíndromo(somos).
         * */
        static void Ejercicio8()
        {
            Console.WriteLine("Ingresar una palabra e indicar si es palíndromo(somos).");
            Console.Write("Ingresar palabra: ");
            string? palabra = Console.ReadLine();
            if (palabra == null)
            {
                Console.WriteLine("No se ingresó una palabra válida");
                return;
            }
            string palabraInvertida = "";
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                palabraInvertida += palabra[i];
            }
            bool esPalindromo = palabraInvertida == palabra;
            if (esPalindromo)
            {
                Console.WriteLine($"La palabra {palabra} es palíndromo");
            }
            else
            {
                Console.WriteLine($"La palabra {palabra} NO es palíndromo");
            }
        }

        /*
         * Ingresar una palabra y mostrarla en el otro sentido(Hola -> aloH).
         */
        static void Ejercicio7()
        {
            Console.WriteLine("Ingresar una palabra y mostrarla en el otro sentido(Hola -> aloH).");
            Console.Write("Ingresar palabra: ");
            string? palabra = Console.ReadLine();
            if (palabra == null)
            {
                Console.WriteLine("No se ingresó una palabra válida");
                return;
            }
            string palabraInvertida = "";
            for (int i = palabra.Length - 1; i >= 0; i--)
            {
                palabraInvertida += palabra[i];
            }
            Console.WriteLine($"La palabra invertida es {palabraInvertida}");
        }

        /*
         Ingresar una palabra y mostrar la cantidad de vocales que tiene.
        */

        static void Ejercicio6()
        {
            Console.WriteLine("Ingresar una palabra y mostrar la cantidad de vocales que tiene.");
            Console.Write("Ingresar palabra: ");
            string? palabra = Console.ReadLine();
            if (palabra == null)
            {
                Console.WriteLine("No se ingresó una palabra válida");
                return;
            }
            int cantidadVocales = 0;
            palabra = palabra.ToLower();
            foreach (char letra in palabra)
            {
                if ("aeiou".Contains(letra))
                {
                    cantidadVocales++;
                }
            }
            Console.WriteLine($"La palabra {palabra} tiene {cantidadVocales} vocales");
        }

        /*
         * Solicitar números hasta que se ingrese el 0. Se debe mostrar la suma de todos ellos.
         */
        static void Ejercicio5()
        {
            Console.WriteLine("Solicitar números hasta que se ingrese el 0. Se debe mostrar la suma de todos ellos.");
            int value = -1;
            int sum = 0;
            while (value != 0)
            {
                Console.Write($"Ingrese valor a sumar: ");
                bool check = int.TryParse(Console.ReadLine(), out value);
                if (check)
                {
                    sum += value;
                }
                else
                {
                    value = -1;
                }
            }
            Console.WriteLine($"La suma de los valores ingresados es {sum}");
        }

        /*
         * Solicitar dos números y un valor, indicar si el valor está comprendido entre los números
         */
        static void Ejercicio4()
        {
            Console.WriteLine("Solicitar dos números y un valor, indicar si el valor está comprendido entre los números");
            SeguirIntentandoMulti((int[] values) =>
            {
                int num1 = values[0];
                int num2 = values[1];
                int num3 = values[2];
                // Check if num3 is between num1 and num2
                if (num1 > num2)
                {
                    (num2, num1) = (num1, num2);
                }
                if (num1 <= num2 && num3 >= num1 && num3 <= num2)
                {
                    Console.WriteLine($"{num3} está comprendido entre {num1} y {num2}");
                }
                else
                {
                    Console.WriteLine($"{num3} NO está entre {num1} y {num2}");
                }
                return false;
            }, 3);
        }

        /*
         Ejercicio 3.
        Solicitar dos números (controlar que el primer número sea menor al segundo) y muestre todos
        los números entre los valores ingresados que sean pares. Para salir se debe ingresar 0.
        */
        static void Ejercicio3()
        {
            Console.WriteLine("Solicitar dos números (controlar que el primer número sea menor al segundo) y muestre todos\nlos números entre los valores ingresados que sean pares. Para salir se debe ingresar 0.");
            SeguirIntentandoMulti((int[] values) =>
            {
                int value1 = values[0];
                int value2 = values[1];
                if (value1 >= value2)
                {
                    Console.WriteLine("El primer valor debe ser menor que el segundo");
                    return false;
                }
                List<int> valores = [];
                for (int i = value1 + 1; i < value2; i++)
                {
                    if (i % 2 == 0)
                    {
                        valores.Add(i);
                    }
                }
                if (valores.Count > 0)
                {
                    Console.Write($"Números pares entre {value1} y {value2}: ");
                    Console.Write(string.Join(", ", valores));
                    Console.WriteLine("");
                }
                else
                {
                    Console.WriteLine($"No hay números pares entre {value1} y {value2}: ");
                }
                return false;
            }, 2);
        }

        /*
         * Ejercicio 2
         * Solicitar números hasta que ingrese el 0 (fin del ingreso).
            Se debe mostrar la tabla del mismo.
            Ejemplo ingresando el numero 2
            2 x 1 = 2
            2 x 2 = 4
            2 x 3 = 6
            Hasta el 9
         */
        static void Ejercicio2()
        {
            Console.WriteLine("Solicitar números hasta que ingrese el 0 (fin del ingreso).\nSe debe mostrar la tabla del mismo.\nEjemplo ingresando el numero 2\n2 x 1 = 2\n2 x 2 = 4\n2 x 3 = 6\nHasta el 9");
            SeguirIntentando((int value) =>
            {
                bool detener = false;
                for (int i = 1; i < 10; i++)
                {
                    Console.WriteLine($"{value} x {i} = {value * i}");
                }
                return detener;
            });
        }

        /* Ejercicio 1
         * Solicitar números hasta que ingrese el 0 (fin del ingreso).
            Se debe comparar con un número random e indicar cuando son iguales.
         */
        static void Ejercicio1()
        {
            Console.WriteLine("Solicitar números hasta que ingrese el 0 (fin del ingreso).\nSe debe comparar con un número random e indicar cuando son iguales.");
            int numeroAleatorio = 0;
            SeguirIntentando((int value) =>
            {
                Random random = new();
                numeroAleatorio = random.Next(0, 10);
                bool esElNumero = value == numeroAleatorio;
                if (esElNumero)
                {
                    Console.WriteLine("¡Adivinaste!");
                }
                else
                {
                    Console.WriteLine($"No adivinaste, el número era {numeroAleatorio}");
                }
                return esElNumero;
            });
        }
    }
}
