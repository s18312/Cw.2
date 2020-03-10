using System;
using System.Collections.Generic;
using System.Text;

namespace Cw._2
{
    class Student
    {
        public String Imie;
        public String Nazwisko;
        public String Wydzial;
        public String Tryb;
        public String Indeks;
        public DateTime DataRoz;
        public String Mail;
        public String ImieMatki;
        public String ImieOjca;

        public String toString()
        {
            return Imie + " " + Nazwisko + " " + Wydzial + " " + Tryb + " " + Indeks + " " + DataRoz + " " + Mail + " " + ImieMatki + " " + ImieOjca;
        }
    }
}
