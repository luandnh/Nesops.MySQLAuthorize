using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nesops.MySQLAuthorize.Models
{
    public class NesopsUser : IdentityUser<int>
    {
        public NesopsUser()
        {
        }
    }
}
