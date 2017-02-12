using System;
using System.Windows.Forms;

class Sample3 : Form
{
    private Label lb;

    public static void Main()
    {
        Application.Run(new Sample3());
    }
    public Sample3()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "ようこそ";

        lb.Parent = this;
        
        this.MouseEnter += new EventHandler(fm_MouseEnter);
        this.MouseLeave += new EventHandler(fm_MouseLeave);
        
    }
    public void fm_MouseEnter(Object sender, EventArgs e)
    {
        lb.Text = "こんにちは";
    }
    public void fm_MouseLeave(Object sender, EventArgs e)
    {
        lb.Text = "さようなら";
    }
}
