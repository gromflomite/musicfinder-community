using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class Playlist
    {
        public int ID { get; set; }

        // FK -> User
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
