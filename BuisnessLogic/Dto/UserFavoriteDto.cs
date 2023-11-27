using System;
using System.Collections.Generic;

namespace DataAccess.DBModels
{
    public partial class UserFavoriteDto
    {
        public int UserFavoritesId { get; set; }
        public int UserId { get; set; }
        public int CarId { get; set; }
    }
}
