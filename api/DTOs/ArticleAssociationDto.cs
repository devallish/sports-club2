namespace Devallish.SportsClub.Api.DTOs{
    public class ArticleAssociationDto{
        public string Name { get; set; }
        public bool IsClub { get; set; }
        public int AssociatedToId { get; set; }
        public bool IsSelected { get; set; }
    }
}