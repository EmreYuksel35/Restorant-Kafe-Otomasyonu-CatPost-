using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatPost
{
    public partial class GarsonForm : Form
    {
        public GarsonForm()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=SQLVERİTABANI;Initial Catalog=restorant;Integrated Security=True;");

        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void GarsonForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void GarsonForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void GarsonForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //this.Close();
            //Environment.Exit(0);
            Application.Exit();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            Form3 form = new Form3();
            this.Close();
            form.Show();
        }
        int gelen = 0;
        private void GarsonForm_Load(object sender, EventArgs e)
        {
            timer1.Start();
            gelen = Convert.ToInt32(Form3.gelen.ToString());
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
                    switch (veri_ad)
                    {
                        case "Masa_1":
                            button1.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button1.ForeColor = Color.White; break;
                        case "Masa_2":
                            button2.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button2.ForeColor = Color.White; break;
                        case "Masa_3":
                            button3.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button3.ForeColor = Color.White; break;
                        case "Masa_4":
                            button4.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button4.ForeColor = Color.White; break;
                        case "Masa_5":
                            button5.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button5.ForeColor = Color.White; break;
                        case "Masa_6":
                            button6.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button6.ForeColor = Color.White; break;
                        case "Masa_7":
                            button7.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button7.ForeColor = Color.White; break;
                        case "Masa_8":
                            button8.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button8.ForeColor = Color.White; break;
                        case "Masa_9":
                            button9.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button9.ForeColor = Color.White; break;
                        case "Masa_10":
                            button10.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button10.ForeColor = Color.White; break;
                        case "Masa_11":
                            button11.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button11.ForeColor = Color.White; break;
                        case "Masa_12":
                            button12.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button12.ForeColor = Color.White; break;
                        case "Masa_13":
                            button13.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button13.ForeColor = Color.White; break;
                        case "Masa_14":
                            button14.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button14.ForeColor = Color.White; break;
                        case "Masa_15":
                            button15.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_boş.png");
                            button15.ForeColor = Color.White; break;
                    }
                }
                else if (veri == "1")
                {
                    switch (veri_ad)
                    {
                        case "Masa_1":
                            button1.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button1.ForeColor = Color.Black; break;
                        case "Masa_2":
                            button2.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button2.ForeColor = Color.Black; break;
                        case "Masa_3":
                            button3.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button3.ForeColor = Color.Black; break;
                        case "Masa_4":
                            button4.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button4.ForeColor = Color.Black; break;
                        case "Masa_5":
                            button5.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button5.ForeColor = Color.Black; break;
                        case "Masa_6":
                            button6.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button6.ForeColor = Color.Black; break;
                        case "Masa_7":
                            button7.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button7.ForeColor = Color.Black; break;
                        case "Masa_8":
                            button8.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button8.ForeColor = Color.Black; break;
                        case "Masa_9":
                            button9.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button9.ForeColor = Color.Black; break;
                        case "Masa_10":
                            button10.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button10.ForeColor = Color.Black; break;
                        case "Masa_11":
                            button11.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button11.ForeColor = Color.Black; break;
                        case "Masa_12":
                            button12.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button12.ForeColor = Color.Black; break;
                        case "Masa_13":
                            button13.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button13.ForeColor = Color.Black; break;
                        case "Masa_14":
                            button14.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button14.ForeColor = Color.Black; break;
                        case "Masa_15":
                            button15.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_dolu.png");
                            button15.ForeColor = Color.Black; break;
                    }
                }
                else if (veri == "2")
                {
                    switch (veri_ad)
                    {
                        case "Masa_1":
                            button1.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button1.ForeColor = Color.Black; break;
                        case "Masa_2":
                            button2.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button2.ForeColor = Color.Black; break;
                        case "Masa_3":
                            button3.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button3.ForeColor = Color.Black; break;
                        case "Masa_4":
                            button4.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button4.ForeColor = Color.Black; break;
                        case "Masa_5":
                            button5.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button5.ForeColor = Color.Black; break;
                        case "Masa_6":
                            button6.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button6.ForeColor = Color.Black; break;
                        case "Masa_7":
                            button7.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button7.ForeColor = Color.Black; break;
                        case "Masa_8":
                            button8.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button8.ForeColor = Color.Black; break;
                        case "Masa_9":
                            button9.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button9.ForeColor = Color.Black; break;
                        case "Masa_10":
                            button10.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button10.ForeColor = Color.Black; break;
                        case "Masa_11":
                            button11.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button11.ForeColor = Color.Black; break;
                        case "Masa_12":
                            button12.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button12.ForeColor = Color.Black; break;
                        case "Masa_13":
                            button13.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button13.ForeColor = Color.Black; break;
                        case "Masa_14":
                            button14.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button14.ForeColor = Color.Black; break;
                        case "Masa_15":
                            button15.Image = Image.FromFile("C:\\Users\\Noc\\Desktop\\Sistem Analizi - Restorant Otomasyonu\\image\\masa_hesap.png");
                            button15.ForeColor = Color.Black; break;
                    }
                }
            }baglanti.Close();
        }
        public static string gidenmasaad = "";
        private void masadolu(string ad)
        {
            gidenmasaad = ad;
            SiparisForm menu = new SiparisForm();
            this.Close();
            menu.Show();
        }
        private void kasa(string ad)
        {
            gidenmasaad = ad;
            HesapForm menu = new HesapForm();
            this.Close();
            menu.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_1");
            }
            else
            {
                kasa("Masa_1");
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_2");
            }
            else
            {
                kasa("Masa_2");
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_3");
            }
            else
            {
                kasa("Masa_3");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_4");
            }
            else
            {
                kasa("Masa_4");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_5");
            }
            else
            {
                kasa("Masa_5");
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_6");
            }
            else
            {
                kasa("Masa_6");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_7");
            }
            else
            {
                kasa("Masa_7");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_8");
            }
            else
            {
                kasa("Masa_8");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_9");
            }
            else
            {
                kasa("Masa_9");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_10");
            }
            else
            {
                kasa("Masa_10");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_11");
            }
            else
            {
                kasa("Masa_11");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_12");
            }
            else
            {
                kasa("Masa_12");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_13");
            }
            else
            {
                kasa("Masa_13");
            }
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_14");
            }
            else
            {
                kasa("Masa_14");
            }
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (gelen == 2)
            {
                masadolu("Masa_15");
            }
            else
            {
                kasa("Masa_15");
            }
        }

        private void button16_Click(object sender, EventArgs e)
        {
            DinamikMasaSistemi gec = new DinamikMasaSistemi();
            gec.ShowDialog();
        }
    }
}
