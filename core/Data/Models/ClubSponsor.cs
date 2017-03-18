namespace Devallish.SportsClub.Data.Models
{
    public class ClubSponsor : BaseEntity
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int SponsorId { get; set; }
        public Sponsor Sponsor { get; set; }
    }
}
