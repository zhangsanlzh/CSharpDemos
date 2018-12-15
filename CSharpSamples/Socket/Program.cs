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
        //创建服务器
        Socket server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        EndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4567);

        server.Bind(ep);//绑定EP

        //服务器开始监听
        server.Listen(100);//设置最大连接数量为100
        Socket client = server.Accept();//获取客户端的socket，用来与客户端通信

        //发送信息
        string message = "你好，我是服务器！";
        byte[] data = Encoding.UTF8.GetBytes(message);//转成能传送的byte类型的数据

        client.Send(data);

        while (true)
        {
            int length = client.Receive(data);
            message = Encoding.UTF8.GetString(data, 0, length);

            Console.WriteLine("客户端：" + message);
        }
    }
}


