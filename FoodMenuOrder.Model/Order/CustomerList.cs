using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuOrder.Model.Order
{
    [Serializable]
    public class CustomerList
    {
        [NonSerialized]
        public int id;

        public List<string> name { get; set; }
    }
}
