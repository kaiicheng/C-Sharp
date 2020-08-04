using Microsoft.VisualBasic.CompilerServices;
using System;

namespace ContagionControl
{
    class Program
    {
        static void Main(string[] args)
        {
            // Receive number of citizens
            Console.WriteLine("Enter number or citizens:");
            int g = int.Parse(Console.ReadLine());

            // Create array in the size of g
            int[] A = new int[g];
            int[] B = new int[g];

            //Set the beginning number of array to be 0
            A[0] = 0;
            B[0] = 0;

            //Set A array
            for (int i = 0; i < g; i++)
            {
                A[i] = A[i] + i; //製造出等差數列0-15!!!
            }

            //Set B array
            for (int i = 0; i < g; i++)
            {
                B[i] = B[i] + i; //製造出數列0-15!!!
            }

            //Make B array random (Not Repeated)
            Random rng = new Random(); //Random Number Generator
            for (int i = 0; i < g; i++)
            {
                //B[i] = rng.Next(0, A.Length); //產生長度為A的亂數列(重複)!!!
                int j = rng.Next(i + 1); //***+1???
                int tmp = B[i];
                B[i] = B[j];
                B[j] = tmp;
            }

            //Print Id and 0-15
            Console.Write("       Id");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write("{0, 4}", A[i]);
            }
            Console.WriteLine();

            //Print Contactee and random number 0-15
            Console.Write("Contactee");
            for (int i = 0; i < g; i++)
            {
                Console.Write("{0, 4}", B[i]);
            }
            Console.WriteLine();

            // Ask question to get the id of infected citizen
            Console.WriteLine("---------------------");
            Console.WriteLine("Enter id of infected citizen:");
            int inf = int.Parse(Console.ReadLine());
            int iso = inf;

            // Give the id of citizen who are to be self-isolated in the following 14 days:
            Console.WriteLine("These citizens are to be self-isolated in the following 14 days:");
            Console.Write("{0,4}", inf);
            while (B[iso]!= inf)
            {
                Console.Write("{0,4}", B[iso]);
                iso = B[iso];
            }

        }
    }
}
