using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("主程序");

            // 不等 Asyn()完成，直接执行下面的代码
            Asyn();

            Console.WriteLine("主程序");
            Console.ReadKey();
        }

        /// <summary>
        /// Asyn()不是被主线程执行的
        /// </summary>
        static async void Asyn()
        {
            // 执行到这里将要等待，等到 CreateFile(...)完成才能执行下面的代码 - 代码 A
            await CreateFile(@"C:\Users\Administrator\Desktop\");

            //// 执行到这里不等待 CreateFile(...)完成,直接执行后面的代码 - 代码　B
            //CreateFile(@"C:\Users\Administrator\Desktop\");

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("hello world");
                Task.Delay(1000);
            }

        }

        static async Task CreateFile(string filePath)
        {
            //await Task.Run(delegate { File.Create(filePath + "a.txt"); });

            //await Task.Delay(5000);
            Task.Delay(5000);

            Task.Run(delegate { File.Create(filePath + "a.txt"); });

        }
    }
}

