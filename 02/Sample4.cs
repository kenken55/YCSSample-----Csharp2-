using System.Windows.Forms;
using System.Drawing;

class Sample4
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Parent = fm;

        Application.Run(fm);
    }
}