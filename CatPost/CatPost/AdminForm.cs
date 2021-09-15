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
    public partial class AdminForm : Form
    {
        public AdminForm()
        {
            InitializeComponent();
        }
        PersonelForm form1 = new PersonelForm();
        YemekForm form2 = new YemekForm();
        MasaForm form3 = new MasaForm();
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            form1.ShowDialog();
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void AdminForm_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void AdminForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void AdminForm_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            form2.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form3 anamenü = new Form3();
            this.Close();
            anamenü.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            FormGunSonu form = new FormGunSonu();
            this.Close();
            form.Show();
        }
    }
}
