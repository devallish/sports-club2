using System;
using System.Collections.Generic;

namespace Devallish.SportsClub.Data.Models
{
    public class Squad : BaseEntity
    {
        public string Name { get; set; }
        public string Summary { get; set; }
        public string Information { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public virtual IList<SquadPerson> Persons { get; set; }
        public virtual IList<SquadArticle> Articles { get; set; }
        public virtual IList<SquadSponsor> Sponsors { get; set; }
    }
}
