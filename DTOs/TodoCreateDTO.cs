using System.ComponentModel.DataAnnotations;
using TodoApi.Models;

namespace TodoApi.DTOs
{
    public class TodoCreateDTO
    {
        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;

        public string? Description { get; set; }

        public DateTime Date { get; set; }

        public TodoStatus Status { get; set; } = TodoStatus.Pending;
    }
}