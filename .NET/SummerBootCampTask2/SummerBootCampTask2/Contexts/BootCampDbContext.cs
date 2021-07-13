using Microsoft.EntityFrameworkCore;
using SummerBootCampTask2.CoreModels;

namespace SummerBootCampTask2.Contexts
{
    public class BootCampDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<UserFriend> UserFriends { get; set; }

        public DbSet<Chat> Chats { get; set; }

        public DbSet<Message> Messages { get; set; }

        public BootCampDbContext(DbContextOptions<BootCampDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFriend>().HasKey(k => new { k.UserId, k.FriendId });
        }
    }
}
