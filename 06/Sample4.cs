using System;
using System.Windows.Forms;

class Sample4 : Form
{
    private Label lb1, lb2;

    public static void Main()
    {
        Application.Run(new Sample4());
    }
    public Sample4()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 100;

        lb1 = new Label();
        lb1.Text = "矢印キーでお選びください。";
        lb1.Width = this.Width;

        lb2 = new Label();
        lb2.Top = lb1.Bottom;

        lb1.Parent = this;
        lb2.Parent = this;

        this.KeyDown += new KeyEventHandler(fm_KeyDown);

    }
    public void fm_KeyDown(Object sender, KeyEventArgs e)
    {
        String str;
        if(e.KeyCode == Keys.Up)
        {
           str = "上";
        }
        else if(e.KeyCode == Keys.Down)
        {
           str = "下";
        }
        else if(e.KeyCode == Keys.Right)
        {
           str = "右";
        }
        else if(e.KeyCode == Keys.Left)
        {
           str = "左";
        }
        else
        {
           str = "他のキー";
        }
        lb2.Text = str + "ですね。";
    }
}
