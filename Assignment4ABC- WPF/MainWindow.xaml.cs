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
/// to do
/// add colors to add ingredients 
/// wraping doesnt work correctly it should start new line
/// 
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
        RecipeManager recipeManager = new RecipeManager(maxNumOfElements);
        

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
            //PASSING THE curRecipe OBJECT TO NEW WINDOW - WindowIngredients!!!
            WindowIngredients dlg = new WindowIngredients(curRecipe);
            dlg. ShowDialog();
        }

        private void SelectionChangedComboBox(object sender, SelectionChangedEventArgs e)
        {
            curRecipe.FoodCategory = (FoodCategory)cmbCategory.SelectedItem; // sends to class food category 
        }

        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            curRecipe.NameRecipe = txtNameOfTheRecipe.Text; // sends to class name of recipe
            curRecipe.DescriptionRecipe = txtDescription.Text; // sends to class description of recipe

            recipeManager.AddRecipeObject(curRecipe); //method which addds recipeobj to array of objects in recipe manager
            DisplayLstResults();



            curRecipe = new Recipe(maxNumOfIngredients);
            cmbCategory.SelectedItem = curRecipe.FoodCategory; // combobox gets the value from recipe class so by default it is "other"
            txtDescription.Text = string.Empty;
            txtNameOfTheRecipe.Text = string.Empty;
        }
        private void lstResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = lstResults.SelectedIndex;
            recipeManager.Index = index;
        }

        private void lstResults_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (recipeManager.Index != -1)
            {
                WindowDisplayRecipe displayRecipe = new WindowDisplayRecipe(recipeManager);
                displayRecipe.Show();
            }
            else
                MessageBox.Show("You need to select something from the recipe list!");
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (recipeManager.Index != -1)
            {
                recipeManager.DeleteAt(recipeManager.Index);
                DisplayLstResults();
            }
            else
            {
                MessageBox.Show("Select the recipe first!");
            }
        }

        private void DisplayLstResults()
        {
            lstResults.Items.Clear();
            for (int i = 0; i < recipeManager.RecipeArray.Length; i++) // not all the characters are the same width. For example, "i" is much narrower than "W", and "." is really narrow while "#" is a lot wider. if you want this to work you need to set up font to courier new or other.
            {
                if (recipeManager.RecipeArray[i] != null)
                    lstResults.Items.Add((string.Format("{0,-18} {1,-20} {2,5} ", recipeManager.RecipeArray[i].NameRecipe, recipeManager.RecipeArray[i].FoodCategory, recipeManager.RecipeArray[i].IngredientCounter)));
            }
        }

        private void btnClearSelection_Click(object sender, RoutedEventArgs e)
        {
            lstResults.SelectedIndex = -1; // -1 means that its not selected
        }

        private void btnEditBegin_Click(object sender, RoutedEventArgs e)
        {
            ///  1 first you select which one you want to edit
            ///  2 click edit begin 
            ///  3. in txtDescription and txtName appears your text
            ///  4. in Add Ingredients appears all your ingredients
            ///  5 food category cmbbox changes to what it is in selected
            int index = recipeManager.Index;

            if(recipeManager.Index == -1)
            {
                MessageBox.Show("You need to select item first");
            }
            else
            {
                curRecipe = recipeManager.RecipeArray[index];
                txtDescription.Text = curRecipe.DescriptionRecipe;
                txtNameOfTheRecipe.Text = curRecipe.NameRecipe;
                cmbCategory.SelectedItem = curRecipe.FoodCategory;
            }

            
            

        }

        private void btnEditFinish_Click(object sender, RoutedEventArgs e)
        {
            if (recipeManager.Index != -1)
            {
                curRecipe.DescriptionRecipe = txtDescription.Text;
                curRecipe.NameRecipe = txtNameOfTheRecipe.Text;
                curRecipe.FoodCategory = (FoodCategory)cmbCategory.SelectedItem;

                recipeManager.RecipeArray[recipeManager.Index] = curRecipe;
                DisplayLstResults();
                curRecipe = new Recipe(maxNumOfIngredients);
            }
            else
            {
                MessageBox.Show("You need to select the recipe!");
            }

        }
    }
}
