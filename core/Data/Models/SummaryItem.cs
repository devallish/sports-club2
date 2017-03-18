using System;

namespace Devallish.SportsClub.Data.Models
{
    public class SummaryItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string Keywords { get; set; }
        public string SmallImageUrl { get; set; }
        public DateTime ArticleDate { get; set; }
    }
}
