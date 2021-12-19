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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = Form1.gidenbilgi.ToString()+" - "+Form1.süre.ToString()+" Gün Kaldı";
        }
        public static string yetki = "";
        public static string personelad = "";
        Form3 form3 = new Form3();
        SqlConnection baglanti = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=restorant;Integrated Security=True;");
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                baglanti.Open();
                SqlCommand sorgu = new SqlCommand("select * from personel where personel_ad=@ad and personel_sifre=@sifre", baglanti);
                sorgu.Parameters.AddWithValue("@ad", textBox1.Text);
                sorgu.Parameters.AddWithValue("@sifre", textBox2.Text);
                SqlDataReader bilgi = sorgu.ExecuteReader();
                while (bilgi.Read())
                {
                    yetki = bilgi["personel_yetki"].ToString();
                    personelad = bilgi["personel_ad"].ToString();
                    this.Hide();
                    form3.ShowDialog();
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
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
    }
}
