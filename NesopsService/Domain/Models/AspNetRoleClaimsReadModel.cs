using System;
using System.Collections.Generic;

namespace NesopsService.Domain.Models
{
    public partial class AspNetRoleClaimsReadModel
    {
        #region Generated Properties
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        #endregion

    }
}
