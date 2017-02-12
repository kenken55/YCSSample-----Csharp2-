using System;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Collections;

class Sample4 : Form
{
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample4());
    }
    public Sample4()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill;

        XDocument doc = XDocument.Load("c:\\Sample.xml");

        IEnumerable qry = from K in doc.Descendants("car")
                          select K;

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}
