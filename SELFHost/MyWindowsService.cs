using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace SELFHost
{
    class MyWindowsService
    {
        private static readonly ILog _log = LogManager.GetLogger(nameof(MyWindowsService));

        public void Start()
        {
            _log.Info("Started succesfully.");
        }

        public void Stop()
        {
            _log.Info("Stopped succesfully.");
        }
    }
}
