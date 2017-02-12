using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

class Sample6S
{
    public static string HOST = "localhost";
    public static int PORT = 10000;

    public static void Main()
    {
        IPHostEntry ih = Dns.GetHostEntry(HOST);

        TcpListener tl = new TcpListener(ih.AddressList[0], PORT);
        tl.Start();

        Console.WriteLine("待機します。");
        while (true)
        {
            TcpClient tc = tl.AcceptTcpClient();
            Console.WriteLine("ようこそ。");

            Client c = new Client(tc);
            Thread th = new Thread(c.run);
            th.Start();
        }
    }
}
class Client
{
    TcpClient tc;

    public Client(TcpClient c)
    {
        tc = c;
    }
    public void run()
    {
        StreamWriter sw = new StreamWriter(tc.GetStream());
        StreamReader sr = new StreamReader(tc.GetStream());

        while(true)
        {
            try
            {
                String str = sr.ReadLine();
                sw.WriteLine("サーバー：「" + str + "」ですね。");
                sw.Flush();
            }
            catch
            {
                sr.Close();
                sw.Close();
                tc.Close();
            }
        }
    }
}