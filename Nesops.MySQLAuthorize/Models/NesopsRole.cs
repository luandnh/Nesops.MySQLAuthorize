using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.MySQLAuthorize.Models
{
    public class NesopsRole : IdentityRole<int>
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public NesopsRole() { }
        public NesopsRole(string roleName) : base(roleName)
        {
        }
    }
}
