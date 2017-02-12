using System.Windows.Forms;
using System.Drawing;

class Sample3
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        int w;
        w = 100;

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Top = w;

        pb.Parent = fm;

        Application.Run(fm);
    }
}

