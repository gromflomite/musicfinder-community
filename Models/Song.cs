using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class Song
    {
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string SongTitle { get; set; }

        // Foreign key -> Album.
        public int AlbumID { get; set; }
        public Album Album { get; set; }

        public string? SongComments { get; set; }

        public List<FavouriteSong> favouriteSongs { get; set; }
    }
}
