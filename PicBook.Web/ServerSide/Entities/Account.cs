using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PicBook.Web.ServerSide.Entities
{
        public partial class Account : IdentityUser<Guid>
    {
            public Account()
            {
                Album = new HashSet<Album>();
                Rating = new HashSet<Rating>();
            }

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

    public partial class Album
    {
        public Album()
        {
            Image = new HashSet<Image>();
        }

        [Key]
        public long Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid AccountId { get; set; }

        public Account Account { get; set; }
        public ICollection<Image> Image { get; set; }
    }

    public partial class Image
    {
        public Image()
        {
            Rating = new HashSet<Rating>();
        }

        [Key]
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

    public partial class Rating
    {
        [Key]
        public long Id { get; set; }
        public Guid AccountId { get; set; }
        public long ImageId { get; set; }
        public string Comment { get; set; }
        public double Value { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public bool Deleted { get; set; }

        public Account Account { get; set; }
        public Image Image { get; set; }
    }

    public class ApplicationRole : IdentityRole<Guid>
    {
        public string Description { get; set; }

    }

}
