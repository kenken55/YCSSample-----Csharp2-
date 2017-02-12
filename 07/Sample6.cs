using System;
using System.Windows.Forms;

class Sample6 : Form
{
    private Label lb;
    private CheckBox cb1, cb2;
    private FlowLayoutPanel flp;
 
    public static void Main()
    {
        Application.Run(new Sample6());
    }
    public Sample6()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "いらっしゃいませ。";
        lb.Dock = DockStyle.Top;

        cb1 = new CheckBox();
        cb2 = new CheckBox();

        cb1.Text = "車";
        cb2.Text = "トラック";

        flp = new FlowLayoutPanel();
        flp.Dock = DockStyle.Bottom;
        
        cb1.Parent = flp;
        cb2.Parent = flp;

        lb.Parent = this; 
        flp.Parent = this;

        cb1.CheckedChanged += new EventHandler(cb_CheckedChanged);
        cb2.CheckedChanged += new EventHandler(cb_CheckedChanged);
    }
    public void cb_CheckedChanged(Object sender, EventArgs e)
    {
        CheckBox tmp = (CheckBox)sender;
        if(tmp.Checked == true)
        {
            lb.Text =  tmp.Text + "を選びました。";
        }
        else if (tmp.Checked == false)
        {
            lb.Text = tmp.Text + "をやめました。";
        }
    }
}