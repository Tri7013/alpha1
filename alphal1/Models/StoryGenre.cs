namespace alphal1.Models
{
    public class StoryGenre
    {
        public int StoryId { get; set; } // Khóa ngoại liên kết đến bảng Stories
        public Story Story { get; set; } // Đối tượng Story tương ứng với StoryId
        public int GenreId { get; set; } // Khóa ngoại liên kết đến bảng Genres
        public Genre Genre { get; set; } // Đối tượng Genre tương ứng với GenreId
    }
}
