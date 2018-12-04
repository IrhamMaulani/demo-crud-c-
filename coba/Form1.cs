using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coba
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Database1Entities database1Entities = new Database1Entities();

            t_matakuliah matakuliah = new t_matakuliah();

            matakuliah.kode_matkul = textBox1.Text;
            matakuliah.nama_matkul = textBox2.Text;

            database1Entities.t_matakuliah.Add(matakuliah);

            database1Entities.SaveChanges();

            loadData();

            MessageBox.Show("Data Sukses Di input");

            resetFrom();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            loadData();

        }

        void loadData()
        {
            Database1Entities database1Entities = new Database1Entities();

            var data = (from d in database1Entities.t_matakuliah
                        select new
                        {
                            id = d.Id,
                            kode_matkul = d.kode_matkul,
                            nama_matkul = d.nama_matkul
                        });
            dataGridView1.DataSource = data.ToList();
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].HeaderText = "Kode Matkul";
            dataGridView1.Columns[2].HeaderText = "Nama Matkul";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatkul = int.Parse(id.Text);

                Database1Entities db = new Database1Entities();

                var data = (from d in db.t_matakuliah
                            where d.Id == idMatkul
                            select d).FirstOrDefault();

                data.kode_matkul = textBox1.Text;
                data.nama_matkul = textBox2.Text;

                db.SaveChanges();

                loadData();

                MessageBox.Show("Data telah di edit");

                resetFrom();
            }
            catch (Exception)
            {

                MessageBox.Show("Isikan Data");
            }
            
        }

        void resetFrom()
        {
            textBox1.Text = "";
            textBox2.Text = "";
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex > -1)
            {
                id.Text = this.dataGridView1[0, e.RowIndex].Value.ToString();
                textBox1.Text = this.dataGridView1[1, e.RowIndex].Value.ToString();
                textBox2.Text = this.dataGridView1[2, e.RowIndex].Value.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatkul = int.Parse(id.Text);

                Database1Entities db = new Database1Entities();

                var data = (from d in db.t_matakuliah
                            where d.Id == idMatkul
                            select d).FirstOrDefault();
                db.t_matakuliah.Remove(data);
                db.SaveChanges();
                loadData();
                MessageBox.Show("Data Telah Dihapus");
                resetFrom();
            }
            catch (Exception)
            {
                MessageBox.Show("Pilih Data Terlebih Dahulu");
            }
        }

        private void id_Click(object sender, EventArgs e)
        {

        }
    }
}
