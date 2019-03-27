using FoodMenuOrder.FrameWork.Configure;
using FoodMenuOrder.Helper.Log;
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
    public sealed class SingleCustomer
    {
        //构造函数私有化
        private SingleCustomer()
        {}

        //lock
        private static readonly object _CustomerLock = new object();

        //定义一个静态的字段，用来储存类SingleCustomer 的实例
        private volatile static SingleCustomer _SingleCustomer = null;

        public CustomerList _CustomerList = new CustomerList();

        public static SingleCustomer CreateInstance()
        {
            if (_SingleCustomer == null)
            {
                lock (_CustomerLock)
                {
                    if (_SingleCustomer == null)
                    {
                        string CurrentXMLPath = Path.GetFullPath("../../");
                        string FileName = StaticConstraint.XmlCustomerPath;

                        if (string.IsNullOrWhiteSpace(FileName))
                        {
                            throw new Exception($"菜单对应的XML文件未配置");
                        }

                        CustomerList list = XmlHelper.FileToObject<CustomerList>(CurrentXMLPath, FileName);
                        _SingleCustomer = new SingleCustomer()
                        {
                            _CustomerList = list
                        };
                    }
                }
            }

            return _SingleCustomer;
        }
    }
}
