using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Oscar_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Path: ");
            var path = @"C:\Users\henri\Documents\GitHub\Oscar_API\marvel.xml";
            string content;

            if (File.Exists(path))
                Console.WriteLine("Path does exist!");
            else
                Console.WriteLine("Path doesn't exist!");

            content = File.ReadAllText(path);
            //Console.WriteLine(content);
            

            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);

            string valor = doc.DocumentElement.ChildNodes[0].InnerXml;

            var movies = new List<Movie>();

            for (int i = 0; i < 10; i++)
            {
                movies.Add(new Movie
                {
                    Title = doc.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText,
                    Release_Date = DateTime.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText)
                });
            }


            Console.WriteLine(valor);
            Console.ReadKey();

            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    content = stream.;
            //}


            //XmlNodeList itemList = xml.SelectNodes("//root/items/item[@id='" + xn.Attributes["idref"].Value + "']");
            //XmlNode node = doc.DocumentElement.SelectSingleNode("/book/title");



            //var serializer = new XmlSerializer(typeof(Films), new XmlRootAttribute("films"));

            ////Use a filestrem instance to opem the Xml file
            //using (var stream = new FileStream(path, FileMode.Open))
            //{
            //    //Deserializer the content of the Xml file in the films variable
            //    films = (Films)serializer.Deserialize(stream);
            //}
            //string contents = File.ReadAllText(@"C:\temp\test.txt");


            Console.ReadKey();
        }
    }
}
