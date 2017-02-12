using System;
using System.Windows.Forms;
using System.IO;

class Sample1 : Form
{
    private Button bt;
    private ListBox lbx;

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill; 

        bt = new Button();
        bt.Text = "選択";
        bt.Dock = DockStyle.Bottom;

        lbx.Parent = this;
        bt.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        FolderBrowserDialog fbd = new FolderBrowserDialog();

        if (fbd.ShowDialog() == DialogResult.OK)
        {
            string[] fnlist = Directory.GetFiles(fbd.SelectedPath);
            foreach(string fn in fnlist)
            {
                lbx.Items.Add(fn);
            }
        }
    }
}