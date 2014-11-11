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
        List<SolidBrush> colors;
       
     

        public Form1()
        {
            InitializeComponent();
            setColors();
        }

        private void setColors()
        {
            colors = new List<SolidBrush>();
            colors.Add(new SolidBrush(Color.Aqua));
            colors.Add(new SolidBrush(Color.Red));
            colors.Add(new SolidBrush(Color.Pink));
            colors.Add(new SolidBrush(Color.SaddleBrown));
            colors.Add(new SolidBrush(Color.SlateGray));
            colors.Add(new SolidBrush(Color.Silver));

        }


        private void button1_Click(object sender, EventArgs e)
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
            Graphics g = pictureBox1.CreateGraphics();

            g.Clear(Color.White);

            int ratioRects = int.Parse(textBox2.Text);

            drawType3(g, 100, 100, ratioRects);

            pictureBox1.Update();
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
            if (ratioRects > 0)
            {


                if (ratioRects > 0)
                {

                    int newRatio = ratioRects / 2;
                    int halfRation = newRatio / 2;


                    drawType3(g, x, y, newRatio);  //Main
                    drawType3(g, x - newRatio, y + newRatio, halfRation); //down left
                    drawType3(g, x + newRatio, y + newRatio, halfRation); //down right
                    drawType3(g, x - newRatio, y - newRatio, halfRation); //top left
                    drawType3(g, x + newRatio, y - newRatio, halfRation); //top right


                    int newx = x - halfRation;
                    int newy = y - halfRation;

                    int random = new Random().Next(0, colors.Count);
                    g.FillRectangle(colors[random], newx, newy, newRatio, newRatio);
                    g.DrawRectangle(pen1, newx, newy, newRatio, newRatio);

                    System.Threading.Thread.Sleep(sleepTime);
                }
            }
        }
          


        
    
    
    
        }
    }

