using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace counter
{
    public class DynamicMenu
    {
        private List<Food> _Foods = new List<Food>();

        public string ToJSON()
        {
            return "";
        }
        public void FromJSON(string jsonStr)
        {
            var jsonData = JsonConvert.DeserializeObject(jsonStr);

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
