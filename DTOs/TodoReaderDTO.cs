using TodoApi.Models;

namespace TodoApi.DTOs
{
    public class TodoReaderDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public TodoStatus Status { get; set; }
    }
}