using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class Food
    {
        public string Name;
        public double Price;
        public List<string> Ingredients;
        public List<string> Extras;

        public Food()
        {
            Name = "";
            Price = 0.0;
            Ingredients = new List<string>();
            Extras = new List<string>();
        }

        public bool hasIngredients
        {
            get
            {
                return Ingredients.Count > 0;
            }
        }

        public bool hasExtras
        {
            get
            {
                return Extras.Count > 0;
            }
        }

        public double calcPrice
        {
            get
            {
                double price = Price;
                foreach(string add in Extras)
                {
                    //price += add.Price;
                }
                return price;
            }
        }
    }
}
