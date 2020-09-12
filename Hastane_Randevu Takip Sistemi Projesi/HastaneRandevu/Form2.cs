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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        int haftaninGunu = 0;

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");
        public static string    gun,ay,yil;
        public static string[] id = new string[10];
        public static string[] ad = new string[10];
        public static string[] soyad = new string[10];
        public static string[] unvan = new string[10];
        public static string[] brans = new string[10];
        public static string[] randevuSaatleri = new string[20];
        public static int selectedIndex = 0;
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedIndex = comboBox2.SelectedIndex;

        }

        public static DateTime tarih = new DateTime();

        private void Form2_Load(object sender, EventArgs e)
        {

           

            dateTimePicker1.MinDate = DateTime.Now;
            

           

            

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

            
            tarih = dateTimePicker1.Value;
             haftaninGunu = Convert.ToInt32( tarih.DayOfWeek);
            
            if (haftaninGunu ==0 || haftaninGunu == 6)
            {
                MessageBox.Show("Cumartesi veya Pazar gününe randevu alınamaz", "HATA");

            }
            else
            {
                
                gun = Convert.ToString(tarih.Day);
                ay = Convert.ToString(tarih.Month);
                yil = Convert.ToString(tarih.Year);
            }

           
          
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((comboBox1.SelectedIndex != -1 && comboBox2.SelectedIndex != -1) && haftaninGunu != 0 && haftaninGunu != 6)
            {


                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from log", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();


                while (kayitokuma.Read())
                {
                    if (kayitokuma["gun"].ToString() == gun && kayitokuma["ay"].ToString() == ay && kayitokuma["yil"].ToString() == yil)
                    {

                        if (kayitokuma["doktorID"].ToString() == id[selectedIndex])
                        {
                            randevuSaatleri[x] = kayitokuma.GetValue(3).ToString();
                            x++;
                        }


                    }
                }

                baglantim.Close();


                int randevuSay = 0;

                /*
                // ayniı gune 2 randevuy onleme

                

                baglantim.Open();
                OleDbCommand selectsorgu2 = new OleDbCommand("select * from log", baglantim);
                OleDbDataReader kayitokuma2 = selectsorgu2.ExecuteReader();


                while (kayitokuma2.Read())
                {
                    if (kayitokuma2["gun"].ToString() == gun && kayitokuma2["ay"].ToString() == ay && kayitokuma2["yil"].ToString() == yil)
                    {

                        string branss = kayitokuma2["bransi"].ToString();

                        if (branss == "Goz" && kayitokuma2["hastaTC"].ToString() == Form1.tcno)
                        {
                            randevuSay++;


                        }


                    }
                }

                baglantim.Close();
                */
                if (randevuSay > 1)
                {

                    MessageBox.Show("Aynı gün içerisinde aynı branşa birden fazla randevu alınamaz.", "HATA!");
                }


                else
                {
                    this.Hide();
                    Form3 frm3 = new Form3();
                    frm3.Show();
                }
            }
            else if(comboBox1.SelectedIndex==-1)
            {
                MessageBox.Show("Branş Alanı Boş Bırakılamaz", "HATA");
            }

            else if(haftaninGunu==0 || haftaninGunu == 6)
            {
                MessageBox.Show("Cumartesi veya Pazar gününe randevu alınamaz", "HATA");
            }
            else
            {
                MessageBox.Show("Doktor Alanı Boş Bırakılamaz", "HATA");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form5 frm5 = new Form5();
            frm5.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
        }

        
        private void label3_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "Dahiliye")
            {
                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {

                    if (kayitokuma["bransi"].ToString() == "Dahiliye")
                    {

                        id[x] = kayitokuma.GetValue(0).ToString();
                        ad[x] = kayitokuma.GetValue(2).ToString();
                        soyad[x] = kayitokuma.GetValue(3).ToString();
                        unvan[x] = kayitokuma.GetValue(4).ToString();
                        brans[x] = kayitokuma.GetValue(5).ToString();
                        
                        comboBox2.Items.Add(unvan[x] + " " + ad[x] + " " + soyad[x]);
                        x++;
                    }

                  

                }

                baglantim.Close();
            }


           else if (comboBox1.Text == "Goz")
            {
                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {

                    if (kayitokuma["bransi"].ToString() == "Goz")
                    {

                        id[x] = kayitokuma.GetValue(0).ToString();
                        ad[x] = kayitokuma.GetValue(2).ToString();
                        soyad[x] = kayitokuma.GetValue(3).ToString();
                        unvan[x] = kayitokuma.GetValue(4).ToString();
                        brans[x] = kayitokuma.GetValue(5).ToString();

                        comboBox2.Items.Add(unvan[x] + " " + ad[x] + " " + soyad[x]);
                        x++;
                    }



                }

                baglantim.Close();
            }

            else if (comboBox1.Text == "KBB")
            {
                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {

                    if (kayitokuma["bransi"].ToString() == "KBB")
                    {

                        id[x] = kayitokuma.GetValue(0).ToString();
                        ad[x] = kayitokuma.GetValue(2).ToString();
                        soyad[x] = kayitokuma.GetValue(3).ToString();
                        unvan[x] = kayitokuma.GetValue(4).ToString();
                        brans[x] = kayitokuma.GetValue(5).ToString();

                        comboBox2.Items.Add(unvan[x] + " " + ad[x] + " " + soyad[x]);
                        x++;
                    }



                }

                baglantim.Close();
            }

            else if (comboBox1.Text == "Noroloji")
            {
                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {

                    if (kayitokuma["bransi"].ToString() == "Noroloji")
                    {

                        id[x] = kayitokuma.GetValue(0).ToString();
                        ad[x] = kayitokuma.GetValue(2).ToString();
                        soyad[x] = kayitokuma.GetValue(3).ToString();
                        unvan[x] = kayitokuma.GetValue(4).ToString();
                        brans[x] = kayitokuma.GetValue(5).ToString();

                        comboBox2.Items.Add(unvan[x] + " " + ad[x] + " " + soyad[x]);
                        x++;
                    }



                }

                baglantim.Close();
            }

            else if (comboBox1.Text == "Genel Cerrah")
            {
                int x = 0;
                baglantim.Open();
                OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
                OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

                while (kayitokuma.Read())
                {

                    if (kayitokuma["bransi"].ToString() == "Genel Cerrah")
                    {

                        id[x] = kayitokuma.GetValue(0).ToString();
                        ad[x] = kayitokuma.GetValue(2).ToString();
                        soyad[x] = kayitokuma.GetValue(3).ToString();
                        unvan[x] = kayitokuma.GetValue(4).ToString();
                        brans[x] = kayitokuma.GetValue(5).ToString();

                        comboBox2.Items.Add(unvan[x] + " " + ad[x] + " " + soyad[x]);
                        x++;
                    }



                }

                baglantim.Close();
            }
        }
    }
}
