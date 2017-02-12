using System.Windows.Forms;
using System.Drawing;

class Sample2
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Top = 100;
        pb.Left = pb.Width;

        pb.Parent = fm;

        Application.Run(fm);
    }
}