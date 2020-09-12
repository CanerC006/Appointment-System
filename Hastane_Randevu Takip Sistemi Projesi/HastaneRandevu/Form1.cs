using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HastaneRandevu
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");

        public static string tcno, sifre,ad,soyad;
        bool durum = false;
        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 frm6 = new Form6();
            frm6.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form4 frm4 = new Form4();
            frm4.Show();
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from hastalar", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();


            while (kayitokuma.Read())
            {
                if (kayitokuma["TC"].ToString() == textBox1.Text && kayitokuma["sifre"].ToString() == textBox2.Text)
                {

                    durum = true;
                    tcno = kayitokuma.GetValue(0).ToString();
                    ad = kayitokuma.GetValue(2).ToString();
                    soyad = kayitokuma.GetValue(3).ToString();
                    baglantim.Close();
                    this.Hide();
                    Form2 frm2 = new Form2();
                    frm2.Show();
                    break;
                }
            }


            if (durum == false)
            {
                MessageBox.Show("TC Kimlik NO veya Şifreniz Yanlış", "HATA");
                baglantim.Close();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

   

        }
    }
}
