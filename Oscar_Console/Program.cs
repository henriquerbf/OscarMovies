using Oscar.Domain.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;

namespace Oscar_Console
{
    class Program
    {

        static void Main(string[] args)
        {
            Thread t3 = new Thread(new ThreadStart(Impar))
            {
                Name = $"impar: "
            };

            Thread t2 = new Thread(new ThreadStart(Par))
            {
                Name = $"par: "
            };

            Thread.CurrentThread.Name = "impar_par: ";

            t3.Start();

            t2.Start();

            Impar_par();

            Console.ReadKey();





            InitialThread(); //executa thread em paralelo
            Console.ReadKey();

            Console.WriteLine("Path: ");
            var path = @"C:\Users\henri\Documents\GitHub\OscarMovies\marvel.xml";

            //var path = Path.Combine(Environment.CurrentDirectory, $@"Marvel.xml");

            if (File.Exists(path))
                Console.WriteLine("Path does exist!");
            else
                Console.WriteLine("Path doesn't exist!");

            string content = File.ReadAllText(path);



            List<Movie> movies = new List<Movie>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(content);

            long ticksMax = long.MinValue;
            long ticksMin = long.MaxValue;
            long ticksTotal = 0;

            Console.WriteLine(DateTime.Now);
            for (int j = 0; j < 1000; j++)
            {
                var ticks = DateTime.Now.Ticks;
                for (int i = 0; i < 10; i++)
                {
                    movies.Add(new Movie
                    {
                        Id_Received = int.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText),
                        Title = doc.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText,
                        Release_Date = DateTime.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText)
                    });
                }

                ticks = DateTime.Now.Ticks - ticks;

                if ((ticks > ticksMax) && (j != 0))
                    ticksMax = ticks;

                if (ticks < ticksMin)
                    ticksMin = ticks;

                ticksTotal += ticks;

                //Console.WriteLine($"teste {j}: {ticks}");
            }

            Console.WriteLine("Not Threading");
            Console.WriteLine($"ticksMax: {ticksMax}");
            Console.WriteLine($"ticksMin: {ticksMin}");
            Console.WriteLine($"Media: {ticksTotal / 1000}");
            Console.WriteLine(DateTime.Now);


            //Thread
            ticksMax = long.MinValue;
            ticksMin = long.MaxValue;
            ticksTotal = 0;
            Console.WriteLine(DateTime.Now);
            for (int j = 0; j < 1000; j++)
            {
                var ticks = DateTime.Now.Ticks;
                for (int i = 0; i < 10; i++)
                {

                    Thread t1 = new Thread(new ThreadStart(() => Add(movies, doc, i)))
                    {
                        Name = $"Thread - {1}"
                    };
                    t1.Start();
                }

                ticks = DateTime.Now.Ticks - ticks;

                if ((ticks > ticksMax) && (j != 0))
                    ticksMax = ticks;

                if (ticks < ticksMin)
                    ticksMin = ticks;

                ticksTotal += ticks;
            }

            Console.WriteLine("Threading");
            Console.WriteLine($"ticksMax: {ticksMax}");
            Console.WriteLine($"ticksMin: {ticksMin}");
            Console.WriteLine($"Media: {ticksTotal / 1000}");
            Console.WriteLine(DateTime.Now);
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

        public static void Run()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread Atual - " + Thread.CurrentThread.Name + i);

                Thread.Sleep(1000);
            }
        }
        public static void Par()
        {
            for (int i = 0; i < 1000; i+=2)
            {
                Console.WriteLine("Thread - " + Thread.CurrentThread.Name + i);

                Thread.Sleep(1000);
            }
        }
        public static void Impar_par()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.WriteLine("Thread - " + Thread.CurrentThread.Name + i);

                Thread.Sleep(1000);
            }
        }
        public static void Impar()
        {
            for (int i = 1; i < 1000; i+=2)
            {   
                Console.WriteLine("Thread - " + Thread.CurrentThread.Name + i);

                Thread.Sleep(1000);
            }
        }

        public static void Add(List<Movie> movies, XmlDocument doc, int i)
        {
            Thread.Sleep(1000);

            movies.Add(new Movie
            {
                Id_Received = int.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[0].InnerText),
                Title = doc.DocumentElement.ChildNodes[i].ChildNodes[1].InnerText,
                Release_Date = DateTime.Parse(doc.DocumentElement.ChildNodes[i].ChildNodes[2].InnerText)
            });
        }

        public static void InitialThread()
        {
            Console.WriteLine("Thread principal iniciada");
            Thread.CurrentThread.Name = "Principal - ";

            Thread t1 = new Thread(new ThreadStart(Run))
            {
                Name = "Secundária - "
            };

            t1.Start();

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Thread atual  - " + Thread.CurrentThread.Name + i);
                Thread.Sleep(1000);

            }

            Console.WriteLine("Thread Principal terminada");
            Console.Read();
        }
    }
}
