namespace alphal1.Models
{
    public interface IStoryRepository : IRepository<Story>
    {
        Task<IEnumerable<Story>> GetStoriesByGenreAsync(int genreId);
        Task<IEnumerable<Story>> GetPopularStoriesAsync();
    }
}
