using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models.ViewModels
{
    public class HomeVM
    {
        public List<Album> Albums { get; set; }
        public List<Song> Songs { get; set; }
        public List<Artist> Artists { get; set; }

        // For carousel Albums images --------------------------------
        public int carousel1;
        public int carousel2;
        public int carousel3;
    }
}
