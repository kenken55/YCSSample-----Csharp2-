using System.Windows.Forms;
using System.Net;

class Sample1 : Form
{
    private Label lb1, lb2;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 100;

        string hn = Dns.GetHostName();
        IPHostEntry ih = Dns.GetHostEntry(hn);

        IPAddress ia = ih.AddressList[0];

        lb1 = new Label();
        lb2 = new Label();

        lb1.Width = 300;
        lb1.Top = 0;

        lb1.Text= "ホスト名：" + hn;

        lb2.Width = 300;
        lb2.Top = lb1.Bottom;
        lb2.Text = "IPアドレス："　+ ia.ToString();

        lb1.Parent = this;
        lb2.Parent = this;
    }
}
