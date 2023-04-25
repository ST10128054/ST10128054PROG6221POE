using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    internal class Program
    {
        

        public static String[] ingrNameArr;
        public static int[] ingrQuantArr;
        public static String[] measurementArr;
        public static String[] stepDescArr;

        
        static void Main(string[] args)
        {
            Recipe rc = new Recipe();

            Console.WriteLine("Enter the number of ingredients for the recipe: ");

            rc.setNumIngr(Convert.ToInt32(Console.ReadLine()));

            ingrNameArr = new string[rc.getNumIngr()];
            ingrQuantArr = new int[rc.getNumIngr()];
            measurementArr = new string[rc.getNumIngr()];
            stepDescArr = new string[rc.getNumIngr()];

            for (int i = 0; i < rc.getNumIngr(); i++)
            {
                Console.WriteLine("Enter the name of ingredient " + i + ": ");
                rc.setIngrName(Console.ReadLine());
                ingrNameArr[i] = rc.getIngrName();
                Console.WriteLine("Enter the quantity of ingredient " + i + ": ");
                rc.setIngrQuant(Convert.ToInt32(Console.ReadLine()));
                ingrQuantArr[i] = rc.getIngrQuant();
                Console.WriteLine("Enter the unit of measurement of ingredient " + i + ": ");
                rc.setMeasurement(Console.ReadLine());
                measurementArr[i] = rc.getMeasurement();
            }

            Console.WriteLine("Enter the number of steps for the recipe: ");
            rc.setNumSteps(Convert.ToInt32(Console.ReadLine()));

            StringBuilder sb = new StringBuilder();

            for (int k = 0; k < 1; k++)
            {
                for (int j = 0; j < rc.getNumSteps(); j++)
                {
                    Console.WriteLine("Enter the description for step " + j + ": ");
                    rc.setStepDesc(Console.ReadLine());
                    sb.Append(rc.getStepDesc());
                }
                stepDescArr[k] = sb.ToString();
            }
        }
    }
}
