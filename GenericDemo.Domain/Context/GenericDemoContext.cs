namespace GenericDemo.Domain.Context
{
    using GenericDemo.Domain.Models;

    using Microsoft.EntityFrameworkCore;

    public class GenericDemoContext : DbContext
    {
        public GenericDemoContext(DbContextOptions<GenericDemoContext> options) : base(options)
        {
        }

        public DbSet<Language> Languages { get; set; }

        public DbSet<Like> Likes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Language>().HasMany(x => x.Likes).WithOne(x => x.Language)
                .HasForeignKey(x => x.LanguageId);
        }
    }
}
