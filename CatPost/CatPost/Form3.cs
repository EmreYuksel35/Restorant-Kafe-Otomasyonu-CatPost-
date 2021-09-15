using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatPost
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string yetki;
        AdminForm form4 = new AdminForm();
        private void Form3_Load(object sender, EventArgs e)
        {
            label1.Text = "Personel = "+Form2.personelad.ToString();
            yetki = Form2.yetki.ToString();
            switch (yetki)
            {
                case "1":
                    this.Height = 384;
                    break;
                case "2" :
                    button2.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "3":
                    button1.Enabled = false;
                    button3.Enabled = false;
                    break;
                case "4":
                    button1.Enabled = false;
                    button2.Enabled = false;
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            form4.ShowDialog();
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void Form3_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void Form3_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form3_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }
        public static int gelen = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            gelen = 1;
            //GarsonForm form = new GarsonForm();
            //DinamikMasaSistemi form = new DinamikMasaSistemi();
            FormKasaHızlıSecim form = new FormKasaHızlıSecim();
            this.Close();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            gelen = 2;
            //GarsonForm form = new GarsonForm();
            DinamikMasaSistemi form = new DinamikMasaSistemi();
            this.Close();
            form.Show();
        }
    }
}
