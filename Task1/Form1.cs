using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HW_Anketa
{
    public partial class Task1 : Form
    {
        public Task1()
        {
            InitializeComponent();
        }
        public string showCoordinates(MouseEventArgs e)
        {
            return $"Mouse coord: x = {e.X.ToString()} y = {e.Y.ToString()}";
        }

        private void Task1_MouseClick(object sender, MouseEventArgs e)
        {
            string msg;
            msg = showCoordinates(e);
            MessageBox.Show(msg, "Mouse click", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (e.X < 10 || e.X > panel1.Width - 10 || e.Y < 10 || e.Y > panel1.Height)
                MessageBox.Show("Курсор за прямоугольником");
            else if (e.X == 10 || e.X == panel1.Width - 10 || e.Y == 10 || e.Y == panel1.Height)
                MessageBox.Show("Курсор на границе прямоугольника");
            else
                MessageBox.Show("Курсор внутри прямоугольника");
        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                Close();
            }
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Размер клиентской области: ширина = {panel1.Width}, высота = {panel1.Height}";
            }
            else if (e.Button == MouseButtons.Left)
                MessageBox.Show("Курсор за прямоугольником");
        }

        private void label1_MouseClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                Close();
            }
            if (e.Button == MouseButtons.Right)
            {
                panel1.Text = $"Размер клиентской области: ширина = {panel1.Width}, высота = {panel1.Height}";
            }
            else if (e.Button == MouseButtons.Left)
            {
                if (e.X == 0 || e.X == label1.Width || e.Y == 0 || e.Y == label1.Height)
                    MessageBox.Show("Курсор на границе прямоугольника");
                else
                    MessageBox.Show("Курсор внутри прямоугольника");
            }
        }

        private void Task1_MouseClick_1(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Control)
            {
                Close();
            }
            if (e.Button == MouseButtons.Right)
            {
                Text = $"Размер клиентской области: ширина = {panel1.Width}, высота = {panel1.Height}";
            }
        }
    }

}
