// using Newtonsoft.Json;

namespace Devallish.SportsClub.Data.Models
{
    public class SquadPerson : BaseEntity
    {
        // [JsonIgnore]
        public int SquadId { get; set; }
        // [JsonIgnore]
        public Squad Squad { get; set; }
        // [JsonIgnore]
        public int PersonId { get; set; }
        public Person Person { get; set; }
        // [JsonIgnore]
        public int PersonRoleId { get; set; }
        public PersonRole PersonRole { get; set; }
    }
}
