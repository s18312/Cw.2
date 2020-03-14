using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace Cw._2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = args.Length > 0 ? args[0] : @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\dane.csv";
            var resultPath = args.Length > 1 ? args[1] : @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\result.xml";
            var format = args.Length > 2 ? args[2] : "xml";
            var hash = new HashSet<Student>(new OwnComparer());


            try{
                if (!File.Exists(path))
                {
                    throw new FileNotFoundException("Plik z danymi nie istnieje");
                }
                if (!File.Exists(resultPath))
                {
                    throw new FileNotFoundException("Plik wynikowy nie istnieje");
                }

                using (var stream = new StreamReader(File.OpenRead(path)))
                {
                    string line = null; while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');
                        var st = new Student
                        {
                            Imie = student[0],
                            Nazwisko = student[1],
                            Wydzial = student[2],
                            Tryb = student[3],
                            Indeks = student[4],
                            DataRoz = DateTime.Parse(student[5]).ToShortDateString(),
                            Mail = student[6],
                            ImieMatki = student[7],
                            ImieOjca = student[8]
                        };
                        bool isNullOrSpace = st.GetType().GetProperties().Where(p => p.GetValue(st) is string).Any(p => string.IsNullOrWhiteSpace((p.GetValue(st) as string)));
                        bool isNullOrEmpty = st.GetType().GetProperties().Where(p => p.GetValue(st) is string).Any(p => string.IsNullOrEmpty((p.GetValue(st) as string)));
                        if (isNullOrSpace || isNullOrEmpty)
                        {
                            ErrorLogging(st);
                        }
                        else
                        {
                            if (!hash.Add(st))
                            {
                                ErrorLogging(st);
                            }
                        }
                    }
                }
            }catch(Exception ex)
            {
                ErrorLogging(ex);
            }

            FileStream writer = new FileStream(@"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\result.xml", FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, hash);




        }


        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\Log.txt";
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("Error Message: " + ex.Message + " " + DateTime.Now)  ;
            }
        }

        public static void ErrorLogging(Student st)
        {
            string strPath = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\Log.txt";
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("Niepoprawny lub zduplikowany student: " + st.toString() + " " + DateTime.Now);
            }
        }


    }
}
