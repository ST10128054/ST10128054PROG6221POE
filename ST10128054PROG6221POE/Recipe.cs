using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    public class Recipe
    {
        private int numRecipe, numIngr, numSteps, alter;
        private String recName, ingrName, measurement, stepDesc,foodGroup;
        private Double ingrQuant, scaledQuant, calories;
        public String FoodGroup
        {
            get { return foodGroup; }
            set { foodGroup = value; }
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

        public String RecName
        {
            get { return recName; }
            set { recName = value; }
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

        public String StepDesc
        {
            get { return stepDesc; }
            set { stepDesc = value; }
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
        }

    }
}
