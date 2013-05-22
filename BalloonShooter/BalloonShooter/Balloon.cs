using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace BalloonShooter
{
    class Balloon
    {

    public float x { get; set; }
    public float y { get; set; }
    public bool visible = true;
    public float brzina { get; set; }
    public Balloon(float x, float y, float brzina) {
            this.x = x;
            this.y = y;
            this.brzina = brzina;
    }
    public void Move() 
    {
        y -= brzina;
    }

    public void Draw(Image i, Graphics g)
{
    if(visible)
    g.DrawImage(i, x, y);
}

    }
}
