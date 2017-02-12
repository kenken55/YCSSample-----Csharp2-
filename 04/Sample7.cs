using System.Windows.Forms;

class Sample7
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";
        fm.Width = 250; fm.Height = 100;

        Label lb = new Label();
        lb.Width = fm.Width; lb.Height = fm.Height;

        string[] str = new string[3]{"鉛筆","消しゴム", "定規"};

        foreach (string s in str)
        {
            lb.Text +=  s + "\n";
        }

        lb.Parent = fm;

        Application.Run(fm);
    }
}

