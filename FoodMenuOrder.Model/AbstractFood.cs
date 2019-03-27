using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Helper.Log;
using FoodMenuOrder.Helper.Serialize;
using FoodMenuOrder.Model.Order;

namespace FoodMenuOrder.Model
{
    public abstract class AbstractFood
    {
        /*
            包含品尝普通方法、点评虚方法(随机评分0到5分 )、做菜抽象方法,
         */

        public List<FoodModel> foodBaseModel { get; set; }

        /// <summary>
        /// 将文件名作为传参的构造函数
        /// </summary>
        /// <param name="configureName"></param>
        public AbstractFood(string configureName)
        {
            this.foodBaseModel = configureName.JsonFileToObject<List<FoodModel>>();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ShowMenuInfo()
        {
            string businessType = "ShowMenu";
            foreach (var fbList in foodBaseModel)
            {
                businessType.WriteLogConsole($"【编码】：{fbList.FoodNo}", "admin", ConsoleColor.White);
                businessType.WriteLogConsole($"【菜名】：{fbList.FoodName}", "admin", ConsoleColor.White);
                businessType.WriteLogConsole($"【价格】：{fbList.FoodPrice}", "admin", ConsoleColor.White);
                businessType.WriteLogConsole($"【简介】：{fbList.FoodIntroduction}", "admin", ConsoleColor.White);
            }
        }

        /// <summary>
        /// 品尝菜肴
        /// </summary>
        public void FoodTaste()
        {
            "品尝".WriteLogConsole($"{foodBaseModel[0].FoodName}还不错", "admin", ConsoleColor.White);
        }

        /// <summary>
        /// 随机打分
        /// </summary>
        public virtual int FoodComment()
        {
            Random random = new Random(DateTime.Now.Millisecond);
            int iScore = random.Next(0, 5);

            "评分".WriteLogConsole($"评分为{iScore}", "admin", ConsoleColor.White);
            return iScore;
        }

        public abstract void CookingFood(FoodModel foodModel);
    }
}
