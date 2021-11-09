using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using QuickPropForum.Models;

#nullable disable

namespace QuickPropForum.Data
{
    public partial class QuickPropForumDBContext : DbContext
    {
        public QuickPropForumDBContext()
        {
        }

        public QuickPropForumDBContext(DbContextOptions<QuickPropForumDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Post>(entity =>
            {
                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Post_Users");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.ProfilePic).IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
