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
    public partial class home : Form
    {
        public home()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
           masterr masterr = new masterr();
            masterr.ShowDialog();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tr_penjualan tr_Penjualan = new tr_penjualan();
            tr_Penjualan.Show();
        }

        private void home_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try

            {

                Koneksi.conn.Open();

                MessageBox.Show("Koneksi Database Berhasil");

            }

            catch (Exception)

            {

                

                MessageBox.Show("Koneksi Gagal");

            }
        }
    }
}
