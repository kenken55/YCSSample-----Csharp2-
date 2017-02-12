using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using System.Threading;

class Sample6C : Form
{
    public static string HOST = "localhost";
    public static int PORT = 10000;

    private TextBox tb1, tb2;
    private Button bt;

    private TcpClient tc;
    private StreamReader sr;
    private StreamWriter sw;

    public static void Main()
    {
        Application.Run(new Sample6C());
    }
    public Sample6C()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 300;

        tb1 = new TextBox();
        tb2 = new TextBox();

        tb1.Height = 150;
        tb1.Dock = DockStyle.Top;

        tb2.Multiline = true;
        tb2.ScrollBars = ScrollBars.Vertical;
        tb2.Height = 150;
        tb2.Width = this.Width;
        tb2.Top = tb1.Bottom;

        bt = new Button();
        bt.Text = "送信";
        bt.Dock = DockStyle.Bottom;

        tb1.Parent = this;
        tb2.Parent = this;
        bt.Parent = this;

        Thread th = new Thread(this.run);
        th.Start();

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        String str = tb1.Text;
        sw.WriteLine(str);
        tb2.AppendText(str + "\n");
        sw.Flush();
        tb1.Clear();
    }
    public void run()
    {
        tc = new TcpClient(HOST, PORT);
        sr = new StreamReader(tc.GetStream());
        sw = new StreamWriter(tc.GetStream());

        while (true)
        {
            try
            {
                String str = sr.ReadLine();
                tb2.AppendText(str + "\n");
            }
            catch
            {
                sr.Close();
                sw.Close();
                tc.Close();
                break;
            }
        }
    }
}







