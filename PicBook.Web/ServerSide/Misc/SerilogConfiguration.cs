using Serilog;

namespace PicBook.Web.ServerSide.Misc
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
