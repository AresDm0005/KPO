using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Linq;

namespace LINQtoXML
{
    class LinqXml7
    {
        private readonly string OutPath = 
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\XMLs\\try.xml";
        private readonly string Path = 
            "C:\\Users\\Arsen\\Desktop\\Универ\\Курс 2\\КПО\\Код\\KPO\\LINQtoXML\\LINQtoXML\\bin\\Debug\\Docs\\Task1.txt";

        private List<List<int>> nums;

        public LinqXml7()
        {            
        }

        public LinqXml7(string path)
        {
            Path = path;
        }

        public void GenerateXMLDocument()
        {
            string content = LoadDoc(Path);
            nums = ParseTxtDoc(content);

            GenerateXml();
        }

        private void GenerateXml()
        {
            XDocument doc = new XDocument(
                new XDeclaration("1.0", "windows-1251", null),
                new XElement("root",
                    nums.Select(line => new XElement("line", 
                        new XElement("sum-positive", line.Where(num => num > 0).Sum()),
                        line.Where(num => num < 0).Select(neg => new XElement("number-negative", neg))
                    ))));

            Console.WriteLine(doc);            
            doc.Save(OutPath);            
        }

        private string LoadDoc(string path)
        {
            string content = String.Empty;

            using (Stream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    content = reader.ReadToEnd();
                }
            }

            return content;
        }

        private List<List<int>> ParseTxtDoc(string content)
        {
            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var list = lines.Select(s => s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).
                Select(s => s.Select(it => Convert.ToInt32(it)).ToList()).ToList();

            return list;
        }
    }
}
