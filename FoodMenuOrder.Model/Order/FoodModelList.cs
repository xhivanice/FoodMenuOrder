using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuOrder.Model.Order
{
    [Serializable]
    public partial class FoodModelList
    {
        public List<FoodModel> menuList { get; set; }
    }
}
