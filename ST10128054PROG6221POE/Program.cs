using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    internal class Program
    {
        public static int numIngr;
        public static String ingrName;
        public static int ingrQuant;
        public static String measurement;
        public static int numSteps;
        public static String stepDesc;

        public static String[] ingrNameArr;
        public static int[] ingrQuantArr;
        public static String[] measurementArr;
        public static String[] stepDescArr;
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of ingredients for the recipe: ");
            numIngr = Convert.ToInt32(Console.ReadLine());

            ingrNameArr = new string[numIngr];
            ingrQuantArr = new int[numIngr];
            measurementArr = new string[numIngr];
            stepDescArr = new string[numIngr];

            for (int i = 0; i < numIngr; i++)
            {
                Console.WriteLine("Enter the name of ingredient " + i + ": ");
                ingrName = Console.ReadLine();
                ingrNameArr[i] = ingrName;
                Console.WriteLine("Enter the quantity of ingredient " + i + ": ");
                ingrQuant = Convert.ToInt32(Console.ReadLine());
                ingrQuantArr[i] = ingrQuant;
                Console.WriteLine("Enter the unit of measurement of ingredient " + i + ": ");
                measurement = Console.ReadLine();
                measurementArr[i] = measurement;
            }

            Console.WriteLine("Enter the number of steps for the recipe: ");
            numSteps = Convert.ToInt32(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < 1; k++)
            {
                for (int j = 0; j < numSteps; j++)
                {
                    Console.WriteLine("Enter the description for step " + j + ": ");
                    stepDesc = Console.ReadLine();
                    sb.Append(stepDesc);
                }
                stepDescArr[k] = sb.ToString();
            }
            
            
        }
    }
}
