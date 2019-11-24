using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class FavouriteSong
    {
        public int ID { get; set; }

        // FK -> User
       public User User { get; set; }
       //public int UserID { get; set; }

        // FK -> Song
        public int SongID { get; set; }
        public Song Song { get; set; }
    }
}
