using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuOrder.Model;
using FoodMenuOrder.Service;

namespace FoodMenuOrder.AbstactFactory
{
    public class CantoneseCuisine : AbstractBaseFactory
    {
        public override AbstractFood CeateChicken()
        {
            return new Eggplant();
        }

        public override AbstractFood CeateFish()
        {
            return new Toufu();
        }

        public override AbstractFood CeatePig()
        {
            return new KungPaoChicken();
        }
    }
}
