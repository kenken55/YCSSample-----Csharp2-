using System;
using System.Windows.Forms;
using System.Linq;
using System.Collections;

class Sample2 : Form
{
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lbx = new ListBox();
        lbx.Dock = DockStyle.Fill;

        var product = new[] {
            new{name= "鉛筆", price = 80},
            new{name= "消しゴム", price = 50},
            new{name= "定規", price = 200},
            new{name= "コンパス", price = 300},
            new{name= "ボールペン", price = 100},
        };

        IEnumerable qry = from p in product
                          where p.price >= 200
                          select new { p.name, p.price };

        foreach (var tmp in qry)
        {
            lbx.Items.Add(tmp);
        }
        lbx.Parent = this;
    }
}