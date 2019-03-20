using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class Food
    {
        private string _Name;
        private double _Price;
        private List<string> _Ingredients;
        private Dictionary<string, bool> _IngredientConf;
        private List<string> _Extras;
        private Dictionary<string, bool> _ExtraConf;

        public Food(string name, double price, List<string> ingredients, List<string> extras)
        {
            _Name = name;
            _Price = price;
            _Ingredients = new List<string>(ingredients);
            _Extras = new List<string>(extras);
        }

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

        public double calcPrice
        {
            get
            {
                double price = _Price;
                foreach (string add in _Extras)
                {
                    //price += add.Price;
                }
                return price;
            }
        }

        public string Name
        {
            get
            {
                return _Name;
            }
        }

        public double Price
        {
            get
            {
                return _Price;
            }
        }

        public List<string> Ingredients
        {
            get
            {
                return _Ingredients;
            }
        }

        public List<string> Extras
        {
            get
            {
                return _Extras;
            }
        }
    }
}
