using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class Album
    {
        public int ID { get; set; }

        // Foreign key -> Artist
        public int ArtistID { get; set; }
        public Artist Artist { get; set; }

        [MaxLength(50)]
        [Required]
        public string AlbumTitle { get; set; }

        [MaxLength(2)]
        public int? AlbumNumberOfSongs { get; set; }

        public DateTime? AlbumReleaseDate { get; set; }

        [MaxLength(50)]
        public string? AlbumImage { get; set; }

        public string? AlbumComments { get; set; }
    }
}
