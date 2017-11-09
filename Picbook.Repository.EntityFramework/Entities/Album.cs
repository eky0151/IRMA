using System;
using System.Collections.Generic;

namespace Picbook.Repository.EntityFramework.Entities
{
    public partial class Album
    {
        public Album()
        {
            Image = new HashSet<Image>();
        }

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
}
