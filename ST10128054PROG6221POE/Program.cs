﻿using System;
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


        }
    }
}
