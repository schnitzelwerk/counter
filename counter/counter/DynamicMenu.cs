using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace counter
{
    public class DynamicMenu
    {
        private List<Food> _Meals;
        private List<Ingredient> _Ingredients;
        private List<Extra> _Extras;

        public DynamicMenu(List<Food> menu, List<Ingredient> ingredients, List<Extra> extras)
        {
            _Meals = menu;
            _Ingredients = ingredients;
            _Extras = extras;
        }

        public List<Food> Meals
        {
            get
            {
                return _Meals;
            }
        }

        public List<Ingredient> Ingredients
        {
            get
            {
                return _Ingredients;
            }
        }

        public List<Extra> Extras
        {
            get
            {
                return _Extras;
            }
        }

        public Food getCopyMealByName(string name)
        {
            Food oldMeal = getMealByName(name);
            Food newMeal = new Food(oldMeal.Name, oldMeal.Price, oldMeal.Ingredients, oldMeal.Extras);
            return newMeal;
        }

        public Food getMealByName(string name)
        {
            Food tmpFood = _Meals.Find(M => M.Name == name);
            return tmpFood;
        }

        public Ingredient getIngredientByName(string name)
        {
            Ingredient tmpIngredient = _Ingredients.Find(I => I.Name == name);
            return tmpIngredient;
        }

        public Extra getExtraByName(string name)
        {
            Extra tmpExtra = _Extras.Find(E => E.Name == name);
            return tmpExtra;
        }
    }
    
}
