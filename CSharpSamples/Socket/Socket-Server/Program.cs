using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

class Server
{
    public static void Main(string[] args)
    {
        TCP();
        //UDP();
    }


    public static void TCP()
    {
        //创建服务器
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4567);

        server.Bind(ep);//绑定EP

        //服务器开始监听
        server.Listen(100);//设置最大连接数量为100
        Socket client = server.Accept();//获取客户端的socket，用来与客户端通信

        //发送信息
        client.Send(Encoding.UTF8.GetBytes("这是一条来自服务器的消息"));

        while (true)
        {
            byte[] data = new byte[1024];
            int length = client.Receive(data);

            string message = Encoding.UTF8.GetString(data, 0, length);

            Console.WriteLine("客户端：" + message);
        }
    }


    public static void UDP()
    {
        Socket udpServer = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        EndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4567);

        udpServer.Bind(ep);

        //接收数据
        EndPoint endP = new IPEndPoint(IPAddress.Any, 0);

        while (true)
        {
            byte[] data = new byte[1024];
            int length = udpServer.ReceiveFrom(data, ref endP);
            string message = Encoding.UTF8.GetString(data, 0, length);

            Console.WriteLine("从IP：" + (endP as IPEndPoint).Address + "取到了消息：" + message);
        }

    }
}