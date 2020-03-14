using Cw2;
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
            var path = "";
            var resultPath ="";
            var format = "";
            if(args.Length != 3)
            {
               path = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\dane.csv";
               resultPath = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\result.xml";
               format = "xml";
            }
            else
            {
               path =args[0];
               resultPath =args[1];
               format=args[2];
            }
            var hash = new HashSet<Student>(new OwnComparer());
            var studiesHash = new HashSet<Studies>(new StudiesComparer());


            try
            {
                using (var stream = new StreamReader(File.OpenRead(path)))
                {
                    string line = null; while ((line = stream.ReadLine()) != null)
                    {
                        string[] student = line.Split(',');
                        var studia = new Studies
                        {
                            Wydzial = student[2],
                            Tryb = student[3],
                        };
                        studiesHash.Add(studia);

                        var st = new Student
                        {
                            Imie = student[0],
                            Nazwisko = student[1],
                            Indeks = student[4],
                            DataRoz = DateTime.Parse(student[5]).ToShortDateString(),
                            Mail = student[6],
                            ImieMatki = student[7],
                            ImieOjca = student[8],
                            Studia = studia
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
            }catch(FileNotFoundException ex)
            {
                ErrorLogging(ex);
            }
            catch (ArgumentException ex)
            {
                ErrorLogging(ex);
            }





            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("CreatedAt", DateTime.Today.ToShortDateString());
            ns.Add("Author", "Jakub Bogusławski");

            FileStream writer = new FileStream(resultPath, FileMode.Create);
            XmlSerializer serializer = new XmlSerializer(typeof(HashSet<Student>), new XmlRootAttribute("uczelnia"));
            serializer.Serialize(writer, hash, ns);
                





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
                sw.WriteLine("Niepoprawny lub zduplikowany student: " + st.ToString() + " " + DateTime.Now);
            }
        }


    }
}
