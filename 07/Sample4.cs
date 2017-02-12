using System.Windows.Forms;
using System.Drawing;

class Sample4 : Form
{
    private Label[] lb = new Label[3];
    private TableLayoutPanel tlp;

    public static void Main()
    {
        Application.Run(new Sample4());
    }
    public Sample4()
    {
        this.Text = "サンプル";
        this.Width = 250; this.Height = 200;

        tlp = new TableLayoutPanel();
        tlp.Dock = DockStyle.Fill;
        tlp.ColumnCount = 1;
        tlp.RowCount = 3;

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i] = new Label();
            lb[i].Text = "This is a Car.";
            lb[i].Width = 200;
        }

        lb[0].Font = new Font("SansSerif", 12,FontStyle.Bold);
        lb[1].Font = new Font("Helvetica", 14 ,FontStyle.Bold);
        lb[2].Font = new Font("Century", 16, FontStyle.Bold);

        for (int i = 0; i < lb.Length; i++)
        {
            lb[i].Parent = tlp;
        }
        tlp.Parent = this;
    }
}
