using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Threading;
using FoodMenuOrder.FrameWork.Configure;

namespace FoodMenuOrder.Helper.Log
{
    public static class LogHelper
    {
        /// <summary>
        /// 读取日志存放的绝对路径
        /// </summary>
        private static readonly string LogPath = StaticConstraint.LogPath;

        /// <summary>
        /// 获取当前程序所在路径
        /// </summary>
        private static string LogPath2 = AppDomain.CurrentDomain.BaseDirectory;


        /// <summary>
        /// 静态的构造函数，由CLR保证。仅在程序运行时启动一次
        /// </summary>
        static LogHelper()
        {
            if (!Directory.Exists(LogPath))
            {
                Directory.CreateDirectory(LogPath);
            }
        }

        private static readonly object LogLock = new object();
        public static void WriteLog(this string sBusinessNumber, string sLogMessage,string sStaffID)
        {
            //定义一个IO写入流
            StreamWriter streamWriter = null;

            try
            {
                string fileName = $"LogFor{DateTime.Now.ToString("yyyy-MM-dd")}.txt";
                string totalPath = Path.Combine(LogPath, fileName);

                lock (LogLock)
                {
                    using (streamWriter = File.AppendText(totalPath))
                    {
                        streamWriter.WriteLine($"{DateTime.Now}:[{sBusinessNumber}] write {sLogMessage}。[{sStaffID}]");
                    }
                }

            }
            catch(Exception ex)
            {
                Console.WriteLine($"LogInsert error({ex.Message})");
            }
            //finally
            //{
            //    if (streamWriter != null)
            //    {
            //        streamWriter.Flush();
            //        streamWriter.Close();
            //        streamWriter.Dispose();
            //    }
            //}
        }

        public static void WriteLogConsole(this string sBusinessNumber, string sLogMessage, string sStaffID,ConsoleColor color)
        {
            sBusinessNumber.WriteLog(sLogMessage, sStaffID);

            lock (LogLock)
            {
                foreach (var itemChar in sLogMessage.ToCharArray())
                {
                    Thread.Sleep(100);
                    Console.ForegroundColor = color;
                    Console.Write($"{itemChar}");
                }
                Console.WriteLine("");
            }
        }
    }
}
