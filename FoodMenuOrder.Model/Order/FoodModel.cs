using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FoodMenuOrder.Model.Order
{
    [Serializable]
    [XmlRoot(Namespace = "", IsNullable = false, ElementName = "RequestResult")]
    public partial class FoodModel
    {
        public string FoodNo { get; set; }
        public string FoodName { get; set; }
        public long FoodPrice { get; set; }
        public string FoodIntroduction { get; set; }

        /// <summary>
        /// 菜品的程序集路径
        /// </summary>
        public string AssemblyPath { get; set; }
    }

    public class FoodDataFactory
    {
        public static object FoodNo { get; private set; }

        public static List<FoodModel> BuildProgrammerList()
        {
            List<FoodModel> list = new List<FoodModel>();
            list.Add(new FoodModel() {
                FoodNo="1",
                FoodName= "麻婆豆腐",
                FoodPrice=12,
                FoodIntroduction= "豆腐切丁后最好不要用开水烫，只用淡盐水浸泡即可。"
            });

            list.Add(new FoodModel()
            {
                FoodNo = "2",
                FoodName = "水煮牛肉",
                FoodPrice = 38,
                FoodIntroduction = "特色传统名菜，属川菜系。主料瘦黄牛肉。辅料豆芽、鸭血"
            });

            return list;
        }
     }
}
