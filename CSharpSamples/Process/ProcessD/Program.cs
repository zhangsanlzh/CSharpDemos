using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;
using System.Threading;

namespace ProcessD
{
    /// <summary>
    /// Pipe-Receive
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Receive();
        }

        private static void Receive()
        {
            while (true)
            {
                try
                {
                    var _pipeServer = new NamedPipeServerStream("closePipe", PipeDirection.InOut, 2);
                    _pipeServer.WaitForConnection();

                    StreamReader sr = new StreamReader(_pipeServer);
                    string recData = sr.ReadLine();

                    Console.WriteLine(recData);

                    if (recData == "exit")
                    {
                        break;
                    }
                    sr.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
