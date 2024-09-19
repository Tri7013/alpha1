using alphal1.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Alphal1.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Story> Stories { get; set; } // Sửa thành Stories và đúng kiểu DbSet
        public DbSet<StoryGenre> StoryGenres { get; set; }
        public DbSet<Genre> Genres { get; set; } // Sửa thành Genres và đúng kiểu DbSet
        public DbSet<Comment> Comments { get; set; } // Sửa thành Comments và đúng kiểu DbSet
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình khóa chính cho StoryGenre
            modelBuilder.Entity<StoryGenre>()
                .HasKey(sg => new { sg.StoryId, sg.GenreId });

            // Cấu hình các thực thể khác nếu cần
        }
    }
}
