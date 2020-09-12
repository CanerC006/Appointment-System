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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");
        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool sifreDurum = false;
            bool tcdNotDigit = false;
            bool tcdLenghtOver = false;

            if (textBox4.Text != textBox5.Text)
                sifreDurum = true;

            if(textBox3.Text.Length!=11)
            {
                tcdLenghtOver = true;
            }
            int y = 0;
            for(y=0;y< textBox3.Text.Length; y++)
            {
                if(char.IsDigit(textBox3.Text[y])==false)
                {
                    tcdNotDigit = true;
                    break;
                }
            
            }

            if (tcdLenghtOver)
                MessageBox.Show("TC Kimlik Numarası 11 karekter olmalıdır.", "HATA");
            else if(tcdNotDigit)
                MessageBox.Show("TC Kimlik Numarası Sayılardan oluşmalıdır.", "HATA");
            else if (sifreDurum)
                MessageBox.Show("girilen Şifreler Aynı değil !", "HATA");

            if (!tcdLenghtOver && !tcdNotDigit && !sifreDurum)
            {

                try
                {
                    baglantim.Open();
                    OleDbCommand selectsorgu = new OleDbCommand("select * from hastalar", baglantim);
                    OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                    string ekle = "insert into hastalar(TC,sifre,adi,soyadi) values (@TC,@sifre,@adi,@soyadi)";
                    OleDbCommand komut = new OleDbCommand(ekle, baglantim);
                    komut.Parameters.AddWithValue("@TC", Convert.ToString(textBox3.Text));
                    komut.Parameters.AddWithValue("@sifre", Convert.ToString(textBox5.Text));
                    komut.Parameters.AddWithValue("@adi", Convert.ToString(textBox1.Text));
                    komut.Parameters.AddWithValue("@soyadi", Convert.ToString(textBox2.Text));
                    komut.ExecuteNonQuery();
                    baglantim.Close();
                    MessageBox.Show("Kayıt Başarılıyla Oluşturuldu");
                    this.Hide();
                    Form1 frm1 = new Form1();
                    frm1.Show();
                }

                catch
                {
                    MessageBox.Show("TC no sistemde kayıtlı", "HATA!");
                    baglantim.Close();

                }







                
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
