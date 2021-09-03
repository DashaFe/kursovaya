using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;

namespace kursovaya
{
    class Img
    {
        //первая характеристика (свойство)
        private List<double> chr_1 = new List<double>();
        //вторая характеристика (свойство)
        private List<double> chr_2 = new List<double>();
        //имя файла, откуда считываются данные
        private string path;

        public List<double> Chr_1 { get { return chr_1; } }
        public List<double> Chr_2 { get { return chr_2; } }

        public Img(string st)
        {
            path = st;
            Read();
        }

        //считывание информации с файла
        private void Read()
        {
            StreamReader sr = new StreamReader(path);
            string line;
            string st = "";
            while (!sr.EndOfStream)
            {
                st = "";
                line = sr.ReadLine();
                for (int i = 0; i < line.Length; i++)
                {
                    if (line[i] != ' ')
                        st += line[i];
                    else
                    {
                        chr_1.Add(Convert.ToDouble(st));
                        st = "";
                    }
                }
                chr_2.Add(Convert.ToDouble(st));
            }
            sr.Close();
        }
    }
}
