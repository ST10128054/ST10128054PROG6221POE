using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST10128054PROG6221POE
{
    public class Recipe
    {
        private int numIngr;
        private String ingrName;
        private int ingrQuant;
        private String measurement;
        private int numSteps;
        private String stepDesc;


        public int getNumIngr()
        {
            return this.numIngr;
        }
        public void setNumIngr(int numIngr)
        {
            this.numIngr = numIngr;
        }

        public String getIngrName()
        {
            return this.ingrName;
        }
        public void setIngrName(String ingrName)
        {
            this.ingrName = ingrName;
        }

        public int getIngrQuant()
        {
            return this.ingrQuant;
        }
        public void setIngrQuant(int ingrQuant)
        {
            this.ingrQuant = ingrQuant;
        }

        public String getMeasurement()
        {
            return this.measurement;
        }
        public void setMeasurement(String measurement)
        {
            this.measurement = measurement;
        }

        public int getNumSteps()
        {
            return this.numSteps;
        }
        public void setNumSteps(int numSteps)
        {
            this.numSteps = numSteps;
        }

        public String getStepDesc()
        {
            return this.stepDesc;
        }
        public void setStepDesc(String stepDesc)
        {
            this.stepDesc = stepDesc;
        }

    }
}
