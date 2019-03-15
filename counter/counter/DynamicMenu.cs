using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace counter
{
    public class DynamicMenu
    {
        private List<Food> _Foods;

        public DynamicMenu(List<Food> menu)
        {
            _Foods = menu;
        }

        public List<Food> Foods
        {
            get
            {
                return _Foods;
            }
        }


    }
    
}
