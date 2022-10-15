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
    /// Interaction logic for WindowDisplayRecipe.xaml
    /// </summary>
    public partial class WindowDisplayRecipe : Window
    {
        private RecipeManager _recipeManager;
        private int _index;
        private string _ingredients;

        public WindowDisplayRecipe(RecipeManager recipe)
        {
            InitializeComponent();
            _recipeManager = recipe;
            _index = _recipeManager.Index;
            InitializeGUI();
            
        }

        public void InitializeGUI()
        {
                this.Title = "Cooking recipe for: " + _recipeManager.RecipeArray[_index].NameRecipe;
                lstRecipeDetails.Items.Add("Ingredients: ");

                PutIngredientsInString();

                lstRecipeDetails.Items.Add(_ingredients);
                lstRecipeDetails.Items.Add("The description of recipe: ");
                lstRecipeDetails.Items.Add(_recipeManager.RecipeArray[_index].DescriptionRecipe);
        }

        private void PutIngredientsInString()
        {
            string[] ingredients = _recipeManager.RecipeArray[_index].ArrayOfIngredients;
            _ingredients = string.Join(",", ingredients.Where(ingredients => !string.IsNullOrEmpty(ingredients))); // lambda expression returns not empty/null strings.
        }

    }
}
