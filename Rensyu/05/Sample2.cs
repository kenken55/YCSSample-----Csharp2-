using System.Windows.Forms;
using System.Drawing;

class Sample2 : Form
{
    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";
        this.Width = 400; this.Height = 200;

        WhiteLabel wl1 = new WhiteLabel();
        wl1.Text = "こんにちは";

        WhiteLabel wl2 = new WhiteLabel();
        wl2.Text = "ありがとう";

        wl2.Left = wl1.Left+150;

        wl1.Parent = this;
        wl2.Parent = this;
    }
}
class WhiteLabel : Label
{
    public WhiteLabel()
    {
        this.BackColor = Color.White;
    }
}

