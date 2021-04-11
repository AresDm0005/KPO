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
            $"{Program.BasePath}\\XMLs\\Task7.xml";
        private readonly string Path = 
            $"{Program.BasePath}\\Docs\\Task7.txt";

        public LinqXml7()
        {            
        }

        public void Task()
        {
            var nums = LoadAndParseDoc(Path);

            XDocument doc = new XDocument(
                new XDeclaration("1.0", "windows-1251", null),
                new XElement("root",
                    nums.Select(line => new XElement("line",
                        new XElement("sum-positive", line.Where(num => num > 0).Sum()),
                        line.Where(num => num < 0).Reverse().Select(neg => new XElement("number-negative", neg))
                    ))));

            doc.Save(OutPath);
        }

        private List<List<int>> LoadAndParseDoc(string path)
        {
            string content = String.Empty;

            using (Stream fs = new FileStream(path, FileMode.Open))
            {
                using (StreamReader reader = new StreamReader(fs))
                {
                    content = reader.ReadToEnd();                    
                }
            }

            string[] lines = content.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            var lists = lines.Select(s => s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)).
                Select(s => s.Select(it => Convert.ToInt32(it)).ToList()).ToList();

            return lists;
        }
    }
}
