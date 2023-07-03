using ST10128054PROG6221POE;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecipeApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static List<string> lstRecipeName = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnAddRecipeName_Click(object sender, RoutedEventArgs e)
        {
            string recipeName = txtRecName.Text;

            if (recipeName != "")
            {
                lstRecipeName.Add(recipeName);
                MessageBox.Show("Recipe name saved!");
                txtRecName.Clear();
            }
            else
            {
                MessageBox.Show("Text box is empty, please fill in.");
            }

        }

        private void btnAddInformation_Click(object sender, RoutedEventArgs e)
        {
            frmAddRecipeInfo recInfo = new frmAddRecipeInfo();
            recInfo.Show();
        }

        private void btnDisplay_Click(object sender, RoutedEventArgs e)
        {
            frmDisplayRecipe disRec = new frmDisplayRecipe();
            disRec.Show();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            frmAddRecipeInfo.lstRecipe.Clear();
            frmAddRecipeInfo.lstScaledRecipe.Clear();
            MessageBox.Show("All recipes cleared.");
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
