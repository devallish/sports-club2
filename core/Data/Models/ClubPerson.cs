namespace Devallish.SportsClub.Data.Models
{
    public class ClubPerson : BaseEntity
    {
        public int ClubId { get; set; }
        public Club Club { get; set; }
        public int PersonId { get; set; }
        public Person Person { get; set; }
        public int PersonRoleId { get; set; }
        public PersonRole Role { get; set; }
    }
}
