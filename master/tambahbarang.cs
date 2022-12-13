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

namespace master
{
    public partial class tambahbarang : Form
    {

        MySqlCommand cmd;
        public tambahbarang()
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `tblbarang`", Koneksi.conn);
                //membuat objek Dasa Set Baru
                DataSet ds = new DataSet();
                //ini digunakan untuk mengisi dataset dari Data Adapter
                da.Fill(ds);

                //Mengisi DataGrid Siswa dengan DataSet
                isna1.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }
        private void tambahbarang_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblbarang` SET `barang` = '"+TY.Text+"', '"+JM.Text+"', '"+JN.Text+"', '"+HC.Text +"'   = '15' WHERE `tblbarang`.`id_barang` = '"+IDBR.Text +"' ;", Koneksi.conn);
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

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void isna1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = isna1.CurrentCell.RowIndex;
            IDBR.Text = isna1.Rows[baris].Cells[0].Value.ToString();
            // MessageBox.Show(id);
            TY.Text = isna1.Rows[baris].Cells[1].Value.ToString();
            JM.Text = isna1.Rows[baris].Cells[2].Value.ToString();
            JN.Text = isna1.Rows[baris].Cells[3].Value.ToString();
            HC.Text = isna1.Rows[baris].Cells[4].Value.ToString();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblbarang WHERE `tblbarang`.`id_barang` = '"+IDBR.Text+"';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil hapus Data");
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
                cmd = new MySqlCommand("INSERT INTO `tblbarang` (`id_barang`, `id_kategori`, `barang`, `hargabeli`, `hargajual`, `stok`, `ketbarang`) VALUES (NULL, '"+TY.Text+"', '"+JM.Text+"', '"+JN.Text+"', '"+HC.Text+"', '1', 'dingin');", Koneksi.conn);
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
