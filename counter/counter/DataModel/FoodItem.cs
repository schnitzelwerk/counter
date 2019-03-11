using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class FoodItem
    {
        private string _Name = "dummy";
        private double _Price = 0.0;
        private List<Ingredient> _Ingredients = new List<Ingredient>();
        private List<Extra> _Extras = new List<Extra>();

        public bool hasIngredients
        {
            get
            {
                return _Ingredients.Count > 0;
            }
        }

        public bool hasExtras
        {
            get
            {
                return _Extras.Count > 0;
            }
        }

        public double Price
        {
            get
            {
                double price = _Price;
                foreach (Extra add in _Extras)
                {
                    price += add.Price;
                }
                return price;
            }
        }
    }
}
