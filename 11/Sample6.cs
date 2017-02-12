using System;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
using System.Collections;

class Sample6 : Form
{
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample6());
    }
    public Sample6()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill;

        XDocument doc = XDocument.Load("c:\\Sample.xml");

        IEnumerable qry = from K in doc.Descendants("car")
                          where (int)K.Attribute("id") >= 1005
                          select K.Element("name").Value;

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}