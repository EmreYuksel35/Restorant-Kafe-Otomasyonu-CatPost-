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
using Microsoft.VisualBasic;

namespace CatPost
{
    public partial class MasaForm : Form
    {
        public MasaForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-G03C6BH4\\SQLEXPRESS;Initial Catalog=restorant;Integrated Security=True;");
        private void yenile()
        {
            SqlCommand sorgu = new SqlCommand("select * from masa", baglanti);
            SqlDataAdapter veri = new SqlDataAdapter(sorgu);
            DataTable tablo = new DataTable();
            veri.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Open();
            SqlCommand masasayı = new SqlCommand("select count(*) from masa",baglanti);
            string sayı = (masasayı.ExecuteScalar()).ToString();
            label4.Text = sayı;
            baglanti.Close();
        }
        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            //Environment.Exit(0);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;

        private void MasaForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void MasaForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void MasaForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string masa = Microsoft.VisualBasic.Interaction.InputBox("Eklenmek istenen masa sayısı");
            if (masa != "")
            {
                for (int i = 0; i < Convert.ToInt32(masa); i++)
                {
                    baglanti.Open();
                    string masa_ad = Microsoft.VisualBasic.Interaction.InputBox("Eklenmek istenen masa adı");
                    SqlCommand sorgu = new SqlCommand("insert into masa (masa_ad,masa_tür) values (@a,0)", baglanti);
                    sorgu.Parameters.AddWithValue("@a", masa_ad);
                    sorgu.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla " + masa_ad + " adı ile masa eklendi !");
                    baglanti.Close();
                    yenile();
                }
            }
            
        }

        private void MasaForm_Load(object sender, EventArgs e)
        {
            yenile();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string bolum = Microsoft.VisualBasic.Interaction.InputBox("Eklenmek istenen bolum adı giriniz");
            baglanti.Open();
            if (bolum != "")
            {
                SqlCommand sorgu = new SqlCommand("select * from bolum where bolum_ad =@bolum", baglanti);
                sorgu.Parameters.AddWithValue("bolum", bolum);
                string veri = sorgu.ExecuteScalar().ToString();
                if (Convert.ToInt32(veri) == 0)
                {
                    SqlCommand kaydet = new SqlCommand("insert into bolum bolum_ad values (@a)", baglanti);
                    kaydet.Parameters.AddWithValue("@a", bolum);
                    kaydet.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla kayıt edildi !");
                }
                else if (Convert.ToInt32(veri) == 1)
                {
                    MessageBox.Show("Bu bilgilere ait bölüm bulunmaktadır !");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bölüm adı giriniz !");
            }
            baglanti.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string bolum = Microsoft.VisualBasic.Interaction.InputBox("Silmek istenilen bolum adı giriniz");
            baglanti.Open();
            if (bolum != "")
            {
                SqlCommand sorgu = new SqlCommand("select * from bolum where bolum_ad =@bolum", baglanti);
                sorgu.Parameters.AddWithValue("bolum", bolum);
                string veri = sorgu.ExecuteScalar().ToString();
                if (Convert.ToInt32(veri) == 1)
                {
                    SqlCommand kaydet = new SqlCommand("delete from bolum where bolum_ad = @a", baglanti);
                    kaydet.Parameters.AddWithValue("@a", bolum);
                    kaydet.ExecuteNonQuery();
                    MessageBox.Show("Başarıyla kayıt silindi !");
                }
                else if (Convert.ToInt32(veri) == 0)
                {
                    MessageBox.Show("Bu bilgilere ait bölüm bulunmamaktadır !");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bölüm adı giriniz !");
            }
            baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            string masa_ad = Microsoft.VisualBasic.Interaction.InputBox("Silmek istenilen masa adı giriniz");
            SqlCommand sorgu = new SqlCommand("delete from masa where masa_ad = @a", baglanti);
            sorgu.Parameters.AddWithValue("@a",masa_ad);
            sorgu.ExecuteNonQuery();
            MessageBox.Show("Masa başarıyla silindi");
            baglanti.Close();

            baglanti.Open();
            SqlCommand sorgu1 = new SqlCommand("delete from siparis where masa_ad = @b",baglanti);
            sorgu1.Parameters.AddWithValue("@b",masa_ad);
            sorgu1.ExecuteNonQuery();
            baglanti.Close();
            yenile();
        }
    }
}
