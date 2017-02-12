using System;
using System.Windows.Forms;
using System.Drawing;

class Sample8 : Form
{
    private Image im;
    private int i;

    public static void Main()
    {
        Application.Run(new Sample8());
    }
    public Sample8()
    {
        this.Text = "サンプル";
        this.Width = 400; this.Height = 300;
        this.DoubleBuffered = true;

        im = Image.FromFile("c:\\tea.jpg");

        i = 0;

        Timer tm = new Timer();
        tm.Start();

        tm.Tick += new EventHandler(tm_Tick); 
        this.Paint += new PaintEventHandler(fm_Paint);

    }
    public void tm_Tick(Object sender, EventArgs e)
    {
        if (i > im.Width+200)
        {
            i = 0;
        }
        else
        {
            i = i+10;
        }
        this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.DrawImage(im, new Rectangle(0, 0, i, im.Height), 0, 0, i, im.Height, GraphicsUnit.Pixel);
    }
}