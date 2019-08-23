using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.Script.Serialization;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {

            Person p = new Person();
            p.name = "小王";
            p.sex = "男";

            string str= JsonConvert.SerializeObject(p);

            string strJson= "{ \"name\":\"小王\",\"sex\":\"男\"}";

            Person person = JsonConvert.DeserializeObject<Person>(strJson);

            Console.WriteLine(person.name);

            JavaScriptSerializer jss = new JavaScriptSerializer();
            var person2 = jss.Deserialize<Person>(strJson);
            
            Console.WriteLine(person2.name);
        }
        public static T JsonToObj<T>(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            return jss.Deserialize<T>(json);

        }
        /// <summary>
        /// 转换对象到Json字符串
        /// </summary>
        /// <typeparam name="T">转换的对象类型</typeparam>
        /// <param name="t">转换的对象</param>
        /// <returns>得到的Json字符串</returns>
        public static string ObjToJson<T>(T t)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            StringBuilder sb = new StringBuilder();
            jss.Serialize(t, sb);
            return sb.ToString();
        }
    }
    public class Person
    {
        public string name { get; set; }
        public string sex { get; set; }
        //public int id { get; set; }
        //public string height { get; set; }
        //public string style { get; set; }
    }
}
