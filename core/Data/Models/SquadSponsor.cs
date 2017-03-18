// using Newtonsoft.Json;

namespace Devallish.SportsClub.Data.Models
{
    public class SquadSponsor : BaseEntity
    {
        // [JsonIgnore]
        public int SquadId { get; set; }
        // [JsonIgnore]
        public Squad Squad { get; set; }
        // [JsonIgnore]
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
