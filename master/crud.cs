using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apkOnline_shop
{
    internal class Crud
    {
        public MySqlConnection con;
        public MySqlDataReader dr;
        public MySqlCommand cmd;
        public DataGridView dg;
        public ComboBox cb;

        public void laptop(String pesan)
        {
            MessageBox.Show(pesan);
        }

        public void koneksi()
        {
            try
            {
                string konf = "Server=localhost;Port=3306;UID=root;PWD=;Database=dbkasironline";

                con = new MySqlConnection(konf);
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                con.Close();
            }
        }

        public void tampil(String query, String mode, DataGridView dg,
            [Optional] ComboBox cmb, [Optional] String diisi, [Optional] String tampil,
            [Optional] Byte[] imagebyte,
            [Optional] PictureBox picture)
        {
            try
            {

                MySqlDataAdapter adp = new MySqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                adp.Fill(dt);
                switch (mode)
                {
                    case "tampil":
                        dg.DataSource = dt;
                        break;
                    case "combo":
                        cmb.DataSource = dt;
                        cmb.DisplayMember = tampil;
                        cmb.ValueMember = diisi;
                        break;
                        //case "gambar":
                        //picture.Image = Image.FromStream(new MemoryStream(imagebyte));
                        // break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void isi(String query, String mode, [Optional] String pesan, [Optional] String field, [Optional] String Imagefile)
        {
            koneksi();

            try
            {
                switch (mode)
                {
                    case "hapus":
                        DialogResult dialog = MessageBox.Show("Yakin ingin menghapus data?", "confirmation", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.OK)
                        {
                            cmd = new MySqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data Berhasiil Dihapus", "Hapus Data", MessageBoxButtons.OK);

                        break;
                    case "simpan":

                        cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        switch (pesan)
                        {
                            case "simpan":
                                MessageBox.Show("Data Berhasiil Disimpan", "Simpan Data", MessageBoxButtons.OK);
                                break;
                            case "ubah":
                                MessageBox.Show("Data Berhasiil Diubah", "Ubah Data", MessageBoxButtons.OK);
                                break;


                        }
                        break;
                    case "simpanGambar":
                        cmd = new MySqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@" + field, File.ReadAllBytes(Imagefile));
                        cmd.ExecuteNonQuery();
                        switch (pesan)
                        {
                            case "simpan":
                                MessageBox.Show("Data Berhasiil Disimpan", "Simpan Data", MessageBoxButtons.OK);
                                break;
                            case "ubah":
                                MessageBox.Show("Data Berhasiil Diubah", "Ubah Data", MessageBoxButtons.OK);
                                break;
                        }
                        break;
                    case "cari":
                        cmd = new MySqlCommand(query, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        break;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }


        }

        public void simpan(String query, String mode, [Optional] String pesan)
        {
            koneksi();

            try
            {

                switch (mode)
                {
                    case "hapus":
                        DialogResult dialog = MessageBox.Show("Yakin ingin menghapus data?", "confirmation", MessageBoxButtons.YesNo);
                        if (dialog == DialogResult.OK)
                        {
                            cmd = new MySqlCommand(query, con);
                            cmd.ExecuteNonQuery();
                        }

                        MessageBox.Show("Data Berhasiil Dihapus", "Hapus Data", MessageBoxButtons.OK);

                        break;
                    case "simpan":

                        cmd = new MySqlCommand(query, con);
                        cmd.ExecuteNonQuery();
                        switch (pesan)
                        {
                            case "simpan":
                                MessageBox.Show("Data Berhasiil Disimpan", "Simpan Data", MessageBoxButtons.OK);
                                break;
                            case "ubah":
                                MessageBox.Show("Data Berhasiil Diubah", "Ubah Data", MessageBoxButtons.OK);
                                break;

                        }
                        break;

                    case "cari":
                        cmd = new MySqlCommand(query, con);
                        dr = cmd.ExecuteReader();
                        dr.Read();

                        break;
                }
            }
            catch (Exception x)
            {
                MessageBox.Show(x.Message);
            }
        }

    }
}