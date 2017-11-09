using System;
using System.Collections.Generic;

namespace Picbook.Repository.EntityFramework.Entities
{
    public partial class Rating
    {
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
}
