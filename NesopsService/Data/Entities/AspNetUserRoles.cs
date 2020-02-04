using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class AspNetUserRoles
    {
        public AspNetUserRoles()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int UserId { get; set; }

        public int RoleId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual AspNetRoles RoleAspNetRoles { get; set; }

        public virtual AspNetUsers UserAspNetUsers { get; set; }

        #endregion

    }
}
