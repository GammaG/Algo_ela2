using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace fractalsCS
{
    public partial class Form1 : Form
    {
        private int sleepTime=10;
        SolidBrush br = new SolidBrush(Color.White);
        Pen pen1 = new Pen(Color.Black);

        public Form1()
        {
            InitializeComponent();
        }

        private void star(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                star(g,  x - newRatio, y + newRatio, newRatio);                
                
                star(g, x - newRatio, y - newRatio, newRatio);

                star(g,  x + newRatio, y - newRatio, newRatio);                
                                                
                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            
            g.Clear(Color.White);
            
            int ratioRects = int.Parse(textBox2.Text);

            star(g,100, 100, ratioRects);

            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}