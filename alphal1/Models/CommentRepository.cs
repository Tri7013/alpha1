using Alphal1.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alphal1.Models
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        public CommentRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Comment>> GetCommentsByStoryIdAsync(int storyId)
        {
            return await _context.Comments
                .Where(c => c.StoryId == storyId)
                .ToListAsync();
        }
    }
}
