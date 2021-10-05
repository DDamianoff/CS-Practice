using System;
using System.Linq;

namespace test_space
{
    class Program
    {
        public const int columnas = 100-1; // alterando este valor se puede expandir o reducir el tamaño total del programa
        public const float valor_viaje = 50;
        static public void DesplegarMenu() // desplegar el enu.

        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n          MENU");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("(1) - REGISTRAR VIAJE");
            Console.WriteLine("(2) - INGRESAR DINERO");
            Console.WriteLine("(3) - TRANSFERIR SALDO");
            Console.WriteLine("(4) - PASAJERO MAS FRECUENTE");
            Console.WriteLine("(5) - SALDO TOTAL");
            Console.WriteLine("(6) - MOSTRAR SALDO");
            Console.WriteLine("(0) - SALIR \n");

            Console.WriteLine($"INFORMACION: \nTarjetas registradas: {columnas+1} \nValor de viaje actual: {valor_viaje}\n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        static public void InicializarMatriz(float[,] mat) //iniciar matriz con todos sus valores en 0.
        {
            for (int f = 0; f < mat.GetLength(0); f++)
            {
                for (int c = 0; c < mat.GetLength(1); c++)
                {
                    mat[f, c] = 0;
                }
            }
        }

        static public void AsignarDatos( int f,int min, int max, float[,] m) //asignar valores a la matriz
            {
                var _random = new Random();

                for (int i = 0; i < columnas; i++) 
                    {
                        m[f,i] = _random.Next(min, max+1);
                    }
            }

        static public int ObtenerOpcion()
            {   
                int x = 0;
                while (true)
                    {
                        Console.Write("Ingrese un valor: ");
                        x = Convert.ToInt32(Console.ReadLine());
                        if ( !(x > 6 || x < 0) ) // salir del ciclo si la opcion ingresada es correcta.
                            {
                                break;
                            }
                        else 
                            {
                                Console.Clear();
                                DesplegarMenu();
                                Console.WriteLine("se espera un valor diferente");
                            }
                    }
                return x;
            }

        static public void RegistrarViaje(float[,] m)
            {
                int usuario;

                Console.WriteLine($"REGISTRAR SALDO           Tarjetas diponibles: 0 - {columnas}");
                Console.Write("\nNro de tarjeta: ");

                usuario = Convert.ToInt32(Console.ReadLine());
                m[0,usuario] -= valor_viaje;
                m[1,usuario]++;

                Console.Clear();
                Console.WriteLine($"HECHO!\nNuevo saldo: {m[0,usuario]}");
            }

        static public void CargarSaldo(float[,] m)
            {
                int usuario;
                float cantidad;

                Console.WriteLine($"CARGAR SALDO            Tarjetas diponibles: 0 - {columnas}");

                Console.Write("\nNro de tarjeta: ");
                usuario = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nCantidad a cargar: ");
                cantidad = float.Parse(Console.ReadLine());


                m[0,usuario] += cantidad;

                Console.Clear();
                Console.WriteLine($"HECHO!\nNuevo saldo: {m[0,usuario]}");
            }

        static public void TransferirSaldo(float[,] m)
            {
                int usuario1;
                int usuario2;
                float cantidad;

                Console.WriteLine($"TRANSFERENCIA DE SALDO ENTRE CUENTAS         Tarjetas diponibles: 0 - {columnas}");

                Console.Write("\nNro de tarjeta a sustraer: ");
                usuario1 = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nNro de tarjeta a añadir: ");
                usuario2 = Convert.ToInt32(Console.ReadLine());

                Console.Write("\nCantidad a transferir: ");
                cantidad = float.Parse(Console.ReadLine());

                m[0,usuario1] -= cantidad;
                m[0,usuario2] += cantidad;

                Console.Clear();
                Console.WriteLine($"HECHO!\nNuevo saldo de {usuario1}: {m[0,usuario1]}\nNuevo saldo de {usuario2}: {m[0,usuario2]}");
            }

        static public void ObtenerUsuarioFrecuente(float[,] m)
            {
                float[] aux = new float[columnas];
                int mayorElemento;

                for (int i = 0; i < columnas-1; i++) 
                    {
                        aux[i] = m[1,i];  // clonar valores de pasajeros.
                    }

                mayorElemento = aux.ToList().IndexOf(aux.Max());

                Console.WriteLine($"El usuario mas frecuente es el N {mayorElemento} con {m[1,mayorElemento]} viajes");
            }

        static public void ObtenerTotal(float[,] m)
            {
                float total = 0;

                Console.WriteLine($"TOTAL DE SALDOS");

                for (int i = 0; i < columnas; i++)
                    {
                        total = total + m[0,i];
                    }
                
                Console.WriteLine($"El total de todos los saldos es: {total}");
            }

        static public void ObtenerSaldo(float[,] m)
            {
                int usuario;

                Console.WriteLine($"CONSULTAR SALDO            Tarjetas diponibles: 0 - {columnas}");

                Console.Write("\nNro de tarjeta: ");
                usuario = Convert.ToInt32(Console.ReadLine());

                Console.Clear();
                Console.WriteLine($"\nSaldo actual: {m[0,usuario]}   \nViajes realizados: {m[1,usuario]}");
            }


        static public void Main(string[] args)
        {

            float[,] datos = new float[2,columnas];
            int opcion = 1;

            InicializarMatriz(datos);

            AsignarDatos(0,50,250,datos);  // asignar los valores correspondientes a los saldos.
            AsignarDatos(1,1,7,datos);     // asignar los valores correspondientes a los viajes.
            
            while (opcion != 0)
                {
                    Console.Clear();

                    DesplegarMenu();
                    opcion = ObtenerOpcion();

                    Console.Clear();

                    switch (opcion)
                    {
                        case 1: // registrar viaje
                            RegistrarViaje(datos);
                            break;

                        case 2: // cargar saldo
                            CargarSaldo(datos);
                            break;

                        case 3: // transferir saldo
                            TransferirSaldo(datos);
                            break;

                        case 4: // pasajero mas frecuente
                            ObtenerUsuarioFrecuente(datos);
                            break;

                        case 5: // saldo total
                            ObtenerTotal(datos);
                            break;

                        case 6: // saldo particular
                            ObtenerSaldo(datos);
                            break;
                    }
                    
                    Console.WriteLine("\n[ pulse cualquier tecla para continuar ]");
                    Console.ReadKey();

                }
        }
    }
}
