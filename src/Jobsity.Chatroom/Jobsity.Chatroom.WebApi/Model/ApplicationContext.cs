using Microsoft.EntityFrameworkCore;

namespace Jobsity.Chatroom.WebApi.Model
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasData(new User
                {
                    Id = Guid.NewGuid(),
                    Name = "user1",
                    Password = "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8"
                },
                new User
                {
                    Id = Guid.NewGuid(),
                    Name = "user2",
                    Password = "a2FpcUtBUzY1MTEyLTFrbJfLJVJXdqn9noF3GwDzW/kF7QQ8"
                });

            modelBuilder.Entity<Chatroom>()
                .HasData(new Chatroom
                {
                    Id = Guid.NewGuid(),
                    Name = "Chatroom 1",
                    Created = DateTime.Now
                });
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Chatroom> Chatrooms { get; set; }
        public DbSet<Message> Messages { get; set; }
    }


}
