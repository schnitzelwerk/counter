using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class Food
    {
        private string _Name;
        private float _Price;
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

        public float Price
        {
            get
            {
                float price = _Price;
                foreach(Extra add in _Extras)
                {
                    price += add.Price;
                }
                return price;
            }
        }
    }
}
