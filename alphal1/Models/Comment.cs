namespace alphal1.Models
{
    public class Comment
    {
        public int Id { get; set; } // Khóa chính của bình luận, tự động tăng
        public int StoryId { get; set; } // Khóa ngoại liên kết đến bảng Stories
        public Story Story { get; set; } // Đối tượng Story tương ứng với StoryId
        public string Content { get; set; } // Nội dung của bình luận
        public DateTime CreatedAt { get; set; } // Ngày giờ bình luận được tạo
        public string Author { get; set; } // Tên tác giả bình luận
    }
}
