using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace BalloonShooter
{
    public partial class BalloonShooter : Form
    {
        Graphics g;
        Balloon[] baloni = new Balloon[1000];
        Timer timer;
        Timer timer1;
        Image img;
        Image img1;
        int brojac = 0;

        public BalloonShooter()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            startgame();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Width = 1000;
            Height = 520;
            button1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            startgame();
        }
        public void startgame(){
        g = CreateGraphics();
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval =100/30;
            timer.Start();

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval =800;
            timer1.Start();

            
            img = Image.FromFile(@"C:\Users\DELL\Documents\Visual Studio 2010\Projects\BalloonShooter\BalloonShooter\Resources\balloon.png");
            img1 = Image.FromFile(@"C:\Users\DELL\Documents\Visual Studio 2010\Projects\BalloonShooter\BalloonShooter\Resources\game_background.jpg");
        }

        private void timer1_Tick(object sender, EventArgs e)
            {
                Random r = new Random();
                int xcord = r.Next(0,Width);
                baloni[brojac] = new Balloon(xcord,Height-20,1);
                brojac++;
            }


        private void timer_Tick(object sender, EventArgs e)
            {

                g.DrawImage(img1,0,0);
                for (int i = 0; i < brojac; i++)
                {
                       baloni[i].Move();
                        baloni[i].Draw(img, g);
                }
            }


        private void Form1_MouseClick(object sender, MouseEventArgs e)
            {
                for (int i = 0; i < brojac; i++)
                    {
                        if ((baloni[i].x < e.X) && (baloni[i].x + 23F>e.X) && (baloni[i].y < e.Y) && (baloni[i].y + 26F > e.Y)) 
                            {
                                baloni[i].visible = false;
                            }
                    }       
            }
    
        }//form
    }
        
