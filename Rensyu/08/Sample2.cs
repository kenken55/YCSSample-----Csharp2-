using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class Sample2 : Form
{
    private Image im;
    private int i;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        im = Image.FromFile("c:\\tea.jpg");

        this.Text = "サンプル";
        this.ClientSize = new Size(400, 300);
        this.BackColor = Color.Black;
        this.DoubleBuffered = true;

        i = 0;
        
        Timer tm = new Timer();
        tm.Start();


        this.Paint += new PaintEventHandler(fm_Paint); 
        tm.Tick += new EventHandler(tm_Tick);
    }
    public void tm_Tick(Object sender, EventArgs e)
    {
        if (i == 400)
        {
            Timer tm = (Timer)sender;
            tm.Stop();
        }
        else
        {
            i = i + 10;
        }
        this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        GraphicsPath gp = new GraphicsPath();

        gp.AddEllipse(new Rectangle(0,0,i,(int)i*3/4));
        Region rg = new Region(gp);
        g.Clip = rg;

        g.DrawImage(im, 0 ,0, 400, 300);
    }
}



