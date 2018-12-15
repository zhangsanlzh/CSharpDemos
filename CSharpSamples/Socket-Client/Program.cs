﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

class Client
{
    public static void Main(string[] args)
    {
        //创建客户端
        Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //入口
        EndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 4567);

        //用来接服务器端的数据
        byte[] data = new byte[1024];
        int length = 0;//数据的长度
        string message;

        //连接服务器
        client.Connect(ep);
        length = client.Receive(data);
        message = Encoding.UTF8.GetString(data, 0, length);

        Console.WriteLine(message);

        while (true)
        {
            message = Console.ReadLine();//发送信息
            data = Encoding.UTF8.GetBytes(message);

            client.Send(data);
        }

    }
}
