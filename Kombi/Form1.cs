using Kombi.Madam;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Kombi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            
           
            yukle();
        }
        MusteriBilgisi _bilgi = new MusteriBilgisi();
        
        private void btnEkle_Click(object sender, EventArgs e)
        {
            _bilgi.MAd = txtAd.Text;
            _bilgi.MSoyad = txtSoyad.Text;
            _bilgi.Adres = txtAdres.Text;
            _bilgi.Ariza = txtAriza.Text;
            _bilgi.DParca = txtParca.Text;
            _bilgi.Fiyat = Convert.ToDouble(txtFiyat.Text);

            _bilgi.Ekle(_bilgi);
            yukle();
            Tutar();
        }

        private void Tutar()
        {

            double toplam = 0;
            for (int i = 0; i < dtgList.Rows.Count; i++)
            {
                
                toplam += Convert.ToDouble(dtgList.Rows[i].Cells[6].Value);
                lblToplam.Text = toplam.ToString() + "TL";
            }

            yukle();
        }

        private void yukle(string Ara="")
        {
            if (Ara == "")
            {
                dtgList.DataSource = _bilgi.get();
            }
            else
            {
                dtgList.DataSource = _bilgi.get(Ara);
            }
            
            txtAd.Text = txtSoyad.Text = txtAdres.Text = txtAriza.Text = txtParca.Text = txtFiyat.Text = "";
        }

        private void btnDuzenle_Click(object sender, EventArgs e)
        {
            _bilgi.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);
            _bilgi.MAd = txtAd.Text;
            _bilgi.MSoyad = txtSoyad.Text;
            _bilgi.Adres = txtAdres.Text;
            _bilgi.Ariza = txtAriza.Text;
            _bilgi.DParca = txtParca.Text;
            _bilgi.Fiyat = Convert.ToDouble(txtFiyat.Text);
            _bilgi.Duzenle(_bilgi);
            Tutar();
            yukle();
            MessageBox.Show("Düzenlendi.");
           
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            txtAd.Text = dtgList.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text = dtgList.CurrentRow.Cells[2].Value.ToString();
            txtAdres.Text = dtgList.CurrentRow.Cells[3].Value.ToString();
            txtAriza.Text = dtgList.CurrentRow.Cells[4].Value.ToString();
            txtParca.Text = dtgList.CurrentRow.Cells[5].Value.ToString();
            txtFiyat.Text = dtgList.CurrentRow.Cells[6].Value.ToString();
           
            
        }

        private void txtAra_TextChanged(object sender, EventArgs e)
        {
            yukle(txtAra.Text);
        }

        private void btnkaldir_Click(object sender, EventArgs e)
        {
            _bilgi.Id = Convert.ToInt32(dtgList.CurrentRow.Cells[0].Value);

            _bilgi.sil(_bilgi);
            MessageBox.Show("Kayıt Kaldırıldı");
            yukle();
            Tutar();
        }

       
        private void lblToplam_Click(object sender, EventArgs e)
        {
            Tutar();
        }

        private void mList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
