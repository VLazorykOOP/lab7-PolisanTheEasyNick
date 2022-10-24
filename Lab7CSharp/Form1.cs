using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab7CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            var mouseEventArgs = e as MouseEventArgs;
            int mouseX = mouseEventArgs.X;
            int mouseY = mouseEventArgs.Y;
            string type = comboBox1.Text;
            switch (type)
            {
                case "Dot":
                    {
                        Point a = new Point(mouseX, mouseY);
                        var rand = new Random();
                        Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))), mouseX, mouseY, 3.0f, 3.0f);
                        break;
                    }
                case "Square":
                    {
                        Point a = new Point(mouseX, mouseY);
                        var rand = new Random();
                        Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                        g.FillRectangle(new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))), mouseX, mouseY, float.Parse(textBox1.Text), float.Parse(textBox1.Text));
                        break;
                    }

                case "Circle":
                    {
                        Point a = new Point(mouseX, mouseY);
                        var rand = new Random();
                        Graphics g = Graphics.FromHwnd(pictureBox1.Handle);
                        g.FillEllipse(new SolidBrush(Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256))), mouseX, mouseY, float.Parse(textBox1.Text), float.Parse(textBox1.Text));
                        break;
                    }

                default:
                    {
                        break;
                    }
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);

        }
    }
}
