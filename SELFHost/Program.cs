using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Topshelf;

namespace SELFHost
{
    class Program
    {
        static void Main(string[] args)
        {
            HostFactory.Run(hostConfig =>
            {

                hostConfig.UseLog4Net();

                hostConfig.EnableServiceRecovery(serviceRecovery =>
                {
                    // first failure, 5 minute delay
                    serviceRecovery.RestartService(5);

                    // second failure, 10 minute delay
                    serviceRecovery.RunProgram(10, @"C:\Windows\Notepad.exe");

                    // subsequent failures, 15 minute delay
                    serviceRecovery.RestartComputer(15, "Topshelf demo failure");
                });
                hostConfig.Service<MyWindowsService>(serviceConfig =>
                {
                    serviceConfig.ConstructUsing(() => new MyWindowsService());
                    serviceConfig.WhenStarted(s => s.Start());
                    serviceConfig.WhenStopped(s => s.Stop());
                });

              


            });

           
        }
    }
}
