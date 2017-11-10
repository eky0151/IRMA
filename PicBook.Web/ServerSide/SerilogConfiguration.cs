using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace PicBook.Web.ServerSide
{
    public static class SerilogConfiguration
    {
      public static void ConfigureSerilog()
      {
        Log.Logger = new LoggerConfiguration()
          .MinimumLevel
          .Information()
          .WriteTo.Seq("http://localhost:5341/")
          .CreateLogger();
    }
    }
}
