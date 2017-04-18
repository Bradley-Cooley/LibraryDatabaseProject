namespace LibraryDatabaseProject
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class LibraryModel : DbContext
    {
        public LibraryModel()
            : base("name=LibraryModel")
        {
        }

        public virtual DbSet<adminuser> adminusers { get; set; }
        public virtual DbSet<book> books { get; set; }
        public virtual DbSet<book_publishedby> book_publishedby { get; set; }
        public virtual DbSet<item> items { get; set; }
        public virtual DbSet<movie> movies { get; set; }
        public virtual DbSet<musicalbum> musicalbums { get; set; }
        public virtual DbSet<publisher> publishers { get; set; }
        public virtual DbSet<rating> ratings { get; set; }
        public virtual DbSet<rents_returns> rents_returns { get; set; }
        public virtual DbSet<user> users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<adminuser>()
                .Property(e => e.admin_firstName)
                .IsUnicode(false);

            modelBuilder.Entity<adminuser>()
                .Property(e => e.admin_lastName)
                .IsUnicode(false);

            modelBuilder.Entity<book>()
                .Property(e => e.author)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.Item_title)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .Property(e => e.genre)
                .IsUnicode(false);

            modelBuilder.Entity<item>()
                .HasOptional(e => e.book)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete();

            modelBuilder.Entity<item>()
                .HasOptional(e => e.movie)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete();

            modelBuilder.Entity<item>()
                .HasOptional(e => e.musicalbum)
                .WithRequired(e => e.item)
                .WillCascadeOnDelete();

            modelBuilder.Entity<movie>()
                .Property(e => e.director)
                .IsUnicode(false);

            modelBuilder.Entity<movie>()
                .Property(e => e.mpaa_rating)
                .IsUnicode(false);

            modelBuilder.Entity<musicalbum>()
                .Property(e => e.artist)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.address)
                .IsUnicode(false);

            modelBuilder.Entity<publisher>()
                .Property(e => e.publisher_name)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_firstName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .Property(e => e.user_lastName)
                .IsUnicode(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.ratings)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.rents_returns)
                .WithRequired(e => e.user)
                .WillCascadeOnDelete(false);
        }
    }
}
