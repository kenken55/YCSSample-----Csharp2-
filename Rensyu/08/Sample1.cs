using System;
using System.Windows.Forms;
using System.Drawing;

class Sample1 : Form
{
    private int[] data;
    
    public static void Main()
    {
        Application.Run(new Sample1());
    }
    public Sample1()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        data = new int[] { 100, 30, 50, 60, 70 };

        this.Paint += new PaintEventHandler(fm_Paint);
    }
    public void fm_Paint(Object sender, PaintEventArgs e)
    {
        Graphics g = e.Graphics;

        for(int i=0; i<data.Length;i++)
        {
            SolidBrush br = new SolidBrush(Color.Blue);

            g.FillRectangle(br, i * 30, 150 - data[i], 20, data[i]);
        }
    }
}