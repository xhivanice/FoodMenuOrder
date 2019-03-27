using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Model;

namespace FoodMenuOrder.Factory
{
    public abstract class BaseFactory
    {
        public abstract AbstractFood CreateInstance();
    }
}
