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
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");
        public static DateTime tarih = new DateTime();
        string gun, ay, yil;

        private void Form7_Load(object sender, EventArgs e)
        {
            tarih = DateTime.Now;
            gun = Convert.ToString(tarih.Day);
            ay = Convert.ToString(tarih.Month);
            yil = Convert.ToString(tarih.Year);

           

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from log", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();



            while (kayitokuma.Read())
            {

                if (kayitokuma["doktorID"].ToString() == Form6.doktorId && kayitokuma["gun"].ToString() == gun && kayitokuma["ay"].ToString() == ay && kayitokuma["yil"].ToString() == yil)
                {

                    string saat = kayitokuma.GetValue(3).ToString();

                    if (saat == "9")
                        label10.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "10")
                        label11.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "11")
                        label12.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "12")
                        label13.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "13")
                        label14.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "14")
                        label15.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "15")
                        label16.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "16")
                        label17.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "17")
                        label18.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();

                }


            }

            baglantim.Close();

        }


        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 frm1 = new Form1();
            frm1.Show();
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            tarih = dateTimePicker1.Value;
            gun = Convert.ToString(tarih.Day);
            ay = Convert.ToString(tarih.Month);
            yil = Convert.ToString(tarih.Year);

            label10.Text = "Boş";
            label11.Text = "Boş";
            label12.Text = "Boş";
            label13.Text = "Boş";
            label14.Text = "Boş";
            label15.Text = "Boş";
            label16.Text = "Boş";
            label17.Text = "Boş";
            label18.Text = "Boş";

            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from log", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();



            while (kayitokuma.Read())
            {

                if (kayitokuma["doktorID"].ToString() == Form6.doktorId && kayitokuma["gun"].ToString() == gun && kayitokuma["ay"].ToString() == ay && kayitokuma["yil"].ToString() == yil)
                {

                    string saat = kayitokuma.GetValue(3).ToString();

                    if (saat == "9")
                        label10.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "10")
                        label11.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "11")
                        label12.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "12")
                        label13.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "13")
                        label14.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "14")
                        label15.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "15")
                        label16.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "16")
                        label17.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();
                    else if (saat == "17")
                        label18.Text = kayitokuma.GetValue(10).ToString() + " " + kayitokuma.GetValue(11).ToString();

                }


            }

            baglantim.Close();
           
        }
    }
}
