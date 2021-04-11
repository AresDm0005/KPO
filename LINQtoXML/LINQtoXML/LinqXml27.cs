using System.Linq;
using System.Xml.Linq;

namespace LINQtoXML
{
    class LinqXml27
    {
        private readonly string Path =
            $"{Program.BasePath}\\XMLs\\Task27In.xml";
        private readonly string OutPath =
            $"{Program.BasePath}\\XMLs\\Task27Out.xml";

        public LinqXml27()
        {
        }

        public void Task()
        {
            XDocument doc = XDocument.Load(Path);

            var secLvlElems = doc.Descendants().Where(x => (x.Parent != null && x.Parent.Parent == doc.Root)).
                Where(x => x.Nodes().Count() > 1);

            foreach (var elem in secLvlElems)
                elem.ReplaceNodes(elem.LastNode);

            doc.Save(OutPath);            
        }
    }
}
