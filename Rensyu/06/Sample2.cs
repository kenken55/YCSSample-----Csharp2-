using System;
using System.Windows.Forms;

class Sample2 : Form
{
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 100;

        bt = new Button();
        bt.Text = "ようこそ";
        bt.Width = 100;

        bt.Parent = this;

        bt.MouseEnter += new EventHandler(bt_MouseEnter);
        bt.MouseLeave += new EventHandler(bt_MouseLeave);
    }
    public void bt_MouseEnter(Object sender, EventArgs e)
    {
        bt.Text = "こんにちは";
    }
    public void bt_MouseLeave(Object sender, EventArgs e)
    {
        bt.Text = "さようなら";
    }

}
