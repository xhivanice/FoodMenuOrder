using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodMenuOrder.Model;

namespace FoodMenuOrder.AbstactFactory
{
    public abstract class AbstractBaseFactory
    {
        public abstract AbstractFood CeateFish();
        public abstract AbstractFood CeatePig();
        public abstract AbstractFood CeateChicken();
    }
}
