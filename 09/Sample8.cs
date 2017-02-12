using System;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

class Sample8 : Form
{
    private PictureBox[] pb;
    private TabControl tc;
    private TabPage[] tp;

    public static void Main()
    {
        Application.Run(new Sample8());
    }
    public Sample8()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        tc = new TabControl();

        string dir = "c:\\";
        
        string[] fls = Directory.GetFiles(dir, "*.bmp");
        pb = new PictureBox[fls.Length];
        tp = new TabPage[fls.Length];

        for (int i = 0; i < fls.Length; i++)
        {
            pb[i] = new PictureBox();
            tp[i] = new TabPage(fls[i]);

            pb[i].Image = Image.FromFile(fls[i]);
            tp[i].Controls.Add(pb[i]);
            tc.Controls.Add(tp[i]);
        }
       
        tc.Parent = this;
    }
}