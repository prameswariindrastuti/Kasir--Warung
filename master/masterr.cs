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
    public partial class masterr : Form
    {
        public masterr()
        {
            InitializeComponent();
        }

        private void button21_Click(object sender, EventArgs e)
        {
            identitastoko identitastoko = new identitastoko();
            identitastoko.Show();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            tambahkategori tambahkategori = new tambahkategori();
            tambahkategori.Show();
        }

        private void button19_Click(object sender, EventArgs e)
        {
            tambahbarang tambahbarang = new tambahbarang();
            tambahbarang.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            tambahpelanggan tambahpelanggan = new tambahpelanggan();
            tambahpelanggan.Show();
        }
    }
}
