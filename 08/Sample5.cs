using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Drawing2D;

class Sample5 : Form
{
    private Image im;

    public static void Main()
    {
        Application.Run(new Sample5());
    }
    public Sample5()
    {
        im = Image.FromFile("c:\\tea.jpg");

        this.Text = "サンプル";
        this.ClientSize = new Size(400, 300);
        this.BackColor = Color.Black;
        
        this.Paint += new PaintEventHandler(fm_Paint); 
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        GraphicsPath gp = new GraphicsPath();

        gp.AddEllipse(new Rectangle(0,0,400,300));
        Region rg = new Region(gp);
        g.Clip = rg;

        g.DrawImage(im, 0, 0, 400, 300);
    }
}
