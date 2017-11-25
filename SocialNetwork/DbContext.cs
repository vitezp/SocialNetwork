using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SocialNetwork.Entities;
using SocialNetwork.Initializers;

namespace SocialNetwork
{
    public class DbContext : System.Data.Entity.DbContext
    {
        public DbContext() : base("PV226-SocialNetwork")
        {
            Database.SetInitializer(new MyInitializer());
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Friendship> Friendships { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }

        protected override void OnModelCreating(DbModelBuilder builder)
        {
            builder.Entity<Friendship>()
                .HasRequired(u => u.User1)
                .WithMany(u => u.RequestedFriendships)
                .HasForeignKey(u => u.User1Id);

            builder.Entity<Friendship>()
                .HasRequired(u => u.User2)
                .WithMany(u => u.AcceptedFriendships)
                .HasForeignKey(u => u.User2Id);

            builder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
        }
    }
}
