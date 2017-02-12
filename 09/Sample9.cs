using System;
using System.Windows.Forms;
using System.IO;

class Sample9 : Form
{
    private ChildForm[] cf;

    public static void Main()
    {
        Application.Run(new Sample9());
    }
    public Sample9()
    {
        this.Text = "サンプル";
        this.Width = 400; this.Height = 400;
        this.IsMdiContainer = true;

        string dir = "c:\\";

        string[] fls = Directory.GetFiles(dir, "*.xml");
        cf = new ChildForm[fls.Length];

        for (int i = 0; i < fls.Length; i++)
        {
            cf[i] = new ChildForm(fls[i]);
            cf[i].MdiParent = this;
            cf[i].Show();
        }
    }
}

class ChildForm : Form
{
    TextBox tb;

    public ChildForm(string name)
    {
        this.Text = name;

        tb = new TextBox();
        tb.Multiline = true;
        tb.Width = this.Width;
        tb.Height = this.Height;
        
        StreamReader sr = new StreamReader(name, System.Text.Encoding.Default);
        tb.Text = sr.ReadToEnd();
        sr.Close();

        tb.Parent = this;
    }
}