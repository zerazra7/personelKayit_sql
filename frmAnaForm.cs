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
    public partial class frmAnaForm : Form
    {
        public frmAnaForm()
        {
            InitializeComponent();
        }

        SqlConnection baglanti =new SqlConnection("Data Source=ZERA-S\\SQLEXPRESS;Initial Catalog=PersonelVeritabani;Integrated Security=True");
        void temizle()
        {
            txtid.Text = "";
            txtmeslek.Text = "";
            txtad.Text = "";
            txtsoyad.Text = "";
            maskedTextBox1.Text = "";
            comboBox1.Text = "";
            radioButton1.Checked=false;
            radioButton2.Checked=false;
            txtad.Focus();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

            this.table_personelTableAdapter.Fill(this.personelVeritabaniDataSet.Table_personel);
        }

        private void btnlistele_Click(object sender, EventArgs e)
        {

            this.table_personelTableAdapter.Fill(this.personelVeritabaniDataSet.Table_personel);
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("insert into Table_personel (perad,persoyad,persehir,permaas,permeslek,perdurum) VALUES(@p1,@p2,@p3,@p4,@p5,@p6)", baglanti);
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", comboBox1.Text);
            komut.Parameters.AddWithValue("@p4", maskedTextBox1.Text);
            komut.Parameters.AddWithValue("@p5", txtmeslek.Text);
            komut.Parameters.AddWithValue("@p6", label8.Text);
            komut.ExecuteNonQuery();  //sorguyu çalıştırır = insert delete ve update de kullanılır.

            baglanti.Close();
            MessageBox.Show("personel eklendi.");
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked== true)
            {
                label8.Text = "true";
            }

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                label8.Text = "false";
            }
        }

        private void btntemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen=dataGridView1.SelectedCells[0].RowIndex;

            txtid.Text = dataGridView1.Rows[secilen].Cells[0].Value.ToString();
            txtad.Text = dataGridView1.Rows[secilen].Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.Rows[secilen].Cells[2].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[secilen].Cells[3].Value.ToString();
            maskedTextBox1.Text = dataGridView1.Rows[secilen].Cells[4].Value.ToString();
            label8.Text=dataGridView1.Rows[secilen].Cells[5].Value.ToString();
            txtmeslek.Text = dataGridView1.Rows[secilen].Cells[6].Value.ToString();

        }

        private void Form1_TextChanged(object sender, EventArgs e)
        {
            if (label8.Text == "true")
            {
                radioButton1.Checked = true;
            }
            if (label8.Text== "false")
            {
                radioButton2.Checked= false;
            }
        }

        private void btnsil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutsil = new SqlCommand("delete from Table_personel where perid=@k1",baglanti) ;
            komutsil.Parameters.AddWithValue("@k1", txtid.Text);
            komutsil.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("kayıt silindi");

        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komutguncelle = new SqlCommand("update Table_personel set perad=@a1,persoyad=@a2,persehir=@a3,permaas=@a4,perdurum=@a5,permeslek=@a6 where perid=@a7", baglanti);
            komutguncelle.Parameters.AddWithValue("@a1", txtad.Text);
            komutguncelle.Parameters.AddWithValue("@a2", txtsoyad.Text);
            komutguncelle.Parameters.AddWithValue("@a3", comboBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a4", maskedTextBox1.Text);
            komutguncelle.Parameters.AddWithValue("@a5", label8.Text);
            komutguncelle.Parameters.AddWithValue("@a6", txtmeslek.Text);
            komutguncelle.Parameters.AddWithValue("@a7",txtid.Text);
            komutguncelle.ExecuteNonQuery();

            baglanti.Close();
            MessageBox.Show("personel bilgi güncellendi");

        }

        private void btnistatistik_Click(object sender, EventArgs e)
        {
            Frmistatistik fr=new Frmistatistik();
            fr.Show();

        }

        private void btngrafik_Click(object sender, EventArgs e)
        {
            Frmgrafik frg =new Frmgrafik();
            frg.Show();
        }
    }
}
 