using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApi.Models
{
    [Table("todos")]
    public class Todo
    {
        [Key]
        public int Id { get; set; }


        [Required]
        [MaxLength(200)]
        public string Title { get; set; } = null!;


        public string? Description { get; set; }


        public DateTime Date { get; set; }


        public TodoStatus Status { get; set; } = TodoStatus.Pending;
    }
}