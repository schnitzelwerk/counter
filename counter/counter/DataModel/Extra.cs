using System;
using System.Collections.Generic;
using System.Text;

namespace counter
{
    public class Extra
    {
        private string _Name;
        private double _Price;

        public Extra()
        {
            _Name = "";
            _Price = 0.0;
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
