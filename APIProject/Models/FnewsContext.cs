using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace APIProject.Models
{
    public partial class FnewsContext : DbContext
    {
        public FnewsContext()
        {
        }

        public FnewsContext(DbContextOptions<FnewsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bookmark> Bookmark { get; set; }
        public virtual DbSet<Channel> Channel { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Group> Group { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<NewsTag> NewsTag { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        public virtual DbSet<Tag> Tag { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserTag> UserTag { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=SE130053\\SQLEXPRESS;Database=Fnews;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.NewsId });

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.NewsId).HasColumnName("newsID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Bookmark)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookmark_News");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookmark)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bookmark_User");
            });

            modelBuilder.Entity<Channel>(entity =>
            {
                entity.Property(e => e.ChannelId).HasColumnName("channelID");

                entity.Property(e => e.ChannelName)
                    .HasColumnName("channelName")
                    .HasMaxLength(100);

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Channel)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_Channel_Group");
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Comment1).HasColumnName("comment");

                entity.Property(e => e.MasterCommentId).HasColumnName("masterCommentID");

                entity.Property(e => e.NewsId).HasColumnName("newsID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.NewsId)
                    .HasConstraintName("FK_Comment_News");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Comment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Comment_User");
            });

            modelBuilder.Entity<Group>(entity =>
            {
                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.GroupName)
                    .HasColumnName("groupName")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.NewsId).HasColumnName("newsID");

                entity.Property(e => e.ChannelId).HasColumnName("channelID");

                entity.Property(e => e.DayOfPost)
                    .HasColumnName("dayOfPost")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.NewsContent).HasColumnName("newsContent");

                entity.Property(e => e.NewsTitle)
                    .HasColumnName("newsTitle")
                    .HasMaxLength(100);

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.News)
                    .HasForeignKey(d => d.ChannelId)
                    .HasConstraintName("FK_News_Channel");
            });

            modelBuilder.Entity<NewsTag>(entity =>
            {
                entity.HasKey(e => new { e.TagId, e.NewsId });

                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.Property(e => e.NewsId).HasColumnName("newsID");

                entity.HasOne(d => d.News)
                    .WithMany(p => p.NewsTag)
                    .HasForeignKey(d => d.NewsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsTag_News");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.NewsTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_NewsTag_Tag");
            });

            modelBuilder.Entity<Subscribe>(entity =>
            {
                entity.HasKey(e => new { e.ChannelId, e.UserId });

                entity.Property(e => e.ChannelId).HasColumnName("channelID");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Channel)
                    .WithMany(p => p.Subscribe)
                    .HasForeignKey(d => d.ChannelId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscribe_Channel");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subscribe)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subscribe_User");
            });

            modelBuilder.Entity<Tag>(entity =>
            {
                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.TagName)
                    .HasColumnName("tagName")
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Email)
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.GroupId).HasColumnName("groupID");

                entity.Property(e => e.IsActive).HasColumnName("isActive");

                entity.Property(e => e.IsAdmin).HasColumnName("isAdmin");

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_User_Group");
            });

            modelBuilder.Entity<UserTag>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.TagId });

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.TagId).HasColumnName("tagID");

                entity.HasOne(d => d.Tag)
                    .WithMany(p => p.UserTag)
                    .HasForeignKey(d => d.TagId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTag_Tag");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTag)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserTag_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
