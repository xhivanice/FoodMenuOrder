using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FoodMenuOrder.Model;
using FoodMenuOrder.FrameWork.Configure;
using System.Reflection;
using FoodMenuOrder.Service;

namespace FoodMenuOrder.SimpleFactory
{
    public static class SimpleFactoryCreate
    {
        /// <summary>
        /// 通过枚举来创建
        /// </summary>
        /// <param name="foodType"></param>
        /// <returns></returns>
        public static AbstractFood CreateInstanceByNormal(SimpleFactorFoodType foodType)
        {
            switch (foodType)
            {
                case SimpleFactorFoodType.Eggplant:
                    return new Eggplant();
                case SimpleFactorFoodType.HotBeef:
                    return new HotBeef();
                case SimpleFactorFoodType.KungPaoChicken:
                    return new KungPaoChicken();
                case SimpleFactorFoodType.Toufu:
                    return new Toufu();
                default:
                    throw new Exception("对不起,本店没有这道菜");
            }
        }


        /// <summary>
        /// 根据配置文件来创建
        /// </summary>
        /// <param name="foodType"></param>
        /// <returns></returns>
        public static AbstractFood CreateTnstanceByNormalConfigure()
        {
            SimpleFactorFoodType smFoodType = (SimpleFactorFoodType)Enum.Parse(typeof(SimpleFactorFoodType),StaticConstraint.AbstractFoodType);
            return CreateInstanceByNormal(smFoodType);
        }


        public static AbstractFood CreateInstance()
        {
            Assembly assembly = Assembly.Load(StaticConstraint.AssemblyPath);
            Type type = assembly.GetType(StaticConstraint.AssemblyClassPath);

            return (AbstractFood)Activator.CreateInstance(type);
        }

        public static AbstractFood CreateInstanceByAssembly(string AssemblyPath)
        {
            Assembly assembly = Assembly.Load(AssemblyPath.Split(',')[0]);
            Type type = assembly.GetType(AssemblyPath.Split(',')[1]);

            return (AbstractFood)Activator.CreateInstance(type);
        }
        public enum SimpleFactorFoodType
        {
            Eggplant = 3,
            HotBeef = 2,
            KungPaoChicken = 4,
            Toufu = 1
        }
    }
}
