using System;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml27
    {
        private readonly string Path =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\rdy.xml";
        private readonly string OutPath =
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\Task27.xml";

        public LinqXml27()
        {
        }

        public void Remove2ndLevelDescendantNodesExceptLastOnes()
        {
            XDocument doc = XDocument.Load(Path);

            var secondLevel = doc.Descendants().Where(x => (x.Parent != null && x.Parent.Parent == doc.Root));
            var toDel = secondLevel.Where(x => x.Nodes().Count() > 1).Select(x => x.Nodes().Where(y => y != x.LastNode).ToList()).ToList();

            foreach (var sndLvl in toDel)
            {
                foreach (var node in sndLvl)
                {
                    Console.WriteLine(node);

                    node.Remove();
                }
            }

            doc.Save(OutPath);
            //Console.WriteLine(doc);
        }

    }
}
