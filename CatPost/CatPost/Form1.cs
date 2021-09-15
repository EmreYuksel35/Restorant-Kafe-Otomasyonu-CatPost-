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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Form2 form2 = new Form2();
        public static string gidenbilgi = "";
        public static string süre = "";
        SqlConnection baglanti = new SqlConnection("Data Source=LAPTOP-G03C6BH4\\SQLEXPRESS;Initial Catalog=CatPost;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                    baglanti.Open();
                    SqlCommand sorgu = new SqlCommand("select * from uyeler where uye_ad=@ad and uye_sifre=@sifre", baglanti);
                    sorgu.Parameters.AddWithValue("@ad", textBox1.Text);
                    sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
                    SqlDataReader bilgi = sorgu.ExecuteReader();
                    while (bilgi.Read())
                    {
                        gidenbilgi = textBox1.Text;
                        string uyeliksuresi = bilgi["süre"].ToString();
                        TimeSpan kalanzaman = Convert.ToDateTime(uyeliksuresi) - DateTime.Now;
                        süre = Convert.ToString(kalanzaman.Days);
                        if (Convert.ToInt32(süre) >= 0)
                        {
                            this.Hide();
                            form2.ShowDialog();
                        }
                        else
                        {
                            MessageBox.Show("Üyelik süreniz dolmuştur lütfen CatPost firması ile iletişime geçiniz !!");
                        }
                    }
                    baglanti.Close();
            }
            else
            {
                MessageBox.Show("Kullanıcı adı ve şifre giriniz !!");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Environment.Exit(0);
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
