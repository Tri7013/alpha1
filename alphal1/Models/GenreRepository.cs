using Alphal1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphal1.Models
{
    public class GenreRepository : Repository<Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Genre>> GetGenresByStoryIdAsync(int storyId)
        {
            // Lấy các thể loại của một câu chuyện dựa trên StoryId
            return await _context.StoryGenres
                .Where(sg => sg.StoryId == storyId)
                .Select(sg => sg.Genre)
                .ToListAsync();
        }
    }
}
