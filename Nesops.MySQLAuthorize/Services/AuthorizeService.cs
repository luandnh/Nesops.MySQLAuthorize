using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Nesops.MySQLAuthorize.Configs;
using Nesops.MySQLAuthorize.IdentityDbContext;
using Nesops.MySQLAuthorize.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Nesops.MySQLAuthorize.Services
{
    public class AuthorizeService
    {
        public NesopsUserManager _userManager { get; set; }
        public RoleManager<NesopsRole> _roleManager { get; set; }
        public SignInManager<NesopsUser> _signInManager { get; set; }
        public NesopsAuthorizeDbContext _dbContext { get; set; }
        public AuthorizeService(NesopsUserManager userManager,
            RoleManager<NesopsRole> roleManager,
            SignInManager<NesopsUser> signInManager,
            NesopsAuthorizeDbContext dbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }
        public async Task<List<NesopsRole>> GetRolesAsync()
        {
            var result = await _roleManager.Roles.ToListAsync();
            return result;
        }
        public async Task<IdentityResult> CreateRoleAsync(NesopsRole role)
        {
            var result = await _roleManager.CreateAsync(role);
            return result;
        }
        public async Task<IdentityResult> CreateUserAsync(NesopsUser user, string password, IEnumerable<string> roles = null)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                var result = await _userManager.CreateAsync(user, password);
                if (!result.Succeeded) return result;
                if (roles != null) result = await _userManager.AddToRolesAsync(user, roles);
                if (result.Succeeded) transaction.Commit();
                return result;
            }
        }
        public virtual async Task<AuthenticationTicket> GetAuthenticateTicketAsync(string username, string password)
        {
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, password)))
            {
                return null;
            }
            var identity = new ClaimsIdentity();
            identity.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            var userClaims = await _userManager.GetClaimsAsync(user);
            var userRoles = (await _userManager.GetRolesAsync(user));
            foreach (var userRole in userRoles)
            {
                userClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }
            identity.AddClaims(userClaims);
            var principal = new ClaimsPrincipal(identity);
            var prop = new AuthenticationProperties()
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddDays(1)
            };
            return new AuthenticationTicket(principal, prop, "application");
        }
        public IDictionary<string, object> GetTokenResponse(AuthenticationTicket ticket)
        {
            var res = new Dictionary<string, object>();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(NesopsJWTConfiguration.SECRETKEY);
            var issuer = NesopsJWTConfiguration.ISSUER;
            var audience = NesopsJWTConfiguration.AUDIENCE;
            var identity = ticket.Principal.Identity as ClaimsIdentity;
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Jti, identity.FindFirst(ClaimTypes.NameIdentifier).Value));
            identity.AddClaim(new Claim(JwtRegisteredClaimNames.Sub, ticket.Principal.Identity.Name));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Issuer = issuer,
                Audience = audience,
                Subject = new ClaimsIdentity(identity),
                IssuedAt = ticket.Properties.IssuedUtc?.UtcDateTime,
                Expires = ticket.Properties.ExpiresUtc?.UtcDateTime,
                NotBefore = ticket.Properties.IssuedUtc?.UtcDateTime,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };
            var token = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            res["access_token"] = tokenString;
            if (ticket.Properties.ExpiresUtc != null)
                res["expire_utc"] = ticket.Properties.ExpiresUtc;
            if (ticket.Properties.IssuedUtc != null)
                res["issued_utc"] = ticket.Properties.IssuedUtc;
            return res;
        }
        public async Task<IDictionary<string, object>> GetTokenResponse2(string username, string password)
        {
            var res = new Dictionary<string, object>();
            var user = await _userManager.FindByNameAsync(username);
            if (user == null || !(await _userManager.CheckPasswordAsync(user, password)))
            {
                return null;
            }
            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(NesopsJWTConfiguration.SECRETKEY);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            res["access_token"] = tokenHandler.WriteToken(token);
            return res;
        }
    }
}
