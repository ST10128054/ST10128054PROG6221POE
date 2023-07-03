using ST10128054PROG6221POE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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

namespace RecipeApplication
{
    /// <summary>
    /// Interaction logic for frmDisplayRecipe.xaml
    /// </summary>
    public partial class frmDisplayRecipe : Window
        
    {
        public static string search;
        public static string filter;
        public static int index;
        public frmDisplayRecipe()
        {
            InitializeComponent();
        }

        private void btnDisplyRecipe_Click(object sender, RoutedEventArgs e)
        {
            
            if (frmAddRecipeInfo.scaled)
            {
                foreach (ScaledRecipe sRec in frmAddRecipeInfo.lstScaledRecipe)
                {
                    lstBxDisplayRecipe.Items.Add("Recipe Name: " + sRec.SRecName + "\n" +
                                        "Ingredients: \n" + sRec.SIngrInfo + "\n" +
                                        "Instructions: " + sRec.SInstructions);
                }
            }
            else if (!frmAddRecipeInfo.scaled) 
            {
                foreach (Recipe rec in frmAddRecipeInfo.lstRecipe)
                {
                    lstBxDisplayRecipe.Items.Add("Recipe Name: " + rec.RecName + "\n" +
                                        "Ingredients: \n" + rec.IngrInfo + "\n" +
                                        "Instructions: " + rec.Instructions);
                }
            }
        }

        private void btnExitDsiplay_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            frmAddRecipeInfo.scaled = false;

            MessageBox.Show("All recipes reset.");
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            search = txtSearch.Text.ToUpper();

            foreach (var searchRecipe in frmAddRecipeInfo.lstScaledRecipe)
            {
                if (searchRecipe.SRecName.Contains(search))
                {
                    if (frmAddRecipeInfo.scaled)
                    {
                        foreach (ScaledRecipe sRec in frmAddRecipeInfo.lstScaledRecipe)
                        {
                            lstBxDisplayRecipe.Items.Add("Recipe Name: " + sRec.SRecName + "\n" +
                                                "Ingredients: \n" + sRec.SIngrInfo + "\n" +
                                                "Instructions: " + sRec.SInstructions);
                        }
                    }
                    else if (!frmAddRecipeInfo.scaled)
                    {
                        foreach (Recipe rec in frmAddRecipeInfo.lstRecipe)
                        {
                            lstBxDisplayRecipe.Items.Add("Recipe Name: " + rec.RecName + "\n" +
                                                "Ingredients: \n" + rec.IngrInfo + "\n" +
                                                "Instructions: " + rec.Instructions);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Recipe not found.");
                }
            }

        }

        private void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            filter = txtFilter.Text.ToUpper();

            foreach (var searchRecipe in frmAddRecipeInfo.lstScaledRecipe)
            {
                if (searchRecipe.SIngrInfo.Contains(filter))
                {
                    if (frmAddRecipeInfo.scaled)
                    {
                        foreach (ScaledRecipe sRec in frmAddRecipeInfo.lstScaledRecipe)
                        {
                            lstBxDisplayRecipe.Items.Add("Recipe Name: " + sRec.SRecName + "\n" +
                                                "Ingredients: \n" + sRec.SIngrInfo + "\n" +
                                                "Instructions: " + sRec.SInstructions);
                        }
                    }
                    else if (!frmAddRecipeInfo.scaled)
                    {
                        foreach (Recipe rec in frmAddRecipeInfo.lstRecipe)
                        {
                            lstBxDisplayRecipe.Items.Add("Recipe Name: " + rec.RecName + "\n" +
                                                "Ingredients: \n" + rec.IngrInfo + "\n" +
                                                "Instructions: " + rec.Instructions);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("No recipes found.");
                }
            }
        }
    }
}
