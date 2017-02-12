using System;
using System.Windows.Forms;
using System.Drawing;

class Sample1 : Form
{
    private Label lb;
    private RadioButton rb1, rb2, rb3;
    private GroupBox gb;

    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 300; this.Height = 200;

        lb = new Label();
        lb.Text = "いらっしゃいませ。";
        lb.Dock = DockStyle.Top;

        rb1 = new RadioButton();
        rb2 = new RadioButton();
        rb3 = new RadioButton();

        rb1.Text = "黄";
        rb2.Text = "赤";
        rb3.Text = "青";
        rb1.Checked = true;

        rb1.Dock = DockStyle.Bottom;
        rb2.Dock = DockStyle.Bottom;
        rb3.Dock = DockStyle.Bottom;

        gb = new GroupBox();
        gb.Text = "種類";
        gb.Dock = DockStyle.Bottom;

        rb1.Parent = gb;
        rb2.Parent = gb;
        rb3.Parent = gb;

        lb.Parent = this;
        gb.Parent = this;

        rb1.Click += new EventHandler(rb_Click);
        rb2.Click += new EventHandler(rb_Click);
        rb3.Click += new EventHandler(rb_Click); 
    }
    public void rb_Click(Object sender, EventArgs e)
    {
        RadioButton tmp = (RadioButton)sender;
        if (tmp == rb1)
        {
            lb.BackColor = Color.Yellow;
        }
        else if (tmp == rb2)
        {
            lb.BackColor = Color.Red;
        }
        else if (tmp == rb3)
        {
            lb.BackColor = Color.Blue;
        }

    }
}