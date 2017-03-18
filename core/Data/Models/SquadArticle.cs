//using Newtonsoft.Json;

namespace Devallish.SportsClub.Data.Models
{
    public class SquadArticle : BaseEntity
    {
        //[JsonIgnore]
        public int SquadId { get; set; }
        //[JsonIgnore]
        public Squad Squad { get; set; }
        //[JsonIgnore]
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
