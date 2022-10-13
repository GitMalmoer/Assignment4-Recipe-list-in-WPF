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
        private int _selectedIndex;
        public WindowIngredients(Recipe recipe) // GETTING THE OBJECT curRecipe
        {
            InitializeComponent();
            curRecipe = recipe;
            ShowList();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String ingredient = txtIngredient.Text;

            if (ingredient != string.Empty)
            {
                curRecipe.AddToArrayOfIngredients(ingredient);
            }
            else
            {
                MessageBox.Show("The textbox is empty");
            }
            ShowList();
            
        }

        private void ShowList()
        {
            int ingredientCounter = 0;
            lstIngredients.Items.Clear();
            for (int i = 0; i < curRecipe.ArrayOfIngredients.Length; i++)
            {
                
                if (curRecipe.ArrayOfIngredients[i] != null && curRecipe.ArrayOfIngredients[i] != String.Empty)
                {
                    lstIngredients.Items.Add(curRecipe.ArrayOfIngredients[i]);
                    ingredientCounter++;
                }
            }
            lblNumberIngredients.Content = ingredientCounter;
            curRecipe.IngredientCounter = ingredientCounter;
        }

        private void ClearArray()
        {
            for (int i = 0; i < curRecipe.ArrayOfIngredients.Length; i++)
            {
                curRecipe.ArrayOfIngredients[i]= null;
            }
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
            ClearArray();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (txtIngredient.Text != string.Empty)
            {
                if (curRecipe.Index != -1)
                {
                    curRecipe.ArrayOfIngredients[curRecipe.Index] = txtIngredient.Text;
                    ShowList();
                }
            }
            else
            {
                MessageBox.Show("Textbox is empty!");
            }
        }

        private void lstIngredients_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstIngredients.SelectedIndex;
            curRecipe.Index = index;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            int index = curRecipe.Index;
            curRecipe.DeleteAt(index);
            ShowList();
        }
    }
}
