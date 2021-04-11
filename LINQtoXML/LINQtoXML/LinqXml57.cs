using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml57
    {
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task57In.xml";
        private readonly string OutPath =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task57Out.xml";

        private readonly string S1;
        private readonly string S2;

        public LinqXml57(string s1, string s2)
        {
            S1 = s1;
            S2 = s2;
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            doc.Root.Add(
                new XAttribute(XNamespace.Xmlns + "x", S1),
                new XAttribute(XNamespace.Xmlns + "y", S2));

            foreach (var elem in doc.Descendants())            
                elem.Name =
                    ((elem.Ancestors().Count() <= 1) ? (XNamespace)S1 : (XNamespace)S2) +
                    elem.Name.LocalName;

            // doc.Descendants().Attributes("xmlns").Remove();
            doc.Save(OutPath);
            //Console.WriteLine(doc);            
        }

    }
}
