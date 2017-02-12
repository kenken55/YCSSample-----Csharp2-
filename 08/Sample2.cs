using System;
using System.Windows.Forms;
using System.Drawing;

class Sample2 : Form
{
    private Image im;
    private RadioButton rb1, rb2, rb3;
    private GroupBox gb;
    private int i;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 300;
        im = Image.FromFile("c:\\car.bmp");

        rb1 = new RadioButton();
        rb2 = new RadioButton();
        rb3 = new RadioButton();
        rb1.Text = "通常";
        rb2.Text = "拡大";
        rb3.Text = "縮小";
        rb1.Dock = DockStyle.Bottom;
        rb2.Dock = DockStyle.Bottom;
        rb3.Dock = DockStyle.Bottom;
        rb1.Checked = true;

        gb = new GroupBox();
        gb.Text = "種類";
        gb.Dock = DockStyle.Bottom;

        rb1.Parent = gb;
        rb2.Parent = gb;
        rb3.Parent = gb;
        gb.Parent = this;

        rb1.Click += new EventHandler(rb_Click);
        rb2.Click += new EventHandler(rb_Click);
        rb3.Click += new EventHandler(rb_Click);
        this.Paint += new PaintEventHandler(fm_Paint);
    }
    public void rb_Click(Object sender, EventArgs e)
    {
        RadioButton tmp = (RadioButton)sender;
        if (tmp == rb1)
            i=1;
        else if(tmp == rb2)
            i=2;
        else if(tmp == rb3)
            i=3;
        this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        if (i == 1)
            g.DrawImage(im, 0, 0); 
        else if(i == 2)
            g.DrawImage(im, 0, 0, im.Width * 2, im.Height * 2);
        else if(i == 3)
            g.DrawImage(im, 0, 0, im.Width / 2, im.Height / 2);
    }
}