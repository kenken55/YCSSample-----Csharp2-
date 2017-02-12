using System;
using System.Windows.Forms;

class Sample1 : Form
{
    private Label lb;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;
     
        lb = new Label();
        lb.Text = "ようこそ";
        
        lb.Parent = this;
       
        this.Click += new EventHandler(fm_Click);
    }
    public void fm_Click(Object sender, EventArgs e)
    {
        lb.Text = "こんにちは";
    }
}
