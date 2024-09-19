namespace alphal1.Models
{
    public class Genre
    {
        public int Id { get; set; } // Khóa chính của thể loại
        public string Name { get; set; } // Tên của thể loại

        public ICollection<StoryGenre> StoryGenres { get; set; } // Quan hệ một-nhiều với StoryGenres
    }
}
