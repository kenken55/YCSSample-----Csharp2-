using System.Windows.Forms;
using System.Data;

class Sample6 : Form
{
    private DataSet ds;
    private DataGridView dg;

    public static void Main()
    {
        Application.Run(new Sample6());
    }
    public Sample6()
    {
        this.Text = "サンプル";

        ds = new DataSet();
        ds.ReadXml("c:\\Sample.xml");

        dg = new DataGridView();
        dg.DataSource = ds.Tables[0];

        dg.Parent = this;
    }
}