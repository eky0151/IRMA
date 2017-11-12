using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace PicBook.Web.ServerSide.Misc
{
    [Obsolete]
    public class JwtFactory : IJwtFactory
    {

      private readonly JwtIssuerOptions _jwtOptions;

      public JwtFactory(IOptions<JwtIssuerOptions> jwtOptions)
      {
          _jwtOptions = jwtOptions.Value;
      }


      public async Task<string> GeneratedToken(string userName, ClaimsIdentity identity)
      {
        var claims = new[]
        {
          new Claim(JwtRegisteredClaimNames.Jti, await _jwtOptions.JtiGenerator()),
          new Claim(JwtRegisteredClaimNames.Iat, ToUnixEpochDate(_jwtOptions.IssuedAt).ToString(), ClaimValueTypes.Integer64),
          identity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Rol),
          identity.FindFirst(Constants.Strings.JwtClaimIdentifiers.Id)
        };

        var jwt = new JwtSecurityToken(
            _jwtOptions.Issuer,
           _jwtOptions.Audience,
            claims,
           _jwtOptions.NotBefore,
           _jwtOptions.Expiration,
           _jwtOptions.SigningCredentials);

        var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

        return encodedJwt;

    }

      public ClaimsIdentity GeneratedClaimsIdentity(string userName, string id)
      {
          return new ClaimsIdentity(new GenericIdentity(userName, "Token"), new[]
          {
            new Claim(Constants.Strings.JwtClaimIdentifiers.Id, id),
            new Claim(Constants.Strings.JwtClaimIdentifiers.Rol, Constants.Strings.JwtClaims.ApiAccess)
          });
    }

      private static long ToUnixEpochDate(DateTime date)
        => (long)Math.Round((date.ToUniversalTime() - new DateTimeOffset(1970, 1, 1, 0, 0, 0, TimeSpan.Zero)).TotalSeconds);
  }

      public static class Constants
      {
        public static class Strings
        {
          public static class JwtClaimIdentifiers
          {
            public const string Rol = "User", Id = "id";
          }

          public static class JwtClaims
          {
            public const string ApiAccess = "Api_access";
          }
        }
      }
}
