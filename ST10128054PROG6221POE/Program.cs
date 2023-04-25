using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    internal class Program
    {
        

        //public static String[] ingrNameArr;
        //public static int[] ingrQuantArr;
        //public static String[] measurementArr;
        //public static String[] stepDescArr;

        public static ArrayList ingrNameArr = new ArrayList();
        public static ArrayList ingrQuantArr = new ArrayList();
        public static ArrayList measurementArr = new ArrayList();
        public static ArrayList stepDescArr = new ArrayList();


        static void Main(string[] args)
        {
            Recipe rc = new Recipe();

            Console.WriteLine("Enter the number of ingredients for the recipe: ");

            rc.NumIngr = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < rc.NumIngr; i++)
            {
                Console.WriteLine("Enter the name of ingredient " + (i + 1) + ": ");
                rc.IngrName = Console.ReadLine();
                ingrNameArr.Add(rc.IngrName);
                Console.WriteLine("Enter the quantity of ingredient " + (i + 1) + ": ");
                rc.IngrQuant = Convert.ToInt32(Console.ReadLine());
                ingrQuantArr.Add(rc.IngrQuant); 
                Console.WriteLine("Enter the unit of measurement of ingredient " + (i + 1) + ": ");
                rc.Measurement = Console.ReadLine();
                measurementArr.Add(rc.Measurement);
            }

            Console.WriteLine("Enter the number of steps for the recipe: ");
            rc.NumSteps = Convert.ToInt32(Console.ReadLine());

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < 1; k++)
            {
                for (int j = 0; j < rc.NumSteps; j++)
                {
                    Console.WriteLine("Enter the description for step " + (j + 1) + ": ");
                    rc.StepDesc = Console.ReadLine();
                    sb.Append(rc.StepDesc + "\n");
                }
                stepDescArr[k] = sb.ToString();
            }

            Console.ReadLine();
        }
    }
}
