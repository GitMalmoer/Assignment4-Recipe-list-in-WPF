﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4ABC__WPF
{
    public class RecipeManager
    {

        Recipe[] _recipeList;
        private int _maxNumOfElements;
        private int _index = -1;
        private int _objectCounter;

        public RecipeManager(int maxNumOfElements)
        {
            _maxNumOfElements = maxNumOfElements;
            _recipeList = new Recipe[_maxNumOfElements];

        }
        public Recipe[] RecipeArray
        {
            get { return _recipeList; }
            set { _recipeList = value;}
        }
        public int ObjectCounter 
        {
            get { return _objectCounter;}
        }
        public int Index 
        {
            get { return _index;}
            set { _index = value;} 
        }
        public void AddRecipeObject(Recipe recipe)
        {
            if (_recipeList[0] == null)
            {

                _recipeList[0] = recipe;
            }
            else if(_objectCounter != _maxNumOfElements)
                for (int i = 0; i < _maxNumOfElements; i++)
                {
                    if (_recipeList[i] == null)
                    {
                        _recipeList[i] = recipe;
                        break;
                    }
                }
            CountObjects();
        }
        public void DeleteAt(int index)
        {
            if (_index != -1)
            {
                _recipeList[index] = null;
            }
            CountObjects();
            MoveItemsToRight(index);
        }
        private void MoveItemsToRight(int index)
        {
                for (int i = index; i < _objectCounter; i++)
                {
                    _recipeList[i] = _recipeList[i + 1];
                    _recipeList[i + 1] = null;
                }
        }

        private void CountObjects()
        {
            int objectCounter = 0;
            for (int i = 0; i < _recipeList.Length ; i++)
            {
                if( _recipeList[i] != null )
                {
                    objectCounter++;
                }
                _objectCounter = objectCounter;
            }

        }

    }
}
