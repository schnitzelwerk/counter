using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace counter
{
    public class Order
    {
        UInt32 _Number;
        List<Food> Parts;

        public double Price
        {
            get
            {
                double price = 0;
                foreach (Food food in Parts)
                {
                    price += food.Price;
                }
                return price;
            }
        }

        public string Serialise()
        {
            string jsonRepr = JsonConvert.SerializeObject(Parts);
            return jsonRepr;
        }
    }
}
