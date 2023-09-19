using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library_Management_Application.Models
{
    public class Books
    {
        public enum Dept
        {
            Select_Your_Department, 
            IT, 
            Electronics, 
            Mechanical ,
            Civil, 
            Electricals, 
            Economics
        };
        [Key]
        public int BookId { get; set; }
        [Required]
        [RegularExpression("[a-zA-z !@#$%^&*()_+`~=]+", ErrorMessage ="Invalid Book Name")]
        public string BookName { get; set; }
        [Required]
        [RegularExpression("[a-zA-z #&*@]+", ErrorMessage = "Invalid Author Name")]
        public string AuthorName { get; set; }
        [Required]
        [RegularExpression("[0-9]{4}", ErrorMessage = "Invalid Year")]
        public int PublishYear { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [RegularExpression("([0-9]{1,4}).([0-9]{1,2})", ErrorMessage = "Invalid Price")]
        public decimal Price { get; set; }
        [Required]
        public Dept BookcategoryId { get; set; }
        [Required]
        public DateTime UpdatedOn{ get; set; } = DateTime.Now;
    }
}
