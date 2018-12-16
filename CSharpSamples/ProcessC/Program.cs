using System;
using System.IO;
using System.IO.Pipes;
using System.Security.Principal;
using System.Threading;

namespace ProcessC
{
    /// <summary>
    /// Pipe-Send
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Send();
        }

        private static void Send()
        {
            while (true)
            {
                try
                {
                    var _pipeClient = new NamedPipeClientStream(".", "closePipe", PipeDirection.InOut, PipeOptions.None, TokenImpersonationLevel.Impersonation);
                    _pipeClient.Connect();

                    StreamWriter sw = new StreamWriter(_pipeClient);
                    sw.WriteLine(Console.ReadLine());
                    sw.Flush();

                    sw.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
        }

    }
}
