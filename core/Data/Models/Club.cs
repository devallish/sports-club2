using System;
using System.Collections.Generic;

namespace Devallish.SportsClub.Data.Models
{
    public class Club : BaseEntity
    {
        public string Name { get; set; }
        public string BrowserTitle { get; set; }
        public string Summary { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        
        public virtual IList<ClubSponsor> Sponsors { get; set; }
        public virtual IList<ClubPerson> Persons { get; set; }
        public virtual IList<ClubArticle> Articles { get; set; }
    }
}
