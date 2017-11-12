using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PicBook.Web.ServerSide.Misc
{
    [Obsolete]
    public interface IJwtFactory
    {
      Task<string> GeneratedToken(string userName, ClaimsIdentity identity);
      ClaimsIdentity GeneratedClaimsIdentity(string userName, string id);
    }
}
