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
    public partial class KullaniciGiris : Form
    {
        public KullaniciGiris()
        {
            InitializeComponent();
        }

        private void KullanıcıGiris_Load(object sender, EventArgs e)
        {
            
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();

            if (txtKAd.Text=="admin"&&txtPass.Text=="123456")
            {
                MessageBox.Show("Giriş Başarılı");
                frm.ShowDialog();

            }
            else
            {
                MessageBox.Show("Giriş Başarısız.");
            }
            Close();
            Dispose();
        }
        
    }
}
