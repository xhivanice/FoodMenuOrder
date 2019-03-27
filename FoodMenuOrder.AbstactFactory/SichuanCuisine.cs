using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuOrder.Model;
using FoodMenuOrder.Service;

namespace FoodMenuOrder.AbstactFactory
{
    public class SichuanCuisine : AbstractBaseFactory
    {
        public override AbstractFood CeateChicken()
        {
            return new KungPaoChicken();
        }

        public override AbstractFood CeateFish()
        {
            return new Toufu();
        }

        public override AbstractFood CeatePig()
        {
            return new HotBeef();
        }
    }
}
