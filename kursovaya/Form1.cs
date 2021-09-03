using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kursovaya
{
    public partial class Form1 : Form
    {
        private LDA lda = new LDA();
        private double sv1, sv2;
        private Mo form2;


        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sv1 = Convert.ToDouble(textBox1.Text);
            sv2 = Convert.ToDouble(textBox2.Text);
            double res = sv1 * lda.B[0] + sv2 * lda.B[1] + lda.P;

            textBox5.Text = res.ToString();
            if (res > 0)
                textBox6.Text = "1";
            else
                textBox6.Text = "2";
        }

        private List<List<double>> Lst()
        {
            List<List<double>> lst = new List<List<double>>();
            for (int i = 0; i < 6; i++)
                lst.Add(new List<double>());
            for(int i=0;i<lda.First_Chr1.Count;i++)
            {
                lst[0].Add(lda.First_Chr1[i]);
                lst[1].Add(lda.First_Chr2[i]);
                lst[2].Add(lda.FirstD[i]);
                lst[3].Add(lda.Second_Chr1[i]);
                lst[4].Add(lda.Second_Chr2[i]);
                lst[5].Add(lda.SecondD[i]);
            }
            return lst;
        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            form2 = new Mo(this, Lst());
            form2.Show();
            this.Hide();
            /*string txt = "";
            for (int i = 0; i < lda.First_Chr1.Count; i++)
            {
                txt += lda.First_Chr1[i].ToString() + "  " + lda.First_Chr2[i].ToString() + "  " + lda.FirstD[i].ToString() + System.Environment.NewLine;
            }
            textBox3.Text = txt;
            txt = "";
            for (int i = 0; i < lda.First_Chr1.Count; i++)
            {
                txt += lda.Second_Chr1[i].ToString() + "  " + lda.Second_Chr2[i].ToString() + "  " + lda.SecondD[i].ToString() + System.Environment.NewLine;
            }
            textBox4.Text = txt;*/
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Draw();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Draw()
        {
            Graphics gr = panel1.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.Green);
            gr.Clear(Color.White);
            for (int i=0;i<lda.First_Chr1.Count;i++)
            {
                gr.FillEllipse(brush, (float)lda.First_Chr1[i]*30, -(float)lda.First_Chr2[i]*10+ 400, 7, 7);
            }
            brush.Color = Color.Blue;
            for (int i = 0; i < lda.Second_Chr1.Count; i++)
            {
                gr.FillEllipse(brush, (float)lda.Second_Chr1[i] * 30, -(float)lda.Second_Chr2[i] * 10+400, 7, 7);
            }
            if (textBox5.Text!="" && textBox6.Text!="")
            {
                brush.Color = Color.Red;
                gr.FillEllipse(brush, (float)sv1 * 30, -(float)sv2 * 10+400, 7, 7);
            }
            brush.Color = Color.Black;
            /*for(int i=0; i<panel1.Width;i+=1*30)
            {
                gr.DrawString((i/30).ToString(), new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular), brush, 10, i) ;
            }*/
            for (int i = 0; i < panel1.Width; i += 1 * 30)
            {
                gr.DrawString((i / 30).ToString(), new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular), brush, 5+i, panel1.Height - 15); ;
            }
            for (int i = 40*10; i >0; i -= 10)
            {
                gr.DrawString((i / 10).ToString(), new Font(FontFamily.GenericSansSerif, 5, FontStyle.Regular), brush, 5, panel1.Height - 15-i);
            }


        }

    }
}
