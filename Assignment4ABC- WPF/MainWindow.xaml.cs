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

        private const int maxNumOfIngredients = 50;
        private const int maxNumOfElements = 200;
        Recipe curRecipe = new Recipe(maxNumOfIngredients);
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
            WindowIngredients windowIngredients = new WindowIngredients();
            lblCategory.Content = curRecipe.FoodCategory; //tester
            windowIngredients.Show();
            
        }

        private void SelectionChangedComboBox(object sender, SelectionChangedEventArgs e)
        {
            curRecipe.FoodCategory = (FoodCategory)cmbCategory.SelectedItem; // sends to class food category 
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            curRecipe.NameRecipe = txtNameOfTheRecipe.Text; // sends to class name of recipe
            curRecipe.DescriptionRecipe = txtDescription.Text; // sends to class description of recipe
        }

       
    }
}
