using System.Windows.Forms;

class Sample2
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        fm.Width = 300;
        fm.Height = 200;

        Label lb1 = new Label();
        Label lb2 = new Label();

        lb1.Text = "こんにちは";
        lb2.Text = "さようなら";

        lb2.Left = lb1.Left + 100;
        
        lb1.Parent = fm;
        lb2.Parent = fm;

        Application.Run(fm);
    }
}