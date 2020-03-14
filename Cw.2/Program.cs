
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
            var resultPath = "";
            var format = "";
            if (args.Length != 3)
            {
                path = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\dane.csv";
                resultPath = @"C:\Users\jakub\OneDrive\Pulpit\APBD\cw.2\Cw.2\result.xml";
                format = "xml";
            }
            else
            {
                path = args[0];
                resultPath = args[1];
                format = args[2];
            }
            var hash = new HashSet<Student>(new OwnComparer());
            List<string> allStudies = new List<string>();


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
                            else
                            {
                                allStudies.Add(st.Studia.Wydzial);
                            }

                        }
                    }
                }

                HashSet<string> studies = new HashSet<string>(allStudies);
                List<ActiveStudy> aktywne= new List<ActiveStudy>();
                foreach (string wydzial in studies)
                {
                    int ile = 0;
                    foreach (Student student in hash)
                    {
                        if (wydzial.Equals(student.Studia.Wydzial))
                        {
                            ile++;
                        }
                    }

                    var aktywny = new ActiveStudy
                    {
                        Wydzial = wydzial,
                        IleStud = ile
                    };

                    aktywne.Add(aktywny);

                }

                var uni = new University
                {
                    studenci = hash,
                    wydzialy = aktywne
                };


                FileStream writer = new FileStream(resultPath, FileMode.Create);
                XmlSerializer serializer = new XmlSerializer(typeof(University), new XmlRootAttribute("uczelnia"));
                serializer.Serialize(writer, uni);

            }
            catch (FileNotFoundException ex)
            {
                ErrorLogging(ex);
            }
            catch (ArgumentException ex)
            {
                ErrorLogging(ex);
            }




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
