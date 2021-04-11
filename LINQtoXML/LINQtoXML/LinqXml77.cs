using System;
using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml77
    {
        private readonly string Path =
            $"{Program.BasePath}\\XMLs\\Task77In.xml";
        private readonly string OutPath =
            $"{Program.BasePath}\\XMLs\\Task77Out.xml";

        public LinqXml77()
        {
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            doc.Root.Name = "addresses";

            doc.Root.ReplaceNodes(
                (doc.Root.Elements().OrderBy(x => Convert.ToInt32(x.Attribute("house").Value)).
                ThenBy(x => Convert.ToInt32(x.Attribute("flat").Value))).
                    Select(x => new XElement($"address{x.Attribute("house").Value}-{x.Attribute("flat").Value}",
                        new XAttribute("name", x.Attribute("name").Value),
                        new XAttribute("debt", x.Value)))
                    );

            doc.Save(OutPath);        
        }
    }
}
