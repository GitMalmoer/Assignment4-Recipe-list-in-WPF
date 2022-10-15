using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ABC__WPF
{
    public class Recipe
    {
        private FoodCategory _FoodCategory;
        private string _descriptionRecipe;
        private string _nameRecipe;
        private string[] _arrayOfIngredients; // every object has inside arrayofingredients
        private int _MaxNumOfIngredients;
        // cant make them static because they are a part of every object not just a class
        private int _index = -1;
        private int _ingredientCounter;

        public Recipe(int maxNumOfIngredients) 
        {
            _MaxNumOfIngredients = maxNumOfIngredients;
            _arrayOfIngredients = new string[_MaxNumOfIngredients];
            _FoodCategory = FoodCategory.Other;

        }

        public int IngredientCounter
        {
            get { return _ingredientCounter; }
            set { _ingredientCounter = value; }
        }

        public int Index 
        {
            get { return _index; }
            set { _index = value; }
        }

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

        public  string[] ArrayOfIngredients
        {
            get { return _arrayOfIngredients;}
            set { _arrayOfIngredients = value;}
        }
        public  void AddToArrayOfIngredients(string ingredient)
        {
            if (_arrayOfIngredients[0] == null)
            {
                _arrayOfIngredients[0] = ingredient;
            }
            else
            {
                for(int i = 0;i<_arrayOfIngredients.Length;i++)
                {
                    if (_arrayOfIngredients[i] == null || _arrayOfIngredients[i] == string.Empty)
                    {
                        _arrayOfIngredients[i] = ingredient;
                        break;
                    }

                }
            }
        }

        public void DeleteAt(int index)
        {
            if(_index != -1)
            {
                ArrayOfIngredients[index] = String.Empty;
            }
            MoveItemsToLeft(index);
        }

        private void MoveItemsToLeft(int index)
        {
            if (index == _ingredientCounter - 1) // checks if index == last item. -1 because index starts from 0 and counter starts from 1.
            {
                ArrayOfIngredients[index] = string.Empty;
            }
            else
            {
                for (int i = index; i < _ingredientCounter; i++)
                {
                    ArrayOfIngredients[i] = ArrayOfIngredients[i + 1];
                    ArrayOfIngredients[i + 1] = String.Empty;
                }
            }
        }



    }
}
