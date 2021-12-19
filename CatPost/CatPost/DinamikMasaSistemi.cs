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
    public partial class DinamikMasaSistemi : Form
    {
        public DinamikMasaSistemi()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=restorant;Integrated Security=True;");
        public static string masaad, masatür = "";
        private void gorunus()
        {
            baglanti.Open();
            SqlCommand sorgu1 = new SqlCommand("select * from gorunus",baglanti);
            SqlDataReader oku = sorgu1.ExecuteReader();
            while (oku.Read())
            {
                this.Width = Convert.ToInt32(oku["gorunus_yatay"].ToString());
                flowLayoutPanel1.Width = Convert.ToInt32(oku["tablo_yatay"].ToString());
                this.Height = Convert.ToInt32(oku["gorunus_dikey"].ToString());
                flowLayoutPanel1.Height = Convert.ToInt32(oku["tablo_dikey"].ToString());
            }
            baglanti.Close();
        }
        private void DinamikMasaSistemi_Load(object sender, EventArgs e)
        {
            goruntule();
            gorunus();
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from masa", baglanti);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                masaad = oku["masa_ad"].ToString();
                masatür = oku["masa_tür"].ToString();
                Button btn = new Button();
                btn.Text = masaad;
                btn.Name = masatür;
                btn.Font = new Font("Times New Roman", 10);
                if (masatür == "0")
                {
                    //btn.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                    btn.Image = Image.FromFile("resim\\masa_boş.png");
                    btn.ForeColor = Color.White;
                }
                else if (masatür == "1")
                {
                    //btn.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                    btn.Image = Image.FromFile("resim\\masa_dolu.png");
                    btn.ForeColor = Color.Black;
                }
                else if (masatür == "2")
                {
                    //btn.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                    btn.Image = Image.FromFile("resim\\masa_hesap.png");
                    btn.ForeColor = Color.Black;
                }
                btn.Width = 140;
                btn.Height =117;
                flowLayoutPanel1.Controls.Add(btn);
                btn.Click += new EventHandler(btn_click);
            }
            baglanti.Close();
        }
        private void btn_click(object sender, EventArgs e)
        {
            //tıklanan butonun özelliğini alma
            Button b2 = sender as Button;
            masaad = b2.Text;
            masatür = b2.Name;
            SiparisForm form = new SiparisForm();
            this.Close();
            form.Show();
        }

        private void buttoncık_Click(object sender, EventArgs e)
        {
            //Environment.Exit(0);
            //this.Close();
            Application.Exit();
        }

        private void buttonasagı_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void DinamikMasaSistemi_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void DinamikMasaSistemi_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("select * from masa",baglanti);
            SqlDataReader oku = sorgu.ExecuteReader();
            while (oku.Read())
            {
                string veri = oku["masa_tür"].ToString();
                string veri_ad = oku["masa_ad"].ToString();
                if (veri == "0")
                {
                    
                }
                else if (veri == "1")
                {

                }
                else if(veri == "2")
                {

                }
            }
            baglanti.Close();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Close();
            form.Show();
        }
        int yükseklik = 471;
        int genişlik = 827;
        int layoutgenişlik = 757;
        int layoutyükseklik = 385;
        private void button1_Click(object sender, EventArgs e)
        {
                this.Height -= 20;
                flowLayoutPanel1.Height -= 20;
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update gorunus set tablo_dikey=@b , gorunus_dikey = @a where gorunus_id = 1", baglanti);
                sorgu.Parameters.AddWithValue("@a", this.Height);
                sorgu.Parameters.AddWithValue("@b", flowLayoutPanel1.Height);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
                this.Height += 20;
                flowLayoutPanel1.Height += 20;
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update gorunus set tablo_dikey=@b , gorunus_dikey = @a where gorunus_id = 1", baglanti);
                sorgu.Parameters.AddWithValue("@a", this.Height);
                sorgu.Parameters.AddWithValue("@b", flowLayoutPanel1.Height);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
                this.Width += 20;
                flowLayoutPanel1.Width += 20;
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update gorunus set tablo_yatay=@b , gorunus_yatay = @a where gorunus_id = 1", baglanti);
                sorgu.Parameters.AddWithValue("@a", this.Width);
                sorgu.Parameters.AddWithValue("@b", flowLayoutPanel1.Width);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
                this.Width -= 20;
                flowLayoutPanel1.Width -= 20;
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("update gorunus set tablo_dikey=@b , gorunus_dikey = @a where gorunus_id = 1", baglanti);
                sorgu.Parameters.AddWithValue("@a", this.Width);
                sorgu.Parameters.AddWithValue("@b", flowLayoutPanel1.Width);
                sorgu.ExecuteNonQuery();
                baglanti.Close();
        }
        private void goruntule()
        {
            this.Width = genişlik;
            this.Height = yükseklik;
            flowLayoutPanel1.Width = layoutgenişlik;
            flowLayoutPanel1.Height = layoutyükseklik;
        }
        private void button5_Click(object sender, EventArgs e)
        {
            goruntule();
        }

        private void DinamikMasaSistemi_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
