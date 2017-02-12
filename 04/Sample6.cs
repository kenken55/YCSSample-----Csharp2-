﻿using System.Windows.Forms;
using System.Drawing;

class Sample6
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";

        PictureBox[] pb = new PictureBox[5];

        for (int i = 0; i < pb.Length; i++)
        {
            pb[i] = new PictureBox();
            pb[i].Image = Image.FromFile("c:\\car.bmp");
            pb[i].Top = i * pb[i].Height;
            pb[i].Parent = fm;
        }
        Application.Run(fm);
    }
}