﻿using System.Windows.Forms;

class Sample5
{
    public static void Main()
    {
        Form fm = new Form();
        fm.Text = "サンプル";
        fm.Width = 300; fm.Height = 150;

        Label lb = new Label();
        lb.Width = fm.Width; lb.Height = fm.Height;

        for (int i = 0; i < 5; i++)
        {
            lb.Text += i + "号車を表示します。\n"; 
        }

        lb.Parent = fm;

        Application.Run(fm);
    }
}