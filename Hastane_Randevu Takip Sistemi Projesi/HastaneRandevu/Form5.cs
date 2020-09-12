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
using System.Collections;

namespace HastaneRandevu
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        int x = 0;
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.Ace.OleDb.12.0;Data Source=Hastane.accdb");

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 frm2 = new Form2();
            frm2.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            
            
            baglantim.Open();
            OleDbCommand selectsorgu = new OleDbCommand("select * from log", baglantim);
            OleDbDataReader kayitokuma = selectsorgu.ExecuteReader();

          
          
            while (kayitokuma.Read())
            {

                if (kayitokuma["hastaTC"].ToString() == Form1.tcno)
                {
                    int gun = 0;
                    int ay = 0;
                    int yil = 0;
                    string gunStr, ayStr;
                    gun = Convert.ToInt32(kayitokuma.GetValue(0));
                    ay = Convert.ToInt32(kayitokuma.GetValue(1));
                    yil = Convert.ToInt32(kayitokuma.GetValue(2));

                    if (gun < 10)
                        gunStr = "0" + Convert.ToString(gun);
                    else
                        gunStr = Convert.ToString(gun);

                    if (ay < 10)
                        ayStr = "0" + Convert.ToString(ay);
                    else
                        ayStr = Convert.ToString(ay);


                    ListViewItem eleman = listView1.Items.Add(gun+"/"+ay+"/"+yil);
                    eleman.SubItems.Add(kayitokuma.GetValue(1).ToString());
                    eleman.SubItems.Add(kayitokuma.GetValue(2).ToString());
                    eleman.SubItems.Add(kayitokuma.GetValue(3).ToString());
                    eleman.SubItems.Add(kayitokuma.GetValue(4).ToString());
                    eleman.SubItems.Add(kayitokuma.GetValue(7).ToString()+" "+ kayitokuma.GetValue(8).ToString()+" "+ kayitokuma.GetValue(9).ToString());






                    x++;
                }

               
            }

            baglantim.Close();
            this.listView1.ListViewItemSorter = new ListViewItemComparer(0);
        }
    }


    class ListViewItemComparer : IComparer
    {
        private int col;
        public ListViewItemComparer()
        {
            col = 0;
        }
        public ListViewItemComparer(int column)
        {
            col = column;
        }
        public int Compare(object x, object y)
        {
            return String.Compare(((ListViewItem)x).SubItems[col].Text, ((ListViewItem)y).SubItems[col].Text);
        }
    }



}
