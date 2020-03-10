using System;
using System.Collections.Generic;
using System.IO;

namespace Cw._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : @"C:\Users\s18312\Desktop\Cw.2\Cw.2\dane.csv";
            var resultPath = args.Length > 1 ? args[1] : @"C:\Users\s18312\Desktop\Cw.2\Cw.2\result.xml";
            var format = args.Length > 2 ? args[2] : "xml";

            // var lines = File.ReadLines(path);

            using (var stream = new StreamReader(File.OpenRead(path)))
            {
                string line = null; while ((line = stream.ReadLine()) != null)
                {
                    string[] student = line.Split(',');
                    var st = new Student
                    {
                        Imie = student[0], Nazwisko = student[1], Wydzial = student[2], Tryb = student[3],
                        Indeks = student[4], DataRoz = DateTime.Parse(student[5]), Mail = student[6],
                        ImieMatki = student[7], ImieOjca = student[8]
                    };
                    Console.WriteLine(st.toString());
                }
            }

            


             var parsedDate = DateTime.Parse("2020.03.10");
            Console.WriteLine(parsedDate);
            var today = DateTime.Today;
            Console.WriteLine(today.ToShortDateString());

        }
    }
}
