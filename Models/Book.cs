using System;
using System.ComponentModel.DataAnnotations;
namespace BooksCrudOperation.Models
{
    public class Book
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string  Title { get; set; }
        public string Description { get; set; }
        public string Author { get; set; }
        public DateTime TimeOfAdd { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Book()
        {
            TimeOfAdd = DateTime.Now;
        }
    }
}
