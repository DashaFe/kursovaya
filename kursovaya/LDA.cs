using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kursovaya
{
    class LDA
    {
        private Img firstImg = new Img("image_first.txt");
        private Img secondImg=new Img("image_second.txt");
        //математическое ожидание по первому свойству
        private double[] mat1 = new double[2];
        //математическое ожидание по первому свойству
        private double[] mat2 = new double[2];
        //матрицы ковариации 
        private double[,] kv;
        //коэффициенты b и p
        private double[] b = new double[2];
        private double p;
        //листы значений дискриминантнйо функции для 2 образов
        private List<double> firstD, secondD;

        public double[] B { get { return b; } }
        public double P { get { return p; } }
        public List<double> FirstD { get { return firstD; } }
        public List<double> SecondD { get { return secondD; } }
        public List<double> First_Chr1 { get { return firstImg.Chr_1; } }
        public List<double> First_Chr2 { get { return firstImg.Chr_2; } }
        public List<double> Second_Chr1 { get { return secondImg.Chr_1; } }
        public List<double> Second_Chr2 { get { return secondImg.Chr_2; } }
        


        public LDA()
        {
            MathOz();
            kv = MatKovOb();
            b = KofB();
            p = KofP();
            firstD = Lda(firstImg);
            secondD = Lda(secondImg);
        }

        private void MathOz()
        {
            //вычисление мат ожиданий
            mat1[0] = firstImg.Chr_1.Average();
            mat1[1] = firstImg.Chr_2.Average();
            mat2[0] = secondImg.Chr_1.Average();
            mat2[1] = secondImg.Chr_2.Average();
        }

        //составление матриц ковариаций
        private double[,] MatKov( Img img)
        {
            double[,] kov = new double[2, 2];
            kov[0, 0] = Kov(img.Chr_1, img.Chr_1);
            kov[0, 1] = Kov(img.Chr_1, img.Chr_2);
            kov[1, 0] = Kov(img.Chr_2, img.Chr_1);
            kov[1, 1] = Kov(img.Chr_2, img.Chr_2);
            return kov;
        }

        private double[,] MatKovOb()
        {
            double[,]  kv1 = MatKov(firstImg);
            double[,] kv2 = MatKov(secondImg);
            double[,] kv = new double[2, 2];
            for(int i=0;i<2;i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    kv[i, j] = (kv1[i, j] * firstImg.Chr_1.Count + kv2[i, j] * secondImg.Chr_1.Count) / (firstImg.Chr_1.Count+ secondImg.Chr_1.Count);
                }
            }
            kv = ObrMat(kv);
            return kv;
        }

        private double Kov(List<double> chr1, List<double> chr2)
        {
            //вычисление ковариации
            double[] kov = new double[chr1.Count];
            for(int i=0;i<kov.Length;i++)
            {
                kov[i] = (chr1[i] - chr1.Average()) * (chr2[i] - chr2.Average());
            }
            double kv = kov.Average();
            return kv;
        }
        
        //вычисление коэффициента b
        private double[] KofB()
        {
            double[] kf = new double[2];
            kf[0] = kv[0, 0] * (mat1[0] - mat2[0]) + kv[0, 1] * (mat1[1] - mat2[1]);
            kf[1] = kv[1, 0] * (mat1[0] - mat2[0]) + kv[1, 1] * (mat1[1] - mat2[1]);
            return kf;
        }

        //вычисление коэффициента p
        private double KofP()
        {
            double kff = 0;
            double[] kf = new double[2];
            kf[0] = kv[0, 0] * (mat1[0] + mat2[0]) + kv[1, 0] * (mat1[1] + mat2[1]);
            kf[1] = kv[0, 1] * (mat1[0] + mat2[0]) + kv[1, 1] * (mat1[1] + mat2[1]);
            kff = kf[0] * (mat1[0] - mat2[0]) + kf[1] * (mat1[1] - mat2[1]);
            kff = -kff / 2;
            return kff;
        }

        //вычисление значенйи дискриминантнйо функции
        private List<double> Lda(Img img)
        {
            List<double> list = new List<double>();
            for (int i=0;i< img.Chr_1.Count;i++)
            {
                double value = b[0] * img.Chr_1[i] + b[1] * img.Chr_2[i] + p;
                list.Add(value);
            }
            return list;
        }

        //вычисление обратной матрицы
        private double [,] ObrMat(double[,]mat)
        {
            double[,] obrmat = new double[2, 2];
            double opr = mat[0, 0] * mat[1, 1] - mat[0, 1] * mat[1, 0];
            obrmat[0, 0] = mat[1, 1];
            obrmat[0, 1] = -mat[0, 1];
            obrmat[1, 0] = -mat[1, 0];
            obrmat[1, 1] = mat[0, 0];
            for(int i=0;i<2;i++)
            {
                for (int j = 0; j < 2; j++)
                    obrmat[i, j] = obrmat[i, j]  / opr;
            }
            return obrmat;
        }

    }
}
