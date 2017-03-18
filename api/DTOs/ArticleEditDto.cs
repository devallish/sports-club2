using System;
using System.Collections.Generic;

namespace Devallish.SportsClub.Api.DTOs{

    public class ArticleEditDto : ArticleDto{

        // Extend the standared ArticleDto
        public DateTime? PublishDate { get; set; }
        public DateTime? RemoveDate { get; set; }
        public IEnumerable<ArticleAssociationDto> Associations { get; set; }
    }
}