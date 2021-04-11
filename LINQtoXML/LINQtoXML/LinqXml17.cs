using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace LINQtoXML
{
    class LinqXml17
    {        
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\rdy.xml";

        public LinqXml17()
        {
        }

        public void FindElementsWithAnyDescendantTextNode()
        {
            XDocument doc = XDocument.Load(Path);

            var uniqueNames = doc.Descendants().Elements().
                Where(x => x.DescendantNodes().Where(y => y is XText).Any()).
                GroupBy(x => x.Name).OrderBy(x => x.Key.LocalName).Select(x => x.Key);

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"<{name}>");

                var txtElems = doc.Descendants().Elements().Where(x => x.Name == name).
                    Select(x => x.Value).OrderBy(x => x);

                Console.WriteLine("-----------------");
                foreach (var text in txtElems)
                    Console.WriteLine(text);
                Console.WriteLine("-----------------");
                Console.Write("\n\n");
            }
        }

        public void FindElementsWithDirectDescendantTextNode()
        {
            XDocument doc = XDocument.Load(Path);

            var uniqueNames = doc.DescendantNodes().Where(x => x is XText).Select(x => x.Parent).
                GroupBy(x => x.Name).OrderBy(x => x.Key.LocalName).Select(x => x.Key);

            foreach (var name in uniqueNames)
            {
                Console.WriteLine($"<{name}>");

                var txtElems = doc.Descendants().Elements().Where(x => x.Name == name).
                    Select(x => x.Value).OrderBy(x => x);

                Console.WriteLine("-----------------");
                foreach (var text in txtElems)
                    Console.WriteLine(text);
                Console.WriteLine("-----------------");
                Console.Write("\n\n");
            }
        }
    }
}
