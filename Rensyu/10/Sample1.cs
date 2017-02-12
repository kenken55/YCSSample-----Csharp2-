using System;
using System.Windows.Forms;
using System.Net;

class Sample1 : Form
{
    private TextBox tb;
    private WebBrowser wb;
    private ToolStrip ts;
    private ToolStripButton[] tsb = new ToolStripButton[4];

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
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
        tsb[2].Text = "→";
        tsb[3].Text = "Home";

        tsb[0].ToolTipText = "移動";
        tsb[1].ToolTipText = "戻る";
        tsb[2].ToolTipText = "進む";
        tsb[3].ToolTipText = "Home";

        tsb[1].Enabled = false;
        tsb[2].Enabled = false;

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
        wb.CanGoForwardChanged += new EventHandler(wb_CanGoForwardChanged);
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
        else if (sender == tsb[2])
        {
            wb.GoForward();
        }
        else if (sender == tsb[3])
        {
            wb.GoHome();
        }
    }
    public void wb_CanGoBackChanged(Object sender, EventArgs e)
    {
        tsb[1].Enabled = wb.CanGoBack;
    }
    public void wb_CanGoForwardChanged(Object sender, EventArgs e)
    {
        tsb[2].Enabled = wb.CanGoForward;
    }
}

