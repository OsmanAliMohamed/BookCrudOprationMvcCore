using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BooksCrudOperation.Models
{
    public class Category
    {
        public int Id { get; set; }
        [MaxLength(100)]
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public bool IsActive { get; set; }
    }
}
