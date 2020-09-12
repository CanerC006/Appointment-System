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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");

       

        int durum9 = 0;
        int durum10 = 0;
        int durum11 = 0;
        int durum12 = 0;
        int durum13 = 0;
        int durum14 = 0;
        int durum15 = 0;
        int durum16 = 0;
        int durum17 = 0;
        public static int secilenSaat=0;

        private void Form3_Load(object sender, EventArgs e)
        {
           

           

            button1.BackColor = Color.Green;
            button2.BackColor = Color.Green;
            button3.BackColor = Color.Green;
            button4.BackColor = Color.Green;
            button5.BackColor = Color.Green;
            button6.BackColor = Color.Green;
            button7.BackColor = Color.Green;
            button8.BackColor = Color.Green;
            button9.BackColor = Color.Green;



            int x = 0;
            for (x = 0; x < Form2.randevuSaatleri.Length; x++)
            {
                if(Form2.randevuSaatleri[x]=="9")
                {
                    button1.BackColor = Color.Red;
                     durum9 = 1;
                }
                else if(Form2.randevuSaatleri[x] == "10")
                {
                    button2.BackColor = Color.Red;
                    durum10 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "11")
                {
                    button3.BackColor = Color.Red;
                    durum11 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "12")
                {
                    button4.BackColor = Color.Red;
                    durum12 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "13")
                {
                    button5.BackColor = Color.Red;
                    durum13 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "14")
                {
                    button6.BackColor = Color.Red;
                    durum14 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "15")
                {
                    button7.BackColor = Color.Red;
                    durum15 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "16")
                {
                    button8.BackColor = Color.Red;
                    durum16 = 1;
                }

                else if (Form2.randevuSaatleri[x] == "17")
                {
                    button9.BackColor = Color.Red;
                    durum17 = 1;
                }

            }





        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (durum9 == 0)
            {
                if (secilenSaat == 0)
                {
                    button1.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button1.BackColor = Color.Yellow;
                }
                secilenSaat = 9;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (durum10 == 0)
            {
                if (secilenSaat == 0)
                {
                    button2.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button2.BackColor = Color.Yellow;

                }
                secilenSaat = 10;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (durum11 == 0)
            {
                if (secilenSaat == 0)
                {
                    button3.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button3.BackColor = Color.Yellow;
                }
                secilenSaat = 11;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (durum12 == 0)
            {
                if (secilenSaat == 0)
                {
                    button4.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button4.BackColor = Color.Yellow;
                }
                secilenSaat = 12;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (durum13 == 0)
            {
                if (secilenSaat == 0)
                {
                    button5.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button5.BackColor = Color.Yellow;
                }
                secilenSaat = 13;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (durum14 == 0)
            {
                if (secilenSaat == 0)
                {
                    button6.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button6.BackColor = Color.Yellow;
                }
                secilenSaat = 14;
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (durum15 == 0)
            {
                if (secilenSaat == 0)
                {
                    button7.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button7.BackColor = Color.Yellow;
                }
                secilenSaat = 15;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (durum16 == 0)
            {
                if (secilenSaat == 0)
                {
                    button8.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button8.BackColor = Color.Yellow;
                }
                secilenSaat = 16;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (durum17 == 0)
            {
                if (secilenSaat == 0)
                {
                    button9.BackColor = Color.Yellow;
                }
                else
                {
                    secimiDegistir(secilenSaat);
                    button9.BackColor = Color.Yellow;
                }
                secilenSaat = 17;
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {

            if (secilenSaat != 0)
            {
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from log", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();
                string ekle = "insert into log(gun,ay,yil,saat,brans,doktorID,hastaTC,doktorUnvan,doktorAd,doktorSoyad,hastaAd,hastaSoyad) values (@gun,@ay,@yil,@saat,@brans,@doktorID,@hastaTC,@doktorUnvan,@doktorAd,@doktorSoyad,@hastaAd,@hastaSoyad)";
                

                OleDbCommand komut = new OleDbCommand(ekle, baglantim);
               komut.Parameters.AddWithValue("@gun", Convert.ToString(Form2.gun));
               komut.Parameters.AddWithValue("@ay", Convert.ToString(Form2.ay));
                komut.Parameters.AddWithValue("@yil", Convert.ToString(Form2.yil));
                komut.Parameters.AddWithValue("@saat", Convert.ToString(secilenSaat));
               komut.Parameters.AddWithValue("@brans", Convert.ToString(Form2.brans[Form2.selectedIndex]));
               komut.Parameters.AddWithValue("@doktorID", Convert.ToString(Form2.id[Form2.selectedIndex]));
                komut.Parameters.AddWithValue("@hastaTC", Convert.ToString(Form1.tcno));
               komut.Parameters.AddWithValue("@doktorUnvan", Convert.ToString(Form2.unvan[Form2.selectedIndex]));
                komut.Parameters.AddWithValue("@doktorAd", Convert.ToString(Form2.ad[Form2.selectedIndex]));
                  komut.Parameters.AddWithValue("@doktorSoyad", Convert.ToString(Form2.soyad[Form2.selectedIndex]));
               komut.Parameters.AddWithValue("@hastaAd", Convert.ToString(Form1.ad));
                komut.Parameters.AddWithValue("@hastaSoyad", Convert.ToString(Form1.soyad));
              
                komut.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Randevunuz Başarıyla Kaydedilmiştir...","Tebrikler");
                this.Hide();
                Form2 frm2 = new Form2();
                frm2.Show();
            }
            else
                MessageBox.Show("Lütfen Geçerli Bir Saat Seçiniz", "HATA");
        }

        private void secimiDegistir(int x)
        {

            if (x == 9)
            {       
                button1.BackColor = Color.Red;
            }

            else if (x == 10)
            {
                button2.BackColor = Color.Red;
            }

            else if (x == 11)
            {
                button3.BackColor = Color.Red;
            }

            else if (x == 12)
            {
                button4.BackColor = Color.Red;
            }

            else if (x == 13)
            {
                button5.BackColor = Color.Red;
            }
            else if (x == 14)
            {
                button6.BackColor = Color.Red;
            }
            else if (x == 15)
            {
                button7.BackColor = Color.Red;
            }

            else if (x == 16)
            {
                button8.BackColor = Color.Red;
            }

            else if (x == 17)
            {
                button9.BackColor = Color.Red;
            }

        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}
