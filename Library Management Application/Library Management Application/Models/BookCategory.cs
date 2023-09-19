using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Library_Management_Application.Models
{
    public class BookCategory
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        [DefaultValue(typeof(DateTime))]
        public DateTime UpdatedOn { get; set; }
        public bool IsDeleted { get; set; }


    }
}
