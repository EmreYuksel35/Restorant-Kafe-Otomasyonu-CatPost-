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
    public partial class FormKasaHızlıSecim : Form
    {
        public FormKasaHızlıSecim()
        {
            InitializeComponent();
        }
        private bool dragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        private void FormKasaHızlıSecim_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void FormKasaHızlıSecim_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void FormKasaHızlıSecim_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3.gelen = 1;
            DinamikMasaSistemi form = new DinamikMasaSistemi();
            this.Close();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3.gelen = 3;
            SiparisForm form = new SiparisForm();
            this.Close();
            form.Show();
        }
    }
}
