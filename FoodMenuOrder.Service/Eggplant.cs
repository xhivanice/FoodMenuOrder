using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Model;
using FoodMenuOrder.Model.Order;
using FoodMenuOrder.Helper.Log;

namespace FoodMenuOrder.Service
{
    public class Eggplant : AbstractFood
    {
        public Eggplant() : base("Eggplant.json")
        {
        }

        public override void CookingFood(FoodModel foodModel)
        {
            "烹饪：".WriteLogConsole($"后厨正在烹饪{foodModel.FoodName},请您耐心等待", "admin", ConsoleColor.DarkGreen);
        }
    }
}
