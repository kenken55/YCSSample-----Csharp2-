using System;
using System.Windows.Forms;
using System.Drawing;

class Sample1 : Form
{
    private Image im;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        im = Image.FromFile("c:\\car.bmp");

        this.Click += new EventHandler(fm_Click);
        this.Paint += new PaintEventHandler(fm_Paint);
    }
    public void fm_Click(Object sender, EventArgs e)
    {
        im.RotateFlip(RotateFlipType.Rotate90FlipNone);
        this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.DrawImage(im, 0, 0);
    }
}