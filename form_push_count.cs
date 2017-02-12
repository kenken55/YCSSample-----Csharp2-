using System;
using System.Drawing;
using System.Windows.Forms;

class Program
{
    static void Main()
    {
        Application.Run(new Form1());
    }
}

class Form1 : Form
{
    Button button1;
    int count = 0;

    public Form1()
    {
        this.Width = 200;
        this.Height = 80;
        this.Text = "サンプルプログラム";

        this.button1 = new Button();
        this.button1.Location = new Point(10, 10);
        this.button1.Size = new Size(170, 30);
        this.button1.Text = "ここを押して";

        this.button1.Click += new EventHandler(this.Button1_Click);

        this.Controls.Add(this.button1);
    }

    void Button1_Click(object sender, EventArgs e)
    {
        this.count++;
        this.button1.Text = this.count.ToString();
    }
}