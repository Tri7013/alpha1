namespace alphal1.Models
{
    public class Status
    {
        public int Id { get; set; } // Khóa chính của tình trạng
        public string Name { get; set; } // Tên của tình trạng

        public ICollection<Story> Stories { get; set; } // Quan hệ một-nhiều với Stories
    }

}
