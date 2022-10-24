using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;
//using Timer = System.Windows.Forms.Timer;

namespace Lab7CSharp
{
    public partial class Form2 : Form
    {
        Color graphicColor = Color.Blue;
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            graphicColor = colorDialog1.Color;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            
            g.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            g.DrawLine(new Pen(Color.Black), new Point(0, pictureBox1.Height / 2), new Point(pictureBox1.Width, pictureBox1.Height / 2));
            g.DrawLine(new Pen(Color.Black), new Point(pictureBox1.Width / 2, 0), new Point(pictureBox1.Width / 2, pictureBox1.Height));
            g.DrawString("0", new Font("Arial", 16), new SolidBrush(Color.Black), 0, pictureBox1.Height / 2 + 10);
            g.DrawString("4", new Font("Arial", 16), new SolidBrush(Color.Black), pictureBox1.Width - 30, pictureBox1.Height / 2 + 10);
            g.DrawString("1", new Font("Arial", 16), new SolidBrush(Color.Black), pictureBox1.Width/2 + 10, 10);
            g.DrawString("-1", new Font("Arial", 16), new SolidBrush(Color.Black), pictureBox1.Width / 2 + 10, pictureBox1.Height - 20);
            
        }

        private double func(double x)
        {
            if (x == 0) return 0;
            return Math.Sin(x) / x;
        }

        float x = 0;
        Timer timer = new Timer();
        public bool animate()
        {
            float yEx = pictureBox1.Height / 2;
            float eF = 50;
            Graphics g = pictureBox1.CreateGraphics();
            double y = func(x);
            g.FillEllipse(new SolidBrush(graphicColor), x * eF, (float)y * eF + yEx, 3, 3);
            x += 0.05f;
            return x < pictureBox1.Width;
        }
        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            if(!animate()) {
                timer.Enabled = false;
                timer.Stop();  
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (timer.Enabled) timer.Stop();
            x = 0;
            timer.Interval = 17;
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Start();

        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer.Stop();
        }
    }
}
