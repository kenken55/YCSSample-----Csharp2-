using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

class Sample5 : Form
{
    private TextBox tb;
    private ToolStrip ts;
    private ToolStripButton[] tsb = new ToolStripButton[3];
    private Button bt1, bt2;
    private FlowLayoutPanel flp;

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample5());
    }
    public Sample5()
    {
        this.Text = "サンプル";

        ts = new ToolStrip();
        for (int i = 0; i < tsb.Length; i++)
        {
            tsb[i] = new ToolStripButton();
        }
        tsb[0].Image = Image.FromFile("c:\\Cut.bmp");
        tsb[1].Image = Image.FromFile("c:\\Copy.bmp");
        tsb[2].Image = Image.FromFile("c:\\Paste.bmp");

        tsb[0].ToolTipText = "カット";
        tsb[1].ToolTipText = "コピー";
        tsb[2].ToolTipText = "ペースト";

        tb = new TextBox();
        tb.Multiline = true;
        tb.Width = this.Width; tb.Height = this.Height - 100;
        tb.Dock = DockStyle.Top;

        bt1 = new Button();
        bt2 = new Button();
        bt1.Text = "読込";
        bt2.Text = "保存";

        flp = new FlowLayoutPanel();
        flp.Dock = DockStyle.Bottom;

        for (int i = 0; i < tsb.Length; i++)
        {
            ts.Items.Add(tsb[i]);
        }

        bt1.Parent = flp;
        bt2.Parent = flp;
        flp.Parent = this;
        tb.Parent = this;
        ts.Parent = this;

        bt1.Click += new EventHandler(bt_Click);
        bt2.Click += new EventHandler(bt_Click);

        for (int i = 0; i < tsb.Length; i++)
        {
            tsb[i].Click += new EventHandler(tsb_Click);
        }
    }
    public void tsb_Click(Object sender, EventArgs e)
    {
        if (sender == tsb[0])
        {
            tb.Cut();
         }
        else if(sender == tsb[1])
        {
            tb.Copy();
        }
        else if (sender == tsb[2])
        {
            tb.Paste();
        }
    }
    public void bt_Click(Object sender, EventArgs e)
    {
        if (sender == bt1)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "テキストファイル|*.txt";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(ofd.FileName, System.Text.Encoding.Default);
                tb.Text = sr.ReadToEnd();
                sr.Close();
            }
        }
        else if (sender == bt2)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "テキストファイル|*.txt";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                StreamWriter sw = new StreamWriter(sfd.FileName);
                sw.WriteLine(tb.Text);
                sw.Close();
            }
        }
    }
}
