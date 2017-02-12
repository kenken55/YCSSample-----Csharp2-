using System.Windows.Forms;
using System.Drawing;

class Sample5
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        PictureBox pb = new PictureBox();
        pb.Image = Image.FromFile("c:\\car.bmp");
        pb.Top = (fm.Height - pb.Height) / 2;
        pb.Left = (fm.Width - pb.Width) / 2;

        pb.Parent = fm;

        Application.Run(fm);
    }
}