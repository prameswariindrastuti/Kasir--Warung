using MySql.Data.MySqlClient;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Internal;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace master
{
    public partial class identitastoko : Form
    {
        public MySqlCommand cmd;
        public string idIdentitas;
        public identitastoko()
        {

            InitializeComponent();

        }

        void tampil()
        {
            try
            {
                //MessageBox.Show("Ini Muncul Saat FOrm dipanggil");

                Koneksi.conn.Open(); //ini membuka koneksi database

                //ini digunakan untuk mengambil data di tabel siswa
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `tblidentitas`", Koneksi.conn);
                //membuat objek Dasa Set Baru
                DataSet ds = new DataSet();
                //ini digunakan untuk mengisi dataset dari Data Adapter
                da.Fill(ds);

                //Mengisi DataGrid Siswa dengan DataSet
                apaiya.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        { 
            tampil();
        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                          
        }

        private void identitastoko_Load(object sender, EventArgs e)
        {
            try
            {
                tampil();
            }
            catch (Exception)
            {

                MessageBox.Show("terjadi kesalahan");
            }
            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblidentitas` SET `namatoko` = '"+textBox1.Text+"', `alamattoko` = '"+textBox6.Text+"', `nomortelepon` = '"+textBox5.Text+"', `captionpertama` = '"+textBox2.Text+"', `captionkedua` = '"+textBox3.Text+"', `captionketiga` = '"+textBox4.Text+"' WHERE `tblidentitas`.`id_identitastoko` = '"+idIdentitas+"';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Ubah Data");
                Koneksi.conn.Close();

                tampil();
            }
            catch (Exception)
            {

                MessageBox.Show("Ubah Data Gagal");
            }
        }

        private void apaiya_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = apaiya.CurrentCell.RowIndex;
            string id = apaiya.Rows[baris].Cells[0].Value.ToString();
            // MessageBox.Show(id);
            textBox1.Text = apaiya.Rows[baris].Cells[1].Value.ToString();
            textBox6.Text = apaiya.Rows[baris].Cells[2].Value.ToString();
            textBox5.Text = apaiya.Rows[baris].Cells[3].Value.ToString();
            textBox2.Text = apaiya.Rows[baris].Cells[4].Value.ToString();
            textBox3.Text = apaiya.Rows[baris].Cells[5].Value.ToString();
            textBox4.Text = apaiya.Rows[baris].Cells[6].Value.ToString();
        }

    private void button16_Click(object sender, EventArgs e)
        {

            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblidentitas WHERE `tblidentitas`.`id_identitastoko` = '" + idIdentitas + "'", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil HAPUS Data");
                Koneksi.conn.Close();

                tampil();
            }
            catch (Exception)
            {

                MessageBox.Show("Hapus Data Gagal");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblidentitas` (`id_identitastoko`, `namatoko`, `alamattoko`, `nomortelepon`, `captionpertama`, `captionkedua`, `captionketiga`) VALUES (NULL, '"+textBox1.Text+"', '"+textBox6.Text+"', '"+textBox5.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"'); ", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Tambah Data");
                Koneksi.conn.Close();

                tampil();
            }
            catch (Exception)
            {

                MessageBox.Show("Tambah Data Gagal");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
        
        }

        private void button14_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblidentitas` SET `namatoko` = '" + textBox1.Text + "', `alamattoko` = '" + textBox6.Text + "', `nomortelepon` = '" + textBox5.Text + "', `captionpertama` = '" + textBox2.Text + "', `captionkedua` = '" + textBox3.Text + "', `captionketiga` = '" + textBox4.Text + "' WHERE `tblidentitas`.`id_identitastoko` = '" + idIdentitas + "';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil simpan Data");
                Koneksi.conn.Close();

                tampil();
            }
            catch (Exception)
            {

                MessageBox.Show("Ubah Data Gagal");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tambahkategori tambahkategori = new tambahkategori();
            tambahkategori.Show();
        }
    }
}
