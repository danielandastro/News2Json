using System;
using Newtonsoft.Json;
using News2Json;
using System.Collections.Generic;

namespace Test
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            var json = new Json();
            var data = json.ReturnJson("http://feeds.bbci.co.uk/news/rss.xml");
            var list = new List<Data>();
            list = JsonConvert.DeserializeObject<List<Data>>(data);
            foreach(var item in list)
            {
                Console.WriteLine(item.title);
                Console.WriteLine(item.summary);
                Console.WriteLine(item.publishingDate);
                Console.WriteLine(item.source);
                Console.WriteLine();
            }
        }
    }
}
