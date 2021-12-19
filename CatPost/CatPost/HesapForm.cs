using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace CatPost
{
    public partial class HesapForm : Form
    {
        public HesapForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=restorant;Integrated Security=True;");
         public static int para = 0;
        private void yenile()
        {
            para = 0;
            listBox1.Items.Clear();
            if (Form3.gelen == 3)
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select * from siparis where masa_ad = @b and siparis_tür=1", baglanti);
                sorgu.Parameters.AddWithValue("@b", "hızlı_siparis");
                SqlDataReader oku = sorgu.ExecuteReader();
                while (oku.Read())
                {
                    int sayı = Convert.ToInt32(oku["masa_aktif"].ToString());
                    if (sayı == 1)
                    {
                        string siparis = oku["siparis_ad"].ToString() + " : " + oku["siparis_fiyat"].ToString() + " x " + oku["siparis_adet"].ToString() + " ( " + oku["ekstra_ad"] + " )";
                        listBox1.Items.Add(siparis);
                        para += Convert.ToInt32(oku["siparis_fiyat"].ToString()) * Convert.ToInt32(oku["siparis_adet"].ToString());
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
                baglanti.Close();
            }
            else
            {

                baglanti.Open();
                //label2.Text = GarsonForm.gidenmasaad.ToString();
                label2.Text = DinamikMasaSistemi.masaad.ToString();
                SqlCommand sorgu = new SqlCommand("select * from siparis where masa_ad = @a and siparis_tür=1", baglanti);
                sorgu.Parameters.AddWithValue("@a", label2.Text);
                SqlDataReader oku = sorgu.ExecuteReader();
                while (oku.Read())
                {
                    int sayı = Convert.ToInt32(oku["masa_aktif"].ToString());
                    if (sayı == 1)
                    {
                        string siparis = oku["siparis_ad"].ToString() + " : " + oku["siparis_fiyat"].ToString() + " x " + oku["siparis_adet"].ToString() + " ( " + oku["ekstra_ad"] + " )";
                        listBox1.Items.Add(siparis);
                        para += Convert.ToInt32(oku["siparis_fiyat"].ToString()) * Convert.ToInt32(oku["siparis_adet"].ToString());
                    }
                    else
                    {
                        listBox1.Items.Clear();
                    }
                }
                baglanti.Close();

            }
            label3.Text = para.ToString() + " TL";
        }
        int gelen = Convert.ToInt32(Form3.gelen.ToString());
        private void HesapForm_Load(object sender, EventArgs e)
        {
            yenile();
            if (gelen == 1)
            {
                button1.Text = "Masa Menü";
            }
            else if (Form3.gelen == 3)
            {
                label2.Text = "Hızlı Sipariş";
            }
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void HesapForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void HesapForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void HesapForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                SiparisForm form = new SiparisForm();
                this.Close();
                form.Show();
            }
            else if (Form3.gelen == 3)
            {
                SiparisForm form = new SiparisForm();
                this.Close();
                form.Show();
            }
            else
            {
                //GarsonForm form = new GarsonForm();
                DinamikMasaSistemi form = new DinamikMasaSistemi();
                this.Close();
                form.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Form3.gelen == 3)
            {
                TotalForm formgit = new TotalForm();
                this.Close();
                formgit.Show();
            }
            else
            {

                //Hesap form loadında otomatik ürün olan 1 e çevrildiği için dönmüyordu ödeme kısmına geçip ordan fiş verip boş haline dönmeli
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("UPDATE masa SET masa_tür=2 WHERE masa_ad='" + label2.Text + "'", baglanti);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                TotalForm form = new TotalForm();
                this.Close();
                form.Show();

            }
            
        }

        string kelime = "";
        string totalpara = "";
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem.ToString() != "")
            {
                kelime = listBox1.SelectedItem.ToString();
                label5.Text = kelime.Substring(0, kelime.IndexOf(":") - 1);
                totalpara = label3.Text;
                label6.Text = totalpara.Substring(0, totalpara.Length - 3);
                listBox1.Items.Remove(listBox1.SelectedItem);
            }

            if (Form3.gelen == 3)
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update siparis set siparis_tür = 3, masa_aktif=0 where masa_ad=@a and masa_aktif=1 and siparis_ad=@b", baglanti);
                sorgu.Parameters.AddWithValue("@a", "hızlı_siparis");
                sorgu.Parameters.AddWithValue("@b", label5.Text);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(label5.Text + " isimli sipariş iptal edildi");
                label5.Text = "";
            }
            else
            {

                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update siparis set siparis_tür = 3 where masa_ad=@a and masa_aktif=1 and siparis_ad=@b", baglanti);
                sorgu.Parameters.AddWithValue("@a", label2.Text);
                sorgu.Parameters.AddWithValue("@b", label5.Text);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
                MessageBox.Show(label5.Text + " isimli sipariş iptal edildi");
                label5.Text = "";

            }
            yenile();
        }

    }
}
