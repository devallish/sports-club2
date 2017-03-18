using System;

namespace Devallish.SportsClub.Api.DTOs
{
    public class ArticleDto {
        public int Id {get; set;}
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        public string Content3 { get; set; }
        public string Content4 { get; set; }
        public string ImageUrl1 { get; set; }
        public string ImageUrl2 { get; set; }
        public string ImageUrl3 { get; set; }
        public string ImageUrl4 { get; set; }
        public string Keywords { get; set; }
        public DateTime ArticleDate { get; set; }
        public AuthorDto Author { get; set; }
        
    }
}