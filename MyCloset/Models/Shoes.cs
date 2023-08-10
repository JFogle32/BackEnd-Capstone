using System.ComponentModel.DataAnnotations;

namespace MyCloset.Models
{
    public class Shoes
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(10)]
        public string Size { get; set; }

        [Required]
        public bool Status { get; set; }

        [Url]
        public string Image { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        [Range(1, int.MaxValue)]
        public int UserId { get; set; }

        [StringLength(100)]
        public string UserName { get; set; }
    }
}