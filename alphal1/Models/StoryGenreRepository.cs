using Alphal1.Models;
using Microsoft.EntityFrameworkCore;

namespace alphal1.Models
{
    public class StoryGenreRepository : Repository<StoryGenre>, IStoryGenreRepository
    {
        public StoryGenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<StoryGenre>> GetGenresByStoryIdAsync(int storyId)
        {
            return await _context.StoryGenres
                .Where(sg => sg.StoryId == storyId)
                .ToListAsync();
        }

        public async Task<IEnumerable<StoryGenre>> GetStoriesByGenreIdAsync(int genreId)
        {
            return await _context.StoryGenres
                .Where(sg => sg.GenreId == genreId)
                .ToListAsync();
        }
    }

}
