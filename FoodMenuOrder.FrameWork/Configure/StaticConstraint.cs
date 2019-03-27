using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;

namespace FoodMenuOrder.FrameWork.Configure
{
    public class StaticConstraint
    {
        /// <summary>
        /// 日志保存的物理地址
        /// </summary>
        public static readonly string LogPath = ConfigurationManager.AppSettings["LogFolder"];

        /// <summary>
        /// JSON 文件保存的物理地址
        /// </summary>
        public static readonly string JsonPath = ConfigurationManager.AppSettings["JsonPath"];

        /// <summary>
        /// 菜单路径 XML
        /// </summary>
        public static readonly string FoodMenuPath = ConfigurationManager.AppSettings["FoodMenu"];

        /// <summary>
        /// 相对路径的XML菜单地址 
        /// </summary>
        public static readonly string XmlFoodPath = ConfigurationManager.AppSettings["XmlFoodPath"];
        public static readonly string XmlCustomerPath = ConfigurationManager.AppSettings["XmlCustomerPath"];
        

        /// <summary>
        /// 枚举创建简单工厂
        /// </summary>
        public static readonly string AbstractFoodType = ConfigurationManager.AppSettings["AbstractFoodType"];

        /// <summary>
        /// 反射程序集路径
        /// </summary>
        public static readonly string AssemblyConfigure = ConfigurationManager.AppSettings["AssemblyConfigure"];
        public static readonly string AssemblyPath = AssemblyConfigure.Split(',')[0];
        public static readonly string AssemblyClassPath = AssemblyConfigure.Split(',')[1];



    }
}
