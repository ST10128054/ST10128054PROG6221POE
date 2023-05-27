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
        public static List<string> recipeNameList = new List<string>();//stores name of recipe
        public static List<string> ingrNameList = new List<string>();//stores name of ingredient
        public static List<double> ingrQuantList = new List<double>();//stores the quantity of ingredient before scaling
        public static List<double> scaledQuantList = new List<double>();//stores the quantity of ingredient after scaling
        public static List<string> measurementList = new List<string>();//stores the unit of measurement
        public static List<string> stepDescList = new List<string>();//stores the descriptions of the steps
        public static int mainMenu = 0;
        public static Boolean scaled = false;

        static void Main(string[] args)
        {
            Boolean check = false;
            while (true && mainMenu < 6)
            {
                try
                {
                    //change text colour to green
                    Console.ForegroundColor = ConsoleColor.Green;
                    //menu system for navigation to access functions
                    Console.WriteLine("************************************\n" +
                                      "Recipe App\n" +
                                      "1) Enter recipe.\n" +
                                      "2) Scale measurements.\n" +
                                      "3) Reset measurements.\n" +
                                      "4) Display recipe.\n" +
                                      "5) Clear recipe.\n" +
                                      "6) Exit.(enter 6 twice)");
                    mainMenu = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");
                    check = true;
                }

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

            //Console.ForegroundColor = ConsoleColor.Cyan;
            Boolean checkRecipe = false;
            Boolean checkIngr = false;
            Boolean checkQuant = false;
            Boolean checkSteps = false;

            while (!checkRecipe)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //prompting user for information and then storing said information into arraylists
                    Console.WriteLine("************************************\n" +
                                      "Enter the number of recipes that you want to save: ");
                    rc.NumRec = Convert.ToInt32(Console.ReadLine());
                    checkRecipe = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");

                }
            }

            for (int i = 0; i < rc.NumRec; i++)
            {
                Console.WriteLine("Enter the name of the recipe " + (i + 1) + ": ");
                rc.IngrName = Console.ReadLine();
                recipeNameList.Add(rc.RecName);
            }

            while (!checkIngr)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //prompting user for information and then storing said information into arraylists
                    Console.WriteLine("************************************\n" +
                                      "Enter the number of ingredients for the recipe: ");
                    rc.NumIngr = Convert.ToInt32(Console.ReadLine());
                    checkIngr = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");
                    
                }
            }

            StringBuilder sbIngr = new StringBuilder();

            for (int k = 0; k < rc.NumRec; k++)
            {
                for (int i = 0; i < rc.NumIngr; i++)
                {
                    Console.WriteLine("Enter the name of the ingredient " + (i + 1) + ": ");
                    rc.IngrName = Console.ReadLine();
                    sbIngr.Append("Ingredient " + (i + 1) + " name: " + rc.IngrName + "\n");
                    ingrNameList.Add(sbIngr.ToString());
                    while (!checkQuant)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Enter the quantity of the ingredient " + (i + 1) + ": ");
                            rc.IngrQuant = Convert.ToInt32(Console.ReadLine());
                            checkQuant = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a number.");

                        }
                    }
                    sbIngr.Append("Ingredient " + (i + 1) + " name: " + rc.IngrName + "\n");
                    ingrQuantList.Add(rc.IngrQuant);
                    Console.WriteLine("Enter the unit of measurement of the ingredient " + (i + 1) + ": ");
                    rc.Measurement = Console.ReadLine();
                    measurementList.Add(rc.Measurement);
                    checkQuant = false;

                    
                }
                


                while (!checkSteps)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter the number of steps for the recipe: ");
                        rc.NumSteps = Convert.ToInt32(Console.ReadLine());
                        checkSteps = true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number.");

                    }
                }

                StringBuilder sb = new StringBuilder();

                for (int j = 0; j < rc.NumSteps; j++)
                {
                    Console.WriteLine("Enter the description for step " + (j + 1) + ": ");
                    rc.StepDesc = Console.ReadLine();
                    sb.Append("Step " + (j + 1) + ": " + rc.StepDesc + "\n");
                }
                stepDescList.Add(sb.ToString());
            }
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            //providing the user with feedback after successfull function
            Console.WriteLine("RECIPE SAVED.");
        }

        //this method scales the quantities of the ingredients
        public static void scaleMeasurement()
        {
            Boolean checkScale = false;

            while (!checkScale)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    //menu system to allow the user to pick the factor amount
                    Console.WriteLine("************************************\n" +
                                      "Do you want to alter the quantities of the ingredients?\n" +
                                      "1) Half.\n" +
                                      "2) Double.\n" +
                                      "3) Triple.\n");
                    rc.Alter = Convert.ToInt32(Console.ReadLine());
                    checkScale = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");

                }
            }

            //multiplies the amount in the arraylist by the factor and stores it in a new arraylist
            if (rc.Alter == 1)
            {
                for (int i = 0; i < ingrQuantList.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantList[i]) * 0.5;
                    scaledQuantList.Insert(i, rc.ScaledQuant);
                }
                scaled = true;
            }
            else if (rc.Alter == 2)
            {
                for (int i = 0; i < ingrQuantList.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantList[i]) * 2;
                    scaledQuantList.Insert(i, rc.ScaledQuant);
                }
                scaled = true;
            }
            else if (rc.Alter == 3)
            {
                for (int i = 0; i < ingrQuantList.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantList[i]) * 3;
                    scaledQuantList.Insert(i, rc.ScaledQuant);
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
            for (int i = 0; i < ingrQuantList.Count; i++)
            {
                //resets quatities to orignal values
                scaledQuantList.Insert(i, ingrQuantList[i]);
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
                for (int i = 0; i < ingrQuantList.Count; i++)
                {
                    Console.WriteLine("Ingredient " + (i+1) + ": " + ingrQuantList[i] + " " +
                                      measurementList[i] + " of " + ingrNameList[i]);
                }
            }
            else if (scaled == true)
            {
                for (int i = 0; i < ingrQuantList.Count; i++)
                {
                    Console.WriteLine("Ingredient " + (i + 1) + ": " + scaledQuantList[i] + " " +
                                      measurementList[i] + " of " + ingrNameList[i]);
                }
            }
            
            Console.WriteLine("Directions");
            for (int i = 0; i < stepDescList.Count; i++)
            {
                Console.WriteLine(stepDescList[i]);
            }
        }

        //this method clears the recipe information
        public static void clearRecipe()
        {
            ingrNameList.Clear();
            ingrQuantList.Clear();
            scaledQuantList.Clear();
            measurementList.Clear();
            stepDescList.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RECIPE CLEARED.");
        }
    }
}
