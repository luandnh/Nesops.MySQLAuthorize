using System;
using System.Collections.Generic;

namespace NesopsService.Data.Entities
{
    public partial class Application
    {
        public Application()
        {
            #region Generated Constructor
            #endregion
        }

        #region Generated Properties
        public int Id { get; set; }

        public string Name { get; set; }

        public string DisplayName { get; set; }

        public string RedirectUrl { get; set; }

        public bool Active { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime UpdateAt { get; set; }

        public int? OwnerId { get; set; }

        #endregion

        #region Generated Relationships
        public virtual AspNetUsers OwnerAspNetUsers { get; set; }

        #endregion

    }
}
