using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class Ingredient
    {
        private string _Name;
        private double _Price;

        public Ingredient()
        {
            _Name = "";
            _Price = 0.0;
        }

        public Ingredient(string name, double price)
        {
            _Name = name;
            _Price = price;
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
    }
}
