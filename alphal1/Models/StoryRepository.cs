using Alphal1.Models;
using Microsoft.EntityFrameworkCore;

namespace alphal1.Models
{
    public class StoryRepository : Repository<Story>, IStoryRepository
    {
        public StoryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Story>> GetStoriesByGenreAsync(int genreId)
        {
            return await _context.StoryGenres
                .Where(sg => sg.GenreId == genreId)
                .Select(sg => sg.Story)
                .ToListAsync();
        }

        public async Task<IEnumerable<Story>> GetPopularStoriesAsync()
        {
            return await _context.Stories
                .OrderByDescending(s => s.LikeCount)
                .Take(10)
                .ToListAsync();
        }
    }

}
