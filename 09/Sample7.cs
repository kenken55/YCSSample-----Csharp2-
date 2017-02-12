using System.Windows.Forms;
using System.Xml;

class Sample7 : Form
{
    private TreeView tv;

    public static void Main()
    {
        Application.Run(new Sample7());
    }
    public Sample7()
    {
        this.Text = "サンプル";

        tv = new TreeView();
        tv.Dock = DockStyle.Fill;

        XmlDocument doc = new XmlDocument();
        doc.Load("c:\\Sample.xml");

        XmlNode xmlroot = doc.DocumentElement;
        TreeNode treeroot = new TreeNode();
        treeroot.Text = xmlroot.Name;
        tv.Nodes.Add(treeroot);
        
        walk(xmlroot, treeroot);
        
        tv.Parent = this;
    }
    public static void walk(XmlNode xn, TreeNode tn)
    {
        for (XmlNode ch = xn.FirstChild;
            ch != null;
            ch = ch.NextSibling)
        {
            TreeNode n = new TreeNode();
            tn.Nodes.Add(n);
            walk(ch,n);
            if (ch.NodeType == XmlNodeType.Element)
            {
                n.Text = ch.Name;
            }
            else
            {
                n.Text = ch.Value;
            }  
        }
    }
}