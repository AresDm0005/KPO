using System;
using System.Linq;
using System.Xml.Linq;

namespace LINQtoXML
{
    class LinqXml17
    {        
        private readonly string Path =
            $"{Program.BasePath}\\XMLs\\Task17In.xml";

        public LinqXml17()
        {
        }

        public void Task(bool direct)
        {
            XDocument doc = XDocument.Load(Path);


            var uniqueNames =
                direct ?
                    doc.DescendantNodes().Where(x => x is XText).Select(x => x.Parent).
                        GroupBy(x => x.Name).OrderBy(x => x.Key.LocalName).Select(x => x.Key)
                :   doc.Descendants().Elements().
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
    }
}
