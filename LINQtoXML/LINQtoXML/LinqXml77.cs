using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml77
    {
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task77In.xml";
        private readonly string OutPath =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task77Out.xml";

        public LinqXml77()
        {
        }

        private static int ParseTime(string time)
        {
            time = time.Substring(2);
            time = time.Substring(0, time.Length - 1);
            var t = time.Split(new char[] { 'H' }).Select(x => Convert.ToInt32(x)).ToArray();

            return 60 * t[0] + t[1];
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            doc.Root.Name = "years";

            doc.Root.ReplaceNodes(doc.Root.Elements().GroupBy(x => x.Element("year").Value).OrderBy(x => Convert.ToInt32(x.Key)).
                Select(x => new XElement($"y{x.Key}",
                Enumerable.Range(1, 12).Select(y => new XElement($"m{y}",                    
                    new XAttribute("total-time",
                        doc.Root.Elements("client").Where(a => a.Element("year").Value == x.Key).
                            Where(a => Convert.ToInt32(a.Element("month").Value) == y).Sum(a => ParseTime(a.Attribute("time").Value))),

                    new XAttribute("client-count",
                         doc.Root.Elements("client").Where(a => a.Element("year").Value == x.Key).
                            Where(a => Convert.ToInt32(a.Element("month").Value) == y).Count())
                    )))));
            
            doc.Save(OutPath);
            //Console.WriteLine(doc);            
        }

    }
}
