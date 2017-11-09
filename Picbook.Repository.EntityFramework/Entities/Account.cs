﻿using System;
using System.Collections.Generic;

namespace Picbook.Repository.EntityFramework.Entities
{
    public partial class Account
    {
        public Account()
        {
            Album = new HashSet<Album>();
            Rating = new HashSet<Rating>();
        }

        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string MobilNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ProfileImageUrl { get; set; }

        public ICollection<Album> Album { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}