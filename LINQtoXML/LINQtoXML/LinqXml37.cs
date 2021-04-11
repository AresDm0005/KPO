using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml37
    {
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task37In.xml";
        private readonly string OutPath =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task37Out.xml";

        public LinqXml37()
        {
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            var secondLevel = doc.Descendants().Where(x => (x.Parent != null && x.Parent.Parent == doc.Root)).
                Where(x => x.Descendants().Any());

            foreach(var elem in secondLevel)            
                elem.SetValue(elem.Value);

            doc.Save(OutPath);
            //Console.WriteLine(doc);            
        }

    }
}
