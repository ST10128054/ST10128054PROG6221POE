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
        public static List<double> caloriesList = new List<double>();
        public static List<double> foodGroupList = new List<double>();

        public static List<string> ingrQuantListStr = new List<string>();
        public static List<string> ingrNamePrint = new List<string>();
        public static List<string> ingrQuantPrint = new List<string>();
        public static List<string> scaledQuantPrint = new List<string>();
        public static List<string> measurementPrint = new List<string>();
        public static List<string> caloriesPrint = new List<string>();
        public static List<string> caloriesListStr = new List<string>();
        public static List<double> foodGroupPrint = new List<double>();
        public static int mainMenu = 0;
        public static Boolean scaled = false;
        public static int recipeIndex;
        public static int foodGroupOpt;
        public static int totCalories;

        public delegate void delDisCalories();

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

            StringBuilder sbIngr = new StringBuilder();
            StringBuilder sbQuant = new StringBuilder();
            StringBuilder sbMeasurement = new StringBuilder();
            StringBuilder sbDesc = new StringBuilder();
            StringBuilder sbCalories = new StringBuilder();
            StringBuilder sbFoodGroup = new StringBuilder();

            while (!checkRecipe)
            {
                try
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    //prompting user for information and then storing said information into arraylists
                    Console.WriteLine("************************************\n" +
                                      "Enter the number of recipes that you want to save: ");
                    rc.NumRecipe = Convert.ToInt32(Console.ReadLine());
                    checkRecipe = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");

                }
            }

            for (int k = 0; k < rc.NumRecipe; k++)
            {
                Console.WriteLine("Enter the name of recipe " + (k + 1) + ": ");
                rc.RecName = Console.ReadLine().ToUpper();
                recipeNameList.Add(rc.RecName);
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

                for (int i = 0; i < rc.NumIngr; i++)
                {
                    Console.WriteLine("Enter the name of ingredient " + (i + 1) + ": ");
                    rc.IngrName = Console.ReadLine();
                    sbIngr.Append(rc.IngrName + ",");
                    
                    while (!checkQuant)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Enter the quantity of ingredient " + (i + 1) + ": ");
                            rc.IngrQuant = Convert.ToInt32(Console.ReadLine());
                            checkQuant = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a number.");

                        }
                    }
                    sbQuant.Append(rc.IngrQuant + ",");
                    

                    Console.WriteLine("Enter the unit of measurement of ingredient " + (i + 1) + ": ");
                    rc.Measurement = Console.ReadLine();
                    sbMeasurement.Append(rc.Measurement + ",");
                    

                    Console.WriteLine("Enter the number of calories of ingredient " + (i + 1) + ": ");
                    rc.Calories = Convert.ToInt32(Console.ReadLine());
                    sbCalories.Append(rc.Measurement + ",");

                    Console.WriteLine("Enter the food group of ingredient " + (i + 1) + ": \n" +
                                      "1) Starchy foods.\n" +
                                      "2) Vegetables and fruits.\n" +
                                      "3) Dry beans, peas, lentils and soya.\n" +
                                      "4) Chicken, fish, meat and eggs.\n" +
                                      "5) Milk and dairy products.\n" +
                                      "6) Fats and oil.\n" +
                                      "7) Water");
                    foodGroupOpt = Convert.ToInt32(Console.ReadLine());

                    if (foodGroupOpt == 1)
                    {
                        rc.FoodGroup = "Starchy foods";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 2)
                    {
                        rc.FoodGroup = "Vegetables and fruits";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 3)
                    {
                        rc.FoodGroup = "Dry beans, peas, lentils and soya";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 4)
                    {
                        rc.FoodGroup = "Chicken, fish, meat and eggs";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 5)
                    {
                        rc.FoodGroup = "Milk and dairy products";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 6)
                    {
                        rc.FoodGroup = "Fats and oil";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }
                    else if (foodGroupOpt == 7)
                    {
                        rc.FoodGroup = "Water";
                        sbFoodGroup.Append(rc.FoodGroup + ",");
                    }

                    
                    sbCalories.Append(rc.Measurement + ",");

                    checkQuant = false;
                }

                rc.NumIngr = 0;
                
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
                rc.NumSteps = 0;

                

                for (int j = 0; j < rc.NumSteps; j++)
                {
                    Console.WriteLine("Enter the description for step " + (j + 1) + ": ");
                    rc.StepDesc = Console.ReadLine();
                    sbDesc.Append("Step " + (j + 1) + ": " + rc.StepDesc + "\n");
                }
                stepDescList.Add(sbDesc.ToString());
                ingrNameList.Add(sbIngr.ToString());
                ingrQuantListStr.Add(sbQuant.ToString());
                measurementList.Add(sbMeasurement.ToString());
                caloriesListStr.Add(sbCalories.ToString());

            }
            
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            //providing the user with feedback after successfull function
            Console.WriteLine("RECIPE SAVED.");
        }

        //this method scales the quantities of the ingredients
        public static void scaleMeasurement()
        {
            Boolean checkScale = false;
            ingrQuantPrint = ingrQuantListStr[recipeIndex].Split(char.Parse(",")).ToList();

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
                for (int i = 0; i < ingrQuantPrint.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantPrint[i]) * 0.5;
                    ingrQuantPrint.Insert(i, Convert.ToString(rc.ScaledQuant));
                }
                scaled = true;
            }
            else if (rc.Alter == 2)
            {
                for (int i = 0; i < ingrQuantPrint.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantPrint[i]) * 2;
                    ingrQuantPrint.Insert(i, Convert.ToString(rc.ScaledQuant));
                }
                scaled = true;
            }
            else if (rc.Alter == 3)
            {
                for (int i = 0; i < ingrQuantPrint.Count; i++)
                {
                    rc.ScaledQuant = Convert.ToDouble(ingrQuantPrint[i]) * 3;
                    ingrQuantPrint.Insert(i, Convert.ToString(rc.ScaledQuant));
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
            //ingrNamePrint = ingrNameList[0].Split(char.Parse(","));///
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            Console.WriteLine("Do you want to: \n" +
                              "1) Search for a recipe.\n" +
                              "2) Display in alphabetical order.");
            int displayType = Convert.ToInt32(Console.ReadLine());

            if (displayType == 1)
            {
                Console.WriteLine("Enter the recipe you want to display: ");
                String searchRecipe = Console.ReadLine();


                if (recipeNameList.Contains(searchRecipe.ToUpper()))
                {
                    recipeIndex = recipeNameList.IndexOf(searchRecipe) + 1;

                    ingrNamePrint = ingrNameList[recipeIndex].Split(char.Parse(",")).ToList();
                    ingrQuantPrint = ingrQuantListStr[recipeIndex].Split(char.Parse(",")).ToList();
                    measurementPrint = measurementList[recipeIndex].Split(char.Parse(",")).ToList();
                    caloriesPrint = caloriesListStr[recipeIndex].ToString().Split(char.Parse(",")).ToList();

                    Console.WriteLine("************************************");
                    if (scaled == false)
                    {

                        Console.WriteLine("Recipe for " + recipeNameList[recipeIndex]);
                        for (int i = 0; i < ingrNamePrint.Count; i++)
                        {
                            Console.WriteLine("Ingredient " + (i + 1) + ": " + ingrQuantPrint[recipeIndex] + " " +
                                                measurementPrint[recipeIndex] + " of " + ingrNamePrint[recipeIndex]);
                        }


                    }
                    else if (scaled == true)
                    {
                        for (int i = 0; i < ingrQuantList.Count; i++)
                        {
                            Console.WriteLine("Ingredient " + (i + 1) + ": " + scaledQuantPrint[recipeIndex] + " " +
                                              measurementPrint[recipeIndex] + " of " + ingrNamePrint[recipeIndex]);
                        }
                    }

                    Console.WriteLine("Directions");
                    for (int i = 0; i < stepDescList.Count; i++)
                    {
                        Console.WriteLine(stepDescList[i]);
                    }
                    
                    
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Recipe not found!");
                }

                delDisCalories delDisplay = displayCalories;

                displayCalories();

            }
            else if(displayType == 2)
            {
                recipeNameList.Sort();

                for (int i = 0; i < recipeNameList.Count; i++)
                {
                    Console.WriteLine("Recipe for " + recipeNameList[i]);
                }
                

            } 
        }

        public static void displayCalories ()
        {

            for (int i = 0; i < caloriesPrint.Count; i++)
            {
                totCalories = Convert.ToInt32(caloriesPrint[i]) + Convert.ToInt32(caloriesPrint[i + 1]);
            }

            Console.WriteLine("Total Calories: " + totCalories);

            if (totCalories >= 300)
            {
                Console.WriteLine("Calories over 300!\n" +
                                  "Total Calories: " + totCalories);
            }
            else
            {
                Console.WriteLine("Total Calories: " + totCalories);
            }


        }

        //this method clears the recipe information
        public static void clearRecipe()
        {
            recipeNameList.Clear();
            ingrNameList.Clear();
            ingrQuantList.Clear();
            scaledQuantList.Clear();
            measurementList.Clear();
            stepDescList.Clear();
            caloriesList.Clear();
            foodGroupList.Clear();

            ingrQuantListStr.Clear();
            ingrNamePrint.Clear();
            ingrQuantPrint.Clear();
            scaledQuantPrint.Clear();
            measurementPrint.Clear();
            caloriesPrint.Clear();
            caloriesListStr.Clear();
            foodGroupPrint.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("RECIPE CLEARED.");
        }
    }
}
