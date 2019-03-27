using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Model;
using FoodMenuOrder.Service;

namespace FoodMenuOrder.Factory
{
    public class FactoryHotBeef : BaseFactory
    {
        public override AbstractFood CreateInstance()
        {
            return new HotBeef();
        }
    }
}
