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
        SolidBrush bl = new SolidBrush(Color.Black);
        Pen pen1 = new Pen(Color.Black);
        Pen pen2 = new Pen(Color.White);
     
       
     

        public Form1()
        {
            InitializeComponent();
           
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            star(g, 100, 100, ratioRects);

            pictureBox1.Update();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            drawType2(g, 100, 100, ratioRects);


            pictureBox1.Update();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Graphics g = pictureBox1.CreateGraphics();

                g.Clear(Color.Black);

                int ratioRects = int.Parse(textBox2.Text);



                drawType1(g, 100, 100, ratioRects);

                pictureBox1.Update();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            drawType3(g, 100, 100, ratioRects);

            pictureBox1.Update();
        }


        private void star(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
                int newRatio = ratioRects / 2;

                star(g, x - newRatio, y + newRatio, newRatio);

                star(g, x - newRatio, y - newRatio, newRatio);

                star(g, x + newRatio, y - newRatio, newRatio);

                g.FillRectangle(br, x, y, ratioRects, ratioRects);
                g.DrawRectangle(pen1, x, y, ratioRects, ratioRects);

                System.Threading.Thread.Sleep(sleepTime);
            }
        }


        private void drawType1(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {


                int newRatio = ratioRects / 2;
                int halfRation = Convert.ToInt32((newRatio / 2)*1.5);
                int newSize = Convert.ToInt32(newRatio*1.5);


                drawType1(g, x, y, newRatio);  //Main
                drawType1(g, x - newRatio, y + newRatio, newRatio); //down left
                drawType1(g, x + newRatio, y + newRatio, newRatio); //down right
                drawType1(g, x - newRatio, y - newRatio, newRatio); //top left
                drawType1(g, x + newRatio, y - newRatio, newRatio); //top right


                int newx = x - halfRation;
                int newy = y - halfRation;

                g.FillRectangle(br, newx, newy, newSize, newSize);
                g.DrawRectangle(pen2, newx, newy, newSize,newSize);

                //System.Threading.Thread.Sleep(sleepTime);

               
            }
        }



        private void drawType2(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 0)
            {
               
                int newRatio = ratioRects / 2;
                int halfRation = newRatio/2;
               

                drawType2(g, x , y  , newRatio);  //Main
                drawType2(g, x - newRatio, y + newRatio, newRatio); //down left
                drawType2(g, x + newRatio, y + newRatio, newRatio); //down right
                drawType2(g, x - newRatio, y - newRatio, newRatio); //top left
                drawType2(g, x + newRatio, y - newRatio, newRatio); //top right


                int newx = x - halfRation;
                int newy = y - halfRation;

                g.FillRectangle(br, newx, newy, newRatio, newRatio);
                g.DrawRectangle(pen1, newx, newy, newRatio, newRatio);

                //System.Threading.Thread.Sleep(sleepTime);
            }
        }

        private void drawType3(Graphics g, int x, int y, int ratioRects)
        {
            if (ratioRects > 20)
            {


               int newRatio = ratioRects / 2;
                
                int halfRation = newRatio / 2;

                int factor = Convert.ToInt32(newRatio / 8);


                drawType3(g, x + halfRation-factor, y + halfRation-factor, newRatio -factor*2); //down left
                drawType3(g, x - halfRation+factor, y + halfRation-factor, newRatio -factor*2); //down right
                drawType3(g, x - halfRation+factor, y - halfRation+factor, newRatio -factor*2); //top left
                drawType3(g, x + halfRation-factor, y - halfRation+factor, newRatio -factor*2); //top right



                int newx = x - newRatio;
                int newy = y - newRatio;
              
                    g.DrawEllipse(pen1, newx, newy, newRatio*2, newRatio*2);
                    if (ratioRects > 40)
                    {
                        int xx = x - Convert.ToInt32(newRatio * 1.2);
                        int yy = y - Convert.ToInt32(newRatio * 1.2);
                        g.DrawEllipse(pen1, xx, yy, Convert.ToInt32(newRatio * 2.4), Convert.ToInt32(newRatio * 2.4));
                    }
                       
                              
            }
        }

       
          


        
    
    
    
        }
    }

