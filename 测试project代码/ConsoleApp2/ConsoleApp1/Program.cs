using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            //long lTime = long.Parse("1566371659201" + "0000");  //说明下，时间格式为13位后面补加4个"0"，如果时间格式为10位则后面补加7个"0",至于为什么我也不太清楚，也是仿照人家写的代码转换的
            //TimeSpan toNow = new TimeSpan(lTime);
            //DateTime dtResult = dtStart.Add(toNow); //得到转换后的时间

            string timestampStr = "1566373973140";
            long timestamp = long.Parse(timestampStr);
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0).AddMilliseconds(timestamp);
            Console.WriteLine(dt);
            Console.WriteLine(dt.ToLocalTime());
        }
    }
}
