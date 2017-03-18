using System;

namespace Devallish.SportsClub.Api.DTOs{

    public class SummaryItemDto {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; }
        public string RouteName {get; set;}
    }
}