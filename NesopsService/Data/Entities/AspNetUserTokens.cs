using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class AspNetUserTokens
    {
        public AspNetUserTokens()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int UserId { get; set; }

        public string LoginProvider { get; set; }

        public string Name { get; set; }

        public string Value { get; set; }

        #endregion

        #region Generated Relationships
        public virtual AspNetUsers UserAspNetUsers { get; set; }

        #endregion

    }
}
