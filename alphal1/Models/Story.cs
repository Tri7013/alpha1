namespace alphal1.Models
{
    public class Story
    {
        public int Id { get; set; } // Khóa chính của truyện, tự động tăng
        public string Title { get; set; } // Tiêu đề của truyện
        public string Author { get; set; } // Tác giả của truyện
        public decimal Price { get; set; } // Giá của truyện
        public string Description { get; set; } // Mô tả về truyện
        public string CoverImageUrl { get; set; } // Đường dẫn đến hình ảnh bìa truyện
        public int Stock { get; set; } // Số lượng còn trong kho

        public int ViewCount { get; set; } // Lượt xem
        public int FollowCount { get; set; } // Lượt theo dõi
        public int LikeCount { get; set; } // Lượt thích

        public int StatusId { get; set; } // Khóa ngoại liên kết đến bảng Status
        public Status Status { get; set; } // Đối tượng Status tương ứng với StatusId

        public ICollection<StoryGenre> StoryGenres { get; set; } // Quan hệ một-nhiều với StoryGenres
        public ICollection<Comment> Comments { get; set; } // Quan hệ một-nhiều với Comments
    }
}
