using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication2
{
    class Balon
    {
        
        public float x { get; set; }
        public float y { get; set; }
        public bool visible = true;
        public float brzina { get; set; }
        public Balon(float x, float y, float brzina) {
            this.x = x;
            this.y = y;
            this.brzina = brzina;
        }
       
        public void Move() {
            y -= brzina;
        }

        public void Draw(Image i, Graphics g)
        {
            if(visible)
            g.DrawImage(i, x, y);
        
        }


        





    }
}
