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
    public partial class tr_penjualan : Form
    {
        Koneksi koneksi = new Koneksi();

        public void Tampil()
        {
            //Query Database
            DataTable1.DataSource = koneksi.ShowData("SELECT * FROM tblpenjualan");

        }
        public tr_penjualan()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tr_penjualan_Load(object sender, EventArgs e)
        {
            Tampil();
        }
    }
}
