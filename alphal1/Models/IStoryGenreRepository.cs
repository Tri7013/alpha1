namespace alphal1.Models
{
    public interface IStoryGenreRepository : IRepository<StoryGenre>
    {
        Task<IEnumerable<StoryGenre>> GetGenresByStoryIdAsync(int storyId);
        Task<IEnumerable<StoryGenre>> GetStoriesByGenreIdAsync(int genreId);
    }

}
