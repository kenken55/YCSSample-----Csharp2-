using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Sample4 : Form
{
    private Button bt1, bt2;
    private FlowLayoutPanel flp;
    private Bitmap bmp;

    [STAThread]
    public static void Main()
    {
        Application.Run(new Sample4());
    }
    public Sample4()
    {
        this.Text = "サンプル";
        this.Width = 400; this.Height = 300;

        bmp = new Bitmap(400, 300);

        bt1 = new Button();
        bt2 = new Button();
        bt1.Text = "読込";
        bt2.Text = "保存";

        flp = new FlowLayoutPanel();
        flp.Dock = DockStyle.Bottom;

        bt1.Parent = flp;
        bt2.Parent = flp;
        flp.Parent = this;

        bt1.Click += new EventHandler(bt_Click);
        bt2.Click += new EventHandler(bt_Click);
        this.Paint += new PaintEventHandler(fm_Paint);
    }
    public void bt_Click(Object sender, EventArgs e)
    {
       if (sender == bt1)
       {
           OpenFileDialog ofd = new OpenFileDialog();
           ofd.Filter = "ビットマップファイル|*.bmp|JPEGファイル|*.jpg";

           if (ofd.ShowDialog() == DialogResult.OK)
           {
                Image tmp = (Bitmap)Image.FromFile(ofd.FileName);
                bmp = new Bitmap(tmp);
            }
        }
        else if(sender == bt2)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "ビットマップファイル|*.bmp|JPEGファイル|*.jpg";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                if (sfd.FilterIndex == 1)
                {
                    bmp.Save(sfd.FileName, ImageFormat.Bmp);
                }
                else if (sfd.FilterIndex == 2)
                {
                    bmp.Save(sfd.FileName, ImageFormat.Jpeg);
                }
            }
       }
       this.Invalidate();
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        g.DrawImage(bmp, 0, 0);
    }
}
