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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");
        public static string doktorId;
        private void button1_Click(object sender, EventArgs e)
        {
            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from doktorlar", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();


            while (kayitokuma.Read())
            {
                if (kayitokuma["ID"].ToString() == textBox1.Text && kayitokuma["sifre"].ToString() == textBox2.Text)
                {
                    doktorId = textBox1.Text;
                    this.Hide();
                    Form7 frm7 = new Form7();
                    frm7.Show();
                    break;
                }
            }
        }

    }
}
