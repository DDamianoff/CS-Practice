using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace LAB1_1_07
{
    class Program 
    {
        
        static void ImprimirMatriz (int[,] m)
            {
                int L = 4;

                for (int i = 0; i < L; i++)
                    {
                        for (int j = 0; j < L; j++)

                            {
                                Console.Write(string.Format("{0}", m[i, j]));
                            }

                        Console.Write(Environment.NewLine);
                    }
            }

        static int[,] ObtenerMatrizRelacion (int [] v)
            {
                int[,] m = new int[4,4];

                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (v[i] == v[j])
                        {
                            m[i,j] = 1;
                        }
                        else
                        {
                            m[i,j] = 0;
                        }
                    }        
                }
                //ImprimirMatriz(m);
                return m;
            }   

        static int ObtenerTriangularSuperior (int[,] m)
            {
                int tSuperior;

                tSuperior =             (   m[0,1]  +  m[0,2]  +  m[0,3]  ) * 100 ; // valores de la primera fila como centécimas. 
                tSuperior = tSuperior + (              m[1,2]  +  m[1,3]  ) * 010 ;   // segunda fila como decenas.
                tSuperior = tSuperior + (                         m[2,3]  ) * 001 ;    // tercera fila como unidad.

                //Console.WriteLine(tSuperior);
                return tSuperior;
            }

        static void Main(string[] args) 
            {
                int[,] v = new int[2,4];    // vector principal.
                int [] va = {0,0,0,0,0};     // vector auxiliar para calcular matriz relacion y t Superior.

                string [] let = {"A","B","C","D","X"};

                string varA;
                string varB;
                string varC;
                string varD;


                int valorDeIgualdad;
                int[] aux = {0,0};
                const int n = 3;

                Console.Write("ingrese 4 valores para operar: \n");

                for (int i = 0; i < 4; i++) // asignar valores a vector
                    {
                        v[0,i] = Convert.ToInt32(Console.ReadLine());
                        va[i] = v[0,i];
                        v[1,i] = i;
                    }
                
                // ordenar mediante burbuja
                for (int i = 0; i < n - 1; i++)  
                {
                    for (int j = i + 1; j < n; j++) 
                    {
                        if (v[0,i] > v[0,j]) 
                            {
                                aux[0]      =   v[0,i];
                                aux[1]      =   v[1,i];
                                let[4]      =   let[i];
                                va[4]       =   va[i];

                                v[0,i]      =   v[0,j];
                                v[1,i]      =   v[1,j];
                                let[i]      =   let[j];
                                va[i] = va[j];

                                v[0,j]      =   aux[0];
                                v[1,j]      =   aux[1];
                                let[j]      =   let[4];
                                va[j]       =   va[4];
                            }
                    }
                }

                varA = let[0];
                varB = let[1];
                varC = let[2];
                varD = let[3];                    

                valorDeIgualdad = ObtenerTriangularSuperior(ObtenerMatrizRelacion(va));
                

                switch (valorDeIgualdad)
                {
                    case 000: // todos los valores son diferentes. Están ordenados mediante burbuja.
                        Console.WriteLine($"{varA} y {varB} son los menores, {varC} y {varD} son mayores");
                        break;
                    case 321:
                        Console.WriteLine("A,B,C y D son iguales");
                        break;
                    case 021:
                        Console.WriteLine($"{varA} es diferente y menor de {varB}, {varC} y {varD} (que son iguales)");
                        break;
                    case 210:
                        Console.WriteLine($"{varA}, {varB} y {varC} son iguales; {varD} es diferente y mayor a los anteriores");
                        break;
                    case 101:
                        Console.WriteLine($"{varA} y {varB} son iguales, menores y diferentes de {varC} y {varD}, que son iguales entre si y mayores que el par anterior");
                        break;
                    case 100:
                        Console.WriteLine($"{varA} y {varB} son iguales (y menores). {varC} y {varD} son mayores");
                        break;
                    case 010:
                        Console.WriteLine($"{varA} es menor; {varB} y {varC} son iguales; {varD} es mayor");
                        break;
                    case 001:
                        Console.WriteLine($"{varA} y {varB} son menores (diferentes entre sí); {varC} y {varD} son iguales y mayores que el par anterior");
                        break;
                    
                }

            }
   }
}
