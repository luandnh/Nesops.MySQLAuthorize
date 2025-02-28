﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Nesops.MySQLAuthorize.Models
{
    public class NesopsApplication
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string RedirectUrl { get; set; }
        public bool Active { get; set; }
        public DateTime createAt { get; set; } = DateTime.Now;
        public DateTime updateAt { get; set; }

        //Relationship with AspNetUsers
        public virtual NesopsUser Owner { get; set; }
    }
}
