using ST10128054PROG6221POE;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.Pkcs;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Xml.Linq;

namespace RecipeApplication
{
    /// <summary>
    /// Interaction logic for frmAddRecipeInfo.xaml
    /// </summary>
    public partial class frmAddRecipeInfo : Window
    {
        //RecApp rcApp = new RecApp();
        //Recipe rc = new Recipe();
        public static List<Recipe> lstRecipe = new List<Recipe>();
        public static List<ScaledRecipe> lstScaledRecipe = new List<ScaledRecipe>();
        public static string recipeName;
        public static string ingrName;
        public static double ingrAmount;
        public static double scaledAmount;
        public static string measurement;
        public static string foodGroup;
        public static double calories;
        public static double totCalories;
        public static string instructions;
        public static string ingrInfo;
        public static  string sIngrInfo;
        public static Boolean scaled;
        public static StringBuilder sbIngrInfo = new StringBuilder();
        public static StringBuilder sbScaledIngrInfo = new StringBuilder();
        public static StringBuilder sbInstr = new StringBuilder();

        public frmAddRecipeInfo()
        {
            InitializeComponent();
            loadRecipe();
            loadFoodGroup();
        }

        public void loadRecipe()
        {
            foreach (string recipeName in MainWindow.lstRecipeName)
            {
                cmbSelectRecipe.Items.Add(recipeName);
            }
            cmbSelectRecipe.SelectedIndex = 0;
        }

        public void loadFoodGroup()
        {
            cmbFoodGroup.Items.Add("Starchy foods");
            cmbFoodGroup.Items.Add("Vegetables and fruits");
            cmbFoodGroup.Items.Add("Dry beans, peas, lentils and soya");
            cmbFoodGroup.Items.Add("Chicken, fish, meat and eggs");
            cmbFoodGroup.Items.Add("Milk and dairy products");
            cmbFoodGroup.Items.Add("Fats and oil");
            cmbFoodGroup.Items.Add("Water");

            cmbFoodGroup.SelectedIndex = 0;
        }

        private void btnAddIngr_Click(object sender, RoutedEventArgs e)
        {
            if (txtIngrName.Text != "" && cmbSelectRecipe.Text != "" && cmbFoodGroup.Text != "" && txtIngrAmount.Text != "" && txtMeasurement.Text != "" && txtCalories.Text != "")
            { 
                ingrName = txtIngrName.Text.ToUpper();
                ingrAmount = Convert.ToDouble(txtIngrAmount.Text);
                scaledAmount = Convert.ToDouble(txtIngrAmount.Text);
                measurement = txtMeasurement.Text;
                foodGroup = cmbFoodGroup.SelectedItem.ToString();
                calories = Convert.ToDouble(txtCalories.Text);

                totCalories += calories;

                if (totCalories > 300)
                {
                    MessageBox.Show("Notice. Total calories have exceeded 300.");
                }

                
                if (rdbHalf.IsChecked == true)
                {
                    scaledAmount = ingrAmount * 0.5;
                    scaled = true;
                }
                else if (rdbDouble.IsChecked == true)
                {
                    scaledAmount = ingrAmount * 2;
                    scaled = true;
                }
                else if (rdbTriple.IsChecked == true)
                {
                    scaledAmount = ingrAmount * 3;
                    scaled = true;
                }

                if (rdbHalf.IsChecked == true || rdbDouble.IsChecked == true || rdbTriple.IsChecked == true)
                {
                    sbScaledIngrInfo.Append(scaledAmount + " " + measurement + " of " + ingrName +
                                  ", Food Group: " + foodGroup + ", Calories: " + calories + "\n");
                } 
                
                    sbIngrInfo.Append(ingrAmount + " " + measurement + " of " + ingrName +
                              ", Food Group: " + foodGroup + ", Calories: " + calories + "\n");
                

                MessageBox.Show("Ingredient added!");
                txtIngrName.Clear();
                txtIngrAmount.Clear();
                txtMeasurement.Clear();
                txtCalories.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.");
            }
        }

        private void btnAddInstr_Click(object sender, RoutedEventArgs e)
        {
            sbInstr.Append(txtInstructions.Text + "\n");

            MessageBox.Show("Instruction added!");

            txtInstructions.Clear();
        }

        private void btnSaveRecipe_Click(object sender, RoutedEventArgs e)
        {
            lstBxView.Items.Clear();

            sbIngrInfo.Append("Total Calories: " + totCalories);
            sbScaledIngrInfo.Append("Total Calories: " + totCalories);

            recipeName = cmbSelectRecipe.SelectedItem.ToString();
            ingrInfo = sbIngrInfo.ToString();
            sIngrInfo = sbScaledIngrInfo.ToString();
            instructions = sbInstr.ToString();

            totCalories = 0;

            
            
            lstRecipe.Add(new Recipe(recipeName, ingrInfo, instructions));
            lstScaledRecipe.Add(new ScaledRecipe(recipeName, sIngrInfo, instructions));

            if (rdbHalf.IsChecked == true || rdbDouble.IsChecked == true || rdbTriple.IsChecked == true)
            {
                foreach (ScaledRecipe sRec in lstScaledRecipe)
                {
                    lstBxView.Items.Add("Recipe Name: " + sRec.SRecName + "\n" +
                                        "Ingredients: \n" + sRec.SIngrInfo + "\n" +
                                        "Instructions: " + sRec.SInstructions);
                }
            } 
            else 
            {
                foreach (Recipe rec in lstRecipe)
                {
                    lstBxView.Items.Add("Recipe Name: " + rec.RecName + "\n" +
                                        "Ingredients: \n" + rec.IngrInfo + "\n" +
                                        "Instructions: " + rec.Instructions);
                }
            }

           
            

            sbIngrInfo.Clear();
            sbScaledIngrInfo.Clear();
            sbInstr.Clear();
        }

        private void rdbHalf_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btnExitInfo_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
