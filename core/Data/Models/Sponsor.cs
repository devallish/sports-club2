using System;

namespace Devallish.SportsClub.Data.Models
{
    public class Sponsor : BaseEntity
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public string LinkUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
