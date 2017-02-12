using System;
using System.Windows.Forms;

class Sample5 : Form
{
    private Label lb;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample5());
    }
    public Sample5()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 100;

        lb = new Label();
        lb.Text = "いらっしゃいませ。";
        lb.Dock = DockStyle.Top;

        bt = new Button();
        bt.Text = "購入";
        bt.Dock = DockStyle.Bottom;

        bt.Click += new EventHandler(bt_Click);

        lb.Parent = this;
        bt.Parent = this;
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        lb.Text = "ご購入ありがとうございました。";
        bt.Enabled = false;
    }
}