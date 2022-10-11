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
using System.Windows.Shapes;

namespace Assignment4ABC__WPF
{
    /// <summary>
    /// Interaction logic for WindowIngredients.xaml
    /// </summary>
    public partial class WindowIngredients : Window 
    {
        Recipe curRecipe;
        
        public WindowIngredients(Recipe recipe) // GETTING THE OBJECT curRecipe
        {
            InitializeComponent();
            curRecipe = recipe;
            Recipe temporaryRecipe = new Recipe(50);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String ingredient = txtIngredient.Text;
            curRecipe.AddToArrayOfIngredients(ingredient);
            ShowList();
        }

        private void ShowList()
        {
            lstIngredients.Items.Clear();
            for (int i = 0; i < curRecipe.ArrayOfIngredients.Length; i++)
            {
                if (curRecipe.ArrayOfIngredients[i] != null)
                {
                    lstIngredients.Items.Add(curRecipe.ArrayOfIngredients[i]);
                }
            }
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            temporaryRecipe = curRecipe;
        }
    }
}
