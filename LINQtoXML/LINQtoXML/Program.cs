using System;

namespace LINQtoXML
{
    class Program
    {
        public static readonly string BasePath = 
            System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

        static void Main(string[] args)
        {
            /* 
            LinqXml7 task1 = new LinqXml7();
            task1.Task();
            */

            /*
            LinqXml17 task2 = new LinqXml17();
            task2.Task(true);
            */

            /*
            LinqXml27 task3 = new LinqXml27();
            task3.Task();
            */

            /*
            LinqXml37 task4 = new LinqXml37();
            task4.Task();
            */

            /*
            LinqXml47 task5 = new LinqXml47();
            task5.Task();
            */

            /*
            LinqXml57 task6 = new LinqXml57("localhost", "wanhost");
            task6.Task();
            */

            /*
            LinqXml67 task7 = new LinqXml67();
            task7.Task();
            */

            
            LinqXml77 task8 = new LinqXml77();
            task8.Task();
            
        }
    }
}
