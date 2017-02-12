using System;
using System.Windows.Forms;
using System.Net;

class Sample2 : Form
{
    private TextBox tb;
    private Label[] lb = new Label[5];
    private Button bt;
    private TableLayoutPanel tlp;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        tb = new TextBox();
        tb.Dock = DockStyle.Fill;

        bt = new Button();
        bt.Width = this.Width;
        bt.Text = "検索";
        bt.Dock = DockStyle.Bottom;        
        
        tlp = new TableLayoutPanel();
        tlp.Dock = DockStyle.Fill;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i] = new Label();
            lb[i].Dock = DockStyle.Fill;
        }

        tlp.ColumnCount = 2;
        tlp.RowCount = 3;

        lb[0].Text = "入力してください。";
        lb[1].Text = "ホスト名：";
        lb[3].Text = "IPアドレス：";

        lb[0].Parent = tlp;
        tb.Parent = tlp;

        for (int i = 1; i < lb.Length; i++)
        {
            lb[i].Parent = tlp;
        }

        bt.Parent = this;
        tlp.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        try
        {
            IPHostEntry ih = Dns.GetHostEntry(tb.Text);
            IPAddress ia = ih.AddressList[0];

            lb[2].Text = ih.HostName;
            lb[4].Text = ia.ToString();
        }
        catch
        {
            MessageBox.Show("エラーが発生しました。");
        }
    }
}
