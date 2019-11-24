using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFCommunity.Models
{
    public class PlaylistSong
    {
        public int ID { get; set; }

        // FK -> Song
        public int SongID { get; set; }
        public Song Song { get; set; }

        // FK -> Playlist
        public int PlaylistID { get; set; }
        public Playlist Playlist { get; set; }
    }
}
