using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ABC__WPF
{
    internal class Recipe
    {
        private FoodCategory _FoodCategory;
        private string _descriptionRecipe;
        private string _nameRecipe;
        private string[] _arrayOfIngredients;
        public FoodCategory FoodCategory
        {
            get { return _FoodCategory;}
            set { _FoodCategory = value;}
        }
        public string NameRecipe
        {
            get { return _nameRecipe;}
            set { _nameRecipe = value;}
        }
        public string DescriptionRecipe
        {
            set { _descriptionRecipe = value;}
            get { return _descriptionRecipe;}
        }

        public Recipe() //string name, string description, FoodCategory foodCategory
        {

            }

    }
}
