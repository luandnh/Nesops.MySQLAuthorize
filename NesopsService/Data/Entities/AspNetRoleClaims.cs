using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class AspNetRoleClaims
    {
        public AspNetRoleClaims()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public int RoleId { get; set; }

        public string ClaimType { get; set; }

        public string ClaimValue { get; set; }

        #endregion

        #region Generated Relationships
        public virtual AspNetRoles RoleAspNetRoles { get; set; }

        #endregion

    }
}
