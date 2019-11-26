using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models.ViewModels
{
    public class ArtistVM
    {
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }
    }
}
