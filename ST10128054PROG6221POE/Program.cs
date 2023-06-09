﻿using System;
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
        //public static Recipe rc = new Recipe();
        //initialzing arraylist to store the recipe details

        public static List<Recipe> lstRecipe = new List<Recipe>();
        public static List<ScaledRecipe> lstScaledRecipe = new List<ScaledRecipe>();

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
        public static int scaleMenu;
        public static Boolean scaled = false;
        public static int ingrQuantScale;
        public static int recipeIndex;
        public static int foodGroupOpt;
        public static int totCalories;

        public static string step;
        public static string ingrName;
        public static string measurement;
        public static string foodGroup;
        public static int numRecipe;
        public static int numIngr;
        public static int numSteps;
        public static int alter;
        public static double ingrQuant;
        public static double scaledQuant;
        public static double calories;

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
                    //scaleMeasurement();
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
            Boolean checkCalories = false; 
            Boolean checkScale = false;
            Boolean checkFoodGroup = false;


            StringBuilder sbIngrInfo = new StringBuilder();
            StringBuilder sbScaledIngrInfo = new StringBuilder();
            StringBuilder sbQuant = new StringBuilder();
            StringBuilder sbMeasurement = new StringBuilder();
            StringBuilder sbInsructions = new StringBuilder();
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
                    numRecipe = Convert.ToInt32(Console.ReadLine());
                    checkRecipe = true;
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please enter a number.");

                }
            }

            for (int k = 0; k < numRecipe; k++)
            {
                

                Console.WriteLine("Enter the name of recipe " + (k + 1) + ": ");
                string recName = Console.ReadLine().ToUpper();

                while (!checkIngr)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        //prompting user for information and then storing said information into arraylists
                        Console.WriteLine("************************************\n" +
                                          "Enter the number of ingredients for the recipe: ");
                        numIngr = Convert.ToInt32(Console.ReadLine());
                        checkIngr = true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number.");

                    }
                }
                checkIngr = false;

                alter = 0;
                

                while (!checkScale)
                {
                    try
                    {
                        
                        //menu system to allow the user to pick the factor amount
                        Console.WriteLine("************************************\n" +
                                          "Do you want to alter the quantities of the ingredients?\n" +
                                          "1) Half.\n" +
                                          "2) Double.\n" +
                                          "3) Triple.\n" +
                                          "4) No.\n" );
                        alter = Convert.ToInt32(Console.ReadLine());
                        checkScale = true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number.");

                    }
                }
                checkScale = false;
                


                for (int i = 0; i < numIngr; i++)
                {
                    Console.WriteLine("Enter the name of ingredient " + (i + 1) + ": ");
                    ingrName = Console.ReadLine();

                    if (alter == 1 || alter == 2 || alter == 3)
                    {
                        while (!checkQuant)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the quantity of ingredient " + (i + 1) + ": ");
                                ingrQuant = Convert.ToInt32(Console.ReadLine());
                                scaledQuant = scaleMeasurement(ingrQuant);


                                checkQuant = true;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter a number.");
                            }
                        }
                        checkQuant = false;
                    }
                    else if (alter == 4)
                    {
                        while (!checkQuant)
                        {
                            try
                            {
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                Console.WriteLine("Enter the quantity of ingredient " + (i + 1) + ": ");
                                ingrQuant = Convert.ToInt32(Console.ReadLine());
                                
                                checkQuant = true;
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Please enter a number.");
                            }
                        }
                        checkQuant = false;
                    }
                    


                    Console.WriteLine("Enter the unit of measurement of ingredient " + (i + 1) + ": ");
                    measurement = Console.ReadLine();
                    
                    while (!checkCalories)
                    {
                        try
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Enter the number of calories of ingredient " + (i + 1) + ": ");
                            calories = Convert.ToInt32(Console.ReadLine());
                            checkCalories = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a number.");
                        }
                    }
                    checkCalories = false;

                    while (!checkFoodGroup)
                    {
                        try
                        {
                            Console.WriteLine("Enter the food group of ingredient " + (i + 1) + ": \n" +
                                      "1) Starchy foods.\n" +
                                      "2) Vegetables and fruits.\n" +
                                      "3) Dry beans, peas, lentils and soya.\n" +
                                      "4) Chicken, fish, meat and eggs.\n" +
                                      "5) Milk and dairy products.\n" +
                                      "6) Fats and oil.\n" +
                                      "7) Water");
                            foodGroupOpt = Convert.ToInt32(Console.ReadLine());
                            checkFoodGroup = true;
                        }
                        catch (Exception ex)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Please enter a number.");
                        }
                    }
                    checkFoodGroup = false;

                    if (foodGroupOpt == 1)
                    {
                        foodGroup = "Starchy foods";
                    }
                    else if (foodGroupOpt == 2)
                    {
                        foodGroup = "Vegetables and fruits";
                    }
                    else if (foodGroupOpt == 3)
                    {
                        foodGroup = "Dry beans, peas, lentils and soya";
                    }
                    else if (foodGroupOpt == 4)
                    {
                        foodGroup = "Chicken, fish, meat and eggs";
                    }
                    else if (foodGroupOpt == 5)
                    {
                        foodGroup = "Milk and dairy products";
                    }
                    else if (foodGroupOpt == 6)
                    {
                        foodGroup = "Fats and oil";
                    }
                    else if (foodGroupOpt == 7)
                    {
                        foodGroup = "Water";
                    }
                    

                    if (alter == 1 || alter == 2 || alter == 3)
                    {
                        sbScaledIngrInfo.Append((i + 1) + ". " + scaledQuant + " " + measurement + " of " + ingrName +
                                      ", Food Group: " + foodGroup + ", Calories: " + calories + "\n");
                    }
                    
                        sbIngrInfo.Append((i + 1) + ". " + ingrQuant + " " + measurement + " of " + ingrName +
                                      ", Food Group: " + foodGroup + ", Calories: " + calories + "\n");
                    
                        
                }
                string ingrInfo = sbIngrInfo.ToString();
                string sIngrInfo = sbScaledIngrInfo.ToString();
                //numIngr = 0;
                
                while (!checkSteps)
                {
                    try
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("Enter the number of steps for the recipe: ");
                        numSteps = Convert.ToInt32(Console.ReadLine());
                        checkSteps = true;
                    }
                    catch (Exception ex)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Please enter a number.");

                    }
                }
                checkSteps = false;
                //rc.NumSteps = 0;

                for (int j = 0; j < numSteps; j++)
                {
                    Console.WriteLine("Enter the description for step " + (j + 1) + ": ");
                    step = Console.ReadLine();
                    sbInsructions.Append("Step " + (j + 1) + ": " + step + "\n");
                }
                string instructions = sbInsructions.ToString();

                lstRecipe.Add(new Recipe(recName, ingrInfo, instructions));
                lstScaledRecipe.Add(new ScaledRecipe(recName, sIngrInfo, instructions));

                /*stepDescList.Add(sbDesc.ToString());
                ingrNameList.Add(sbIngr.ToString());
                ingrQuantListStr.Add(sbQuant.ToString());
                measurementList.Add(sbMeasurement.ToString());
                caloriesListStr.Add(sbCalories.ToString());*/

            }
            
            

            Console.ForegroundColor = ConsoleColor.Yellow;
            //providing the user with feedback after successfull function
            Console.WriteLine("RECIPE SAVED.");
        }

        //this method scales the quantities of the ingredients
        public static double scaleMeasurement(double ingrQuant)
        {
            //multiplies the amount in the arraylist by the factor and stores it in a new arraylist
            if (alter == 1)
            {
                scaledQuant = ingrQuant * 0.5;
                scaled = true;
            }
            else if (alter == 2)
            {
                scaledQuant = ingrQuant * 2;
                scaled = true;
            }
            else if (alter == 3)
            {
                scaledQuant = ingrQuant * 3;
                scaled = true;
            } else if (alter == 4)
            {
                scaledQuant = ingrQuant;
            }
            
            
            return scaledQuant;
        }

        //this method resets the quantities back to their original values
        public static void resetMeasurement()///////
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            

            foreach (ScaledRecipe sRec in lstScaledRecipe)
            {
                foreach (Recipe rec in lstRecipe)
                {
                    sRec.SIngrInfo = rec.IngrInfo;
                }
            }
            Console.WriteLine("MEASUREMENTS RESET.");
        }

        //this method displays the recipe information
        public static void displayRecipe() 
        {
            //ingrNamePrint = ingrNameList[0].Split(char.Parse(","));///
            Console.ForegroundColor = ConsoleColor.DarkYellow;

            

            if (alter == 1 || alter == 2 || alter == 3)
            {
                foreach (ScaledRecipe sRec in lstScaledRecipe)
                {
                    Console.WriteLine(sRec.SRecName + "\n" +
                                      sRec.SIngrInfo + "\n" +
                                      sRec.SInstructions);

                }
            }
            else if (alter == 4)
            {
                foreach (Recipe rec in lstRecipe)
                {
                    Console.WriteLine(rec.RecName + "\n" +
                                      rec.IngrInfo + "\n" +
                                      rec.Instructions);

                }
            }

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
