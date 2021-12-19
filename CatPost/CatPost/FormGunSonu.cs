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
using System.Net.Mail;
using Microsoft.VisualBasic;

namespace CatPost
{
    public partial class FormGunSonu : Form
    {
        public FormGunSonu()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=restorant;Integrated Security=True;");
        SqlConnection baglanti1 = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=CatPost;Integrated Security=True;");
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void FormGunSonu_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormGunSonu_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormGunSonu_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void yenile()
        {
            DateTime gün = DateTime.Now.AddDays(-1);
            DataTable tablo = new DataTable();
            tablo.Clear();
            SqlCommand sorgu = new SqlCommand("select masa_ad,siparis_ad,ekstra_ad,siparis_fiyat,siparis_adet,siparis_tür,siparis_tarih from siparis where siparis_tarih > @a", baglanti);
            sorgu.Parameters.AddWithValue("@a",gün);
            SqlDataAdapter oku = new SqlDataAdapter(sorgu);
            oku.Fill(tablo);
            dataGridView1.DataSource = tablo;
        }
        double toplam_para = 0;
        private void toplam()
        {
            DateTime gün = DateTime.Now.AddDays(-1);
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from siparis where siparis_tarih > @b",baglanti);
            sorgu.Parameters.AddWithValue("@b", gün);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                toplam_para += Convert.ToInt32(oku["siparis_fiyat"].ToString())*Convert.ToInt32(oku["siparis_adet"].ToString());
            }
            baglanti.Close();
        }
        double oncekigun = 0;
        private void birgünonce()
        {
            DateTime bugün = DateTime.Now.AddDays(-1);
            DateTime dün = DateTime.Now.AddDays(-3);
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from siparis where siparis_tarih >  @c and siparis_tarih < @h",baglanti);
            sorgu.Parameters.AddWithValue("@c",dün);
            sorgu.Parameters.AddWithValue("@h",bugün);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                oncekigun += Convert.ToInt32(oku["siparis_fiyat"].ToString()) * Convert.ToInt32(oku["siparis_adet"].ToString());
            }
            baglanti.Close();
            if (toplam_para > oncekigun)
            {
                label4.Text = "+ " + Convert.ToString(toplam_para - oncekigun);
            }
            else if (toplam_para == oncekigun)
            {
                label4.Text = Convert.ToString(toplam_para - oncekigun);
            }
            else if (toplam_para < oncekigun)
            {
                label4.Text = "- " + Convert.ToString(oncekigun - toplam_para);
            }
        }
        double oncekihafta = 0;
        private void birhaftaonce()
        {
            DateTime hafta = DateTime.Now.AddDays(-8);
            DateTime suan = DateTime.Now.AddDays(-1);
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from siparis where siparis_tarih > @d and siparis_tarih < @g", baglanti);
            sorgu.Parameters.AddWithValue("@d", hafta);
            sorgu.Parameters.AddWithValue("@g", suan);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                oncekihafta += Convert.ToInt32(oku["siparis_fiyat"].ToString()) * Convert.ToInt32(oku["siparis_adet"].ToString());
            }
            oncekihafta = Math.Round((oncekihafta / 7),2);
            baglanti.Close();
            if (toplam_para > oncekihafta)
            {
                label6.Text = "+ " + Convert.ToString(toplam_para - oncekihafta);
            }
            else if (toplam_para == oncekihafta)
            {
                label6.Text = Convert.ToString(toplam_para - oncekihafta);
            }
            else if (toplam_para < oncekihafta)
            {
                label6.Text = "- " + Convert.ToString(oncekihafta - toplam_para);
            }
        }
        double oncekiay = 0;
        private void birayonce()
        {
            DateTime ay = DateTime.Now.AddMonths(-1);
            DateTime gün = DateTime.Now.AddDays(-1);
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from siparis where siparis_tarih > @e and siparis_tarih < @j", baglanti);
            sorgu.Parameters.AddWithValue("@e", ay);
            sorgu.Parameters.AddWithValue("@j", gün);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                oncekiay += Convert.ToInt32(oku["siparis_fiyat"].ToString()) * Convert.ToInt32(oku["siparis_adet"].ToString());
            }
            oncekiay = Math.Round((oncekiay / 30),2);
            baglanti.Close();
            if (toplam_para > oncekiay)
            {
                label8.Text = "+ " + Convert.ToString(toplam_para - oncekiay);
            }
            else if (toplam_para == oncekiay)
            {
                label8.Text = Convert.ToString(toplam_para - oncekiay);
            }
            else if (toplam_para < oncekiay)
            {
                label8.Text = "- " + Convert.ToString(oncekiay - toplam_para);
            }
        }
        private void FormGunSonu_Load(object sender, EventArgs e)
        {
            yenile();
            toplam();
            label2.Text = toplam_para.ToString() + " TL";
            birgünonce();
            birhaftaonce();
            birayonce();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            printDocument1.Print();
            string soru = Microsoft.VisualBasic.Interaction.InputBox("E-Mail Atmak İçin Evet Yazın , Atmamak İçin Hayır Yazın");
            if (soru == "Evet")
            {
                button4.Visible = true;
            }
            else
            {
                button4.Visible = false;
                Application.Exit();
            }
            //Application.Exit();
        }

        Font Baslik = new Font("Times New Roman", 20, FontStyle.Bold);
        Font altBaslik = new Font("Times New Roman", 12, FontStyle.Regular);
        Font icerik = new Font("Times New Roman", 10);
        SolidBrush sb = new SolidBrush(Color.Black);
        int i = 0;
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            DateTime tarih = DateTime.Now;
            DateTime gün = DateTime.Now.AddDays(-1);
            string adres = "";
            string tel = "";
            StringFormat st = new StringFormat();
            st.Alignment = StringAlignment.Near;
            e.Graphics.DrawString(Form1.gidenbilgi.ToString(), Baslik, sb, 150, 100, st);
            baglanti1.Open();
            SqlCommand sorgu1 = new SqlCommand("select * from uyeler where uye_ad = @a", baglanti1);
            sorgu1.Parameters.AddWithValue("@a", Form1.gidenbilgi.ToString());
            SqlDataReader oku1 = sorgu1.ExecuteReader();
            while (oku1.Read())
            {
                tel = oku1["uye_tel"].ToString();
                adres = oku1["uye_adres"].ToString();
            }
            baglanti1.Close();
            e.Graphics.DrawString(adres + " ", altBaslik, sb, 150, 140, st);
            e.Graphics.DrawString("Tel : " + tel, altBaslik, sb, 150, 160, st);
            e.Graphics.DrawString("Tarih : " + tarih, altBaslik, sb, 150, 180, st);
            e.Graphics.DrawString("Kasiyer : " + Form2.personelad.ToString(), altBaslik, sb, 150, 200);

            e.Graphics.DrawString("--------------------------------------------------------------------------------", altBaslik, sb, 150, 210, st);
            e.Graphics.DrawString("Ürün Adı             Adet             Fiyat             Ekstra", altBaslik, sb, 150, 230, st);
            e.Graphics.DrawString("--------------------------------------------------------------------------------", altBaslik, sb, 150, 240, st);
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select masa_ad,siparis_ad,ekstra_ad,siparis_fiyat,siparis_adet,siparis_tür,siparis_tarih from siparis where siparis_tarih > @c", baglanti);
            sorgu.Parameters.AddWithValue("@c", gün);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                i += 1;
                e.Graphics.DrawString((oku["siparis_ad"] + "                       " + oku["siparis_adet"] + "                      " + oku["siparis_fiyat"] + "                       " + oku["ekstra_ad"]), icerik, sb, 150, 250 + i * 30, st);
            }
            baglanti.Close();
            e.Graphics.DrawString("--------------------------------------------------------------------------------", altBaslik, sb, 150, 250 + 35 * i, st);
            e.Graphics.DrawString("Toplam Tutar :  " + HesapForm.para.ToString(), altBaslik, sb, 150, 235 + 40 * (i + 1), st);
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
             DialogResult sec = openFileDialog1.ShowDialog();
            if (sec ==DialogResult.OK)
            {
                MailMessage e_mail = new MailMessage();
                try
                {
                    e_mail.From = new MailAddress("kimden");
                    e_mail.To.Add("kime");
                    e_mail.Subject = "Gün Sonu Raporu ";
                    e_mail.Body = "";//"catpost test"

                    try
                    {
                        e_mail.Attachments.Add(new Attachment(openFileDialog1.FileName));
                    }
                    catch (Exception)
                    {
                    }

                    SmtpClient smtp = new SmtpClient("smtp.live.com");
                    //smtp.Host = "smtp.live.com";//gmail ise smtp.gmail.com hotmail iste smtp.live.com
                    smtp.Port = 587;
                    smtp.EnableSsl = true; //hotmail true gmailde false
                    smtp.Credentials = new System.Net.NetworkCredential("kimden", "kimden şifre");
                    smtp.Send(e_mail);
                }
                catch (Exception)
                {
                    MessageBox.Show("GÖNDERİLDİ");
                }
                Application.Exit();
            }
            

        }
    }
}
