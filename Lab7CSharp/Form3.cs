using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Lab7CSharp
{

    public partial class Form3 : Form
    {
        public List<Figure> figures = new List<Figure>();
        public uint elements = 0;
        public Color color = Color.Black;
        List<RectangleF> rectangles = new List<RectangleF>();
        List<Color> colors = new List<Color>();
        List<int> types = new List<int>();
        List<Pen> pens = new List<Pen>();
        List<string> texts = new List<string>();
        List<PointF> textPos = new List<PointF>();
        List<Font> fonts = new List<Font>();
        public Form3()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //pryam
            groupBox3.Text = "Параметри прямокутника";
            label4.Visible = true;
            label3.Text = "Сторона 1";
            label4.Text = "Сторона 2";
            textBox4.Visible = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            //romb
            groupBox3.Text = "Параметри ромба";
            label3.Text = "Сторона";
            label4.Visible = false;
            textBox4.Visible = false;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //colo
            label3.Text = "Радіус";
            label4.Visible = false;
            textBox4.Visible = false;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            //duga
            groupBox3.Text = "Параметри дуги";
            label4.Visible = true;
            label3.Text = "Ширина";
            label4.Text = "Висота";
            textBox4.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            int type;
            if (radioButton1.Checked)
            {
                type = 1; //pryam
            }
            else if (radioButton2.Checked)
            {
                type = 2; //romb
            }
            else if (radioButton3.Checked)
            {
                type = 3; //circle
            }
            else if (radioButton4.Checked)
            {
                type = 4; //duga
            }
            else type = 0;
            switch (type)
            {
                case 1:
                    { //pryam
                        var mouseEventArgs = e as MouseEventArgs;
                        int mouseX = mouseEventArgs.X;
                        int mouseY = mouseEventArgs.Y;
                        Pryamocytnyk pryamocytnyk = new Pryamocytnyk();
                        pryamocytnyk.Draw(mouseX, mouseY);
                        figures.Add(pryamocytnyk);
                        elements++;
                        textBox1.Text = elements.ToString();
                        break;
                    }
                case 2:
                    {//romb
                        var mouseEventArgs = e as MouseEventArgs;
                        int mouseX = mouseEventArgs.X;
                        int mouseY = mouseEventArgs.Y;
                        Rhomb rhomb = new Rhomb();
                        rhomb.Draw(mouseX, mouseY);
                        figures.Add(rhomb);
                        elements++;
                        textBox1.Text = elements.ToString();
                        break;
                    }
                case 3:
                    {//circle
                        var mouseEventArgs = e as MouseEventArgs;
                        int mouseX = mouseEventArgs.X;
                        int mouseY = mouseEventArgs.Y;
                        Circle circle = new Circle();
                        circle.Draw(mouseX, mouseY);
                        figures.Add(circle);
                        elements++;
                        textBox1.Text = elements.ToString();
                        break;
                    }
                case 4:
                    { //duga
                        var mouseEventArgs = e as MouseEventArgs;
                        int mouseX = mouseEventArgs.X;
                        int mouseY = mouseEventArgs.Y;
                        Arc arc = new Arc();
                        arc.Draw(mouseX, mouseY);
                        figures.Add(arc);
                        elements++;
                        textBox1.Text = elements.ToString();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }

        public abstract class Figure
        {
            protected RectangleF rect;
            protected Color color;
            protected Pen pen;
            protected string text;
            protected PointF textPos;
            protected Font textFont;
            public abstract void Draw(int x, int y);
            public abstract void reDraw();
            public void move(float xoffset, float yoffset)
            {
                rect.X += xoffset;
                rect.Y += yoffset;
                textPos.X += xoffset;
                textPos.Y += yoffset;
            }

        }

        public class Pryamocytnyk : Figure
        {
            public override void Draw(int x, int y)
            {
                float wid = float.Parse(Program.form3.textBox3.Text);
                float heig = float.Parse(Program.form3.textBox4.Text);
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawRectangle(brush, x, y, wid, heig);
                if (wid < heig)
                {
                    float temp = wid;
                    wid = heig;
                    heig = temp;
                }
                g.DrawString(Program.form3.textBox2.Text, new Font("Arial", wid / 2), new SolidBrush(Color.Black), x + wid / 4, y - heig / 2.5f);
                pen = brush;
                rect = new RectangleF(x, y, wid, heig);
                color = Program.form3.color;
                text = Program.form3.textBox2.Text;
                textPos = new PointF((x + wid / 4), (y - heig / 2.5f));
                textFont = new Font("Arial", wid / 2);

            }
            public override void reDraw()
            {
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawRectangle(brush, Rectangle.Round(rect));
                g.DrawString(text, textFont, new SolidBrush(Color.Black), textPos);
            }
        }

        public class Rhomb : Figure
        {
            public override void Draw(int x, int y)
            {
                float wid = float.Parse(Program.form3.textBox3.Text);
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawString(Program.form3.textBox2.Text, new Font("Arial", wid / 2), new SolidBrush(Color.Black), x + wid / 4, y + wid / 8);
                g.DrawRectangle(brush, x, y, wid, wid);
                pen = brush;
                rect = new RectangleF(x, y, wid, wid);
                color = Program.form3.color;
                text = Program.form3.textBox2.Text;
                textPos = new PointF(x + wid / 4, y + wid / 4);
                textFont = new Font("Arial", wid / 2);

            }

            public override void reDraw()
            {
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawRectangle(brush, Rectangle.Round(rect));
                g.DrawString(text, textFont, new SolidBrush(Color.Black), textPos);
            }
        }

        public class Circle : Figure
        {
            public override void Draw(int x, int y)
            {
                float radius = float.Parse(Program.form3.textBox3.Text);
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawString(Program.form3.textBox2.Text, new Font("Arial", radius / 2), new SolidBrush(Color.Black), x + radius / 4, y + radius / 8);
                g.DrawEllipse(brush, x, y, radius, radius);
                pen = brush;
                rect = new RectangleF(x, y, radius, radius);
                color = Program.form3.color;
                text = Program.form3.textBox2.Text;
                textPos = new PointF(x + radius / 4, y + radius / 8);
                textFont = new Font("Arial", radius / 2);
            }

            public override void reDraw()
            {
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawEllipse(brush, Rectangle.Round(rect));
                g.DrawString(text, textFont, new SolidBrush(Color.Black), textPos);
            }
        }

        public class Arc : Figure
        {
            public override void Draw(int x, int y)
            {
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                float wid = float.Parse(Program.form3.textBox3.Text);
                float hei = float.Parse(Program.form3.textBox4.Text);
                g.DrawArc(brush, x, y, wid, hei, 45.0F, 270.0F);
                pen = brush;
                rect = new RectangleF(x, y, wid, hei);
                color = Program.form3.color;
            }

            public override void reDraw()
            {
                Graphics g = Program.form3.pictureBox1.CreateGraphics();
                Pen brush = new Pen(Program.form3.color);
                g.DrawArc(brush, Rectangle.Round(rect), 45.0F, 270.0F);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            color = colorDialog1.Color;
            pictureBox2.CreateGraphics().FillRectangle(new SolidBrush(color), 0, 0, pictureBox2.Width, pictureBox2.Height);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(color), 0, 0, pictureBox2.Width, pictureBox2.Height);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
        }

        private void button2_Click(object sender, EventArgs e)
        { //left
            int figure = int.Parse(textBox5.Text);
            if (figure <= 0 && figure > elements) return;
            figures[figure].move(-5, 0);
            pictureBox1.CreateGraphics().FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < elements; i++)
            {
                figures[i].reDraw();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        { //up
            int figure = int.Parse(textBox5.Text);
            if (figure <= 0 && figure > elements) return;
            figures[figure].move(0, -5);
            pictureBox1.CreateGraphics().FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < elements; i++)
            {
                figures[i].reDraw();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {//right
            int figure = int.Parse(textBox5.Text);
            if (figure <= 0 && figure > elements) return;
            figures[figure].move(5, 0);
            pictureBox1.CreateGraphics().FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < elements; i++)
            {
                figures[i].reDraw();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {//down
            int figure = int.Parse(textBox5.Text);
            if (figure <= 0 && figure > elements) return;
            figures[figure].move(0, 5);
            pictureBox1.CreateGraphics().FillRectangle(new SolidBrush(Color.White), 0, 0, pictureBox1.Width, pictureBox1.Height);
            for (int i = 0; i < elements; i++)
            {
                figures[i].reDraw();
            }
        }
    }
}
