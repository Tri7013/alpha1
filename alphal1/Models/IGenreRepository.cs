namespace alphal1.Models
{
    public interface IGenreRepository : IRepository<Genre>
    {
        Task<IEnumerable<Genre>> GetGenresByStoryIdAsync(int storyId);
    }

}
