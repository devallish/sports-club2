using System;

namespace Devallish.SportsClub.Data.Models
{
    public class Person : BaseEntity
    {
        public string Forenames { get; set; }
        public string Surname { get; set; }
        public string PhoneNo { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string FacebookProfile { get; set; }
        public string ImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
    }
}
