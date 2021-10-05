using System;

namespace _2_sangucheria
{
    class Program
    {   
        static void DesplegarMenu()
            {
                Console.Clear();
                Console.WriteLine
                    (
                        "### seleccione el producto a ingresar ###\n"
                        + "1 - sanguche de milanesa \n"
                        + "2 - hamburguesa \n"
                        + "3 - sanguche de lomito \n"
                        + "0 - finalizar ingreso de datos"
                    );
            }

        static double CalcularPorcentaje(double total, double producto)
        {
            double resultado = (producto * 100) / total;
            return resultado;
        }

        static void MostrarVendidos(int milanesas, int hamburguesas, int lomitos)
        {
            Console.Clear();
            Console.WriteLine("VENTAS TOTALES DE CADA TIPO");

            Console.WriteLine
                (
                     $"Milanesas vendidas: {milanesas} \n"
                    +$"Hamburguesas vendidadas: {hamburguesas} \n"
                    +$"Lomitos vendidos: {lomitos} \n"
                );
        }

        static void MostrarTotal(int milanesas, int hamburguesas, int lomitos)
        {
            const double precio1 = 350; // milanesa
            const double precio2 = 250; // hamburguesa
            const double precio3 = 400; // lomito

            double total = (milanesas*precio1) + (hamburguesas*precio2) + (lomitos*precio3);

            double porcentajeMilanesas = CalcularPorcentaje(total, precio1*milanesas);
            double porcentajeHamburguesas = CalcularPorcentaje(total, precio2*hamburguesas);
            double porcentajeLomitos = CalcularPorcentaje(total, precio3*lomitos);

            Console.Clear();

            Console.WriteLine($"TOTAL DE VENTAS: {total}\n");

            Console.WriteLine("CONTRIBUCION DE LOS PRODUCTOS AL TOTAL\n");
            Console.WriteLine($"Milanesas: {porcentajeMilanesas}%");
            Console.WriteLine($"Hambuerguesas: {porcentajeHamburguesas}%");
            Console.WriteLine($"lomitos: {porcentajeLomitos}%");
        }
        static void Main(string[] args)
        {
            int cantidad1 = 0; // milanesa
            int cantidad2 = 0; // hamburguesa
            int cantidad3 = 0; // lomito



            int opcion = 1; // para que ingrese al ciclo
            int ingresoCantidad = 0;

            while (opcion != 0)
            {
                DesplegarMenu();
                opcion = Convert.ToInt32(Console.ReadLine());
                
                if (opcion == 0)
                {
                    break;
                }

                Console.WriteLine("ingrese la cantidad de ventas del producto seleccionado");
                ingresoCantidad = Convert.ToInt32(Console.ReadLine());

                switch (opcion)
                {
                    case 1: // milanga
                        cantidad1 += ingresoCantidad;
                        break;

                    case 2: // hamburguesa
                        cantidad2 += ingresoCantidad;
                        break;

                    case 3: // lomito
                        cantidad3 += ingresoCantidad;
                        break;

                    case 0: // milanga
                        {} // para evitar que si se pone 0 ponga error.
                        break;

                    default:
                        Console.WriteLine("Valor errÃ³neo");
                        
                        break;
                }
            }

            MostrarVendidos(cantidad1,cantidad2,cantidad3);

            Console.WriteLine("\nPulse cualquier tecla para continuar");
            Console.ReadKey();

            MostrarTotal(cantidad1,cantidad2,cantidad3);

            Console.WriteLine("\nPulse cualquier tecla para finalizar");
            Console.ReadKey();

        }
    }
}
