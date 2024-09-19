namespace alphal1.Models
{
    public interface ICommentRepository : IRepository<Comment>
    {
        Task<IEnumerable<Comment>> GetCommentsByStoryIdAsync(int storyId);
    }

}
