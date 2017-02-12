using System;
using System.Windows.Forms;
using System.Drawing;

class Sample9 : Form
{
    private Label lb;

    public static void Main()
    {
        Application.Run(new Sample9());
    }
    public Sample9()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 100;

        Timer tm = new Timer();
        tm.Interval = 1000;
        tm.Start();

        lb = new Label();
        lb.Font = new Font("Courier", 20, FontStyle.Regular);
        lb.Dock = DockStyle.Fill;

        lb.Parent = this;

        tm.Tick += new EventHandler(tm_Tick);
    }
    public void tm_Tick(Object sender, EventArgs e)
    {
        DateTime dt = DateTime.Now;

        lb.Text = dt.ToLongTimeString();
    }
}
