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
        //initialzing an object of the class Recipe
        public static Recipe rc = new Recipe();
        //initialzing arraylist to store the recipe details
        public static ArrayList ingrNameArr = new ArrayList();//stores name of ingredient
        public static ArrayList ingrQuantArr = new ArrayList();//stores the quantity of ingredient before scaling
        public static ArrayList scaledQuantArr = new ArrayList();//stores the quantity of ingredient after scaling
        public static ArrayList measurementArr = new ArrayList();//stores the unit of measurement
        public static ArrayList stepDescArr = new ArrayList();//stores the descriptions of the steps
        public static int mainMenu = 0;
        public static Boolean scaled = false;


        static void Main(string[] args)
        {
            //while loop to keep the aplication running until the user wants to stop
            while(mainMenu < 6)
            {
                //change text colour to green
                Console.ForegroundColor = ConsoleColor.Green;
                //menu system for navigation to access functions
                Console.WriteLine("************************************\n" +
                                  "Recipe App\n" +
                                  "1) Enter ingredients and steps.\n" +
                                  "2) Scale measurements.\n" +
                                  "3) Reset measurements.\n" +
                                  "4) Display recipe.\n" +
                                  "5) Clear recipe.\n" +
                                  "6) Exit.(enter 6 twice)");
                mainMenu = Convert.ToInt32(Console.ReadLine());
                //series of else if statements to select the desired method
                if (mainMenu == 1)
                {
                    //call enterRecipe method
                    enterRecipe();
                }
                else if (mainMenu == 2)
                {
                    //call scaleMeasurement method
                    scaleMeasurement();
                }
                else if (mainMenu == 3)
                {
                    //call resetMeasurement method
                    resetMeasurement();
                }
                else if (mainMenu == 4)
                {
                    //call displayRecipe method
                    displayRecipe();
                }
                else if (mainMenu == 5)
                {
                    //call clearRecipe method
                    clearRecipe();
                }
            }

            Console.ReadLine();
        }

        //this method allows the user the enter the details of the recipe and stores them in arraylists
        public static void enterRecipe()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            //prompting user for information and then storing said information into arraylists
            Console.WriteLine("************************************\n" + 
                              "Enter the number of ingredients for the recipe: ");
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

            Console.ForegroundColor = ConsoleColor.Yellow;
            //providing the user with feedback after successfull function
            Console.WriteLine("RECIPE SAVED.");
        }

        //this method scales the quantities of the ingredients
        public static void scaleMeasurement()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            //menu system to allow the user to pick the factor amount
            Console.WriteLine("************************************\n" + 
                              "Do you want to alter the quantities of the ingredients?\n" +
                              "1) Half.\n" +
                              "2) Double.\n" +
                              "3) Triple.\n");
            rc.Alter = Convert.ToInt32(Console.ReadLine());

            //multiplies the amount in the arraylist by the factor and stores it in a new arraylist
            if (rc.Alter == 1)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 0.5;
                    scaledQuantArr.Insert(i, rc.ScaledQuant);
                }
                scaled = true;
            }
            else if (rc.Alter == 2)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 2;
                    scaledQuantArr.Insert(i, rc.ScaledQuant);
                }
                scaled = true;
            }
            else if (rc.Alter == 3)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantArr[i]) * 3;
                    scaledQuantArr.Insert(i, rc.ScaledQuant);
                }
                scaled = true;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("MEASUREMENTS SCALED.");
        }

        //this method resets the quantities back to their original values
        public static void resetMeasurement()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 0; i < ingrQuantArr.Count; i++)
            {
                //resets quatities to orignal values
                scaledQuantArr.Insert(i, ingrQuantArr[i]);
            }
            Console.WriteLine("MEASUREMENTS RESET.");
        }

        //this method displays the recipe information
        public static void displayRecipe() 
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("************************************");
            if (scaled == false)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    Console.WriteLine("Ingredient " + (i+1) + ": " + ingrQuantArr[i] + " " + 
                                      measurementArr[i] + " of " + ingrNameArr[i]);
                }
            }
            else if (scaled == true)
            {
                for (int i = 0; i < ingrQuantArr.Count; i++)
                {
                    Console.WriteLine("Ingredient " + (i + 1) + ": " + scaledQuantArr[i] + " " +
                                      measurementArr[i] + " of " + ingrNameArr[i]);
                }
            }
            
            Console.WriteLine("Directions");
            for (int i = 0; i < stepDescArr.Count; i++)
            {
                Console.WriteLine(stepDescArr[i]);
            }
        }

        //this method clears the recipe information
        public static void clearRecipe()
        {
            ingrNameArr.Clear();
            ingrQuantArr.Clear();
            scaledQuantArr.Clear();
            measurementArr.Clear();
            stepDescArr.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RECIPE CLEARED.");
        }
    }
}
