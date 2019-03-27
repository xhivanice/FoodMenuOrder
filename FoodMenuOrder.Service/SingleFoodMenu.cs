using FoodMenuOrder.FrameWork.Configure;
using FoodMenuOrder.Helper.Serialize;
using FoodMenuOrder.Model.Order;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMenuOrder.Service
{
    public sealed class SingleFoodMenu
    {
        /*
            单例生成菜单
                单例步骤
                1.构造函数私有化，避免别人直接new
                2.定义一个公开的方法，让别人来创建实例
         */

        // 定义一个静态变量来保存类的实例
        private volatile static SingleFoodMenu _SingleFoodMenu = null;

        //定义一把锁
        private static readonly object SingleLock = new object();

        public List<FoodModel> foodList = new List<FoodModel>();

        /// <summary>
        /// 定义私有构造函数，使外界不能创建该类实例
        /// </summary>
        private SingleFoodMenu()
        {

        }

        //定义公有方法提供一个全局访问点。
        public static SingleFoodMenu CreateInstance()
        {
            //双IF + LOCK
            if (_SingleFoodMenu == null)
            {
                lock (SingleLock)
                {
                    if (_SingleFoodMenu == null)
                    {
                        //string CurrentXMLPath = StaticConstraint.FoodMenuPath;//在后台配置固定文件
                        //string CurrentXMLPath = AppDomain.CurrentDomain.BaseDirectory; 获取程序集
                        string CurrentXMLPath = Path.GetFullPath("../../");
                        string FileName = StaticConstraint.XmlFoodPath;


                        if (string.IsNullOrWhiteSpace(FileName))
                        {
                            throw new Exception($"菜单对应的XML文件未配置");
                        }
                        //List<FoodModel> list = XmlHelper.FileToObject<List<FoodModel>>(CurrentXMLPath, FileName);
                        //_SingleFoodMenu = new SingleFoodMenu()
                        //{
                        //    foodList = list
                        //};
                        FoodModelList _foodModelList = XmlHelper.FileToObject<FoodModelList>(CurrentXMLPath, FileName);
                        _SingleFoodMenu = new SingleFoodMenu()
                        {
                            foodList = _foodModelList.menuList
                        };
                    }
                }
            }
            return _SingleFoodMenu;
        }
    }
}
