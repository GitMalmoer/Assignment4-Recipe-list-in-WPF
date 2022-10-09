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

namespace Assignment4ABC__WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Recipe recipe = new Recipe();
        public MainWindow()
        {
            InitializeComponent();
            InitializeGUI();
        }

        private void InitializeGUI()
        {
            // ComboBox
            cmbCategory.ItemsSource = Enum.GetValues(typeof(FoodCategory));
            cmbCategory.SelectedIndex = 10; // default other option selected
        }

        private void btnAddIngredients_Click(object sender, RoutedEventArgs e)
        {
            
            //lblCategory.Content = cmbCategory.SelectedItem;
            lblCategory.Content = recipe.FoodCategory; 
        }

        private void SelectionChangedComboBox(object sender, SelectionChangedEventArgs e)
        {
            recipe.FoodCategory = (FoodCategory)cmbCategory.SelectedItem;
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            recipe.NameRecipe = txtNameOfTheRecipe.Text;
        }
    }
}
