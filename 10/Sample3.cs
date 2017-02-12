using System;
using System.Windows.Forms;
using System.Net;

class Sample3 : Form
{
    private TextBox tb;
    private WebBrowser wb;
    private ToolStrip ts;
    private ToolStripButton[] tsb = new ToolStripButton[2];

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample3());
    }
    public Sample3()
    {
        this.Text = "サンプル";
        this.Width = 600; this.Height = 400;

        tb = new TextBox();
        tb.Text = "http://";
        tb.Dock = DockStyle.Top;

        wb = new WebBrowser();
        wb.Dock = DockStyle.Fill;

        ts = new ToolStrip();
        ts.Dock = DockStyle.Top;

        for (int i = 0; i < tsb.Length; i++)
        {
            tsb[i] = new ToolStripButton();
        }

        tsb[0].Text = "Go";
        tsb[1].Text = "←";

        tsb[0].ToolTipText = "移動";
        tsb[1].ToolTipText = "戻る";

        tsb[1].Enabled = false;

        for (int i = 0; i < tsb.Length; i++)
        {
            ts.Items.Add(tsb[i]);
        }

        tb.Parent = this;
        wb.Parent = this;
        ts.Parent = this;

        for (int i = 0; i < tsb.Length; i++)
        {
            tsb[i].Click += new EventHandler(bt_Click);
        }

        wb.CanGoBackChanged += new EventHandler(wb_CanGoBackChanged);

    }
    public void bt_Click(Object sender, EventArgs e)
    {
        if (sender == tsb[0])
        {
            try
            {
                Uri uri = new Uri(tb.Text);
                wb.Url = uri;
            }
            catch
            {
                MessageBox.Show("URLを入力してください");
            }
        }
        else if (sender == tsb[1])
        {
            wb.GoBack();
        }

    }
    public void wb_CanGoBackChanged(Object sender, EventArgs e)
    {
        tsb[1].Enabled = wb.CanGoBack;
    }
}
