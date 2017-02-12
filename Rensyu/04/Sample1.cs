using System.Windows.Forms;

class Sample1
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";
        fm.Width = 250; fm.Height = 150;

        Label lb = new Label();
        lb.Width = fm.Width; lb.Height = fm.Height;

        for (int i = 1; i <= 10; i++)
        {
            if (i % 2 == 0)
                lb.Text += i + "を表示します。\n";
        }

        lb.Parent = fm;

        Application.Run(fm);
    }
}