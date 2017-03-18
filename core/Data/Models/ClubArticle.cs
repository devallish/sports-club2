namespace Devallish.SportsClub.Data.Models
{
    public class ClubArticle : BaseEntity
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int ArticleId { get; set; }
        public Article Article { get; set; }
    }
}
