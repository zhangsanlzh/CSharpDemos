using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Lock
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
            ////顺序执行
            //new Action(async () =>
            //{
            //    await Delay3000Async();
            //    await Delay2000Async();
            //    await Delay1000Async();
            //})();

            ////异步执行
            //new Action(async () =>
            //{
            //    Delay3000Async();
            //    Delay2000Async();
            //    Delay1000Async();
            //})();

            ////异步执行
            //var task3 = Delay3000Async();
            //var task2 = Delay2000Async();
            //var task1 = Delay1000Async();
            //new Action(async () =>
            //{
            //    await task3;
            //    await task2;
            //    await task1;
            //})();

            //Console.WriteLine("hello");

            ////异步执行
            //var tasks = new List<Task>
            //{
            //    Delay3000Async(),
            //    Delay2000Async(),
            //    Delay1000Async()
            //};
            //tasks.ForEach(async s => await s);

            ////异步执行
            //Action[] actions = new Action[3]
            //{
            //    new Action(()=>{Delay3000Async(); }),
            //    new Action(()=>{Delay2000Async(); }),
            //    new Action(()=>{Delay1000Async(); })
            //};
            //Parallel.Invoke(actions);

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

        static async Task Delay3000Async()
        {
            await Task.Delay(3000);
            Console.WriteLine(3000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay2000Async()
        {
            await Task.Delay(2000);
            Console.WriteLine(2000);
            Console.WriteLine(DateTime.Now);
        }

        static async Task Delay1000Async()
        {
            await Task.Delay(1000);
            Console.WriteLine(1000);
            Console.WriteLine(DateTime.Now);
        }
    }
}

