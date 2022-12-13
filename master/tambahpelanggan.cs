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
    public partial class tambahpelanggan : Form
    {
        MySqlCommand cmd;

        public tambahpelanggan()
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
                MySqlDataAdapter da = new MySqlDataAdapter("SELECT * FROM `tblpelanggan`", Koneksi.conn);
                //membuat objek Dasa Set Baru
                DataSet ds = new DataSet();
                //ini digunakan untuk mengisi dataset dari Data Adapter
                da.Fill(ds);

                //Mengisi DataGrid Siswa dengan DataSet
                jeno.DataSource = ds.Tables[0];
                Koneksi.conn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Duh!!, Ada Error Nih");
            }
        }
        private void tambahpelanggan_Load(object sender, EventArgs e)
        {
            tampil();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void jeno_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int baris = jeno.CurrentCell.RowIndex;
            IDPL.Text = jeno.Rows[baris].Cells[0].Value.ToString();
            // MessageBox.Show(id);
            zoro.Text = jeno.Rows[baris].Cells[1].Value.ToString();
            nami.Text = jeno.Rows[baris].Cells[2].Value.ToString();
            luffy.Text = jeno.Rows[baris].Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("UPDATE `tblpelanggan` SET `pelanggan` = '" + zoro.Text + "', `alamat` = '" + nami.Text + "', `notlp` = '" + luffy.Text + "' WHERE `tblpelanggan`.`id_pelanggan` =  '"+IDPL.Text+"';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil tambah Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah Data Gagal");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("DELETE FROM tblpelanggan WHERE `tblpelanggan`.`id_pelanggan` = '"+IDPL.Text+"';", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil hapus Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah Hapus Gagal");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Koneksi.conn.Open();
                cmd = new MySqlCommand("INSERT INTO `tblpelanggan` (`id_pelanggan`, `pelanggan`, `alamat`, `notlp`) VALUES (NULL, '"+zoro.Text+"', '"+nami.Text+"', '"+luffy.Text +"');", Koneksi.conn);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Berhasil Simpan Data");
                Koneksi.conn.Close();
                tampil();
            }
            catch (Exception)
            {
                MessageBox.Show("Tambah Simpan Gagal");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {

        }
    }
}
