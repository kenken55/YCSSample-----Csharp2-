using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

class Sample1 : Form
{
    private  ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill;

        var 車表 = new[] {
            new{番号= 2, 名前 ="乗用車"},
            new{番号= 3, 名前 ="オープンカー"},
            new{番号= 4, 名前 ="トラック"},
        };

        IEnumerable qry = from K in 車表
                          select new { K.名前, K.番号 };

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}