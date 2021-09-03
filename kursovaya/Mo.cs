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
    public partial class Mo : Form
    {
        private Form1 form;
        private List<List<double>> mo;

        public Mo(Form1 form, List<List<double>> mo)
        {
            InitializeComponent();
            this.form = form;
            this.mo = mo;
            button1.Focus();
            Shows();
        }

        public void Shows()
        {
            for(int i=0;i<mo[0].Count;i++)
            {
                listBox1.Items.Add(mo[0][i]+"     "+ mo[1][i]+"     "+ mo[2][i]);
                listBox2.Items.Add(mo[3][i]+"     "+ mo[4][i]+"     "+ mo[5][i]);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form.Show();
            Hide();
        }
    }
}
