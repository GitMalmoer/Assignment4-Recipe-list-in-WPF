using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ABC__WPF
{
    public class RecipeManager
    {
       
        Recipe[] _recipeList = new Recipe[200];
        private int _maxNumOfElements;
        private int _recipesCounter;

        public RecipeManager(int maxNumOfElements)
        {
            _maxNumOfElements = maxNumOfElements;
        }

        public Recipe[] RecipeArray 
        {
            get { return _recipeList;} 
        }

        public void AddRecipeObject(Recipe recipe)
        {
            if (_recipeList[0] == null)
            {
                
                _recipeList[0] = recipe;
            }
            else
                for(int i = 0; i<_maxNumOfElements;i++)
                {
                    if (
                        _recipeList[i] == null)
                    {
                        
                        
                        _recipeList[i] = recipe;
                        break;
                    }
                }
        }


    }
}
