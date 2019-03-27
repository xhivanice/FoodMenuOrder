using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Service;
using FoodMenuOrder.Service.CommonMethod;
using FoodMenuOrder.Model;
using FoodMenuOrder.SimpleFactory;
using FoodMenuOrder.Factory;
using FoodMenuOrder.AbstactFactory;
using FoodMenuOrder.Model.Order;
using System.IO;
using System.Xml.Serialization;
using FoodMenuOrder.Helper.Log;
using System.Threading;
using FoodMenuOrder.Helper.Serialize;

namespace FoodMenuOrder
{
    class Program
    {
        static void Main(string[] args)
        {
            #region 1.普通方法展示
            {
                /*
                    普通方法通过对象创建(NEW)
                    引用左边是细节，右边也是细节(属于强依赖)
                 */
                //Console.WriteLine("**********Common method开始执行***********");

                //AbstractFood hotBeefFood = new HotBeef();
                //hotBeefFood.ShowMenuInfo();
                //hotBeefFood.FoodTaste();
                //hotBeefFood.FoodComment();

                //AbstractFood eggplantFood = new Eggplant();
                //eggplantFood.ShowMenuInfo();
                //eggplantFood.FoodTaste();
                //eggplantFood.FoodComment();

                //AbstractFood toufuFood = new Toufu();
                //toufuFood.ShowMenuInfo();
                //toufuFood.FoodTaste();
                //toufuFood.FoodComment();

                //AbstractFood kungPaoChickenFood = new KungPaoChicken();
                //kungPaoChickenFood.ShowMenuInfo();
                //kungPaoChickenFood.FoodTaste();
                //kungPaoChickenFood.FoodComment();

                //Console.WriteLine("**********Common method 结束***********");


            }
            #endregion


            #region 工厂方法展示
            {
                #region 简单工厂
                /*
                    优点
                    缺点
                 */

                //使用枚举值在简单工厂里面判断枚举值来创建对象
                //AbstractFood abstractFood = SimpleFactoryCreate.CreateInstanceByNormal(SimpleFactoryCreate.SimpleFactorFoodType.Toufu);
                //abstractFood.ShowMenuInfo();
                //abstractFood.FoodTaste();
                //abstractFood.FoodComment();

                //通过配置文件的枚举值来创建对象
                //AbstractFood abstractFood = SimpleFactoryCreate.CreateTnstanceByNormalConfigure();
                //abstractFood.ShowMenuInfo();
                //abstractFood.FoodTaste();
                //abstractFood.FoodComment();

                //通过反射来创建对象
                //AbstractFood abstactFactory = SimpleFactoryCreate.CreateInstance();
                //abstactFactory.ShowMenuInfo();
                //abstactFactory.FoodTaste();
                //abstactFactory.FoodComment();
                #endregion
            }

            {
                #region 工厂模式
                /*
                    优点：实现了开闭原则(开放扩展，封闭修改)。
                    缺点：如果要新建一种类就需要新建一个工厂
                 */
                //BaseFactory baseFactory = new FactoryHotBeef();
                //AbstractFood abstractFood = baseFactory.CreateInstance();
                //abstractFood.ShowMenuInfo();
                #endregion
            }

            {
                #region 抽象工厂
                /*
                    优点：
                    缺点:
                 */
                //AbstractBaseFactory abstractBaseFactory = new SichuanCuisine();
                //AbstractFood abstractFood = abstractBaseFactory.CeateChicken();
                //abstractFood.ShowMenuInfo();
                //abstractFood.FoodTaste();
                //abstractFood.FoodComment();
                #endregion
            }
            #endregion

            #region 单人
            {

                //Console.WriteLine("*****************控制台点餐系统***********************");
                //Console.WriteLine("********下面是我们的菜单，请选择要点菜的编号***********");

                //Console.WriteLine("*************************************");
                //#region 单例 菜单
                SingleFoodMenu menu = SingleFoodMenu.CreateInstance();
                if (menu != null && menu.foodList.Count() > 0)
                {
                    foreach (var menuList in menu.foodList)
                    {
                        Console.WriteLine($"菜品编码[{menuList.FoodNo}] 菜品名称:{menuList.FoodName} 售价:{menuList.FoodPrice}");
                    }
                }

                ////string fileName = @"C:\Users\Administrator\source\repos\FoodMenuOrder\FoodMenuOrder\ConfigureFile\FoodMenu.xml";//文件名称与路径
                ////using (Stream fStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
                ////{
                ////    List<FoodModel> pList = FoodDataFactory.BuildProgrammerList();
                ////    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<FoodModel>));//创建XML序列化器，需要指定对象的类型
                ////    xmlFormat.Serialize(fStream, pList);
                ////}


                ////using (Stream fStream = new FileStream(fileName, FileMode.Open, FileAccess.ReadWrite))
                ////{
                ////    XmlSerializer xmlFormat = new XmlSerializer(typeof(List<FoodModel>));//创建XML序列化器，需要指定对象的类型
                ////                                                                          //使用XML反序列化对象
                ////    fStream.Position = 0;//重置流位置
                ////    List<FoodModel> pList = pList = (List<FoodModel>)xmlFormat.Deserialize(fStream);
                ////}
                //#endregion


                //"点餐".WriteLogConsole("Please input food id  and press enter to continue...", "admin", ConsoleColor.Magenta);
                //while (true)
                //{
                //    if (!int.TryParse(Console.ReadLine(), out int input))
                //    {
                //        "识别输入：".WriteLogConsole("非数字类型,请重新输入", "admin", ConsoleColor.Red);
                //    }
                //    else
                //    {
                //        var selectFood = menu.foodList.FirstOrDefault(c => c.FoodNo == input.ToString());
                //        if (selectFood == null)
                //        {
                //            "菜品选择：".WriteLogConsole("您选择的菜本店没有", "admin", ConsoleColor.Red);
                //        }
                //        else
                //        {
                //            "正确选择:".WriteLogConsole(string.Format("您当前点了编码{0}的【{1}】，价格{2}", selectFood.FoodNo, selectFood.FoodName, selectFood.FoodPrice), "root", ConsoleColor.Gray);
                //            AbstractFood abstractFood = SimpleFactoryCreate.CreateInstanceByNormal((SimpleFactoryCreate.SimpleFactorFoodType)Enum.Parse(typeof(SimpleFactoryCreate.SimpleFactorFoodType), selectFood.FoodNo));
                //            abstractFood.ShowMenuInfo();
                //            abstractFood.FoodTaste();
                //            abstractFood.CookingFood(abstractFood.foodBaseModel.FirstOrDefault());
                //        }
                //    }
                //}

                #region 多人订购
                {
                    //Read the XML load configuration
                    //showMenu
                    CustomerList customerList = SingleCustomer.CreateInstance()._CustomerList;
                    Console.WriteLine($"{string.Join(",", customerList.name)}前来点餐");

                    List<Task> tasks = new List<Task>();
                    Dictionary<string, Dictionary<AbstractFood, int>> dicAll = new Dictionary<string, Dictionary<AbstractFood, int>>();
                    List<Dictionary<AbstractFood, int>> dicList = new List<Dictionary<AbstractFood, int>>(); 
                    foreach (var customerItem in customerList.name)
                    {
                        dicList.Add(new Dictionary<AbstractFood, int>());
                    }

                    int k = 0;

                    //遍历所有顾客
                    foreach (var item in customerList.name)
                    {
                        Dictionary<AbstractFood, int> foodDic = dicList[k++];
                        tasks.Add(Task.Run(()=> {
                            //随机点5个菜
                            List<FoodModel> list = menu.foodList.GetFoodListByRandom();
                            "已点菜单".WriteLogConsole($"客人{item},已点{string.Join(",", list.Select(s => s.FoodName))}", "shsjj", ConsoleColor.Red);
                            foreach (var foodList in list)
                            {
                                "开始烹饪：".WriteLogConsole($"菜名：{foodList.FoodName}即将开始:", "admin", ConsoleColor.Yellow);
                                //依次做菜、尝、点评
                                AbstractFood abstractFood = SimpleFactoryCreate.CreateInstanceByAssembly(foodList.AssemblyPath);
                                abstractFood.CookingFood(foodList);
                                abstractFood.FoodTaste();
                                int score = abstractFood.FoodComment();
                                foodDic.Add(abstractFood, score);
                            }
                            dicAll.Add(item, foodDic);
                            int foodMaxScore = foodDic.Values.Max();//获取字典内的最大分数值
                            //循环 查找字典内 值为最大分数的(有可能最大分数有多个)
                            foreach (var maxScoreItem in foodDic.Where(d => d.Value == foodMaxScore))
                            {
                                Console.WriteLine($"{item}点餐中,最高分食物是{maxScoreItem.Key.foodBaseModel[0].FoodName},最高分为{maxScoreItem.Value}");
                            }
                        }));//可以 每个线程把最高分返回回来
                    }
                    Task.WaitAll(tasks.ToArray());//一定要等客人都吃完

                    Console.WriteLine("*********************************");
                    int maxAll = dicList.Max(d => d.Values.Max());

                    for (int i = 0; i < customerList.name.Count; i++)
                    {
                        var dic = dicList[i];
                        foreach (var item in dic.Where(d => d.Value == maxAll))
                        {
                            Console.WriteLine($"{customerList.name[i]}最高分食物是{item.Key.foodBaseModel[0].FoodName},分数为{item.Value}");
                        }
                    }
                }
                #endregion
            }
            #endregion


            Console.Read();
        }
    }
}
