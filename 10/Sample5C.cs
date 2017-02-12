using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;

class Sample5C : Form
{
    public static string HOST = "localhost";
    public static int PORT = 10000;

    TextBox tb;
    Button bt;

    public static void Main()
    {
        Application.Run(new Sample5C());

    }
    public Sample5C()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 300;

        tb = new TextBox();

        tb.Multiline = true;
        tb.ScrollBars = ScrollBars.Vertical;
        tb.Height = 150;
        tb.Dock = DockStyle.Top;

        bt = new Button();
        bt.Text = "接続";
        bt.Dock = DockStyle.Bottom;

        tb.Parent = this;
        bt.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        TcpClient tc = new TcpClient(HOST, PORT);

        StreamReader sr = new StreamReader(tc.GetStream());
        String str = sr.ReadLine();
        tb.Text = str;

        sr.Close();
        tc.Close();
    }
}