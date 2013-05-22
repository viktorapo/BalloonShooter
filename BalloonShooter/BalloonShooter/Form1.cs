using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;


namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        int poen = 0;
        Graphics g;
        Balon[] baloni=new Balon[1000];
        Timer timer;
        Timer timer1;
        Image img;
        Image img1;
        Image cimg;
        int brojac = 0;
        int sekundi = 60;
        int stoperica;
        public int brzina { get; set; }
        Timer stop;
        public Form1(int brzina)
        {
            InitializeComponent();
            this.brzina = brzina;
        }
        
        public Form1()
        {
            InitializeComponent();
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Random r = new Random();
            int xcord = r.Next(0,Width);
            baloni[brojac] = new Balon(xcord,Height-20,brzina);
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
                if ((baloni[i].x < e.X) && (baloni[i].x + 23F>e.X) && (baloni[i].y < e.Y) && (baloni[i].y + 26F > e.Y)) {
                    baloni[i].visible = false;
                    poen++;
                    label1.Text = "" + poen;
                }
            }
        }
       

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            g = CreateGraphics();
            timer = new Timer();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = brzina ;
            timer.Start();

            timer1 = new Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 900;
            timer1.Start();

   //         img = Image.FromFile(@"C:\\Users\\Goran\\Desktop\\balon1.png");
        //    img1 = Image.FromFile(@"C:\\Users\\Goran\\Desktop\\Sky.jpg");
            img = Properties.Resources.balon1;
            img1 = Properties.Resources.Sky;
            stop = new Timer();
            stop.Interval = 1000;
            stop.Tick += stop_Tick;
            stop.Start();
        }

        void stop_Tick(object sender, EventArgs e)
        {
            label2.Text = "" + (++stoperica);
            if (stoperica == 25)
                Close();


        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
        }
 
    }

}

