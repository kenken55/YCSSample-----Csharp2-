using System;
using System.Windows.Forms;
using System.IO;

class Sample3 : Form
{
    private TextBox[] tb = new TextBox[5];
    private Button bt1, bt2;
    private FlowLayoutPanel flp;

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample3());
    }
    public Sample3()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        for (int i = 0; i < tb.Length; i++)
        {
            tb[i] = new TextBox();
            tb[i].Width = 30; tb[i].Height = 30;
            tb[i].Top = 0; tb[i].Left = i * tb[i].Width;
            tb[i].Text = Convert.ToString(i);
        }

        bt1 = new Button();
        bt2 = new Button();
        bt1.Text = "読込";
        bt2.Text = "保存";

        flp = new FlowLayoutPanel();
        flp.Dock = DockStyle.Bottom;

        bt1.Parent = flp;
        bt2.Parent = flp;
        flp.Parent = this;
        for (int i = 0; i < tb.Length; i++)
        {
            tb[i].Parent = this;
        }

        bt1.Click += new EventHandler(bt_Click);
        bt2.Click += new EventHandler(bt_Click);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
       if (sender == bt1)
       {
           OpenFileDialog ofd = new OpenFileDialog();
           ofd.Filter = "バイナリファイル|*.bin";

           if (ofd.ShowDialog() == DialogResult.OK)
           {
                BinaryReader br = new BinaryReader(new FileStream(ofd.FileName,FileMode.Open,FileAccess.Read));
                for (int i = 0; i < tb.Length; i++)
                {
                    int num = br.ReadInt32();
                    tb[i].Text= Convert.ToString(num);
                }
                br.Close();
            }
        }
        else if(sender == bt2)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "バイナリファイル|*.bin";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BinaryWriter br = new BinaryWriter(new FileStream(sfd.FileName, FileMode.OpenOrCreate, FileAccess.Write));
                for (int i = 0; i < tb.Length; i++)
                {
                   br.Write(Convert.ToInt32(tb[i].Text));
                }
                br.Close();
            }
        }
    }
}
