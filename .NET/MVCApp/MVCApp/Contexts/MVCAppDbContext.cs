using Microsoft.EntityFrameworkCore;
using MVCApp.CoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVCApp.Contexts
{
    public class MVCAppDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserFriend> UserFriends { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        public MVCAppDbContext(DbContextOptions<MVCAppDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasKey(key => new { key.UserId, key.FriendId });
        }
    }
}
