using System.Linq;
using System.Xml.Linq;


namespace LINQtoXML
{
    class LinqXml47
    {
        private readonly string Path =
            $"{Program.BasePath}\\XMLs\\Task47In.xml";
        private readonly string OutPath =
            $"{Program.BasePath}\\XMLs\\Task47Out.xml";

        public LinqXml47()
        {
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            var secondLevel = doc.Descendants().Where(x => x.Descendants().Count() > 0);


            foreach (var elem in secondLevel)            
                elem.Elements().First().
                    AddAfterSelf(new XElement("has-comments", elem.DescendantNodes().Any(x => x is XComment)));
            

            doc.Save(OutPath);          
        }

    }
}
