using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml47
    {
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task47In.xml";
        private readonly string OutPath =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task47Out.xml";

        public LinqXml47()
        {
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            var secondLevel = doc.Descendants().Where(x => x.Descendants().Count() > 0);


            foreach (var elem in secondLevel)
            {
                elem.Elements().First().
                    AddAfterSelf(new XElement("has-comments", elem.DescendantNodes().Any(x => x is XComment)));
            }

            doc.Save(OutPath);
            //Console.WriteLine(doc);            
        }

    }
}
