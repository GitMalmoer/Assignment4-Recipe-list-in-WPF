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
        //private string[] _arrayOfIngredients;
        public WindowIngredients()
        {
            //_arrayOfIngredients = Recipe.ArrayOfIngredients;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String ingredient = txtIngredient.Text;
            Recipe.AddToArrayOfIngredients(ingredient);
            ShowList();
        }

        private void ShowList()
        {
            lstIngredients.Items.Clear();
            for (int i = 0; i < Recipe.ArrayOfIngredients.Length; i++)
            {
                if (Recipe.ArrayOfIngredients[i] != null)
                {
                    lstIngredients.Items.Add(Recipe.ArrayOfIngredients[i]);
                }
            }
            //lstIngredients.Items.Add(Recipe.ArrayOfIngredients.Length);
        }
    }
}
