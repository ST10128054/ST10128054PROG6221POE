using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    public class Recipe
    {
        private int numIngr, numSteps, alter;
        private String ingrName, measurement, stepDesc;
        private Double ingrQuant, scaledQuant;
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
