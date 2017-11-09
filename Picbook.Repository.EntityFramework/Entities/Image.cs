﻿using System;
using System.Collections.Generic;

namespace Picbook.Repository.EntityFramework.Entities
{
    public partial class Image
    {
        public Image()
        {
            Rating = new HashSet<Rating>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public string OriginalSizeUrl { get; set; }
        public string WebSizeUrl { get; set; }
        public string MobileSizeUrl { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }
        public long? AlbumId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Public { get; set; }
        public bool Deleted { get; set; }

        public Album Album { get; set; }
        public ICollection<Rating> Rating { get; set; }
    }
}
