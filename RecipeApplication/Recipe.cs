using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipeApplication
{
    public class Recipe
    {
        public string RecName { get; set; }
        public string IngrInfo { get; set; }
        public string Instructions { get; set; }
        
        public Recipe(string recName, string ingrInfo, string instructions)
        {
            RecName = recName;
            IngrInfo = ingrInfo;
            Instructions = instructions;
        }

        /*public String FoodGroup
        {
            get { return foodGroup; }
            set { foodGroup = value; }
        }
        public String Step
        {
            get { return step; }
            set { step = value; }
        }
        public double Calories
        {
            get { return calories; }
            set { calories = value; }
        }
        public int NumRecipe
        {
            get { return numRecipe; }
            set { numRecipe = value; }
        }

        

        public String IngrName
        {
            get { return ingrName; }
            set { ingrName = value; }
        }

        public int NumIngr
        {
            get { return numIngr; }
            set { numIngr = value; }
        }

        public Double IngrQuant
        {
            get { return ingrQuant; }
            set { ingrQuant = value; }
        }

        public String Measurement
        {
            get { return measurement; }
            set { measurement = value; }
        }
        
        public int NumSteps
        {
            get { return numSteps; }
            set { numSteps = value; }
        }

       

        public int Alter
        {
            get { return alter; }
            set { alter = value; }
        }

        public Double ScaledQuant
        {
            get { return scaledQuant; }
            set { scaledQuant = value; }
        }*/

    }
}
