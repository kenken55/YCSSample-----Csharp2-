using System;
using System.Windows.Forms;

class Sample9 : Form
{
    private Label lb;
    private ListBox lbx;

    public static void Main()
    {
        Application.Run(new Sample9());
    }
    public Sample9()
    {
        string[] str = {"乗用車", "トラック", "オープンカー",
                      "タクシー", "スポーツカー", "ミニカー",
                      "自転車", "三輪車", "バイク",
                      "飛行機", "ヘリコプター", "ロケット"};

        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        lb = new Label();
        lb.Text = "いらっしゃいませ。";
        lb.Dock = DockStyle.Top;

        lbx = new ListBox();

        for (int i = 0; i < str.Length; i++)
        {
            lbx.Items.Add(str[i]);
        }
        lbx.Top = lb.Bottom;

        lb.Parent = this;
        lbx.Parent = this;

        lbx.SelectedIndexChanged += new EventHandler(lbx_SelectedIndexChanged);
    }
    public void lbx_SelectedIndexChanged(Object sender, EventArgs e)
    {
        ListBox tmp = (ListBox)sender;

        lb.Text = tmp.Text + "を選びました。";
     }
}
