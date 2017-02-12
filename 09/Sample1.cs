using System;
using System.Windows.Forms;
using System.IO;

class Sample1 : Form
{
    private Button bt;
    private Label[] lb = new Label[3];

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i] = new Label();
            lb[i].Top = i * lb[0].Height;
            lb[i].Width = 300;
        }

        bt = new Button();
        bt.Text = "表示";
        bt.Dock = DockStyle.Bottom;

        bt.Parent = this;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i].Parent = this;
        }

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        OpenFileDialog ofd = new OpenFileDialog();

        if (ofd.ShowDialog() == DialogResult.OK)
        {
            FileInfo fi = new FileInfo(ofd.FileName);
            lb[0].Text = "ファイル名は" + ofd.FileName + "です。";
            lb[1].Text = "絶対パスは" + Path.GetFullPath(ofd.FileName) + "です。";
            lb[2].Text = "サイズは" + Convert.ToString(fi.Length) + "です。";
        }
    }
}