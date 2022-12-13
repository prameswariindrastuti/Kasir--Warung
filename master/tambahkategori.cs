using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace master
{
    public partial class tambahkategori : Form
    {
        public MySqlCommand cmd;
        public tambahkategori()
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `tblkategori`", Koneksi.conn);
                //membuat objek Dasa Set Baru
                DataSet ds = new DataSet();
                //ini digunakan untuk mengisi dataset dari Data Adapter
                da.Fill(ds);

                //Mengisi DataGrid Siswa dengan DataSet
                jaemin.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }
        private void button20_Click(object sender, EventArgs e)
        {
            tambahkategori tambahkategori = new tambahkategori();
            tambahkategori.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = jaemin.CurrentCell.RowIndex;
            lbid.Text = jaemin.Rows[baris].Cells[0].Value.ToString();
            // MessageBox.Show(id);
            robin.Text = jaemin.Rows[baris].Cells[1].Value.ToString();
        }

        private void tambahkategori_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblkategori` (`id_kategori`, `kategori`) VALUES (NULL, '"+ robin.Text +"');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Tambah Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah data Gagal");
            }

}

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblkategori` SET `id_kategori` = '2345', `kategori` = 'nasiiiiii' WHERE `tblkategori`.`id_kategori` = 234;", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Edit Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah Edit Gagal");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try 
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblkategori WHERE `tblkategori`.`id_kategori` = '"+lbid.Text+"'", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Hapus Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Hapus Data Gagal");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblkategori` SET `kategori` = 'mie hantu' WHERE `tblkategori`.`id_kategori` = 567;", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Simpan Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Simpan Data Gagal");
            }
        }
    }
    }
    

