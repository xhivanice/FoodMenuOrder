using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Linq;
using System.Xml.Serialization;
using FoodMenuOrder.FrameWork.Configure;

namespace FoodMenuOrder.Helper.Serialize
{

    /// <summary>
    /// 使用序列化完成的
    /// </summary>
    public class XmlHelper
    {
        /// <summary>
        /// 通过XmlSerializer序列化实体为字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string ModelToXml<T>(T t) where T : new()
        {
            XmlSerializer xmlSerializer = new XmlSerializer(t.GetType());
            Stream stream = new MemoryStream();

            xmlSerializer.Serialize(stream, t);
            stream.Position = 0;

            StreamReader streamReader = new StreamReader(stream);
            return streamReader.ReadToEnd();
        }


        /// <summary>
        /// 字符串序列化成XML
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="content"></param>
        /// <returns></returns>
        public static T StrToXml<T>(string content) where T : new()
        {
            using (MemoryStream stream = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(content)))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                return (T)xmlFormat.Deserialize(stream);
            }
        }

        /// <summary>
        /// 文件反序列化成实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static T FileToObject<T>(string filePath,string fileName) where T : new()
        {
            string fullName = Path.Combine(filePath, fileName);
            if (!File.Exists(fullName))
                throw new Exception(string.Format("配置文件{0}不存在",fileName));

            using (Stream fStream = new FileStream(fullName, FileMode.Open, FileAccess.ReadWrite))
            {
                XmlSerializer xmlFormat = new XmlSerializer(typeof(T));
                fStream.Position = 0;//重置流位置
                return (T)xmlFormat.Deserialize(fStream);
            }
        }
    }
}
