using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

class Sample11 : Form
{
    private Label lb;
    private RichTextBox rt;
    private TextBox tb;
    private Button bt;
    private TableLayoutPanel tlp;

    public static void Main()
    {
        Application.Run(new Sample11());
    }
    public Sample11()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 300;

        lb = new Label();
        lb.Dock = DockStyle.Fill;

        rt = new RichTextBox();
        rt.Dock = DockStyle.Fill;

        tb = new TextBox();
        tb.Dock = DockStyle.Fill;

        bt = new Button();

        tlp = new TableLayoutPanel();
        tlp.ColumnCount = 2;
        tlp.RowCount = 3;
        tlp.Dock = DockStyle.Fill;

        lb.Text = "入力してください。";
        tlp.SetColumnSpan(lb, 2);

        rt.Multiline = true;
        rt.Height = 100;
        tlp.SetColumnSpan(rt, 2);

        bt.Text = "検索";
        tlp.SetColumnSpan(bt, 2);

        lb.Parent = tlp;
        rt.Parent = tlp;
        tb.Parent = tlp;
        bt.Parent = tlp;

        tlp.Parent = this;

        bt.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        Regex rx = new Regex(tb.Text);
        Match m = null;
        for(m = rx.Match(rt.Text); m.Success; m = m.NextMatch())
        {
            rt.Select(m.Index, m.Length);
            rt.SelectionColor = Color.Red;
        }
    }
}