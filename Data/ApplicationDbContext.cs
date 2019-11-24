using System;
using System.Collections.Generic;
using System.Text;
using MFCommunity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MFCommunity.Data
{
    public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<MFCommunity.Models.Album> Albums { get; set; }

        public DbSet<MFCommunity.Models.Artist> Artists { get; set; }

        public DbSet<MFCommunity.Models.FavouriteSong> FavouriteSongs { get; set; }

        public DbSet<MFCommunity.Models.Playlist> Playlists { get; set; }

        public DbSet<MFCommunity.Models.PlaylistSong> PlaylistSongs { get; set; }

        public DbSet<MFCommunity.Models.Song> Songs { get; set; }

        public DbSet<MFCommunity.Models.User> Users { get; set; }
    }
}
