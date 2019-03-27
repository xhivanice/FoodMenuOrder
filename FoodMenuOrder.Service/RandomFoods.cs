using FoodMenuOrder.Model.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuOrder.Service
{
    public static class RandomFoods
    {
        public static List<FoodModel> GetFoodListByRandom(this List<FoodModel> foodModelList,int takeNum = 5)
        {
            var foodList = foodModelList.Select(a => new { a,newID= Guid.NewGuid()}).OrderBy(b => b.newID);

            if (takeNum > 0)
            {
                return foodList.Take(takeNum).Select(c => c.a).ToList();
            }
            else
            {
                return foodList.Select(c => c.a).ToList();
            }
        }
    }
}
