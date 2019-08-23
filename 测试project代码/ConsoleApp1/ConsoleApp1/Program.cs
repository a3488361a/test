using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();


            Dictionary<string, string> res = new Dictionary<string, string>();
            res.Add("Token", "633333");
            
            Console.WriteLine( jss.Serialize(res));

            //Person p = new Person();
            //p.name = "小王";
            //p.sex = "男";
            //p.school = new School() {
            //    city = new City() {
            //        id = 1,
            //        name = "北京"
            //    },
            //    id = 1,
            //    height = "1000"
            //};

            // string s= jss.Serialize(p);

            // Console.WriteLine(s);

            string strJson = "{\"name\":\"小王\",\"sex\":\"男\",\"id\":0,\"height\":null,\"style\":null,\"school\":{\"id\":1,\"height\":\"1000\",\"city\":{\"name\":\"北京\",\"sex\":null,\"id\":1}}}";
            
            var person2 = jss.Deserialize<Person>(strJson);

            Console.WriteLine(person2.name);

            string newStr = jss.Serialize(person2);
            Console.WriteLine(newStr);
        }
    }
    public class Person
    {
        public string name { get; set; }
        public string sex { get; set; }
        public int id { get; set; }
        public string height { get; set; }
        public string style { get; set; }
        //public School school { get; set; }
    }
    public class School
    {
        public int id { get; set; }
        public string height { get; set; }
        public City city { get; set; }
    }
    public class City
    {
        public string name { get; set; }
        public string sex { get; set; }
        public int id { get; set; }
    }
}
