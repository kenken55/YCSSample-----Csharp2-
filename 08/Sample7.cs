using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;

class Sample7 : Form
{
    private Ball bl;
    private int x, y;

    public static void Main()
    {
        Application.Run(new Sample7());
    }
    public Sample7()
    {
        this.Text = "サンプル";
        this.ClientSize = new Size(250, 100);
        
        bl = new Ball();

        Point p = new Point(0, 0);
        Color c = Color.Blue;

        bl.Point = p;
        bl.Color = c;

        x = 2;
        y = 2;

        Timer tm = new Timer();
        tm.Interval = 100;
        tm.Start();
        
        this.Paint += new PaintEventHandler(fm_Paint);
        tm.Tick += new EventHandler(tm_Tick);
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        Point p = bl.Point;
        Color c = bl.Color;
        SolidBrush br = new SolidBrush(c);

        int x = p.X;
        int y = p.Y;
        g.FillEllipse(br, x, y, 10, 10);
    }
    public void tm_Tick(Object sender,EventArgs e)
    {
        Point p = bl.Point;

        if (p.X < 0 || p.X > this.ClientSize.Width-10) x = -x;
        if (p.Y < 0 || p.Y > this.ClientSize.Height-10) y = -y; 
   
        p.X = p.X + x;
        p.Y = p.Y + y;

        bl.Point = p;
        this.Invalidate();
     }
}
class Ball
{
    public Color Color;
    public Point Point;
}
