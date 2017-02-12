using System.Windows.Forms;
using System.Drawing;

class Sample2
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";
        fm.Width = 600; fm.Height = 300;

        PictureBox[,] pb = new PictureBox[5,5];

        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                pb[i, j] = new PictureBox();
                pb[i, j].Image = Image.FromFile("c:\\car.bmp");
                pb[i, j].Left = pb[i, j].Width * i;
                pb[i, j].Top = pb[i, j].Height * j;
                pb[i, j].Parent = fm;
            }
        }

        Application.Run(fm);
    }
}