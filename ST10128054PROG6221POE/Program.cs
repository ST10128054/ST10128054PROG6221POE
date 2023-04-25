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
        public static ArrayList ingrNameArr = new ArrayList();
        public static ArrayList ingrQuantArr = new ArrayList();
        public static ArrayList scaledQuantArr = new ArrayList();
        public static ArrayList measurementArr = new ArrayList();
        public static ArrayList stepDescArr = new ArrayList();
        public static int mainMenu;


        static void Main(string[] args)
        {
            Recipe rc = new Recipe();

            Console.WriteLine("Recipe App\n" + 
                              "************************************\n\n" + 
                              "1) Enter ingredients and steps.\n" +
                              "2) Scale measurements.\n" +
                              "3) Display recipe.\n" +
                              "4) Exit.");
            mainMenu = Convert.ToInt32(Console.ReadLine());

            while(mainMenu != 4)
            {
                if (mainMenu == 1)
                {

                }
                else if (mainMenu == 2)
                {

                }
                else if (mainMenu == 3)
                {

                }
            }

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


            for (int j = 0; j < rc.NumSteps; j++)
            {
                Console.WriteLine("Enter the description for step " + (j + 1) + ": ");
                rc.StepDesc = Console.ReadLine();
                sb.Append("Step " + (j + 1) + ": " + rc.StepDesc + "\n");
            }
            stepDescArr.Add(sb.ToString());

            Console.WriteLine("Do you want to alter the quantities of the ingredients?\n" +
                              "1) Half\n" +
                              "2) Double\n" +
                              "3) Triple\n" +
                              "4) None");
            rc.Alter = Convert.ToInt32(Console.ReadLine());

            if (rc.Alter == 1)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 0.5;
                    scaledQuantArr.Add(rc.ScaledQuant);
                }  
            }
            else if (rc.Alter == 2)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 2;
                    scaledQuantArr.Add(rc.ScaledQuant);
                }
            }
            else if (rc.Alter == 3)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 3;
                    scaledQuantArr.Add(rc.ScaledQuant);
                }
            }
            else if (rc.Alter == 4)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]);
                    scaledQuantArr.Add(rc.ScaledQuant);
                }
            }


            Console.WriteLine("************************************************************");
            for (int i = 0; i < ingrQuantArr.Count; i++)
            {
                Console.WriteLine("Ingredient name: " + ingrNameArr[i] + "\n" +
                                  "Quantity: " + scaledQuantArr[i] + "\n" +
                                  "Measurements: " + measurementArr[i] + "\n");
            }
            Console.WriteLine("Directions: ");
            for (int i = 0; i < stepDescArr.Count; i++)
            {
                Console.WriteLine(stepDescArr[i]);
            }
            Console.WriteLine("************************************************************");

            Console.ReadLine();
        }
    }
}
