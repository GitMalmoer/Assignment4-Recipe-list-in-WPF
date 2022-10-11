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
        public Recipe(int maxNumOfIngredients) //string name, string description, FoodCategory foodCategory
        {
            _MaxNumOfIngredients = maxNumOfIngredients;
            _arrayOfIngredients = new string[_MaxNumOfIngredients];
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
            //set { _arrayOfIngredients = value;}
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
                    if (_arrayOfIngredients[i] == null)
                    {
                        _arrayOfIngredients[i] = ingredient;
                        break;
                    }

                }
            }
        }



        

    }
}
