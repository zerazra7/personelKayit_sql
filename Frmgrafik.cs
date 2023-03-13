using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PersonelKayit_sql
{
    public partial class Frmgrafik : Form
    {
        public Frmgrafik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=ZERA-S\\SQLEXPRESS;Initial Catalog=PersonelVeritabani;Integrated Security=True");

      

         private void Frmgrafik_Load(object sender, EventArgs e)
         {
            //grafik1
             baglanti.Open();
             SqlCommand komutgrf1 = new SqlCommand("select persehir,count(*) from table_personel GROUP by persehir", baglanti);
             SqlDataReader dr1 = komutgrf1.ExecuteReader();
             while (dr1.Read())
             {
                 chart1.Series["Sehirler"].Points.AddXY(dr1[0], dr1[1]);
             }

             baglanti.Close();

            //grafik2
           /* baglanti.Open();
            SqlCommand komutgrf2 = new SqlCommand("select permeslek,avg(mermaas) from table_personel GROUP by permeslek", baglanti);
            SqlDataReader dr2 = komutgrf2.ExecuteReader();
            while (dr2.Read())
            {
                chart2.Series["Meslek-Maas"].Points.AddXY(dr2[0], dr2[1]);
            }

            baglanti.Close();*/

        }

    }
}
