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
        pb.Top = pb.Top + 10;
        pb.Left = pb.Left + 10;

        pb.Parent = fm;

        Application.Run(fm);
    }
}