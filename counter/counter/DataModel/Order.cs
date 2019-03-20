using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace counter
{
    public enum OrderState
    {
        OPEN = 0,
        CLOSED,
        FINISHED
    };

    public class Order
    {
        UInt32 _Number;
        List<Food> _Parts;
        OrderState _State;

        public Order()
        {
            _Number = 0;
            _Parts = new List<Food>();
            _State = OrderState.OPEN;
        }

        public double Price
        {
            get
            {
                double price = 0;
                foreach (Food food in _Parts)
                {
                    price += food.Price;
                }
                return price;
            }
        }

        public void placeOrder(string name)
        {
            
        }

        public List<Food> Parts
        {
            get
            {
                return _Parts;
            }
        }

        public OrderState State
        {
            get
            {
                return _State;
            }
        }

        public string Serialise()
        {
            string jsonRepr = JsonConvert.SerializeObject(_Parts);
            return jsonRepr;
        }
    }
}
