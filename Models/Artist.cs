using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class Artist
    {
        public int ID { get; set; }

        [MaxLength(50)]
        [Required]
        public string ArtistName { get; set; }

        [MaxLength(50)]
        public string? ArtistImage { get; set; }

        public string? ArtistBio { get; set; }

        public List<Album> Albums { get; set; }
    }
}
