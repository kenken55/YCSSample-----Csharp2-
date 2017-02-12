using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

class Sample12 : Form
{
    private ListBox lbx;
    private Button bt;

    public static void Main()
    {
        Application.Run(new Sample12());
    }
    public Sample12()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        string dir = "c:\\";

        string[] name = Directory.GetFiles(dir);

        lbx = new ListBox();
        lbx.Dock = DockStyle.Top;

        for(int i =0; i< name.Length; i++)
        {
            lbx.Items.Add(name[i]);
        }

        bt = new Button();
        bt.Text = "起動";
        bt.Dock = DockStyle.Bottom;

        lbx.Parent = this;
        bt.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        string name = lbx.SelectedItem.ToString();

        if (name != null)
        {
            Process.Start(@name);
        }
    }
}