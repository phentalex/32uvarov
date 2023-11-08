using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Configuration;

namespace _32uvarov
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.AllowUserToAddRows = false;
            DataTable table = new DataTable();

            table.Rows.Clear();
            table.Columns.Clear();
            table.Columns.Add("Выстрел", typeof(string));
            table.Columns.Add("Попадание", typeof(string));

            string[] x = richTextBox1.Text.Split(';');
            string[] y = richTextBox2.Text.Split(';');
            double r = 3;

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 1; j++)
                {
                    if (Double.Parse(x[i]) >= 0 && Math.Pow(Double.Parse(x[i]), 2) + Math.Pow(Double.Parse(y[i]), 2) <= Math.Pow(r, 2) ||
                        Double.Parse(x[i]) <= 0 && Math.Abs(Double.Parse(x[i])) <= r && Double.Parse(y[i]) >= -r && Double.Parse(y[i]) <= r && Double.Parse(y[i]) <= Double.Parse(x[i]) ||
                        Double.Parse(x[i]) <= 0 && Double.Parse(y[i]) >= -Double.Parse(x[i]))
                    {
                        table.Rows.Add(i + 1, "Попал");
                    }
                    else
                    {
                        table.Rows.Add(i + 1, "Не попал");
                    }
                }
            }
            dataGridView1.DataSource = table;
        }
    }
}