using System.Windows.Forms;
using System.IO;

class Sample2 : Form
{
    private TreeView tv;

    public static void Main()
    {
        Application.Run(new Sample2());
    }
    public Sample2()
    {
        this.Text = "サンプル";

        tv = new TreeView();
        tv.Dock = DockStyle.Fill;

        string dir = Directory.GetCurrentDirectory();

        TreeNode treeroot = new TreeNode();
        treeroot.Text = Path.GetFileName(dir);
        tv.Nodes.Add(treeroot);

        walk(dir, treeroot);

        tv.Parent = this;
    }
    public static void walk(string d, TreeNode tn)
    {
        string[] dirlist = Directory.GetDirectories(d);
        foreach (string dn in dirlist)
        {
            TreeNode n = new TreeNode();
            tn.Nodes.Add(n);
            walk(dn, n);
            n.Text = Path.GetFileName(dn);
        }

        string[] fnlist = Directory.GetFiles(d);
        foreach (string fn in fnlist)
        {
            TreeNode n = new TreeNode();
            tn.Nodes.Add(n);
            n.Text = Path.GetFileName(fn);
        }
    }
}