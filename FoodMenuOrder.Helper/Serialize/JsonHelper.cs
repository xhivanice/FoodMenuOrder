using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using FoodMenuOrder.FrameWork.Configure;

namespace FoodMenuOrder.Helper.Serialize
{
    public static class JsonHelper
    {
        /// <summary>
        /// JsonConvert.SerializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJson<T>(this T obj)
        {
            return JsonConvert.SerializeObject(obj);
        }


        /// <summary>
        /// JsonConvert.DeserializeObject
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T ToObject<T>(this string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public static T JsonFileToObject<T>(this string fileName)
        {
            string fullName = Path.Combine(StaticConstraint.JsonPath, fileName);

            if (File.Exists(fullName))
            {
                string json = File.ReadAllText(fullName, Encoding.Default);
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                throw new Exception($"json文件 {fullName} 不存在");
            }
        }
    }
}
