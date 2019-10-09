using System;
using TioRAC.DosBox.Process;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            var aaa = new DosBoxParameters
            {
                Exit = true,
                ForceScaler = true,
                Fullscreen = true,
                Machine = "machine",
                Name = "Nome",
                NoAutoexec = true,
                UserConf = true,
                Version = true,
                StartMapper = true,
                Socket = true,
                SecureMode = true,
                Scaler = true,
                ResetMapper = true,
                ResetConf = true,
                PrintConf = true,
                OpenCaptures = "open",
                NoConsole = true,
            };

            aaa.Commands.Add("dir");
            aaa.Commands.Add("dir -ls");


            var b = aaa.ToString();
        }
    }
}
